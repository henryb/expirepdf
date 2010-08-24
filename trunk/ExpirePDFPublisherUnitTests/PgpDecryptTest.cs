using SPL.Crypto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ExpirePDFPublisherUnitTests
{
    
    
    /// <summary>
    ///This is a test class for PgpDecryptTest and is intended
    ///to contain all PgpDecryptTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PgpDecryptTest
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
        ///A test for DecryptAndVerify
        ///</summary>
        [TestMethod()]
        public void DecryptAndVerifyTest()
        {
            PgpEncryptionKeys encryptionKeys = new PgpEncryptionKeys("..\\..\\..\\Misc\\keys\\viewpub.txt", "..\\..\\..\\Misc\\keys\\viewpriv.txt",""); // TODO: Initialize to an appropriate value
            PgpDecrypt target = new PgpDecrypt(encryptionKeys); // TODO: Initialize to an appropriate value
            Stream inputStream = null; // TODO: Initialize to an appropriate value
            string outputFile = string.Empty; // TODO: Initialize to an appropriate value
            target.DecryptAndVerify(inputStream, outputFile);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PgpDecrypt Constructor
        ///</summary>
        [TestMethod()]
        public void PgpDecryptConstructorTest()
        {
            PgpEncryptionKeys encryptionKeys = null; // TODO: Initialize to an appropriate value
            PgpDecrypt target = new PgpDecrypt(encryptionKeys);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
