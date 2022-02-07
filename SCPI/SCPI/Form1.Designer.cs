namespace SCPI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mxaIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mxaPort = new System.Windows.Forms.TextBox();
            this.mxaConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mxgIP = new System.Windows.Forms.TextBox();
            this.mxgPort = new System.Windows.Forms.TextBox();
            this.mxgConnect = new System.Windows.Forms.Button();
            this.textConsole = new System.Windows.Forms.TextBox();
            this.mxaCmd = new System.Windows.Forms.TextBox();
            this.mxaSend = new System.Windows.Forms.Button();
            this.mxgCmd = new System.Windows.Forms.TextBox();
            this.mxgSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "MXA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP address";
            // 
            // mxaIP
            // 
            this.mxaIP.Location = new System.Drawing.Point(149, 6);
            this.mxaIP.MaxLength = 16;
            this.mxaIP.Name = "mxaIP";
            this.mxaIP.Size = new System.Drawing.Size(125, 25);
            this.mxaIP.TabIndex = 1;
            this.mxaIP.Text = "192.168.2.101";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port";
            // 
            // mxaPort
            // 
            this.mxaPort.Location = new System.Drawing.Point(341, 6);
            this.mxaPort.MaxLength = 8;
            this.mxaPort.Name = "mxaPort";
            this.mxaPort.Size = new System.Drawing.Size(85, 25);
            this.mxaPort.TabIndex = 1;
            this.mxaPort.Text = "5025";
            // 
            // mxaConnect
            // 
            this.mxaConnect.Location = new System.Drawing.Point(572, 6);
            this.mxaConnect.Name = "mxaConnect";
            this.mxaConnect.Size = new System.Drawing.Size(90, 25);
            this.mxaConnect.TabIndex = 2;
            this.mxaConnect.Text = "Connect";
            this.mxaConnect.UseVisualStyleBackColor = true;
            this.mxaConnect.Click += new System.EventHandler(this.mxaConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "MXG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Port";
            // 
            // mxgIP
            // 
            this.mxgIP.Location = new System.Drawing.Point(149, 90);
            this.mxgIP.MaxLength = 16;
            this.mxgIP.Name = "mxgIP";
            this.mxgIP.Size = new System.Drawing.Size(125, 25);
            this.mxgIP.TabIndex = 1;
            this.mxgIP.Text = "192.168.2.102";
            // 
            // mxgPort
            // 
            this.mxgPort.Location = new System.Drawing.Point(341, 90);
            this.mxgPort.MaxLength = 8;
            this.mxgPort.Name = "mxgPort";
            this.mxgPort.Size = new System.Drawing.Size(85, 25);
            this.mxgPort.TabIndex = 1;
            this.mxgPort.Text = "5025";
            // 
            // mxgConnect
            // 
            this.mxgConnect.Location = new System.Drawing.Point(572, 88);
            this.mxgConnect.Name = "mxgConnect";
            this.mxgConnect.Size = new System.Drawing.Size(90, 25);
            this.mxgConnect.TabIndex = 2;
            this.mxgConnect.Text = "Connect";
            this.mxgConnect.UseVisualStyleBackColor = true;
            this.mxgConnect.Click += new System.EventHandler(this.mxgConnect_Click);
            // 
            // textConsole
            // 
            this.textConsole.Location = new System.Drawing.Point(15, 172);
            this.textConsole.Multiline = true;
            this.textConsole.Name = "textConsole";
            this.textConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textConsole.Size = new System.Drawing.Size(805, 311);
            this.textConsole.TabIndex = 3;
            // 
            // mxaCmd
            // 
            this.mxaCmd.Location = new System.Drawing.Point(81, 37);
            this.mxaCmd.Name = "mxaCmd";
            this.mxaCmd.Size = new System.Drawing.Size(480, 25);
            this.mxaCmd.TabIndex = 4;
            // 
            // mxaSend
            // 
            this.mxaSend.Location = new System.Drawing.Point(572, 37);
            this.mxaSend.Name = "mxaSend";
            this.mxaSend.Size = new System.Drawing.Size(90, 25);
            this.mxaSend.TabIndex = 2;
            this.mxaSend.Text = "Send";
            this.mxaSend.UseVisualStyleBackColor = true;
            this.mxaSend.Click += new System.EventHandler(this.mxaSend_Click);
            // 
            // mxgCmd
            // 
            this.mxgCmd.Location = new System.Drawing.Point(81, 121);
            this.mxgCmd.Name = "mxgCmd";
            this.mxgCmd.Size = new System.Drawing.Size(480, 25);
            this.mxgCmd.TabIndex = 4;
            // 
            // mxgSend
            // 
            this.mxgSend.Location = new System.Drawing.Point(572, 121);
            this.mxgSend.Name = "mxgSend";
            this.mxgSend.Size = new System.Drawing.Size(90, 25);
            this.mxgSend.TabIndex = 2;
            this.mxgSend.Text = "Send";
            this.mxgSend.UseVisualStyleBackColor = true;
            this.mxgSend.Click += new System.EventHandler(this.mxgSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 495);
            this.Controls.Add(this.mxgCmd);
            this.Controls.Add(this.mxaCmd);
            this.Controls.Add(this.textConsole);
            this.Controls.Add(this.mxgConnect);
            this.Controls.Add(this.mxgSend);
            this.Controls.Add(this.mxaSend);
            this.Controls.Add(this.mxaConnect);
            this.Controls.Add(this.mxgPort);
            this.Controls.Add(this.mxaPort);
            this.Controls.Add(this.mxgIP);
            this.Controls.Add(this.mxaIP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mxaIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mxaPort;
        private System.Windows.Forms.Button mxaConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mxgIP;
        private System.Windows.Forms.TextBox mxgPort;
        private System.Windows.Forms.Button mxgConnect;
        private System.Windows.Forms.TextBox textConsole;
        private System.Windows.Forms.TextBox mxaCmd;
        private System.Windows.Forms.Button mxaSend;
        private System.Windows.Forms.TextBox mxgCmd;
        private System.Windows.Forms.Button mxgSend;
    }
}

