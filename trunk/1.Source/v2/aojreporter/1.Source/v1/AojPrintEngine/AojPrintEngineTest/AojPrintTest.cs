using AojReport.AojPrintEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing.Printing;
using System.Data;
using System.Drawing;

namespace AojPrintEngineTest
{
    
    
    /// <summary>
    ///This is a test class for AojPrintTest and is intended
    ///to contain all AojPrintTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AojPrintTest
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
        ///A test for TotalPage
        ///</summary>
        [TestMethod()]
        public void PrintTest()
        {
            AojPrint target = new AojPrint(); // TODO: Initialize to an appropriate value
            DataTable dt = new DataTable();

            DataColumn dcol = new DataColumn();
            dcol.ColumnName = "No";
            dt.Columns.Add(dcol);

            dcol = new DataColumn();
            dcol.ColumnName = "Jno";
            dt.Columns.Add(dcol);

            dcol = new DataColumn();
            dcol.ColumnName = "Name";
            dt.Columns.Add(dcol);

            dcol = new DataColumn();
            dcol.ColumnName = "Ukeymd";
            dt.Columns.Add(dcol);

            dcol = new DataColumn();
            dcol.ColumnName = "Kaijyo";
            dt.Columns.Add(dcol);

            dcol = new DataColumn();
            dcol.ColumnName = "Bikou";
            dt.Columns.Add(dcol);


            for (int n = 0; n < 13; n++)
            {
                DataRow drNew = dt.NewRow();
                drNew[0] = "No" + n.ToString();
                drNew[1] = "Jno" + n.ToString();
                drNew[2] = "Name" + n.ToString();
                drNew[3] = "Ukeymd" + n.ToString();
                drNew[4] = "Kaijyo" + n.ToString();
                drNew[5] = "Bikou" + n.ToString();
                dt.Rows.Add(drNew);
            }
            //AojPrint aojprint = new AojPrint();
            string[] strpath = new string[]{
                  @"d:\Aojtest\Label.aojx"
                };
            target.Parse(strpath);
            target.PrintDataTable("G1", "paper1", dt, true);
            target.Preview();
            Assert.AreEqual<int>(2, target.TotalPage);
        }
    }
}
