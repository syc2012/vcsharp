namespace MySerialPort
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BConnect = new System.Windows.Forms.Button();
            this.TPort = new System.Windows.Forms.TextBox();
            this.TBaud = new System.Windows.Forms.TextBox();
            this.TRecv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TSend = new System.Windows.Forms.TextBox();
            this.BClean = new System.Windows.Forms.Button();
            this.BSend = new System.Windows.Forms.Button();
            this.BDisconnect = new System.Windows.Forms.Button();
            this.TDelay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BConnect
            // 
            this.BConnect.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BConnect.Location = new System.Drawing.Point(201, 12);
            this.BConnect.Name = "BConnect";
            this.BConnect.Size = new System.Drawing.Size(99, 40);
            this.BConnect.TabIndex = 0;
            this.BConnect.Text = "Connect";
            this.BConnect.UseVisualStyleBackColor = true;
            this.BConnect.Click += new System.EventHandler(this.BConnect_Click);
            // 
            // TPort
            // 
            this.TPort.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPort.Location = new System.Drawing.Point(12, 12);
            this.TPort.Name = "TPort";
            this.TPort.Size = new System.Drawing.Size(127, 26);
            this.TPort.TabIndex = 1;
            this.TPort.Text = "COM15";
            // 
            // TBaud
            // 
            this.TBaud.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBaud.Location = new System.Drawing.Point(12, 61);
            this.TBaud.Name = "TBaud";
            this.TBaud.Size = new System.Drawing.Size(127, 26);
            this.TBaud.TabIndex = 2;
            this.TBaud.Text = "9600";
            // 
            // TRecv
            // 
            this.TRecv.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TRecv.Location = new System.Drawing.Point(12, 197);
            this.TRecv.Multiline = true;
            this.TRecv.Name = "TRecv";
            this.TRecv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TRecv.Size = new System.Drawing.Size(651, 309);
            this.TRecv.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Recv:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Send:";
            // 
            // TSend
            // 
            this.TSend.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSend.Location = new System.Drawing.Point(12, 136);
            this.TSend.Name = "TSend";
            this.TSend.Size = new System.Drawing.Size(651, 26);
            this.TSend.TabIndex = 6;
            // 
            // BClean
            // 
            this.BClean.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClean.Location = new System.Drawing.Point(440, 12);
            this.BClean.Name = "BClean";
            this.BClean.Size = new System.Drawing.Size(99, 40);
            this.BClean.TabIndex = 7;
            this.BClean.Text = "Clean";
            this.BClean.UseVisualStyleBackColor = true;
            this.BClean.Click += new System.EventHandler(this.BClean_Click);
            // 
            // BSend
            // 
            this.BSend.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSend.Location = new System.Drawing.Point(559, 12);
            this.BSend.Name = "BSend";
            this.BSend.Size = new System.Drawing.Size(99, 40);
            this.BSend.TabIndex = 8;
            this.BSend.Text = "Send";
            this.BSend.UseVisualStyleBackColor = true;
            this.BSend.Click += new System.EventHandler(this.BSend_Click);
            // 
            // BDisconnect
            // 
            this.BDisconnect.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDisconnect.Location = new System.Drawing.Point(323, 12);
            this.BDisconnect.Name = "BDisconnect";
            this.BDisconnect.Size = new System.Drawing.Size(99, 40);
            this.BDisconnect.TabIndex = 9;
            this.BDisconnect.Text = "Disonnect";
            this.BDisconnect.UseVisualStyleBackColor = true;
            this.BDisconnect.Click += new System.EventHandler(this.BDisconnect_Click);
            // 
            // TDelay
            // 
            this.TDelay.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TDelay.Location = new System.Drawing.Point(559, 61);
            this.TDelay.Name = "TDelay";
            this.TDelay.Size = new System.Drawing.Size(99, 26);
            this.TDelay.TabIndex = 2;
            this.TDelay.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 528);
            this.Controls.Add(this.BDisconnect);
            this.Controls.Add(this.BSend);
            this.Controls.Add(this.BClean);
            this.Controls.Add(this.TSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TRecv);
            this.Controls.Add(this.TDelay);
            this.Controls.Add(this.TBaud);
            this.Controls.Add(this.TPort);
            this.Controls.Add(this.BConnect);
            this.Name = "Form1";
            this.Text = "Serial Port";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BConnect;
        private System.Windows.Forms.TextBox TPort;
        private System.Windows.Forms.TextBox TBaud;
        private System.Windows.Forms.TextBox TRecv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TSend;
        private System.Windows.Forms.Button BClean;
        private System.Windows.Forms.Button BSend;
        private System.Windows.Forms.Button BDisconnect;
        private System.Windows.Forms.TextBox TDelay;
    }
}

