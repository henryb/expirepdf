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
using System.Diagnostics;

namespace ExpirePDFViewer
{
    public partial class Viewer : Form
    {
        public Viewer(string[] args)
        {
            InitializeComponent();
            filename = args[0].Trim();
        }


        public Image Base64DecodeImage(string image)
        {

            byte[] filebytes = Convert.FromBase64String(image);
            MemoryStream ms = new MemoryStream(filebytes);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        private byte[] Base64DecodeFile(string file)
        {

            return Convert.FromBase64String(file);

            
        }

       

        private void LaunchFile()
        {

            string newfilename = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".pdf");
            
            FileStream fs = new FileStream(newfilename, FileMode.CreateNew, FileAccess.Write, FileShare.None);

            fs.Write(fileData, 0, fileData.Length);
            fs.Flush();
            fs.Close();

            currentProcess = new Process();
            currentProcess.StartInfo.FileName = newfilename;
            currentProcess.StartInfo.UseShellExecute = true;
            currentProcess.Start();

        }

        private Process currentProcess = null;

        private byte[] fileData;

        /*
         * 
         * 
         * There may be specific reasons why you choose not to use an install package for your project but an install package is a great place to easily perform application configuration tasks such registering file extensions, adding desktop shortcuts, etc.

Here's how to create file extension association using the built-in Visual Studio Install tools:

1) Within your existing C# solution, add a new project and select project type as Other Project Types->Setup and Deployment->Setup Project (or try the Setup Wizard)

2) Configure your installer (plenty of existing docs for this if you need help)

3) Right-click the setup project in the Solution explorer, select View->File Types, and then add the extension that you want to register along with the program to run it.

This method has the added benefit of cleaning up after itself if a user runs the uninstall for your application.

         * 
         * 
         * */

        private string filename = string.Empty;

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (TextBox_Password.Text.Trim() != password)
            {
                MessageBox.Show("Incorrect password, please try again.");

                return;
            }

            LaunchFile();
           
        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            Timer_Hide.Start();
        }

        private void Timer_Hide_Tick(object sender, EventArgs e)
        {
            if ((filename.Substring(filename.Length - 5, 5).ToLower() != ".epdf") || !System.IO.File.Exists(filename))
            {
                
                this.Close();
            }

            Timer_Hide.Stop();

            ExtractFile(filename);
        }

        private void ExtractFile(string filename)
        {
            XmlDocument newDoc = new XmlDocument();
            newDoc.Load(filename);

            XmlElement rootNode = (XmlElement)(newDoc.SelectSingleNode("Root"));          

            fileData = Base64DecodeFile(rootNode.SelectSingleNode("File").InnerText);
            //System.Diagnostics.Debug.WriteLine(fileData.Length);
            expirationDate = DateTime.Parse(rootNode.SelectSingleNode("ExpirationDate").InnerText);
            availabilityDate = DateTime.Parse(rootNode.SelectSingleNode("AvailabilityDate").InnerText);
            password = rootNode.SelectSingleNode("Password").InnerText.Trim();
            message = rootNode.SelectSingleNode("Message").InnerText;

            if (message != string.Empty)
            {
                Label_Message.Text = message;

            }
            website = rootNode.SelectSingleNode("Website").InnerText;

            if (website != string.Empty)
            {
                LinkLabel_Website.Text = website;
            }

            if (rootNode.SelectSingleNode("Image").InnerText.Trim() != string.Empty)
            {
                PictureBox_Image.BackgroundImage = Base64DecodeImage(rootNode.SelectSingleNode("Image").InnerText.Trim());

            }
            

        }

        private string message = string.Empty;
        private string website = string.Empty;

        private string password = string.Empty;
        private DateTime expirationDate = DateTime.Now;
        private DateTime availabilityDate = DateTime.Now;

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
