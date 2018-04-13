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
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace MTGSMFunctions
{
    struct Contact
    {
        int     index;
        string  name;
        string  phone;           
    }

    class GSM
    {
        public SerialPort serialPort;
        private bool    connected = false;
        public Control log;
       
        public  GSM(string comPort)
        {
            this.serialPort = new SerialPort();
            this.serialPort.PortName = comPort;
            this.serialPort.BaudRate = 9600;
            this.serialPort.Parity = Parity.None;
            this.serialPort.DataBits = 8;
            this.serialPort.StopBits = StopBits.One;
            this.serialPort.Handshake = Handshake.RequestToSend;
            this.serialPort.DtrEnable = true;
            this.serialPort.RtsEnable = true;
            this.serialPort.DataReceived += PortDataReceived;
        }

        public bool  open()
        {
            if (!this.serialPort.IsOpen)
            {
                try
                {
                    this.serialPort.Open();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            connected = this.serialPort.IsOpen;
            return connected;
        }

        public void closeAllPorts()
        {
            if (connected)
                close();
        }

        public bool isConnected()
        {
            return connected;
        }
        public bool close()
        {
            if (this.serialPort.IsOpen)
                this.serialPort.Close();

            connected = this.serialPort.IsOpen;
            return connected;

        }

        public void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string message = "";
            SerialPort spL = (SerialPort)sender;
            byte[] buf = new byte[spL.BytesToRead];
            spL.Read(buf, 0, buf.Length);

            foreach (Byte b in buf)
            {
                message += b.ToString();
            }

            var result = Encoding.ASCII.GetString(buf);
            if (result.Substring(0, 2).Equals("\r\n"))
                result = result.Substring(2);

            int resLen = result.Length;
            if (resLen > 4 && result.Substring(0,1) == "^")
            {

            }
            else if (result.Length > 6 && result.Substring(0, 6).Equals("+CUSD:"))
            {
                int idx = result.IndexOf("\"");
                if (idx > 0)
                {
                    int idx2 = result.Substring(idx + 1).IndexOf("\"");
                    String ussdRes = PduToStr(result.Substring(idx + 1, idx2));
                    ChangeText(this.log, ussdRes);
                }
            }
            else
            {
                ChangeText(this.log, result);
            }
        }

        public void sendATCommand(string command)
        {
            try
            {
                serialPort.Write(command + (char)(13) + (char)(26));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        public static String StrReverse(String st)
        {
            char[] ch = st.ToCharArray();
            Array.Reverse(ch);
            return new string(ch);
        }

        public static String StrToPdu(String command)
        {
            String bin = "";
            int sLen = command.Length;
            

            for (int i = 0; i < sLen; i++)
            {
                char []ch = command.Substring(i, 1).ToCharArray();
                bin += StrReverse(Convert.ToString(ch[0], 2).PadLeft(7, '0'));
            }

            String zeros = "00000000";
            bin +=  zeros.Substring(0, 8 - bin.Length % 8);
            String pdu = "";
            while (bin.Length > 0)
            {
                String symbol = StrReverse(bin.Substring(0, 8)); //  substr($bin, 0, 8);
                bin = bin.Substring(8); // substr($bin, 8);
                pdu += Dec2Hex(Bin2Dec(symbol.Substring(0, 4))) + Dec2Hex(Bin2Dec(symbol.Substring(4)));
            }

            return pdu;

        }

        public static String PduToStr(String st)
        {
            String str = "";
            if ((st.Length & 1) > 0) return "";
            Byte []by =  new Byte[ (st.Length) / 2 ];
            for (int i=0;i < (st.Length / 2); i++)
            {
                by[i] = Convert.ToByte(st.Substring( (i * 2), 2), 16);
            }

            String bin = "";
            for (int i=0; i < by.Length; i++)
            {
                bin += StrReverse( Convert.ToString(by[i], 2).PadLeft(8, '0') );
            }

            while (bin.Length >= 7)
            {
                String symbol = "0" + StrReverse(bin.Substring(0, 7));
                bin = bin.Substring(7);

                str += Dec2Hex(Bin2Dec(symbol.Substring(0,4))).ToUpper() + Dec2Hex(Bin2Dec(symbol.Substring(4))).ToUpper();
            }

            String hex = "";
            for (int i = 0; i < (str.Length / 2); i++)
            {
                hex += Convert.ToChar(Convert.ToByte(str.Substring((i * 2), 2), 16));
            }

            return hex;
        }
        public static string Hex2Bin(string value)
        {
            return Convert.ToString(Convert.ToInt32(value, 16), 2).PadLeft(value.Length * 4, '0');
        }

        public static String Bin2Dec(String binNum)
        {
            String str = Convert.ToUInt64(binNum, 2).ToString();
            return str;
        }

        public static String Dec2Hex(String decNum)
        {
            String str = Convert.ToString(Convert.ToInt32(decNum), 16);
            return str;
        }
        public void sendUSSD(string command)
        {
            serialPort.Write("AT+CUSD=1,\"" + StrToPdu( command ) + "\",15" + (char)(13) + (char)(26));
        }

        public bool writeContact(Contact cnt)
        {
            return true;
        }

        public void readContacts(out Contact[] cnt)
        {
            cnt = new Contact[120];
        }

        delegate void ChangeTextDelegate(Control ctrl, string text);
        public static void ChangeText(Control ctrl, string text)
		{
			if (ctrl.InvokeRequired)
			{
				ChangeTextDelegate del = new ChangeTextDelegate(ChangeText);
				ctrl.Invoke(del, ctrl, text);
			}
			else
			{
				ctrl.Text += text + "\r\n";
			}
		}
    }
}
