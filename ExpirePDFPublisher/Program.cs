﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpirePDFPublisher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
	/// This program is terrible, Monkeys could have done better
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Publisher());
        }
    }
}
