namespace WindowsFormsApplication1
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bilgilerDataSet = new WindowsFormsApplication1.bilgilerDataSet();
            this.bilgilerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bilgilerTableAdapter = new WindowsFormsApplication1.bilgilerDataSetTableAdapters.bilgilerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bilgilerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(935, 586);
            this.reportViewer1.TabIndex = 0;
            // 
            // bilgilerDataSet
            // 
            this.bilgilerDataSet.DataSetName = "bilgilerDataSet";
            this.bilgilerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bilgilerBindingSource
            // 
            this.bilgilerBindingSource.DataMember = "bilgiler";
            this.bilgilerBindingSource.DataSource = this.bilgilerDataSet;
            // 
            // bilgilerTableAdapter
            // 
            this.bilgilerTableAdapter.ClearBeforeFill = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 586);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form5";
            this.Text = "RAPOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bilgilerBindingSource;
        private bilgilerDataSet bilgilerDataSet;
        private bilgilerDataSetTableAdapters.bilgilerTableAdapter bilgilerTableAdapter;
    }
}