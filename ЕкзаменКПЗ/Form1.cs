using System;
using System.IO;
using System.Windows.Forms;

namespace ЕкзаменКПЗ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        interface IReport
        {
            void Accept(IReportVisitor visitor);
        }

        interface IReportVisitor
        {
            void Visit(FinancialReport report);
            void Visit(SalesReport report);
        }

        class FinancialReport : IReport
        {
            public string Data { get; set; }

            public FinancialReport(string data)
            {
                Data = data;
            }

            public void Accept(IReportVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        class SalesReport : IReport
        {
            public string Data { get; set; }

            public SalesReport(string data)
            {
                Data = data;
            }

            public void Accept(IReportVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        class TxtExportVisitor : IReportVisitor
        {
            private string filePath;

            public TxtExportVisitor(string path)
            {
                filePath = path;
                File.WriteAllText(filePath, "");
            }

            public void Visit(FinancialReport report)
            {
                File.AppendAllText(filePath, "Фінанси: " + report.Data + "\n");
            }

            public void Visit(SalesReport report)
            {
                File.AppendAllText(filePath, "Продажі: " + report.Data + "\n");
            }
        }

        class HtmlExportVisitor : IReportVisitor
        {
            private string filePath;

            public HtmlExportVisitor(string path)
            {
                filePath = path;
                File.WriteAllText(filePath, "<html><body>\n");
            }

            public void Visit(FinancialReport report)
            {
                File.AppendAllText(filePath,
                    $"<h2>Фінанси</h2><p>{report.Data}</p>\n");
            }

            public void Visit(SalesReport report)
            {
                File.AppendAllText(filePath,
                    $"<h2>Продажі</h2><p>{report.Data}</p>\n");
            }

            public void Close()
            {
                File.AppendAllText(filePath, "</body></html>");
            }
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFinance.Text) ||
                string.IsNullOrWhiteSpace(txtSales.Text))
            {
                MessageBox.Show("Заповніть обидва поля!");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "TXT (*.txt)|*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var reports = new IReport[]
                {
                    new FinancialReport(txtFinance.Text),
                    new SalesReport(txtSales.Text)
                };

                var visitor = new TxtExportVisitor(dialog.FileName);

                foreach (var r in reports)
                    r.Accept(visitor);

                MessageBox.Show("TXT створено!");
            }
        }

        private void btnHtml_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFinance.Text) ||
                string.IsNullOrWhiteSpace(txtSales.Text))
            {
                MessageBox.Show("Заповніть обидва поля!");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "HTML (*.html)|*.html";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var reports = new IReport[]
                {
                    new FinancialReport(txtFinance.Text),
                    new SalesReport(txtSales.Text)
                };

                var visitor = new HtmlExportVisitor(dialog.FileName);

                foreach (var r in reports)
                    r.Accept(visitor);

                visitor.Close();

                MessageBox.Show("HTML створено!");
            }
        }
    }
}