using AojReport.AojPrintEngine.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections;

namespace AojPrintEngineTest
{
    
    
    /// <summary>
    ///This is a test class for AojUnitConvertTest and is intended
    ///to contain all AojUnitConvertTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AojUnitConvertTest
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
        ///A test for SafeToString
        ///</summary>
        [TestMethod()]
        public void SafeToStringTest1()
        {
            object obj = null; // TODO: Initialize to an appropriate value
            string strDefault = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AojUnitConvert.SafeToString(obj, strDefault);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SafeToString
        ///</summary>
        [TestMethod()]
        public void SafeToStringTest()
        {
            Hashtable h = null; // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            string strDefault = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AojUnitConvert.SafeToString(h, obj, strDefault);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SafeToSingle
        ///</summary>
        [TestMethod()]
        public void SafeToSingleTest1()
        {
            Hashtable h = null; // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            float fDefualt = 0F; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = AojUnitConvert.SafeToSingle(h, obj, fDefualt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SafeToSingle
        ///</summary>
        [TestMethod()]
        public void SafeToSingleTest()
        {
            object obj = null; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = AojUnitConvert.SafeToSingle(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SafeToInt
        ///</summary>
        [TestMethod()]
        public void SafeToIntTest2()
        {
            object obj = null; // TODO: Initialize to an appropriate value
            int iDefault = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AojUnitConvert.SafeToInt(obj, iDefault);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SafeToInt
        ///</summary>
        [TestMethod()]
        public void SafeToIntTest1()
        {
            object obj = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AojUnitConvert.SafeToInt(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SafeToInt
        ///</summary>
        [TestMethod()]
        public void SafeToIntTest()
        {
            Hashtable h = null; // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            int iDefault = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AojUnitConvert.SafeToInt(h, obj, iDefault);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SafeRound
        ///</summary>
        [TestMethod()]
        public void SafeRoundTest()
        {
            object obj = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AojUnitConvert.SafeRound(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PointToMM
        ///</summary>
        [TestMethod()]
        public void PointToMMTest()
        {
            float point = 0F; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = AojUnitConvert.PointToMM(point);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PixelToMM
        ///</summary>
        [TestMethod()]
        public void PixelToMMTest()
        {
            int pixel = 0; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = AojUnitConvert.PixelToMM(pixel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MMToPoint
        ///</summary>
        [TestMethod()]
        public void MMToPointTest()
        {
            float mm = 0F; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AojUnitConvert.MMToPoint(mm);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MMToPixel
        ///</summary>
        [TestMethod()]
        public void MMToPixelTest()
        {
            float mm = 0F; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AojUnitConvert.MMToPixel(mm);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImageToBase64String
        ///</summary>
        [TestMethod()]
        public void ImageToBase64StringTest()
        {
            Image image = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AojUnitConvert.ImageToBase64String(image);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImageFromFile
        ///</summary>
        [TestMethod()]
        public void ImageFromFileTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Image expected = null; // TODO: Initialize to an appropriate value
            Image actual;
            actual = AojUnitConvert.ImageFromFile(path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ImageFromBase64String
        ///</summary>
        [TestMethod()]
        public void ImageFromBase64StringTest()
        {
            string value = string.Empty; // TODO: Initialize to an appropriate value
            Image expected = null; // TODO: Initialize to an appropriate value
            Image actual;
            actual = AojUnitConvert.ImageFromBase64String(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEnumType
        ///</summary>
        public void GetEnumTypeTestHelper<T, U>()
        {
            U u = default(U); // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            actual = AojUnitConvert.GetEnumType<T, U>(u);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetEnumTypeTest()
        {
            GetEnumTypeTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///A test for AojUnitConvert Constructor
        ///</summary>
        [TestMethod()]
        public void AojUnitConvertConstructorTest()
        {
            AojUnitConvert target = new AojUnitConvert();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
