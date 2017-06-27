using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSUST.Net;

namespace EMTASS_ServerDemo
{
    public partial class SocketServerDemo : Form
    {
        TSocketServerBase<TTestSession, TTestAccessDatabase> m_socketServer;

        public SocketServerDemo()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void SocketServerDemo_Load(object sender, EventArgs e)
        {
            cb_maxDatagramSize.SelectedIndex = 1;
        }

        private void SocketServerDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_socketServer != null)
            {
                m_socketServer.Dispose();  // 关闭服务器进程
            }
        }

        private void AttachServerEvent()
        {
            m_socketServer.ServerStarted += this.SocketServer_Started;
            m_socketServer.ServerClosed += this.SocketServer_Stoped;
            m_socketServer.ServerListenPaused += this.SocketServer_Paused;
            m_socketServer.ServerListenResumed += this.SocketServer_Resumed;
            m_socketServer.ServerException += this.SocketServer_Exception;

            m_socketServer.SessionRejected += this.SocketServer_SessionRejected;
            m_socketServer.SessionConnected += this.SocketServer_SessionConnected;
            m_socketServer.SessionDisconnected += this.SocketServer_SessionDisconnected;
            m_socketServer.SessionReceiveException += this.SocketServer_SessionReceiveException;
            m_socketServer.SessionSendException += this.SocketServer_SessionSendException;

            m_socketServer.DatagramDelimiterError += this.SocketServer_DatagramDelimiterError;
            m_socketServer.DatagramOversizeError += this.SocketServer_DatagramOversizeError;
            m_socketServer.DatagramAccepted += this.SocketServer_DatagramReceived;
            m_socketServer.DatagramError += this.SocketServer_DatagramrError;
            m_socketServer.DatagramHandled += this.SocketServer_DatagramHandled;

            if (ck_UseDatabase.Checked)
            {
                m_socketServer.DatabaseOpenException += this.SocketServer_DatabaseOpenException;
                m_socketServer.DatabaseCloseException += this.SocketServer_DatabaseCloseException;
                m_socketServer.DatabaseException += this.SocketServer_DatabaseException;
            }

            m_socketServer.ShowDebugMessage += this.SocketServer_ShowDebugMessage;
        }

        private void bn_Start_Click(object sender, EventArgs e)
        {

            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = DemoAccessDatabase.mdb;";

            if (ck_UseDatabase.Checked)
            {
                m_socketServer = new TSocketServerBase<TTestSession, TTestAccessDatabase>(1024, 32 * 1024, 64 * 1024, connStr);
            }
            else
            {
                m_socketServer = new TSocketServerBase<TTestSession, TTestAccessDatabase>();
            }

            m_socketServer.MaxDatagramSize = 1024 * int.Parse(cb_maxDatagramSize.Text);

            this.AttachServerEvent();  // 附加服务器全部事件
            m_socketServer.Start();
        }

        private void bn_Stop_Click(object sender, EventArgs e)
        {
            if (m_socketServer != null)
            {
                m_socketServer.Stop();
                m_socketServer.Dispose();
            }
        }

        private void bn_Pause_Click(object sender, EventArgs e)
        {
            m_socketServer.PauseListen();
        }

        private void bn_Resume_Click(object sender, EventArgs e)
        {
            m_socketServer.ResumeListen();        
        }

        private void SocketServer_Started(object sender, EventArgs e)
        {
            this.AddInfo("Server started at: " + DateTime.Now.ToString());
        }

        private void SocketServer_Stoped(object sender, EventArgs e)
        {
            this.AddInfo("Server stoped at: " + DateTime.Now.ToString());
        }

        private void SocketServer_Paused(object sender, EventArgs e)
        {
            this.AddInfo("Server paused at: " + DateTime.Now.ToString());
        }

        private void SocketServer_Resumed(object sender, EventArgs e)
        {
            this.AddInfo("Server resumed at: " + DateTime.Now.ToString());
        }

        private void SocketServer_Exception(object sender, TExceptionEventArgs e)
        {
            this.tb_ServerExceptionCount.Text = m_socketServer.ServerExceptionCount.ToString();
            this.AddInfo("Server exception: " + e.ExceptionMessage);
        }

        private void SocketServer_SessionRejected(object sender, EventArgs e)
        {
            this.AddInfo("Session connect rejected");
        }

        private void SocketServer_SessionTimeout(object sender, TSessionEventArgs e)
        {
            this.AddInfo("Session timeout: ip " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_SessionConnected(object sender, TSessionEventArgs e)
        {
            this.tb_SessionCount.Text = m_socketServer.SessionCount.ToString();
            this.AddInfo("Session connected: ip " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_SessionDisconnected(object sender, TSessionEventArgs e)
        {
            this.tb_SessionCount.Text = m_socketServer.SessionCount.ToString();
            this.AddInfo("Session disconnected: ip " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_SessionReceiveException(object sender, TSessionEventArgs e)
        {
            this.tb_SessionCount.Text = m_socketServer.SessionCount.ToString();
            this.tb_ClientExceptionCount.Text = m_socketServer.SessionExceptionCount.ToString();
            this.AddInfo("Session receive exception: ip " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_SessionSendException(object sender, TSessionEventArgs e)
        {
            this.tb_SessionCount.Text = m_socketServer.SessionCount.ToString();
            this.tb_ClientExceptionCount.Text = m_socketServer.SessionExceptionCount.ToString();
            this.AddInfo("Session send exception: ip " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_SocketReceiveException(object sender, TSessionExceptionEventArgs e)
        {
            this.tb_SessionCount.Text = m_socketServer.SessionCount.ToString();
            this.tb_ClientExceptionCount.Text = m_socketServer.SessionExceptionCount.ToString();
            this.AddInfo("client socket receive exception: ip: " + e.SessionBaseInfo.IP + " exception message: " + e.ExceptionMessage);
        }

        private void SocketServer_SocketSendException(object sender, TSessionExceptionEventArgs e)
        {
            this.tb_SessionCount.Text = m_socketServer.SessionCount.ToString();
            this.tb_ClientExceptionCount.Text = m_socketServer.SessionExceptionCount.ToString();
            this.AddInfo("client socket send exception: ip: " + e.SessionBaseInfo.IP + " exception message: " + e.ExceptionMessage);
        }

        private void SocketServer_DatagramDelimiterError(object sender, TSessionEventArgs e)
        {
            this.tb_DatagramCount.Text = m_socketServer.ReceivedDatagramCount.ToString();
            this.tb_DatagramQueueCount.Text = m_socketServer.DatagramQueueLength.ToString();
            this.tb_ErrorDatagramCount.Text = m_socketServer.ErrorDatagramCount.ToString();

            this.AddInfo("datagram delimiter error. ip: " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_DatagramOversizeError(object sender, TSessionEventArgs e)
        {
            this.tb_DatagramCount.Text = m_socketServer.ReceivedDatagramCount.ToString();
            this.tb_DatagramQueueCount.Text = m_socketServer.DatagramQueueLength.ToString();
            this.tb_ErrorDatagramCount.Text = m_socketServer.ErrorDatagramCount.ToString();

            this.AddInfo("datagram oversize error. ip: " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_DatagramReceived(object sender, TSessionEventArgs e)
        {
            this.tb_DatagramCount.Text = m_socketServer.ReceivedDatagramCount.ToString();
            this.tb_DatagramQueueCount.Text = m_socketServer.DatagramQueueLength.ToString();
            this.AddInfo("datagram received. ip: " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_DatagramrError(object sender, TSessionEventArgs e)
        {
            this.tb_DatagramCount.Text = m_socketServer.ReceivedDatagramCount.ToString();
            this.tb_DatagramQueueCount.Text = m_socketServer.DatagramQueueLength.ToString();
            this.tb_ErrorDatagramCount.Text = m_socketServer.ErrorDatagramCount.ToString();

            this.AddInfo("datagram error. ip: " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_DatagramHandled(object sender, TSessionEventArgs e)
        {
            this.tb_DatagramCount.Text = m_socketServer.ReceivedDatagramCount.ToString();
            this.tb_DatagramQueueCount.Text = m_socketServer.DatagramQueueLength.ToString();
            this.AddInfo("datagram handled. ip: " + e.SessionBaseInfo.IP);
        }

        private void SocketServer_DatabaseOpenException(object sender, TExceptionEventArgs e)
        {
            this.tb_DatabaseExceptionCount.Text = m_socketServer.DatabaseExceptionCount.ToString();
            this.AddInfo("open database exception: " + e.ExceptionMessage);
        }

        private void SocketServer_DatabaseCloseException(object sender, TExceptionEventArgs e)
        {
            this.tb_DatabaseExceptionCount.Text = m_socketServer.DatabaseExceptionCount.ToString();
            this.AddInfo("close database exception: " + e.ExceptionMessage);
        }

        private void SocketServer_DatabaseException(object sender, TExceptionEventArgs e)
        {
            this.tb_DatabaseExceptionCount.Text = m_socketServer.DatabaseExceptionCount.ToString();
            this.AddInfo("operate database exception: " + e.ExceptionMessage);
        }

        private void SocketServer_ShowDebugMessage(object sender, TExceptionEventArgs e)
        {
            this.AddInfo("debug message: " + e.ExceptionMessage);
        }

        private void AddInfo(string message)
        {
            if (lb_ServerInfo.Items.Count > 1000)
            {
                lb_ServerInfo.Items.Clear();
            }

            lb_ServerInfo.Items.Add(message);
            lb_ServerInfo.SelectedIndex = lb_ServerInfo.Items.Count - 1;
            lb_ServerInfo.Focus();
        }
    }

    /// <summary>
    /// 测试用会话Session类
    /// </summary>
    public class TTestSession : TSessionBase
    {
        //private Socket m_socket;
        private int m_maxDatagramSize;

        private BufferManager m_bufferManager;

        private int m_bufferBlockIndex;
        private byte[] m_receiveBuffer;
        private byte[] m_sendBuffer;

        private byte[] m_datagramBuffer;

        private TDatabaseBase m_databaseObj;
        private Queue<byte[]> m_datagramQueue;


        /// <summary>
        /// 重写错误处理方法, 返回消息给客户端
        /// </summary>
        protected override void OnDatagramDelimiterError()
        {
            base.OnDatagramDelimiterError();
            
            base.SendDatagram("datagram delimiter error");
        }

        /// <summary>
        /// 重写错误处理方法, 返回消息给客户端
        /// </summary>
        protected override void OnDatagramOversizeError()
        {
            base.OnDatagramOversizeError();

            base.SendDatagram("datagram over size");
        }

        /*protected override void ResolveSessionBuffer(int readBytesLength)
        {
            // 上次留下包文非空, 必然含开始字符<
            bool hasHeadDelimiter = (m_datagramBuffer != null);

            int headDelimiter = 1;
            int tailDelimiter = 1;

            int bufferOffset = m_bufferManager.GetReceivevBufferOffset(m_bufferBlockIndex);
            int start = bufferOffset;   // m_receiveBuffer 缓冲区中包开始位置
            int length = 0;  // 已经搜索的接收缓冲区长度

            int subIndex = bufferOffset;  // 缓冲区下标
            while (subIndex < readBytesLength + bufferOffset)
            {
                if (m_receiveBuffer[subIndex] == 0xA5 && m_receiveBuffer[subIndex+1] == 0xA5)  // 数据包开始字符<，前面包文作废
                {
                    if (hasHeadDelimiter || length > 0)  // 如果 < 前面有数据，则认为错误包
                    {
                        this.OnDatagramDelimiterError();
                    }

                    m_datagramBuffer = null;  // 清空包缓冲区，开始一个新的包

                    start = subIndex;         // 新包起点，即<所在位置
                    length = headDelimiter;   // 新包的长度（即<）
                    hasHeadDelimiter = true;  // 新包有开始字符
                }
                else if (m_receiveBuffer[subIndex-1] == 0x5A && m_receiveBuffer[subIndex] == 0x5A)  // 数据包的结束字符>
                {
                    if (hasHeadDelimiter)  // 两个缓冲区中有开始字符<
                    {
                        length += tailDelimiter;  // 长度包括结束字符“>”

                        this.GetDatagramFromBuffer(start, length); // >前面的为正确格式的包

                        start = subIndex + tailDelimiter;  // 新包起点（一般一次处理将结束循环）
                        length = 0;  // 新包长度
                    }
                    else  // >前面没有开始字符，此时认为结束字符>为一般字符，待后续的错误包处理
                    {
                        length++;  //  hasHeadDelimiter = false;
                    }
                }
                else  // 即非 < 也非 >， 是一般字符，长度 + 1
                {
                    length++;
                }
                ++subIndex;
            }

            if (length > 0)  // 剩下的待处理串，分两种情况
            {
                int mergedLength = length;
                if (m_datagramBuffer != null)
                {
                    mergedLength += m_datagramBuffer.Length;
                }

                // 剩下的包文含首字符且不超长，转存到包文缓冲区中，待下次处理
                if (hasHeadDelimiter && mergedLength <= m_maxDatagramSize)
                {
                    //this.CopyToDatagramBuffer(start, length);

                    int datagramLength = 0;
                    if (m_datagramBuffer != null)
                    {
                        datagramLength = m_datagramBuffer.Length;
                    }

                    Array.Resize(ref m_datagramBuffer, datagramLength + length);  // 调整长度（m_datagramBuffer 为 null 不出错）
                    Array.Copy(m_receiveBuffer, start, m_datagramBuffer, datagramLength, length);  // 拷贝到数据包缓冲区
                }
                else  // 不含首字符或超长
                {
                    this.OnDatagramOversizeError();
                    m_datagramBuffer = null;  // 丢弃全部数据
                }
            }
        }*/


        /// <summary>
        /// 重写 AnalyzeDatagram 方法, 调用数据存储方法
        /// </summary>
        protected override void AnalyzeDatagram(byte[] datagramBytes)
        {
            string msg = "";
            int bytesRead = datagramBytes.Length;

            switch (datagramBytes[21])
            {
                case 0x22:
                    if (datagramBytes[9] == 0xAA)
                    {
                        msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--AD采样开始" + "\n";
                    }
                    else if (datagramBytes[9] == 0x55)
                    {
                        msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--AD采样结束" + "\n";
                    }
                    break;

                case 0x25:
                    if (datagramBytes[9] == 0x55)
                    {
                        msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--设定GPS采样时间成功" + "\n";
                    }

                    break;

                case 0x26:
                    if (datagramBytes[7] == 0x01)
                    {
                        msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--设定开启时长和关闭时长成功" + "\n";

                    }
                    break;

                case 0x27:
                    int[] gpsData = new int[23];
                    for (int i = 0; i < 23; i++)
                    {
                        gpsData[i] = datagramBytes[9 + i];
                    }
                    //gpsDistance.getGPSData(gpsData, out dataitem.Latitude, out dataitem.Longitude);
                    //msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--经度为：" + dataitem.Longitude + "纬度为：" + dataitem.Latitude + "\n";

                    break;

                case 0x29:
                    msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--设定服务器IP成功" + "\n";
                    break;

                case 0x30:
                    msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--设定服务器端口号成功" + "\n";

                    break;

                case 0x31:
                    msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--设定AP名称成功" + "\n";

                    break;

                case 0x32:
                    msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--设定AP密码成功" + "\n";

                    break;

                case 0x23:
                    /*if (bytesRead == perPackageLength)
                    {
                        if (dataitem.isSendDataToServer == true)
                        {
                            dataitem.currentsendbulk++;

                            ShowProgressBar(null);

                            for (int i = 7; i < perPackageLength - 2; i++)//将上传的包去掉头和尾的两个字节后，暂时存储在TotalData[]中
                            {
                                dataitem.byteAllData[dataitem.datalength++] = datagramBytes[i];
                            }

                            if (dataitem.datalength == g_datafulllength)//1000*600 = 600000;
                            {
                                StoreDataToFile(dataitem.intDeviceID, dataitem.byteAllData);

                                dataitem.currentsendbulk = 0;
                                dataitem.isSendDataToServer = false;
                                dataitem.CmdStage = 3;

                                msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + "" + "设备号--" + ""+ "--数据上传完毕" + "\n";
                                Console.WriteLine(msg);
                                ShowMsg(msg);
                            }
                        }
                        else
                        {
                            for (int i = 368, j = 0; i <= 373; i++, j++)//将上传的包去掉头和尾的两个字节后，暂时存储在TotalData[]中
                            {
                                dataitem.byteTimeStamp[j] = (byte)(Convert.ToInt32(datagramBytes[i]) - 0x30);
                            }
                            msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "硬件" + dataitem."" + "设备号--" + ""+ "--时间戳是:" + byteToHexStr(dataitem.byteTimeStamp) + "\n";
                            Console.WriteLine(msg);
                            ShowMsg(msg);
                        }
                    }*/
                    break;

                case 0xFF:
                    msg = "收到心跳包";
                    /*if (""== 0)//只判断新地址的心跳包，避免重复检测
                    {
                        //设备的ID字符串
                        ID[0] = datagramBytes[3];
                        ID[1] = datagramBytes[4];
                        ID[2] = datagramBytes[5];
                        ID[3] = datagramBytes[6];
                        intdeviceID = byteToInt(ID);

                        string oldAddress = checkIsHaveID(intdeviceID);//得到当前ID对应的旧地址

                        if (oldAddress != null)//若存在，把旧地址的属性复制到新地址上
                        {//！！！由于掉线，新dataitem属性要继承旧设备，只需要更新网络属性，如IP、port、socket等
                            DataItem olddataitem = (DataItem)htClient[oldAddress];//取出当前数据IP对应的dataitem

                            dataitem.strIP = strIP;
                            dataitem.strPort = strPort;
                            dataitem.socket = clientSocket;
                            datagramBytes = new byte[perPackageLength];
                            dataitem."" = "";

                            dataitem.datalength = olddataitem.datalength;//继承旧属性
                            dataitem.byteAllData = olddataitem.byteAllData;//继承旧属性
                            dataitem.currentsendbulk = olddataitem.currentsendbulk;//继承旧属性

                            dataitem.byteDeviceID = ID;
                            ""= intdeviceID;

                            dataitem.isSendDataToServer = olddataitem.isSendDataToServer;//继承旧属性
                            dataitem.isChoosed = false;
                            dataitem.CmdStage = olddataitem.CmdStage;//继承旧属性
                            dataitem.uploadGroup = 0;

                            dataitem.byteTimeStamp = olddataitem.byteTimeStamp;//时间戳，继承旧属性
                            dataitem.Longitude = olddataitem.Longitude;//经度，后半段，继承旧属性
                            dataitem.Latitude = olddataitem.Latitude;//纬度， 前半段，继承旧属性

                            htClient.Remove(oldAddress);//删除旧地址的键值对
                            string OldAddress = oldAddress + "--" + dataitem.intDeviceID.ToString();
                            RemoveAddress(OldAddress);

                            htClient[""] = dataitem;//把设备的IP和设备的dataitem对应地更新进哈希表
                            string newAddress = "" + "--" + dataitem.intDeviceID.ToString();
                            AddAddress(newAddress);
                        }
                        else
                        {
                            //若不存在，属于全新地址，更新ID号
                            ""= intdeviceID;
                            dataitem.byteDeviceID = ID;

                            string newAddress = "" + "--" + dataitem.intDeviceID.ToString();
                            AddAddress(newAddress);
                        }
                    }//if (""== 0)*/
                    break;

                default:
                    break;
            }

            Console.WriteLine(msg);

            /*string datagramText = Encoding.ASCII.GetString(datagramBytes);

            string clientName = string.Empty;
            int datagramTextLength = 0;

            int n = datagramText.IndexOf(',');  // 格式为 <C12345,0000000000,****>
            if (n >= 1)
            {
                clientName = datagramText.Substring(1, n - 1);
                try
                {
                    datagramTextLength = int.Parse(datagramText.Substring(n + 1, 10));
                }
                catch
                {
                    datagramTextLength = 0;
                }
            }

            base.OnDatagramAccepted();  // 模拟接收到一个完整的数据包

            if (!string.IsNullOrEmpty(clientName) && datagramTextLength > 0)
            {

                if (datagramTextLength == datagramBytes.Length)
                {
                    base.SendDatagram("<OK: " + clientName + ", datagram length = " + datagramTextLength.ToString() + ">");

                    this.Store(datagramBytes);
                    base.OnDatagramHandled();  // 模拟已经处理（存储）了数据包
                }
                else
                {
                    base.SendDatagram("<ERROR: " + clientName + ", error length, datagram length = " + datagramTextLength.ToString() + ">");
                    base.OnDatagramError();  // 错误包
                }
            }
            else if (string.IsNullOrEmpty(clientName))
            {
                base.SendDatagram("client: no name, datagram length = " + datagramTextLength.ToString());
                base.OnDatagramError();
            }
            else if (datagramTextLength == 0)
            {
                base.SendDatagram("client: " + clientName + ", datagram length = " + datagramTextLength.ToString());
                base.OnDatagramError();  // 错误包
            }*/
        }

        /// <summary>
        /// 自定义的数据存储方法
        /// </summary>
        private void Store(byte[] datagramBytes)
        {
            if (this.DatabaseObj == null)
            {
                return;
            }

            TTestAccessDatabase db = this.DatabaseObj as TTestAccessDatabase;
            db.Store(datagramBytes, this);
        }
    }

    /// <summary>
    /// 测试用Access数据库类
    /// </summary>
    public class TTestAccessDatabase : TOleDatabaseBase
    {
        private OleDbCommand m_command;  // 自定义的字段
        
        /// <summary>
        /// 重写 Open 方法
        /// </summary>
        public override void Open()
        {
            base.Open();  // 打开数据库

            m_command = new OleDbCommand();
            m_command.Connection = (OleDbConnection)this.DbConnection;

            // OleDbCommand 不能像 SqlCommand 在 CommandText 使用参数名称
            m_command.CommandText = "insert into DatagramTextTable(SessionIP, SessionName, DatagramSize) values (?, ?, ?)";

            m_command.Parameters.Add(new OleDbParameter("SessionIP",OleDbType.VarChar));
            m_command.Parameters.Add(new OleDbParameter("SessionName", OleDbType.VarChar));
            m_command.Parameters.Add(new OleDbParameter("DatagramSize", OleDbType.Integer));
        }

        /// <summary>
        /// 自定义数据存储方法
        /// </summary>
        public override void Store(byte[] datagramBytes, TSessionBase session)
        {
            string datagramText = Encoding.ASCII.GetString(datagramBytes);
            try
            {
                m_command.Parameters["SessionIP"].Value = session.IP;
                m_command.Parameters["SessionName"].Value = session.Name;
                m_command.Parameters["DatagramSize"].Value = datagramBytes.Length;

                m_command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                this.OnDatabaseException(err);
            }
        }
    }
}