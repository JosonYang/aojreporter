using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AojReport.AojPrintEngine;
using AojReport.AojPrintEngine.AojPrintGraphicsParse;


namespace TestMainForm
{
    public partial class MainForm : Form
    {
        private string[] TemplatesPath = new string[] { };

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileAojdx.ShowDialog())
            {
                TemplatesPath = openFileAojdx.FileNames;
                foreach (string str in openFileAojdx.FileNames)
                {
                    lstFilePath.Items.Add(str);
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            AojPrint aojPrint = new AojPrint();
            aojPrint.Parse(TemplatesPath);

            aojPrint.Preview();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //int a = 7;
        //    //int b = 9;

        //    //textBox1.Text = (7 / 9).ToString();
        //    //textBox2.Text = (13 % 7).ToString();
        //    DataTable dt = new DataTable();

        //    DataColumn dcol = new DataColumn();
        //    dcol.ColumnName = "No";
        //    dt.Columns.Add(dcol);

        //    dcol = new DataColumn();
        //    dcol.ColumnName = "Jno";
        //    dt.Columns.Add(dcol);

        //    dcol = new DataColumn();
        //    dcol.ColumnName = "Name";
        //    dt.Columns.Add(dcol);

        //    dcol = new DataColumn();
        //    dcol.ColumnName = "Ukeymd";
        //    dt.Columns.Add(dcol);

        //    dcol = new DataColumn();
        //    dcol.ColumnName = "Kaijyo";
        //    dt.Columns.Add(dcol);

        //    dcol = new DataColumn();
        //    dcol.ColumnName = "Bikou";
        //    dt.Columns.Add(dcol);


        //    for (int n = 0; n < 16; n++)
        //    {
        //        DataRow drNew = dt.NewRow();
        //        drNew[0] = "No" + n.ToString();
        //        drNew[1] = "Jno" + n.ToString();
        //        drNew[2] = "Name" + n.ToString();
        //        drNew[3] = "Ukeymd" + n.ToString();
        //        drNew[4] = "Kaijyo" + n.ToString();
        //        drNew[5] = "Bikou" + n.ToString();
        //        dt.Rows.Add(drNew);
        //    }
        //    AojPrint aojprint = new AojPrint();
        //    AojPrintSettings settings = AojPrintSettings.CreateInstance();
        //    // settings.AojdPath = @"c:\Aojtest\as.aojd";
        //    string[] strpath = new string[]{
        //      @"c:\Aojtest\Label.aojx"
        //     //,@"c:\Aojtest\Label1.aojx"
        //    };
        //    aojprint.Parse(strpath);
        //    aojprint.PrintDataTable("G1", "paper1", dt, true);
        //    aojprint.Preview();
        //}
    }
}
