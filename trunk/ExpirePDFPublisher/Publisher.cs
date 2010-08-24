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
using Org.BouncyCastle;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;

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
            try
            {
                foreach (string s in ListBox_Files.Items)
                {
                    BuildFile(s);
                }
            }
            catch (Exception t)
            {
                MessageBox.Show("Error in publishing:" + t.Message.ToString());
            }

            if (ListBox_Files.Items.Count > 0)
            {
                MessageBox.Show(ListBox_Files.Items.Count + " file(s) successfully published.");
            }
            else
            {
                MessageBox.Show("Please add some files to publish.");
            }

        }


        private string Base64EncodeFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            return Convert.ToBase64String(filebytes, Base64FormattingOptions.InsertLineBreaks);
        }



        private string Base64EncodeImage(Image theImage)
        {
            MemoryStream ms = new MemoryStream();
            theImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            return Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.InsertLineBreaks);
        }

        private void BuildFile(string filename)
        {

            XmlDocument newDoc = new XmlDocument();

            XmlElement rootNode = newDoc.CreateElement("Root");

            XmlElement fileNode = newDoc.CreateElement("File");
            fileNode.InnerText = Base64EncodeFile(filename);
            //String fileNod = Base64EncodeFile(filename);


            XmlElement availabilitydateNode = newDoc.CreateElement("AvailabilityDate");
            availabilitydateNode.InnerText = DateTimePicker_AvailabilityDate.Value.ToString();

            XmlElement expirationdateNode = newDoc.CreateElement("ExpirationDate");
            expirationdateNode.InnerText = DateTimePicker_ExpirationDate.Value.ToString();


            XmlElement passwordNode = newDoc.CreateElement("Password");
            passwordNode.InnerText = TextBox_Password.Text.Trim();

            XmlElement messageNode = newDoc.CreateElement("Message");
            messageNode.InnerText = TextBox_Message.Text.Trim();

            XmlElement websiteNode = newDoc.CreateElement("Website");
            websiteNode.InnerText = TextBox_Website.Text.Trim();

            XmlElement imageNode = newDoc.CreateElement("Image");
            if (PictureBox_Image.BackgroundImage != null)
            {
                imageNode.InnerText = Base64EncodeImage(PictureBox_Image.BackgroundImage);
            }
            else {
                imageNode.InnerText = string.Empty;
            }

            rootNode.AppendChild(passwordNode);
            rootNode.AppendChild(messageNode);
            rootNode.AppendChild(websiteNode);
            rootNode.AppendChild(imageNode);
            rootNode.AppendChild(availabilitydateNode);
            rootNode.AppendChild(expirationdateNode);
            rootNode.AppendChild(fileNode);

            newDoc.AppendChild(rootNode);
            newDoc.Save(filename.Substring(0, filename.Length - 4) + ".epdf");
            /*
            String argument = "-e " + filename.Substring(0, filename.Length - 4) + ".cpdf" + " keys\\viewpub.txt";

            EncryptIt(argument.Split(" ".ToCharArray()));


            String argument2 = "-d " + filename.Substring(0, filename.Length - 4) + ".epdf" + " keys\\viewpriv.txt 123123123";

            EncryptIt(argument2.Split(" ".ToCharArray()));
            
            */

        }
     /*   private void EncryptIt(string filename)
        {
            PgpEncryptionKeys keys = new PgpEncryptionKeys("C:\\keys\\viewpub.txt", "C:\\keys\\viewpriv.txt", "123123123");
            PgpEncrypt encrypt = new PgpEncrypt(keys);
            FileStream outputstream = new FileStream(filename.Substring(0, filename.Length - 4) + ".epdf", FileMode.Create,FileAccess.Write);
            FileInfo epdf = new FileInfo(filename.Substring(0, filename.Length - 4) + ".cpdf");
            encrypt.EncryptAndSign(outputstream, epdf);
            /*PgpPublicKey pubkey = new StreamReader("C:\\keys\\pubpub.txt").ReadToEnd();
            PgpPrivateKey privkey =new StreamReader("C:\\keys\\pubpriv.txt").ReadToEnd();
            String password = "123123123";
            Stream outputStream = File.OpenWrite(filename.Substring(0, filename.Length - 4) + ".epdf"); // this can be replaced with any other output stream e.g. MemoryStream
            PgpSignAndEncryptStream pgpOutStream = new PgpSignAndEncryptStream(outputStream, publicKey, secretKey, password);
            StreamWriter writer = new StreamWriter(pgpOutStream);
            writer.Write(new StreamReader(filename.Substring(0, filename.Length - 4) + ".cpdf").ReadToEnd());
            writer.Close();
            pgpOutStream.Close();
            outputStream.Close();
        
        }*/
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

       
    



     /**
        * A simple routine that opens a key ring file and loads the first available key suitable for
        * encryption.
        *
        * @param in
        * @return
        * @m_out
        * @
        */
        private static PgpPublicKey ReadPublicKey(
            Stream inputStream)
        {
            inputStream = PgpUtilities.GetDecoderStream(inputStream);

			PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(inputStream);

			//
            // we just loop through the collection till we find a key suitable for encryption, in the real
            // world you would probably want to be a bit smarter about this.
            //

            //
            // iterate through the key rings.
            //

            foreach (PgpPublicKeyRing kRing in pgpPub.GetKeyRings())
            {
                foreach (PgpPublicKey k in kRing.GetPublicKeys())
                {
                    if (k.IsEncryptionKey)
                    {
                        return k;
                    }
                }
            }

			throw new ArgumentException("Can't find encryption key in key ring.");
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
			PgpSecretKeyRingBundle	pgpSec,
            long					keyId,
            char[]					pass)
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
        private static void DecryptFile(
            Stream	inputStream,
            Stream	keyIn,
			char[]	passwd,
			string	defaultFileName)
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

                if (message is PgpLiteralData)
                {
                    PgpLiteralData ld = (PgpLiteralData)message;

					string outFileName = ld.FileName;
					if (outFileName.Length == 0)
					{
						outFileName = defaultFileName;
					}

					Stream fOut = File.Create(outFileName);
					Stream unc = ld.GetInputStream();
					
                    Streams.PipeAll(unc, fOut);
					fOut.Close();
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
            }
        }

        private static void EncryptFile(
            Stream			outputStream,
            string			fileName,
            PgpPublicKey	encKey,
            bool			armor,
            bool			withIntegrityCheck)
        {
            if (armor)
            {
                outputStream = new ArmoredOutputStream(outputStream);
            }

            try
            {
                MemoryStream bOut = new MemoryStream();

				PgpCompressedDataGenerator comData = new PgpCompressedDataGenerator(
                    CompressionAlgorithmTag.Zip);

				PgpUtilities.WriteFileToLiteralData(
					comData.Open(bOut),
					PgpLiteralData.Binary,
					new FileInfo(fileName));

				comData.Close();

				PgpEncryptedDataGenerator cPk = new PgpEncryptedDataGenerator(
					SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());

				cPk.AddMethod(encKey);

				byte[] bytes = bOut.ToArray();

				Stream cOut = cPk.Open(outputStream, bytes.Length);

				cOut.Write(bytes, 0, bytes.Length);

				cOut.Close();

				if (armor)
				{
					outputStream.Close();
				}
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
            }
        }

        public static void EncryptIt(
          string[] args)
        {

//usage: KeyBasedFileProcessor -e|-d [-a|ai] file [secretKeyFile passPhrase|pubKeyFile]");

            

            if (args[0].Equals("-e"))
            {
				Stream keyIn, fos;
                if (args[1].Equals("-a") || args[1].Equals("-ai") || args[1].Equals("-ia"))
                {
                    keyIn = File.OpenRead(args[3]);
                    fos = File.Create(args[2] + ".asc");
                    EncryptFile(fos, args[2], ReadPublicKey(keyIn), true, (args[1].IndexOf('i') > 0));
                }
                else if (args[1].Equals("-i"))
                {
                    keyIn = File.OpenRead(args[3]);
                    fos = File.Create(args[2]);
                    EncryptFile(fos, args[2], ReadPublicKey(keyIn), false, true);
                }
                else
                {
                    keyIn = File.OpenRead(args[2]);
                    fos = File.Create(args[1].Substring(0, args[1].Length - 5) + ".epdf");
                    //System.Diagnostics.Debug.WriteLine("Outputting to: " + args[1] + ".epdf");
                    EncryptFile(fos, args[1], ReadPublicKey(keyIn), false, false);
                }
				keyIn.Close();
				fos.Close();
            }
            else if (args[0].Equals("-d"))
            {
                Stream fin = File.OpenRead(args[1]);
                Stream keyIn = File.OpenRead(args[2]);
				//DecryptFile(fin, keyIn, args[3].ToCharArray(), new FileInfo(args[1]).Name + ".out");
                DecryptFile(fin, keyIn, "".ToCharArray(), new FileInfo(args[1]).Name + ".out");
				fin.Close();
				keyIn.Close();
            }
            else
            {
                Console.Error.WriteLine("usage: KeyBasedFileProcessor -d|-e [-a|ai] file [secretKeyFile passPhrase|pubKeyFile]");
            }
        }

        private void Button_AddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog_PDF.ShowDialog();
        }

        private void Button_RemoveFile_Click(object sender, EventArgs e)
        {

            if (ListBox_Files.SelectedIndex > -1 && ListBox_Files.SelectedIndex < ListBox_Files.Items.Count)
            {
                ListBox_Files.Items.RemoveAt(ListBox_Files.SelectedIndex);
            }
        }

        private void Button_AddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog_PNG.ShowDialog();        
        }

        private void Button_RemoveImage_Click(object sender, EventArgs e)
        {
            PictureBox_Image.BackgroundImage.Dispose();
            PictureBox_Image.BackgroundImage = null;
        }

        private void OpenFileDialog_PNG_FileOk(object sender, CancelEventArgs e)
        {
            PictureBox_Image.BackgroundImage = Image.FromFile(OpenFileDialog_PNG.FileName);
        }

       
    }












