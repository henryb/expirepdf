using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpirePDFViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /*
            if (args.Length > 0)
            {
             * */
            string[] args2 = {"test.epdf"};
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Viewer(args2));
            //}
        }
    }
}
