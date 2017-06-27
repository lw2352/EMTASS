namespace EMTASS_ServerDemo
{
    partial class SocketServerDemo
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
            this.bn_Start = new System.Windows.Forms.Button();
            this.bn_Stop = new System.Windows.Forms.Button();
            this.bn_Pause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_SessionCount = new System.Windows.Forms.TextBox();
            this.tb_DatagramCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_DatagramQueueCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ErrorDatagramCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_DatabaseExceptionCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_ServerExceptionCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bn_Resume = new System.Windows.Forms.Button();
            this.lb_ServerInfo = new System.Windows.Forms.ListBox();
            this.tb_ClientExceptionCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_maxDatagramSize = new System.Windows.Forms.ComboBox();
            this.ck_UseDatabase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bn_Start
            // 
            this.bn_Start.Location = new System.Drawing.Point(191, 306);
            this.bn_Start.Name = "bn_Start";
            this.bn_Start.Size = new System.Drawing.Size(86, 34);
            this.bn_Start.TabIndex = 1;
            this.bn_Start.Text = "启动服务器";
            this.bn_Start.UseVisualStyleBackColor = true;
            this.bn_Start.Click += new System.EventHandler(this.bn_Start_Click);
            // 
            // bn_Stop
            // 
            this.bn_Stop.Location = new System.Drawing.Point(288, 306);
            this.bn_Stop.Name = "bn_Stop";
            this.bn_Stop.Size = new System.Drawing.Size(57, 34);
            this.bn_Stop.TabIndex = 2;
            this.bn_Stop.Text = "停止";
            this.bn_Stop.UseVisualStyleBackColor = true;
            this.bn_Stop.Click += new System.EventHandler(this.bn_Stop_Click);
            // 
            // bn_Pause
            // 
            this.bn_Pause.Location = new System.Drawing.Point(365, 306);
            this.bn_Pause.Name = "bn_Pause";
            this.bn_Pause.Size = new System.Drawing.Size(86, 34);
            this.bn_Pause.TabIndex = 3;
            this.bn_Pause.Text = "暂停连接请求";
            this.bn_Pause.UseVisualStyleBackColor = true;
            this.bn_Pause.Click += new System.EventHandler(this.bn_Pause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "会话数合计";
            // 
            // tb_SessionCount
            // 
            this.tb_SessionCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_SessionCount.Location = new System.Drawing.Point(82, 13);
            this.tb_SessionCount.Name = "tb_SessionCount";
            this.tb_SessionCount.Size = new System.Drawing.Size(45, 21);
            this.tb_SessionCount.TabIndex = 5;
            this.tb_SessionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_DatagramCount
            // 
            this.tb_DatagramCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_DatagramCount.Location = new System.Drawing.Point(206, 13);
            this.tb_DatagramCount.Name = "tb_DatagramCount";
            this.tb_DatagramCount.Size = new System.Drawing.Size(58, 21);
            this.tb_DatagramCount.TabIndex = 7;
            this.tb_DatagramCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "接收包合计";
            // 
            // tb_DatagramQueueCount
            // 
            this.tb_DatagramQueueCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_DatagramQueueCount.Location = new System.Drawing.Point(82, 47);
            this.tb_DatagramQueueCount.Name = "tb_DatagramQueueCount";
            this.tb_DatagramQueueCount.Size = new System.Drawing.Size(45, 21);
            this.tb_DatagramQueueCount.TabIndex = 9;
            this.tb_DatagramQueueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "包队列长度";
            // 
            // tb_ErrorDatagramCount
            // 
            this.tb_ErrorDatagramCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_ErrorDatagramCount.Location = new System.Drawing.Point(206, 47);
            this.tb_ErrorDatagramCount.Name = "tb_ErrorDatagramCount";
            this.tb_ErrorDatagramCount.Size = new System.Drawing.Size(58, 21);
            this.tb_ErrorDatagramCount.TabIndex = 11;
            this.tb_ErrorDatagramCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "错误包合计";
            // 
            // tb_DatabaseExceptionCount
            // 
            this.tb_DatabaseExceptionCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_DatabaseExceptionCount.Location = new System.Drawing.Point(346, 48);
            this.tb_DatabaseExceptionCount.Name = "tb_DatabaseExceptionCount";
            this.tb_DatabaseExceptionCount.Size = new System.Drawing.Size(45, 21);
            this.tb_DatabaseExceptionCount.TabIndex = 15;
            this.tb_DatabaseExceptionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "数据库异常";
            // 
            // tb_ServerExceptionCount
            // 
            this.tb_ServerExceptionCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_ServerExceptionCount.Location = new System.Drawing.Point(346, 12);
            this.tb_ServerExceptionCount.Name = "tb_ServerExceptionCount";
            this.tb_ServerExceptionCount.Size = new System.Drawing.Size(45, 21);
            this.tb_ServerExceptionCount.TabIndex = 13;
            this.tb_ServerExceptionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "服务器异常";
            // 
            // bn_Resume
            // 
            this.bn_Resume.Location = new System.Drawing.Point(457, 306);
            this.bn_Resume.Name = "bn_Resume";
            this.bn_Resume.Size = new System.Drawing.Size(56, 34);
            this.bn_Resume.TabIndex = 16;
            this.bn_Resume.Text = "恢复";
            this.bn_Resume.UseVisualStyleBackColor = true;
            this.bn_Resume.Click += new System.EventHandler(this.bn_Resume_Click);
            // 
            // lb_ServerInfo
            // 
            this.lb_ServerInfo.FormattingEnabled = true;
            this.lb_ServerInfo.ItemHeight = 12;
            this.lb_ServerInfo.Location = new System.Drawing.Point(14, 80);
            this.lb_ServerInfo.Name = "lb_ServerInfo";
            this.lb_ServerInfo.Size = new System.Drawing.Size(499, 208);
            this.lb_ServerInfo.TabIndex = 17;
            // 
            // tb_ClientExceptionCount
            // 
            this.tb_ClientExceptionCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_ClientExceptionCount.Location = new System.Drawing.Point(468, 13);
            this.tb_ClientExceptionCount.Name = "tb_ClientExceptionCount";
            this.tb_ClientExceptionCount.Size = new System.Drawing.Size(45, 21);
            this.tb_ClientExceptionCount.TabIndex = 19;
            this.tb_ClientExceptionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "客户端异常";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "数据包长上限(K)";
            // 
            // cb_maxDatagramSize
            // 
            this.cb_maxDatagramSize.ForeColor = System.Drawing.Color.Blue;
            this.cb_maxDatagramSize.FormattingEnabled = true;
            this.cb_maxDatagramSize.Items.AddRange(new object[] {
            "10000",
            "5000",
            "1000",
            "100",
            "50",
            "20",
            "15",
            "10",
            "5",
            "1",
            "2"});
            this.cb_maxDatagramSize.Location = new System.Drawing.Point(113, 298);
            this.cb_maxDatagramSize.Name = "cb_maxDatagramSize";
            this.cb_maxDatagramSize.Size = new System.Drawing.Size(69, 20);
            this.cb_maxDatagramSize.TabIndex = 20;
            // 
            // ck_UseDatabase
            // 
            this.ck_UseDatabase.AutoSize = true;
            this.ck_UseDatabase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ck_UseDatabase.Checked = true;
            this.ck_UseDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_UseDatabase.Location = new System.Drawing.Point(12, 324);
            this.ck_UseDatabase.Name = "ck_UseDatabase";
            this.ck_UseDatabase.Size = new System.Drawing.Size(168, 16);
            this.ck_UseDatabase.TabIndex = 22;
            this.ck_UseDatabase.Text = "保存到数据包Access数据库";
            this.ck_UseDatabase.UseVisualStyleBackColor = true;
            // 
            // SocketServerDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 352);
            this.Controls.Add(this.ck_UseDatabase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_maxDatagramSize);
            this.Controls.Add(this.tb_ClientExceptionCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_ServerInfo);
            this.Controls.Add(this.bn_Resume);
            this.Controls.Add(this.tb_DatabaseExceptionCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_ServerExceptionCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_ErrorDatagramCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_DatagramQueueCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_DatagramCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_SessionCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bn_Pause);
            this.Controls.Add(this.bn_Stop);
            this.Controls.Add(this.bn_Start);
            this.Name = "SocketServerDemo";
            this.Text = "可扩展多线程异步Socket服务器框架(EMTASS2.1）ServerDemo";
            this.Load += new System.EventHandler(this.SocketServerDemo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SocketServerDemo_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bn_Start;
        private System.Windows.Forms.Button bn_Stop;
        private System.Windows.Forms.Button bn_Pause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SessionCount;
        private System.Windows.Forms.TextBox tb_DatagramCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_DatagramQueueCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ErrorDatagramCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_DatabaseExceptionCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_ServerExceptionCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bn_Resume;
        private System.Windows.Forms.ListBox lb_ServerInfo;
        private System.Windows.Forms.TextBox tb_ClientExceptionCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_maxDatagramSize;
        private System.Windows.Forms.CheckBox ck_UseDatabase;
    }
}