///*
//    /// <summary>
//    /// Wrapper around Bouncy Castle OpenPGP library.
//    /// Bouncy documentation can be found here: http://www.bouncycastle.org/docs/pgdocs1.6/index.html
//    /// Code from: http://blogs.microsoft.co.il/blogs/kim/archive/2009/01/23/pgp-zip-encrypted-files-with-c.aspx
//    /// with some very minor changes.
//    /// </summary>
//    public class PgpEncrypt
//    {
//        #region Private Variables

//        private PgpEncryptionKeys mEncryptionKeys;
//        private const int bufferSize = 0x10000; // should always be power of 2 

//        #endregion

//        #region Public Methods
//        /// <summary>
//        /// Instantiate a new PgpEncrypt class with initialized PgpEncryptionKeys.
//        /// </summary>
//        /// <param name="encryptionKeys"></param>
//        /// <exception cref="ArgumentNullException">encryptionKeys is null</exception>
//        public PgpEncrypt(PgpEncryptionKeys encryptionKeys)
//        {
//            if (encryptionKeys == null)
//            {
//                throw new ArgumentNullException("encryptionKeys", "encryptionKeys is null.");
//            }

//            mEncryptionKeys = encryptionKeys;
//        }

//        /// <summary>
//        /// Encrypt and sign the file pointed to by unencryptedFileInfo and
//        /// write the encrypted content to outputStream.
//        /// </summary>
//        /// <param name="outputStream">
//        ///     The stream that will contain the encrypted data when this method returns.
//        /// </param>
//        /// <param name="fileName">FileInfo of the file to encrypt</param>
//        public void EncryptAndSign(Stream outputStream, FileInfo unencryptedFileInfo)
//        {
//            if (outputStream == null)
//            {
//                throw new ArgumentNullException("outputStream", "outputStream is null.");
//            }
//            if (unencryptedFileInfo == null)
//            {
//                throw new ArgumentNullException("unencryptedFileInfo", "unencryptedFileInfo is null.");
//            }
//            if (!File.Exists(unencryptedFileInfo.FullName))
//            {
//                throw new ArgumentException("File to encrypt not found.");
//            }

