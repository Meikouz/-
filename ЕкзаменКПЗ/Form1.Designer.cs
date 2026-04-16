namespace ЕкзаменКПЗ
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnTxt;
        private System.Windows.Forms.Button btnHtml;
        private System.Windows.Forms.TextBox txtFinance;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.Label lblFinance;
        private System.Windows.Forms.Label lblSales;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFinance = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.btnTxt = new System.Windows.Forms.Button();
            this.btnHtml = new System.Windows.Forms.Button();
            this.lblFinance = new System.Windows.Forms.Label();
            this.lblSales = new System.Windows.Forms.Label();

            // Label Finance
            this.lblFinance.Text = "Фінанси:";
            this.lblFinance.Location = new System.Drawing.Point(50, 20);

            // txtFinance
            this.txtFinance.Location = new System.Drawing.Point(50, 40);
            this.txtFinance.Size = new System.Drawing.Size(300, 22);

            // Label Sales
            this.lblSales.Text = "Продажі:";
            this.lblSales.Location = new System.Drawing.Point(50, 70);

            // txtSales
            this.txtSales.Location = new System.Drawing.Point(50, 90);
            this.txtSales.Size = new System.Drawing.Size(300, 22);

            // btnTxt
            this.btnTxt.Location = new System.Drawing.Point(50, 130);
            this.btnTxt.Size = new System.Drawing.Size(130, 30);
            this.btnTxt.Text = "TXT";
            this.btnTxt.Click += new System.EventHandler(this.btnTxt_Click);

            // btnHtml
            this.btnHtml.Location = new System.Drawing.Point(220, 130);
            this.btnHtml.Size = new System.Drawing.Size(130, 30);
            this.btnHtml.Text = "HTML";
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblFinance);
            this.Controls.Add(this.txtFinance);
            this.Controls.Add(this.lblSales);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.btnTxt);
            this.Controls.Add(this.btnHtml);
            this.Text = "Visitor Pattern - Reports";
        }
    }
}