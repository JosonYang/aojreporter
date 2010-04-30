using System;
using System.Collections.Generic;
using System.Text;
using AojReport.AojPrintEngine;
using System.Data;

namespace testConsole
{

    public class Example
    {
        public static void Main()
        {
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
                AojPrint aojprint = new AojPrint();
                AojPrintSettings settings = AojPrintSettings.CreateInstance();
                // settings.AojdPath = @"c:\Aojtest\as.aojd";
                string[] strpath = new string[]{
                  @"d:\Aojtest\Label.aojx"
                 //,@"c:\Aojtest\Label1.aojx"
                };
                aojprint.Parse(strpath);
                aojprint.PrintDataTable("G1", "paper1", dt, true);
                aojprint.Preview();
            }
        }
    }