//            using (Stream encryptedOut = chainEncryptedOut(outputStream))
//            {
//                using (Stream compressedOut = chainCompressedOut(encryptedOut))
//                {
//                    PgpSignatureGenerator signatureGenerator = initSignatureGenerator(compressedOut);
//                    using (Stream literalOut = chainLiteralOut(compressedOut, unencryptedFileInfo))
//                    {
//                        using (FileStream inputFile = unencryptedFileInfo.OpenRead())
//                        {
//                            writeOutputAndSign(compressedOut, literalOut, inputFile, signatureGenerator);
//                        }
//                    }
//                }
//            }
//        }

//        #endregion

//        #region Private Methods
//        private static void writeOutputAndSign(Stream compressedOut, Stream literalOut, FileStream inputFile, PgpSignatureGenerator signatureGenerator)
//        {
//            int length = 0;
//            byte[] buf = new byte[bufferSize];

//            while ((length = inputFile.Read(buf, 0, buf.Length)) > 0)
//            {
//                literalOut.Write(buf, 0, length);
//                signatureGenerator.Update(buf, 0, length);
//            }

//            signatureGenerator.Generate().Encode(compressedOut);
//        }

//        private Stream chainEncryptedOut(Stream outputStream)
//        {
//            PgpEncryptedDataGenerator encryptedDataGenerator;
//            encryptedDataGenerator = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.TripleDes, new SecureRandom());
//            encryptedDataGenerator.AddMethod(mEncryptionKeys.PublicKey);

