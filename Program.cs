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
//using System.Linq;
using System.Windows.Forms;

namespace MTGSMFunctions
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

        }
    }
}
