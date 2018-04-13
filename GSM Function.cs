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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MTGSMFunctions
{
    public partial class MainWindow : Form
    {
        private bool COMConnected=false;
        GSM gsm;
        public MainWindow()
        {
            InitializeComponent();
            InitCOMPorts();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CBPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitCOMPorts()
        {
            if (gsm != null)
            {
                gsm.closeAllPorts();
                if (gsm.isConnected()) return;
            }
            System.Windows.Forms.TextBox.CheckForIllegalCrossThreadCalls = false;
            string[] comports = SerialPort.GetPortNames();
            CBPorts.Items.Clear();
            foreach (string comport in comports)
            {
                CBPorts.Items.Add(comport);
            }
        }

        private void COMConnect_Click(object sender, EventArgs e)
        {
            if (COMConnected)
            {
                if (gsm.close() == false)
                {
                    COMConnect.Text = "Connect";
                    COMConnected = false;
                }
            }
            else
            {
                if (gsm == null) gsm = new GSM(CBPorts.Text);
                if (gsm != null)
                {
                    gsm.log = this.LOG;
                }

                if (gsm.open())
                {
                    COMConnect.Text = "Disconnect";
                    COMConnected = true;
                }
            }
        }

        private void SendAT_Click(object sender, EventArgs e)
        {
            gsm.sendATCommand(MSG.Text);
            LOG.AppendText(MSG.Text + "\r\n");
            MSG.Text = "";
        }

        private void SendUSSD_Click(object sender, EventArgs e)
        {
            gsm.sendUSSD(EDUSSD.Text);               
            LOG.AppendText(EDUSSD.Text + "\r\n");
            EDUSSD.Text = "";
        }

        private void LOG_TextChanged(object sender, EventArgs e)
        {
            LOG.SelectionStart = LOG.Text.Length;
            LOG.ScrollToCaret();
        }

        public void appendLOGText(string str)
        {
            LOG.AppendText(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitCOMPorts();
        }
    }
}
