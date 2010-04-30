using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Management;

namespace AojReport.AojPrintEngine
{
    public partial class PrintForm : Form
    {
        private PageSettings _settings = null;
        public PrintDialogResult Result = PrintDialogResult.None;
        public PrintForm(PageSettings e)
        {
            InitializeComponent();
            this.IsAccessible = false;
            InitPrintForm();
            _settings = e;
        }

        public void InitPrintForm()
        {
            //取得Printer集合
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Printer");
            ManagementObjectCollection moc = mos.Get();

            foreach (ManagementObject mo in moc)
            {
                //名字取得
                cmbPrinters.Items.Add(mo["Name"].ToString());
                //
                if ((((uint)mo["Attributes"]) & 4) == 4)
                {
                    //默认选项
                    cmbPrinters.SelectedIndex = cmbPrinters.Items.Count - 1;
                }
            }
            mos.Dispose();
        }

        private void rabPageNums_CheckedChanged(object sender, EventArgs e)
        {
            if (rabPageNums.Checked)
            {
                pnlPageNums.Enabled = true;
            }
            else
            {
                pnlPageNums.Enabled = false;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            InitPrinter();
            Result = PrintDialogResult.Set;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Result = PrintDialogResult.Cancel;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (InitPrinter())
            {
                Result = PrintDialogResult.Yes;
                this.Close();
            }
        }

        private bool InitPrinter()
        {
            if (_settings == null)
            {
                return false;
            }
            if (rabPageNums.Checked)
            {
                //多页打印
                _settings.PrinterSettings.PrintRange = PrintRange.SomePages;

                int from;
                int to;
                //起始页
                Int32.TryParse(txtPageStart.Text, out from);
                //终止页
                Int32.TryParse(txtPageEnd.Text, out to);

                if (to < from)
                {
                    return false;
                }

                _settings.PrinterSettings.FromPage = from;
                _settings.PrinterSettings.ToPage = to;
            }
            else
            {
                //打印所有
                _settings.PrinterSettings.PrintRange = PrintRange.AllPages;
            }
            //打印机名称
            _settings.PrinterSettings.PrinterName = cmbPrinters.Text;
            //打印份数
            _settings.PrinterSettings.Copies = (short)nubPageCounts.Value;
            //自动分页
            _settings.PrinterSettings.Collate = ChkAutoPageBreak.Checked;

            return true;
        }

    }
}