//            return encryptedDataGenerator.Open(outputStream, new byte[bufferSize]);
//        }

//        private static Stream chainCompressedOut(Stream encryptedOut)
//        {
//            PgpCompressedDataGenerator compressedDataGenerator = new PgpCompressedDataGenerator(CompressionAlgorithmTag.Zip);
//            return compressedDataGenerator.Open(encryptedOut);
//        }

//        private static Stream chainLiteralOut(Stream compressedOut, FileInfo file)
//        {
//            PgpLiteralDataGenerator pgpLiteralDataGenerator = new PgpLiteralDataGenerator();
//            return pgpLiteralDataGenerator.Open(compressedOut, PgpLiteralData.Binary, file);
//        }

//        private PgpSignatureGenerator initSignatureGenerator(Stream compressedOut)
//        {
//            const bool IsCritical = false;
//            const bool IsNested = false;

//            PublicKeyAlgorithmTag tag = mEncryptionKeys.SecretKey.PublicKey.Algorithm;
//            PgpSignatureGenerator pgpSignatureGenerator = new PgpSignatureGenerator(tag, HashAlgorithmTag.Sha1);
//            pgpSignatureGenerator.InitSign(PgpSignature.BinaryDocument, mEncryptionKeys.PrivateKey);

//            foreach (string userId in mEncryptionKeys.SecretKey.PublicKey.GetUserIds())
//            {
//                PgpSignatureSubpacketGenerator subPacketGenerator = new PgpSignatureSubpacketGenerator();
//                subPacketGenerator.SetSignerUserId(IsCritical, userId);
//                pgpSignatureGenerator.SetHashedSubpackets(subPacketGenerator.Generate());

//                // Just the first one!
//                break;
//            }

//            pgpSignatureGenerator.GenerateOnePassVersion(IsNested).Encode(compressedOut);
//            return pgpSignatureGenerator;
//        }

//        #endregion
//    }
//}/*
//public class PgpEncryptionKeys
//{
//    #region Public Methods
//    public PgpPublicKey PublicKey { get; private set; }
//    public PgpPrivateKey PrivateKey { get; private set; }
//    public PgpSecretKey SecretKey { get; private set; }

//    /// <summary>
//    /// Initializes a new instance of the EncryptionKeys class.
//    /// Two keys are required to encrypt and sign data. Your private key and the recipients public key.
//    /// The data is encrypted with the recipients public key and signed with your private key.
//    /// </summary>
//    /// <param name="publicKeyPath">The key used to encrypt the data</param>
//    /// <param name="privateKeyPath">The key used to sign the data.</param>
//    /// <param name="passPhrase">The (your) password required to access the private key</param>
//    /// <exception cref="ArgumentException">Public key not found. Private key not found. Missing password</exception>
//    public PgpEncryptionKeys(string publicKeyPath, string privateKeyPath, string passPhrase)
//    {
//        if (!File.Exists(publicKeyPath))
//        {
//            throw new ArgumentException("Public key file not found.", "publicKeyPath");
//        }
//        if (!File.Exists(privateKeyPath))
//        {
//            throw new ArgumentException("Private key file not found.", "privateKeyPath");
//        }
//        if (String.IsNullOrEmpty(passPhrase))
//        {
//            throw new ArgumentException("passPhrase is null or empty.", "passPhrase");
//        }

