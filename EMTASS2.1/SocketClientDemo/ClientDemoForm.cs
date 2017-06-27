//## Project  : ETMASS——Extensible Multi-Thread Asynchronous Socket Server Framework
//## Author   : Hulihui(ehulh@163.com)
//## Creation Date : 2008-10-13
//## Modified Date : 2008-11-08
//## Modified:
//## 1) 异步接收包, 使用中容易出现错误包(100K/50ms), 原因待查
//## 2）判断返回包: <OK,...>表示正确，<ERROR,...>表示错误

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace EMTASS_ClientDemo
{
    public partial class ClientDemoForm : Form
    {
        TcpClient m_socketClient;

        bool m_stopLoop = true;

        int m_sendCount = 0;
        int m_receiveCount = 0;
        int m_errorCount = 0;

        // 2M 的接收缓冲区，目的是一次接收完服务器发回的消息
        byte[] m_receiveBuffer = new byte[2048 * 1024];

        public ClientDemoForm()
        {
            InitializeComponent();
        }

        private void ClientDemoForm_Load(object sender, EventArgs e)
        {
            cb_MaxDatagramSize.SelectedIndex = 0;
            cb_TimeInterval.SelectedIndex = 0;

            tb_ClientName.Text = "C" + DateTime.Now.ToString("mmssf");
        }

        private void bn_Connect_Click(object sender, EventArgs e)
        {
            if (m_socketClient != null)
            {
                this.Disconnect();
            }

            m_sendCount = 0;
            m_receiveCount = 0;
            m_errorCount = 0;

            this.RefreshSendCount();
            this.RefreshReceiveCount();
            this.RefreshErrorCount();

            m_stopLoop = true;
            this.Connect();
        }

        private void Connect()
        {
            lock (this)
            {
                try
                {
                    m_socketClient = new TcpClient(tb_IP.Text, 3130);
                    m_socketClient.ReceiveTimeout = 60 * 1000;

                    if (m_socketClient.Connected)
                    {
                        this.AddInfo("client connected.");
                    }
                    else
                    {
                        this.AddInfo("connect failed.");
                    }
                }
                catch (Exception err)
                {
                    this.AddInfo("client connect exception: " + err.Message);
                }
            }
        }

        private void Disconnect()
        {
            lock (this)
            {
                if (m_socketClient == null)
                {
                    return;
                }

                try
                {
                    m_socketClient.Close();
                    this.AddInfo("client disconnected successfully.");
                }
                catch (Exception err)
                {
                    this.AddInfo("client disconnected exception: " + err.Message);
                }
                finally
                {
                    m_socketClient = null;
                }
            }
        }

        private void AddInfo(string message)
        {
            if (lb_Info.Items.Count > 1000)
            {
                lb_Info.Items.Clear();
            }

            lb_Info.Items.Add(message);
            lb_Info.SelectedIndex = lb_Info.Items.Count - 1;
            lb_Info.Focus();
        }

        private void bn_Disconnect_Click(object sender, EventArgs e)
        {
            m_stopLoop = true;
            this.Disconnect();
        }

        private void bn_LoopSend_Click(object sender, EventArgs e)
        {
            if (m_socketClient == null)
            {
                this.Connect();
            }

            ThreadPool.QueueUserWorkItem(this.SendDatagramThread);
        }

        private void SendDatagramThread(object state)
        {
            m_stopLoop = false;

            while (!m_stopLoop)
            {
                int timeInterval = int.Parse(cb_TimeInterval.Text);
                if (m_socketClient == null || m_socketClient.Connected == false)
                {
                    this.Connect();
                }
                this.SendOneDatagram();
                Thread.Sleep(timeInterval);
            }
        }

        private void SendOneDatagram()
        {
            int maxLength = int.Parse(cb_MaxDatagramSize.Text) * 1024;

            Random rnd = new Random();
            int datagramLength = rnd.Next(1, maxLength);

            string datagramText;
            if (ck_ErrorDatagram.Checked && datagramLength < maxLength * 0.20)  // 产生一个无 > 的包
            {
                datagramText = "<" + tb_ClientName.Text.Trim() + ",".PadRight(datagramLength, 'a');
            }
            else if (ck_ErrorDatagram.Checked && datagramLength > maxLength * 0.80)  // 产生一个无 < 的包
            {
                datagramText = tb_ClientName.Text.Trim() + ",".PadRight(datagramLength, 'a') + ">";
            }
            else  // 正常包
            {
                string header = "<" + tb_ClientName.Text.Trim() + ",";
                string tailer = ",".PadRight(datagramLength, 'a') + ">";
                datagramText = header + (header.Length + tailer.Length + 10).ToString("0000000000") + tailer;  // 第二个字节是长度
            }

            byte[] datagram = Encoding.ASCII.GetBytes(datagramText);

            try
            {
                m_socketClient.Client.Send(datagram);

                this.RefreshSendCount();
                this.AddInfo("send text len = " + datagramText.Length.ToString());

                if (ck_AsyncReceive.Checked)  // 异步接收回答
                {
                    m_socketClient.Client.BeginReceive(m_receiveBuffer, 0, m_receiveBuffer.Length, SocketFlags.None, this.EndReceiveDatagram, this);
                }
                else
                {
                    this.Receive();
                }
            }
            catch (Exception err)
            {
                this.AddInfo("send exception: " + err.Message);
                this.CloseClientSocket();
            }
        }

        private void Receive()
        {
            try
            {
                int len = m_socketClient.Client.Receive(m_receiveBuffer, 0, m_receiveBuffer.Length, SocketFlags.None);
                if (len > 0)
                {
                    CheckReplyDatagram(len);
                }
            }
            catch (Exception err)
            {
                this.AddInfo("receive exception: " + err.Message);
                this.CloseClientSocket();
            }
        }

        private void CheckReplyDatagram(int len)
        {
            string replyMesage = Encoding.ASCII.GetString(m_receiveBuffer, 0, len);
            
            this.AddInfo("reply: " + replyMesage);
            this.RefreshReceiveCount();
            
            if (replyMesage.IndexOf("OK") == -1 || replyMesage.IndexOf(tb_ClientName.Text) == -1)
            {
                this.RefreshErrorCount();
            }
        }

        private void RefreshSendCount()
        {
            tb_SendCount.Text = m_sendCount.ToString();

            m_sendCount++;
            tb_SendCount.Refresh();
        }

        private void RefreshReceiveCount()
        {
            tb_ReceiveCount.Text = m_receiveCount.ToString();

            m_receiveCount++;
            tb_ReceiveCount.Refresh();
        }

        private void RefreshErrorCount()
        {
            tb_ErrorCount.Text = m_errorCount.ToString();
            m_errorCount++;
            tb_ErrorCount.Refresh();
        }

        private void CloseClientSocket()
        {
            try
            {
                m_socketClient.Client.Shutdown(SocketShutdown.Both);
                m_socketClient.Client.Close();
            }
            catch (Exception)
            {
            }
        }

        private void OnOffSocket()
        {

            if (m_socketClient != null)
            {
                this.Disconnect();
            }

            this.Connect();

            int timeInterval = int.Parse(cb_TimeInterval.Text);
            Thread.Sleep(timeInterval);

            this.Disconnect();
        }

        private void bn_OnOff(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(this.OnOffSocketThread);
        }

        private void OnOffSocketThread(object state)
        {
            m_stopLoop = false;

            while (!m_stopLoop)
            {
                int timeInterval = int.Parse(cb_TimeInterval.Text);
                this.OnOffSocket();
                Thread.Sleep(timeInterval);
            }
        }

        private void EndReceiveDatagram(IAsyncResult iar)
        {
            try
            {
                int readBytesLength = m_socketClient.Client.EndReceive(iar);
                if (readBytesLength == 0)
                {
                    this.CloseClientSocket();
                }
                else  // 正常数据包
                {
                    this.CheckReplyDatagram(readBytesLength);
                }
            }
            catch (Exception)
            {
                this.CloseClientSocket();
            }
        }

        private void bn_SendOneDatagram_Click(object sender, EventArgs e)
        {
            if (m_stopLoop == false)
            {
                MessageBox.Show("正在做连续操作, 必须停止后才能单步发送");
                return;
            }
         
            this.SendOneDatagram();
        }

        private void bn_Stop_Click(object sender, EventArgs e)
        {
            m_stopLoop = true;
            this.Disconnect();
        }
    }
}