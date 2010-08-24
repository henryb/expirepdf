using SPL.Crypto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ExpirePDFPublisherUnitTests
{
    
    
    /// <summary>
    ///This is a test class for PgpEncryptTest and is intended
    ///to contain all PgpEncryptTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PgpEncryptTest
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
        ///A test for EncryptAndSign
        ///</summary>
        [TestMethod()]
        public void EncryptAndSignTest()
        {
            PgpEncryptionKeys encryptionKeys = null; // TODO: Initialize to an appropriate value
            PgpEncrypt target = new PgpEncrypt(encryptionKeys); // TODO: Initialize to an appropriate value
            Stream outputStream = null; // TODO: Initialize to an appropriate value
            FileInfo unencryptedFileInfo = null; // TODO: Initialize to an appropriate value
            target.EncryptAndSign(outputStream, unencryptedFileInfo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PgpEncrypt Constructor
        ///</summary>
        [TestMethod()]
        public void PgpEncryptConstructorTest()
        {
            PgpEncryptionKeys encryptionKeys = null; // TODO: Initialize to an appropriate value
            PgpEncrypt target = new PgpEncrypt(encryptionKeys);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
