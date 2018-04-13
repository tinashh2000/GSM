/***************************************************************************************
* Copyright (C) 2018 Tinashe Mutandagayi                                               *
*                                                                                      *
* This file is part of the GSM System source code. The author(s) of this file          *
* is/are not liable for any damages, loss or loss of information, deaths, sicknesses   *
* or other bad things resulting from use of this file or software, either direct or    *
* indirect.                                                                            *
* Terms and conditions for use and distribution can be found in the license file named *
* LICENSE.TXT. If you distribute this file or continue using it,                       *
* it means you understand and agree with the terms and conditions in the license file, *
* if not, do not use the file														   *
*                                                                                      *
* Happy Coding :)                                                                      *
****************************************************************************************/

namespace MTGSMFunctions
{
    public partial class MainWindow
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
            this.CBPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.COMConnect = new System.Windows.Forms.Button();
            this.LOG = new System.Windows.Forms.TextBox();
            this.MSG = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.EDUSSD = new System.Windows.Forms.TextBox();
            this.SendUSSD = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBPorts
            // 
            this.CBPorts.FormattingEnabled = true;
            this.CBPorts.Location = new System.Drawing.Point(177, 13);
            this.CBPorts.Name = "CBPorts";
            this.CBPorts.Size = new System.Drawing.Size(152, 21);
            this.CBPorts.TabIndex = 0;
            this.CBPorts.SelectedIndexChanged += new System.EventHandler(this.CBPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port";
            // 
            // COMConnect
            // 
            this.COMConnect.Location = new System.Drawing.Point(335, 13);
            this.COMConnect.Name = "COMConnect";
            this.COMConnect.Size = new System.Drawing.Size(74, 21);
            this.COMConnect.TabIndex = 2;
            this.COMConnect.Text = "Connect";
            this.COMConnect.UseVisualStyleBackColor = true;
            this.COMConnect.Click += new System.EventHandler(this.COMConnect_Click);
            // 
            // LOG
            // 
            this.LOG.Location = new System.Drawing.Point(26, 49);
            this.LOG.MaxLength = 655360;
            this.LOG.Multiline = true;
            this.LOG.Name = "LOG";
            this.LOG.ReadOnly = true;
            this.LOG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LOG.Size = new System.Drawing.Size(431, 134);
            this.LOG.TabIndex = 3;
            this.LOG.TextChanged += new System.EventHandler(this.LOG_TextChanged);
            // 
            // MSG
            // 
            this.MSG.Location = new System.Drawing.Point(31, 195);
            this.MSG.Name = "MSG";
            this.MSG.Size = new System.Drawing.Size(330, 20);
            this.MSG.TabIndex = 4;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(366, 189);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(90, 31);
            this.Send.TabIndex = 5;
            this.Send.Text = "Send AT";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.SendAT_Click);
            // 
            // EDUSSD
            // 
            this.EDUSSD.Location = new System.Drawing.Point(30, 232);
            this.EDUSSD.Name = "EDUSSD";
            this.EDUSSD.Size = new System.Drawing.Size(330, 20);
            this.EDUSSD.TabIndex = 4;
            // 
            // SendUSSD
            // 
            this.SendUSSD.Location = new System.Drawing.Point(366, 226);
            this.SendUSSD.Name = "SendUSSD";
            this.SendUSSD.Size = new System.Drawing.Size(90, 31);
            this.SendUSSD.TabIndex = 5;
            this.SendUSSD.Text = "Send USSD";
            this.SendUSSD.UseVisualStyleBackColor = true;
            this.SendUSSD.Click += new System.EventHandler(this.SendUSSD_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SendUSSD);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.EDUSSD);
            this.Controls.Add(this.MSG);
            this.Controls.Add(this.LOG);
            this.Controls.Add(this.COMConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainWindow";
            this.Text = "MT-GSM Functions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button COMConnect;
        public  System.Windows.Forms.TextBox LOG;
        private System.Windows.Forms.TextBox MSG;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox EDUSSD;
        private System.Windows.Forms.Button SendUSSD;
        private System.Windows.Forms.Button button1;
    }
}

