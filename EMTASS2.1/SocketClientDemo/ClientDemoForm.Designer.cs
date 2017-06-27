namespace EMTASS_ClientDemo
{
    partial class ClientDemoForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Info = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_MaxDatagramSize = new System.Windows.Forms.ComboBox();
            this.tb_SendCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_ReceiveCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ClientName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ck_AsyncReceive = new System.Windows.Forms.CheckBox();
            this.ck_ErrorDatagram = new System.Windows.Forms.CheckBox();
            this.bn_ConnectDisconnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bn_Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_TimeInterval = new System.Windows.Forms.ComboBox();
            this.bn_LoopSend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bn_SendOneDatagram = new System.Windows.Forms.Button();
            this.bn_Disconnect = new System.Windows.Forms.Button();
            this.bn_Connect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_ErrorCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Info
            // 
            this.lb_Info.FormattingEnabled = true;
            this.lb_Info.ItemHeight = 12;
            this.lb_Info.Items.AddRange(new object[] {
            "说明：",
            "",
            "1）可以修改服务器IP和客户端名；",
            "2）数据包的界限符号为：<>；",
            "3）数据包的组成格式为：<客户端名, 数据包长度(含界限符，10位带前导0), 字符串>",
            "",
            "注意：",
            "",
            "1）服务器发回的消息长度要 <= 设定的发回缓冲区长度",
            "2）服务器发回消息<OK,客户端名...>表示正确，<ERROR,...>表示错误"});
            this.lb_Info.Location = new System.Drawing.Point(8, 12);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(528, 148);
            this.lb_Info.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "服务器IP";
            // 
            // tb_IP
            // 
            this.tb_IP.ForeColor = System.Drawing.Color.Blue;
            this.tb_IP.Location = new System.Drawing.Point(65, 18);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(100, 21);
            this.tb_IP.TabIndex = 8;
            this.tb_IP.Text = "172.30.141.16";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "(KB)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "随机数据包长上限";
            // 
            // cb_MaxDatagramSize
            // 
            this.cb_MaxDatagramSize.ForeColor = System.Drawing.Color.Blue;
            this.cb_MaxDatagramSize.FormattingEnabled = true;
            this.cb_MaxDatagramSize.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "1000",
            "5000",
            "10000",
            "15",
            "10",
            "5",
            "1",
            "2"});
            this.cb_MaxDatagramSize.Location = new System.Drawing.Point(120, 17);
            this.cb_MaxDatagramSize.Name = "cb_MaxDatagramSize";
            this.cb_MaxDatagramSize.Size = new System.Drawing.Size(72, 20);
            this.cb_MaxDatagramSize.TabIndex = 10;
            // 
            // tb_SendCount
            // 
            this.tb_SendCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_SendCount.Location = new System.Drawing.Point(65, 78);
            this.tb_SendCount.Name = "tb_SendCount";
            this.tb_SendCount.Size = new System.Drawing.Size(100, 21);
            this.tb_SendCount.TabIndex = 14;
            this.tb_SendCount.Text = "0";
            this.tb_SendCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "发送合计";
            // 
            // tb_ReceiveCount
            // 
            this.tb_ReceiveCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_ReceiveCount.Location = new System.Drawing.Point(65, 108);
            this.tb_ReceiveCount.Name = "tb_ReceiveCount";
            this.tb_ReceiveCount.Size = new System.Drawing.Size(100, 21);
            this.tb_ReceiveCount.TabIndex = 16;
            this.tb_ReceiveCount.Text = "0";
            this.tb_ReceiveCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "接收合计";
            // 
            // tb_ClientName
            // 
            this.tb_ClientName.ForeColor = System.Drawing.Color.Blue;
            this.tb_ClientName.Location = new System.Drawing.Point(65, 48);
            this.tb_ClientName.Name = "tb_ClientName";
            this.tb_ClientName.Size = new System.Drawing.Size(100, 21);
            this.tb_ClientName.TabIndex = 19;
            this.tb_ClientName.Text = "C2114";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "客户端名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ck_AsyncReceive);
            this.groupBox1.Controls.Add(this.ck_ErrorDatagram);
            this.groupBox1.Controls.Add(this.bn_ConnectDisconnect);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bn_Stop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_TimeInterval);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bn_LoopSend);
            this.groupBox1.Controls.Add(this.cb_MaxDatagramSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(188, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 116);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // ck_AsyncReceive
            // 
            this.ck_AsyncReceive.AutoSize = true;
            this.ck_AsyncReceive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ck_AsyncReceive.Location = new System.Drawing.Point(231, 47);
            this.ck_AsyncReceive.Name = "ck_AsyncReceive";
            this.ck_AsyncReceive.Size = new System.Drawing.Size(108, 16);
            this.ck_AsyncReceive.TabIndex = 31;
            this.ck_AsyncReceive.Text = "异步接收数据包";
            this.ck_AsyncReceive.UseVisualStyleBackColor = true;
            // 
            // ck_ErrorDatagram
            // 
            this.ck_ErrorDatagram.AutoSize = true;
            this.ck_ErrorDatagram.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ck_ErrorDatagram.Location = new System.Drawing.Point(231, 19);
            this.ck_ErrorDatagram.Name = "ck_ErrorDatagram";
            this.ck_ErrorDatagram.Size = new System.Drawing.Size(108, 16);
            this.ck_ErrorDatagram.TabIndex = 30;
            this.ck_ErrorDatagram.Text = "随机产生错误包";
            this.ck_ErrorDatagram.UseVisualStyleBackColor = true;
            // 
            // bn_ConnectDisconnect
            // 
            this.bn_ConnectDisconnect.Location = new System.Drawing.Point(123, 76);
            this.bn_ConnectDisconnect.Name = "bn_ConnectDisconnect";
            this.bn_ConnectDisconnect.Size = new System.Drawing.Size(102, 32);
            this.bn_ConnectDisconnect.TabIndex = 28;
            this.bn_ConnectDisconnect.Text = "连续连接/断开";
            this.bn_ConnectDisconnect.UseVisualStyleBackColor = true;
            this.bn_ConnectDisconnect.Click += new System.EventHandler(this.bn_OnOff);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "连续操作时间间隔";
            // 
            // bn_Stop
            // 
            this.bn_Stop.Location = new System.Drawing.Point(243, 76);
            this.bn_Stop.Name = "bn_Stop";
            this.bn_Stop.Size = new System.Drawing.Size(99, 31);
            this.bn_Stop.TabIndex = 26;
            this.bn_Stop.Text = "停止连续操作";
            this.bn_Stop.UseVisualStyleBackColor = true;
            this.bn_Stop.Click += new System.EventHandler(this.bn_Stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "(MS)";
            // 
            // cb_TimeInterval
            // 
            this.cb_TimeInterval.ForeColor = System.Drawing.Color.Blue;
            this.cb_TimeInterval.FormattingEnabled = true;
            this.cb_TimeInterval.Items.AddRange(new object[] {
            "1000",
            "500",
            "200",
            "100",
            "50",
            "20",
            "10",
            "5000",
            "10000",
            "60000",
            "120000",
            "300000"});
            this.cb_TimeInterval.Location = new System.Drawing.Point(120, 44);
            this.cb_TimeInterval.Name = "cb_TimeInterval";
            this.cb_TimeInterval.Size = new System.Drawing.Size(72, 20);
            this.cb_TimeInterval.TabIndex = 24;
            // 
            // bn_LoopSend
            // 
            this.bn_LoopSend.Location = new System.Drawing.Point(6, 76);
            this.bn_LoopSend.Name = "bn_LoopSend";
            this.bn_LoopSend.Size = new System.Drawing.Size(102, 32);
            this.bn_LoopSend.TabIndex = 22;
            this.bn_LoopSend.Text = "连续发数据包";
            this.bn_LoopSend.UseVisualStyleBackColor = true;
            this.bn_LoopSend.Click += new System.EventHandler(this.bn_LoopSend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bn_SendOneDatagram);
            this.groupBox2.Controls.Add(this.bn_Disconnect);
            this.groupBox2.Controls.Add(this.bn_Connect);
            this.groupBox2.Location = new System.Drawing.Point(188, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 57);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // bn_SendOneDatagram
            // 
            this.bn_SendOneDatagram.Location = new System.Drawing.Point(240, 16);
            this.bn_SendOneDatagram.Name = "bn_SendOneDatagram";
            this.bn_SendOneDatagram.Size = new System.Drawing.Size(102, 32);
            this.bn_SendOneDatagram.TabIndex = 5;
            this.bn_SendOneDatagram.Text = "发一个包";
            this.bn_SendOneDatagram.UseVisualStyleBackColor = true;
            this.bn_SendOneDatagram.Click += new System.EventHandler(this.bn_SendOneDatagram_Click);
            // 
            // bn_Disconnect
            // 
            this.bn_Disconnect.Location = new System.Drawing.Point(123, 17);
            this.bn_Disconnect.Name = "bn_Disconnect";
            this.bn_Disconnect.Size = new System.Drawing.Size(102, 32);
            this.bn_Disconnect.TabIndex = 4;
            this.bn_Disconnect.Text = "断开连接";
            this.bn_Disconnect.UseVisualStyleBackColor = true;
            this.bn_Disconnect.Click += new System.EventHandler(this.bn_Disconnect_Click);
            // 
            // bn_Connect
            // 
            this.bn_Connect.Location = new System.Drawing.Point(6, 16);
            this.bn_Connect.Name = "bn_Connect";
            this.bn_Connect.Size = new System.Drawing.Size(102, 32);
            this.bn_Connect.TabIndex = 3;
            this.bn_Connect.Text = "连服务器";
            this.bn_Connect.UseVisualStyleBackColor = true;
            this.bn_Connect.Click += new System.EventHandler(this.bn_Connect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_ErrorCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tb_IP);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tb_ClientName);
            this.groupBox3.Controls.Add(this.tb_SendCount);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tb_ReceiveCount);
            this.groupBox3.Location = new System.Drawing.Point(8, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 174);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // tb_ErrorCount
            // 
            this.tb_ErrorCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_ErrorCount.Location = new System.Drawing.Point(65, 138);
            this.tb_ErrorCount.Name = "tb_ErrorCount";
            this.tb_ErrorCount.Size = new System.Drawing.Size(100, 21);
            this.tb_ErrorCount.TabIndex = 21;
            this.tb_ErrorCount.Text = "0";
            this.tb_ErrorCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "错包合计";
            // 
            // ClientDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 348);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_Info);
            this.Name = "ClientDemoForm";
            this.Text = "EMTASS——客户端Demo";
            this.Load += new System.EventHandler(this.ClientDemoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_MaxDatagramSize;
        private System.Windows.Forms.TextBox tb_SendCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_ReceiveCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_ClientName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bn_ConnectDisconnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bn_Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_TimeInterval;
        private System.Windows.Forms.Button bn_LoopSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bn_Disconnect;
        private System.Windows.Forms.Button bn_Connect;
        private System.Windows.Forms.CheckBox ck_ErrorDatagram;
        private System.Windows.Forms.CheckBox ck_AsyncReceive;
        private System.Windows.Forms.Button bn_SendOneDatagram;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_ErrorCount;
        private System.Windows.Forms.Label label9;
    }
}

