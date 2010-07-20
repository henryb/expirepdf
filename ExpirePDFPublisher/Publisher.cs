using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

// Main form
namespace ExpirePDFPublisher
{
    public partial class Publisher : Form
    {
        public Publisher()
        {
            InitializeComponent();
        }

        private void Button_Publish_Click(object sender, EventArgs e)
        {

            foreach (string s in ListBox_Files.Items)
            {
                BuildFile(s);
            }

        }


        private string Base64EncodeFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            return Convert.ToBase64String(filebytes, Base64FormattingOptions.InsertLineBreaks);
        }

        private void BuildFile(string filename)
        {

            XmlDocument newDoc = new XmlDocument();

            XmlElement rootNode = newDoc.CreateElement("Root");

            XmlElement fileNode = newDoc.CreateElement("File");
            fileNode.InnerText = Base64EncodeFile(filename);

            XmlElement releasedateNode = newDoc.CreateElement("ReleaseDate");
            releasedateNode.InnerText = DateTimePicker_ReleaseDate.Value.ToString();

            XmlElement expirationdateNode = newDoc.CreateElement("ExpirationDate");
            expirationdateNode.InnerText = DateTimePicker_ExpirationDate.Value.ToString();

            
            rootNode.AppendChild(releasedateNode);
            rootNode.AppendChild(expirationdateNode);
            rootNode.AppendChild(fileNode);

            newDoc.AppendChild(rootNode);

            newDoc.Save(filename.Substring(0, filename.Length - 4) + ".epdf");


        }

        private void ListBox_Files_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        /// <summary>
        /// Adds all files with filenames ending with .pdf to the files list
        /// </summary>
        /// <param name="sender">The source of the drag drop event</param>
        /// <param name="e">The arguments for the drag drop event</param>
        private void ListBox_Files_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            
            foreach (string file in files)
            {

                if (file.Substring(file.Length - 4, 4).ToLower() == ".pdf")
                {
                    ListBox_Files.Items.Add(file);
                }
            }

        }

        private void Button_Open_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog_PDF.ShowDialog();
        }

        private void OpenFileDialog_PDF_FileOk(object sender, CancelEventArgs e)
        {
            string[] files = OpenFileDialog_PDF.FileNames;

            foreach (string file in files)
            {

                ListBox_Files.Items.Add(file);
            }

        }
    }
}
