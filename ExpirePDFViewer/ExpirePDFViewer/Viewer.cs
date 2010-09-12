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
using System.Threading;
using Org.BouncyCastle;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;

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

        private int elapsedTime = 0;
        //private bool eventHandled;



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
            currentProcess.EnableRaisingEvents = true;
            currentProcess.Exited += new EventHandler(currentProcess_Exited);
            currentProcess.Start();


            

            const int SLEEP_AMOUNT = 100;
            while (!eventHandled)
            {
                elapsedTime += SLEEP_AMOUNT;
                if (elapsedTime > 30000)
                {
                    break;
                }
                Thread.Sleep(SLEEP_AMOUNT);
            }

            this.Close();

            File.Decrypt(newfilename);



        }

        private bool eventHandled = false;

        void currentProcess_Exited(object sender, EventArgs e)
        {
            eventHandled = true; 
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
            Hide();
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
            string executableName = Application.ExecutablePath;
            FileInfo executableFileInfo = new FileInfo(executableName);
            string executableDirectoryName = executableFileInfo.DirectoryName;
            Stream fin = File.OpenRead(filename);
            Stream keyIn = File.OpenRead(executableDirectoryName+"\\secring.gpg");
            String xmlstring = DecryptFile(fin, keyIn, "".ToCharArray(), new FileInfo(filename).Name + ".out");
            fin.Close();
            keyIn.Close();

            if (xmlstring == null)
                Application.Exit();
            
            XmlDocument newDoc = new XmlDocument();
            newDoc.LoadXml(xmlstring);

            XmlElement rootNode = (XmlElement)(newDoc.SelectSingleNode("Root"));          

            fileData = Base64DecodeFile(rootNode.SelectSingleNode("File").InnerText);
            //System.Diagnostics.Debug.WriteLine(fileData.Length);
            expirationDate = DateTime.Parse(rootNode.SelectSingleNode("ExpirationDate").InnerText);
            availabilityDate = DateTime.Parse(rootNode.SelectSingleNode("AvailabilityDate").InnerText);
            password = rootNode.SelectSingleNode("Password").InnerText.Trim();
            message = rootNode.SelectSingleNode("Message").InnerText;

            if (expirationDate.Ticks < DateTime.Now.Ticks)
            {
                MessageBox.Show("PDF has expired.");
                killit = true;
            }

            if (availabilityDate.Ticks > DateTime.Now.Ticks)
            {
                MessageBox.Show("PDF is not available yet.");
               
                killit = true;
            }

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

            if (password == string.Empty && !killit)
            {
                Hide();
                LaunchFile();
            }

            if (killit)
            {

                
                Application.Exit();
            }

        }


        private bool killit = false;
        private string message = string.Empty;
        private string website = string.Empty;

        private string password = string.Empty;
        private DateTime expirationDate = DateTime.Now;
        private DateTime availabilityDate = DateTime.Now;

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
        * Search a secret key ring collection for a secret key corresponding to
        * keyId if it exists.
        *
        * @param pgpSec a secret key ring collection.
        * @param keyId keyId we want.
        * @param pass passphrase to decrypt secret key with.
        * @return
        */
        private static PgpPrivateKey FindSecretKey(
            PgpSecretKeyRingBundle pgpSec,
            long keyId,
            char[] pass)
        {
            PgpSecretKey pgpSecKey = pgpSec.GetSecretKey(keyId);

            if (pgpSecKey == null)
            {
                return null;
            }

            return pgpSecKey.ExtractPrivateKey(pass);
        }

        /**
        * decrypt the passed in message stream
        */
        private static String DecryptFile(
            Stream inputStream,
            Stream keyIn,
            char[] passwd,
            string defaultFileName)
        {
            inputStream = PgpUtilities.GetDecoderStream(inputStream);

            try
            {
                PgpObjectFactory pgpF = new PgpObjectFactory(inputStream);
                PgpEncryptedDataList enc;

                PgpObject o = pgpF.NextPgpObject();
                //
                // the first object might be a PGP marker packet.
                //
                if (o is PgpEncryptedDataList)
                {
                    enc = (PgpEncryptedDataList)o;
                }
                else
                {
                    enc = (PgpEncryptedDataList)pgpF.NextPgpObject();
                }

                //
                // find the secret key
                //
                PgpPrivateKey sKey = null;
                PgpPublicKeyEncryptedData pbe = null;
                PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(
                    PgpUtilities.GetDecoderStream(keyIn));

                foreach (PgpPublicKeyEncryptedData pked in enc.GetEncryptedDataObjects())
                {
                    sKey = FindSecretKey(pgpSec, pked.KeyId, passwd);

                    if (sKey != null)
                    {
                        pbe = pked;
                        break;
                    }
                }

                if (sKey == null)
                {
                    throw new ArgumentException("secret key for message not found.");
                }

                Stream clear = pbe.GetDataStream(sKey);

                PgpObjectFactory plainFact = new PgpObjectFactory(clear);

                PgpObject message = plainFact.NextPgpObject();

                if (message is PgpCompressedData)
                {
                    PgpCompressedData cData = (PgpCompressedData)message;
                    PgpObjectFactory pgpFact = new PgpObjectFactory(cData.GetDataStream());

                    message = pgpFact.NextPgpObject();
                }

                String decryptedstring;

                if (message is PgpLiteralData)
                {
                    PgpLiteralData ld = (PgpLiteralData)message;
                    Stream unc = ld.GetInputStream();

                    //string outFileName = ld.FileName;
                    //if (outFileName.Length == 0)
                    //{
                    //    outFileName = defaultFileName;
                    //}

                    //Stream fos = File.Create("C:\\test.epdf");

                    //Streams.PipeAll(unc, fos);
                    //fos.Close();
                    
                    StreamReader reader = new StreamReader(unc);
                    decryptedstring = reader.ReadToEnd();
                }
                else if (message is PgpOnePassSignatureList)
                {
                    throw new PgpException("encrypted message contains a signed message - not literal data.");
                }
                else
                {
                    throw new PgpException("message is not a simple encrypted file - type unknown.");
                }

                if (pbe.IsIntegrityProtected())
                {
                    if (!pbe.Verify())
                    {
                        Console.Error.WriteLine("message failed integrity check");
                    }
                    else
                    {
                        Console.Error.WriteLine("message integrity check passed");
                    }
                }
                else
                {
                    Console.Error.WriteLine("no message integrity check");
                }
                return decryptedstring;
            }
            catch (PgpException e)
            {
                Console.Error.WriteLine(e);

                Exception underlyingException = e.InnerException;
                if (underlyingException != null)
                {
                    Console.Error.WriteLine(underlyingException.Message);
                    Console.Error.WriteLine(underlyingException.StackTrace);
                }
                return null;
            }
        }

    }
}
