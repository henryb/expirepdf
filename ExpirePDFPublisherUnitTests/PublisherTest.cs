using ExpirePDFPublisher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Drawing;

namespace ExpirePDFPublisherUnitTests
{
    
    
    /// <summary>
    ///This is a test class for PublisherTest and is intended
    ///to contain all PublisherTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PublisherTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FindSecretKey
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ExpirePDFPublisher.exe")]
        public void FindSecretKeyTest()
        {
            PgpSecretKeyRingBundle pgpSec = null; // TODO: Initialize to an appropriate value
            long keyId = 0; // TODO: Initialize to an appropriate value
            char[] pass = null; // TODO: Initialize to an appropriate value
            PgpPrivateKey expected = null; // TODO: Initialize to an appropriate value
            PgpPrivateKey actual;
            actual = Publisher_Accessor.FindSecretKey(pgpSec, keyId, pass);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Base64EncodeFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ExpirePDFPublisher.exe")]
        public void Base64EncodeFileTest()
        {
            Publisher_Accessor target = new Publisher_Accessor(); // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Base64EncodeFile(filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Base64EncodeImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ExpirePDFPublisher.exe")]
        public void Base64EncodeImageTest()
        {
            Publisher_Accessor target = new Publisher_Accessor(); // TODO: Initialize to an appropriate value
            Image theImage = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Base64EncodeImage(theImage);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ExpirePDFPublisher.exe")]
        public void BuildFileTest()
        {
            Publisher_Accessor target = new Publisher_Accessor(); // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            target.BuildFile(filename);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EncryptFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ExpirePDFPublisher.exe")]
        public void EncryptFileTest()
        {
            Stream outputStream = null; // TODO: Initialize to an appropriate value
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            PgpPublicKey encKey = null; // TODO: Initialize to an appropriate value
            bool armor = false; // TODO: Initialize to an appropriate value
            bool withIntegrityCheck = false; // TODO: Initialize to an appropriate value
            Publisher_Accessor.EncryptFile(outputStream, fileName, encKey, armor, withIntegrityCheck);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DecryptFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ExpirePDFPublisher.exe")]
        public void DecryptFileTest()
        {
            Stream inputStream = null; // TODO: Initialize to an appropriate value
            Stream keyIn = null; // TODO: Initialize to an appropriate value
            char[] passwd = null; // TODO: Initialize to an appropriate value
            string defaultFileName = string.Empty; // TODO: Initialize to an appropriate value
            Publisher_Accessor.DecryptFile(inputStream, keyIn, passwd, defaultFileName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReadPublicKey
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ExpirePDFPublisher.exe")]
        public void ReadPublicKeyTest()
        {
            Stream inputStream = null; // TODO: Initialize to an appropriate value
            PgpPublicKey expected = null; // TODO: Initialize to an appropriate value
            PgpPublicKey actual;
            actual = Publisher_Accessor.ReadPublicKey(inputStream);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EncryptIt
        ///</summary>
        [TestMethod()]
        public void EncryptItTest()
        {
            string[] args = null; // TODO: Initialize to an appropriate value
            Publisher.EncryptIt(args);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
