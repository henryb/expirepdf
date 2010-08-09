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
            String fileNod = Base64EncodeFile(filename);


            XmlElement releasedateNode = newDoc.CreateElement("ReleaseDate");
            releasedateNode.InnerText = DateTimePicker_ReleaseDate.Value.ToString();

            XmlElement expirationdateNode = newDoc.CreateElement("ExpirationDate");
            expirationdateNode.InnerText = DateTimePicker_ExpirationDate.Value.ToString();


            rootNode.AppendChild(releasedateNode);
            rootNode.AppendChild(expirationdateNode);
            rootNode.AppendChild(fileNode);

            newDoc.AppendChild(rootNode);
            newDoc.Save(filename.Substring(0, filename.Length - 4) + ".cpdf");

            EncryptIt(filename);


        }
        private void EncryptIt(string filename)
        {
            PgpEncryptionKeys keys = new PgpEncryptionKeys("C:\\keys\\viewpub.txt", "C:\\keys\\viewpriv.txt", "123123123");
            PgpEncrypt encrypt = new PgpEncrypt(keys);
            FileStream outputstream = new FileStream(filename.Substring(0, filename.Length - 4) + ".epdf", FileMode.Create,FileAccess.Write);
            FileInfo epdf = new FileInfo(filename.Substring(0, filename.Length - 4) + ".cpdf");
            encrypt.EncryptAndSign(outputstream, epdf);
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

        private void label6_Click(object sender, EventArgs e)
        {
        }
    }

    /// <summary>
    /// Wrapper around Bouncy Castle OpenPGP library.
    /// Bouncy documentation can be found here: http://www.bouncycastle.org/docs/pgdocs1.6/index.html
    /// Code from: http://blogs.microsoft.co.il/blogs/kim/archive/2009/01/23/pgp-zip-encrypted-files-with-c.aspx
    /// with some very minor changes.
    /// </summary>
    public class PgpEncrypt
    {
        #region Private Variables

        private PgpEncryptionKeys mEncryptionKeys;
        private const int bufferSize = 0x10000; // should always be power of 2 

        #endregion

        #region Public Methods
        /// <summary>
        /// Instantiate a new PgpEncrypt class with initialized PgpEncryptionKeys.
        /// </summary>
        /// <param name="encryptionKeys"></param>
        /// <exception cref="ArgumentNullException">encryptionKeys is null</exception>
        public PgpEncrypt(PgpEncryptionKeys encryptionKeys)
        {
            if (encryptionKeys == null)
            {
                throw new ArgumentNullException("encryptionKeys", "encryptionKeys is null.");
            }

            mEncryptionKeys = encryptionKeys;
        }

        /// <summary>
        /// Encrypt and sign the file pointed to by unencryptedFileInfo and
        /// write the encrypted content to outputStream.
        /// </summary>
        /// <param name="outputStream">
        ///     The stream that will contain the encrypted data when this method returns.
        /// </param>
        /// <param name="fileName">FileInfo of the file to encrypt</param>
        public void EncryptAndSign(Stream outputStream, FileInfo unencryptedFileInfo)
        {
            if (outputStream == null)
            {
                throw new ArgumentNullException("outputStream", "outputStream is null.");
            }
            if (unencryptedFileInfo == null)
            {
                throw new ArgumentNullException("unencryptedFileInfo", "unencryptedFileInfo is null.");
            }
            if (!File.Exists(unencryptedFileInfo.FullName))
            {
                throw new ArgumentException("File to encrypt not found.");
            }

            using (Stream encryptedOut = chainEncryptedOut(outputStream))
            {
                using (Stream compressedOut = chainCompressedOut(encryptedOut))
                {
                    PgpSignatureGenerator signatureGenerator = initSignatureGenerator(compressedOut);
                    using (Stream literalOut = chainLiteralOut(compressedOut, unencryptedFileInfo))
                    {
                        using (FileStream inputFile = unencryptedFileInfo.OpenRead())
                        {
                            writeOutputAndSign(compressedOut, literalOut, inputFile, signatureGenerator);
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Methods
        private static void writeOutputAndSign(Stream compressedOut, Stream literalOut, FileStream inputFile, PgpSignatureGenerator signatureGenerator)
        {
            int length = 0;
            byte[] buf = new byte[bufferSize];

            while ((length = inputFile.Read(buf, 0, buf.Length)) > 0)
            {
                literalOut.Write(buf, 0, length);
                signatureGenerator.Update(buf, 0, length);
            }

            signatureGenerator.Generate().Encode(compressedOut);
        }

        private Stream chainEncryptedOut(Stream outputStream)
        {
            PgpEncryptedDataGenerator encryptedDataGenerator;
            encryptedDataGenerator = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.TripleDes, new SecureRandom());
            encryptedDataGenerator.AddMethod(mEncryptionKeys.PublicKey);

            return encryptedDataGenerator.Open(outputStream, new byte[bufferSize]);
        }

        private static Stream chainCompressedOut(Stream encryptedOut)
        {
            PgpCompressedDataGenerator compressedDataGenerator = new PgpCompressedDataGenerator(CompressionAlgorithmTag.Zip);
            return compressedDataGenerator.Open(encryptedOut);
        }

        private static Stream chainLiteralOut(Stream compressedOut, FileInfo file)
        {
            PgpLiteralDataGenerator pgpLiteralDataGenerator = new PgpLiteralDataGenerator();
            return pgpLiteralDataGenerator.Open(compressedOut, PgpLiteralData.Binary, file);
        }

        private PgpSignatureGenerator initSignatureGenerator(Stream compressedOut)
        {
            const bool IsCritical = false;
            const bool IsNested = false;

            PublicKeyAlgorithmTag tag = mEncryptionKeys.SecretKey.PublicKey.Algorithm;
            PgpSignatureGenerator pgpSignatureGenerator = new PgpSignatureGenerator(tag, HashAlgorithmTag.Sha1);
            pgpSignatureGenerator.InitSign(PgpSignature.BinaryDocument, mEncryptionKeys.PrivateKey);

            foreach (string userId in mEncryptionKeys.SecretKey.PublicKey.GetUserIds())
            {
                PgpSignatureSubpacketGenerator subPacketGenerator = new PgpSignatureSubpacketGenerator();
                subPacketGenerator.SetSignerUserId(IsCritical, userId);
                pgpSignatureGenerator.SetHashedSubpackets(subPacketGenerator.Generate());

                // Just the first one!
                break;
            }

            pgpSignatureGenerator.GenerateOnePassVersion(IsNested).Encode(compressedOut);
            return pgpSignatureGenerator;
        }

        #endregion
    }
}
public class PgpEncryptionKeys
{
    #region Public Methods
    public PgpPublicKey PublicKey { get; private set; }
    public PgpPrivateKey PrivateKey { get; private set; }
    public PgpSecretKey SecretKey { get; private set; }

    /// <summary>
    /// Initializes a new instance of the EncryptionKeys class.
    /// Two keys are required to encrypt and sign data. Your private key and the recipients public key.
    /// The data is encrypted with the recipients public key and signed with your private key.
    /// </summary>
    /// <param name="publicKeyPath">The key used to encrypt the data</param>
    /// <param name="privateKeyPath">The key used to sign the data.</param>
    /// <param name="passPhrase">The (your) password required to access the private key</param>
    /// <exception cref="ArgumentException">Public key not found. Private key not found. Missing password</exception>
    public PgpEncryptionKeys(string publicKeyPath, string privateKeyPath, string passPhrase)
    {
        if (!File.Exists(publicKeyPath))
        {
            throw new ArgumentException("Public key file not found.", "publicKeyPath");
        }
        if (!File.Exists(privateKeyPath))
        {
            throw new ArgumentException("Private key file not found.", "privateKeyPath");
        }
        if (String.IsNullOrEmpty(passPhrase))
        {
            throw new ArgumentException("passPhrase is null or empty.", "passPhrase");
        }

        PublicKey = readPublicKey(publicKeyPath);
        SecretKey = readSecretKey(privateKeyPath);
        PrivateKey = readPrivateKey(passPhrase);
    }

    #endregion

    #region Private Methods

    #region Secret Key

    private PgpSecretKey readSecretKey(string privateKeyPath)
    {
        using (Stream keyIn = File.OpenRead(privateKeyPath))
        {
            using (Stream inputStream = PgpUtilities.GetDecoderStream(keyIn))
            {

                PgpSecretKeyRingBundle secretKeyRingBundle = new PgpSecretKeyRingBundle(inputStream);
                PgpSecretKey foundKey = getFirstSecretKey(secretKeyRingBundle);

                if (foundKey != null)
                {
                    return foundKey;
                }
            }
        }
        throw new ArgumentException("Can't find signing key in key ring.");
    }

    /// <summary>
    /// Return the first key we can use to encrypt.
    /// Note: A file can contain multiple keys (stored in "key rings")
    /// </summary>
    private PgpSecretKey getFirstSecretKey(PgpSecretKeyRingBundle secretKeyRingBundle)
    {
        foreach (PgpSecretKeyRing kRing in secretKeyRingBundle.GetKeyRings())
        {
            // Note: You may need to use something other than the first key
            //  in your key ring. Keep that in mind. 
            // ex: .Where(k => !k.IsSigningKey)
            PgpSecretKey key = kRing.GetSecretKeys()
                .Cast<PgpSecretKey>()
                //.Where(k => k.IsSigningKey)
                .Where(k => !k.IsSigningKey)
                .FirstOrDefault();

            if (key != null)
            {
                return key;
            }
        }

        return null;
    }

    #endregion

    #region Public Key

    private PgpPublicKey readPublicKey(string publicKeyPath)
    {
        using (Stream keyIn = File.OpenRead(publicKeyPath))
        {
            using (Stream inputStream = PgpUtilities.GetDecoderStream(keyIn))
            {
                try
                {
                    PgpPublicKeyRingBundle publicKeyRingBundle = new PgpPublicKeyRingBundle(inputStream);
                    PgpPublicKey foundKey = getFirstPublicKey(publicKeyRingBundle);

                    if (foundKey != null)
                    {
                        return foundKey;
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException("There was a problem with the public key ring.");
                }
            }
        }
        throw new ArgumentException("No encryption key found in public key ring.");
    }

    private PgpPublicKey getFirstPublicKey(PgpPublicKeyRingBundle publicKeyRingBundle)
    {
        foreach (PgpPublicKeyRing kRing in publicKeyRingBundle.GetKeyRings())
        {
            PgpPublicKey key = kRing.GetPublicKeys()
                .Cast<PgpPublicKey>()
                .Where(k => k.IsEncryptionKey)
                .FirstOrDefault();

            if (key != null)
            {
                return key;
            }
        }

        return null;
    }

    #endregion

    #region Private Key

    private PgpPrivateKey readPrivateKey(string passPhrase)
    {
        PgpPrivateKey privateKey = SecretKey.ExtractPrivateKey(passPhrase.ToCharArray());

        if (privateKey != null)
        {
            return privateKey;
        }

        throw new ArgumentException("No private key found in secret key.");
    }

    #endregion

    #endregion
}