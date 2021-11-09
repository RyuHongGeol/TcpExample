namespace TcpServer
{
    partial class frmServer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkLEDStatus = new System.Windows.Forms.CheckBox();
            this.txtHumidity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(23, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(71, 21);
            this.txtPort.TabIndex = 13;
            this.txtPort.Text = "10004";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(100, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "서비스 시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkLEDStatus
            // 
            this.chkLEDStatus.AutoSize = true;
            this.chkLEDStatus.Location = new System.Drawing.Point(225, 63);
            this.chkLEDStatus.Name = "chkLEDStatus";
            this.chkLEDStatus.Size = new System.Drawing.Size(67, 16);
            this.chkLEDStatus.TabIndex = 11;
            this.chkLEDStatus.Text = "LED On";
            this.chkLEDStatus.UseVisualStyleBackColor = true;
            this.chkLEDStatus.CheckedChanged += new System.EventHandler(this.chkLEDStatus_CheckedChanged);
            // 
            // txtHumidity
            // 
            this.txtHumidity.Location = new System.Drawing.Point(80, 85);
            this.txtHumidity.Name = "txtHumidity";
            this.txtHumidity.Size = new System.Drawing.Size(100, 21);
            this.txtHumidity.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "현재습도";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(80, 58);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(100, 21);
            this.txtTemperature.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "현재온도";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(13, 128);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(491, 292);
            this.txtLog.TabIndex = 14;
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 432);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkLEDStatus);
            this.Controls.Add(this.txtHumidity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTemperature);
            this.Controls.Add(this.label1);
            this.Name = "frmServer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkLEDStatus;
        private System.Windows.Forms.TextBox txtHumidity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
    }
}