//        PublicKey = readPublicKey(publicKeyPath);
//        SecretKey = readSecretKey(privateKeyPath);
//        //SecretKey = findSecretKey();
//        PrivateKey = readPrivateKey(passPhrase);
//    }

//    #endregion

//    #region Private Methods

//    #region Secret Key
//    /*private static PgpPrivateKey findSecretKey()
//        {
    
//        }

//    *//*
//    private PgpSecretKey readSecretKey(string privateKeyPath)
//    {
//    /*    using (Stream keyIn = File.OpenRead(privateKeyPath))
//        {
//            using (Stream inputStream = PgpUtilities.GetDecoderStream(keyIn))
//            {
//                PgpSecretKeyRingBundle secretKeyRingBundle = new PgpSecretKeyRingBundle(inputStream);
//                PgpSecretKey foundKey = getFirstSecretKey(secretKeyRingBundle);

//                if (foundKey != null)
//                {
//                    return foundKey;
//                }
//            }
//        }
//        throw new ArgumentException("Can't find signing key in key ring.");*/
//        /*char[] pass = "123123123".ToCharArray();
//        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
//        PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(encoding.GetBytes(new StreamReader("C:\\keys\\viewpriv.txt").ReadToEnd()));
//        PgpSecretKey pgpSecKey = pgpSec.GetSecretKey(1);
//        if (pgpSecKey == null)
//        {
//            return null;
//        }

//        return pgpSecKey.ExtractPrivateKey(pass);
//    }

//    /// <summary>
//    /// Return the first key we can use to encrypt.
//    /// Note: A file can contain multiple keys (stored in "key rings")
//    /// </summary>
//    private PgpSecretKey getFirstSecretKey(PgpSecretKeyRingBundle secretKeyRingBundle)
//    {
//        foreach (PgpSecretKeyRing kRing in secretKeyRingBundle.GetKeyRings())
//        {
//            // Note: You may need to use something other than the first key
//            //  in your key ring. Keep that in mind. 
//            // ex: .Where(k => !k.IsSigningKey)
//            PgpSecretKey key = kRing.GetSecretKeys()
//                .Cast<PgpSecretKey>()
//                //.Where(k => k.IsSigningKey)
//                .Where(k => !k.IsSigningKey)
//                .FirstOrDefault();

//            if (key != null)
//            {
//                return key;
//            }
//        }

//        return null;
//    }

//    #endregion

//    #region Public Key

//    private PgpPublicKey readPublicKey(string publicKeyPath)
//    {
//        using (Stream keyIn = File.OpenRead(publicKeyPath))
//        {
//            using (Stream inputStream = PgpUtilities.GetDecoderStream(keyIn))
//            {
//                try
//                {
//                    PgpPublicKeyRingBundle publicKeyRingBundle = new PgpPublicKeyRingBundle(inputStream);
//                    PgpPublicKey foundKey = getFirstPublicKey(publicKeyRingBundle);

//                    if (foundKey != null)
//                    {
//                        return foundKey;
//                    }
//                }
//                catch (Exception)
//                {
//                    throw new ArgumentException("There was a problem with the public key ring.");
//                }
//            }
//        }
//        throw new ArgumentException("No encryption key found in public key ring.");
//    }

//    private PgpPublicKey getFirstPublicKey(PgpPublicKeyRingBundle publicKeyRingBundle)
//    {
//        foreach (PgpPublicKeyRing kRing in publicKeyRingBundle.GetKeyRings())
//        {
//            PgpPublicKey key = kRing.GetPublicKeys()
//                .Cast<PgpPublicKey>()
//                .Where(k => k.IsEncryptionKey)
//                .FirstOrDefault();

//            if (key != null)
//            {
//                return key;
//            }
//        }

//        return null;
//    }

//    #endregion

//    #region Private Key

//    private PgpPrivateKey readPrivateKey(string passPhrase)
//    {
//        PgpPrivateKey privateKey = SecretKey.ExtractPrivateKey(passPhrase.ToCharArray());

//        if (privateKey != null)
//        {
//            return privateKey;
//        }

//        throw new ArgumentException("No private key found in secret key.");
//    }

//    #endregion

//    #endregion*/
}

       