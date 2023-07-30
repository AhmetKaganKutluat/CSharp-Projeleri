namespace _1.UYGULAMA
{
    partial class Form3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bilgilerDataSet1 = new _1.UYGULAMA.bilgilerDataSet1();
            this.tablo1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablo1TableAdapter = new _1.UYGULAMA.bilgilerDataSet1TableAdapters.Tablo1TableAdapter();
            this.aDIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sOYADIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEMLEKETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mESLEKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gELİRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gİDERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aDIDataGridViewTextBoxColumn,
            this.sOYADIDataGridViewTextBoxColumn,
            this.mEMLEKETDataGridViewTextBoxColumn,
            this.mESLEKDataGridViewTextBoxColumn,
            this.gELİRDataGridViewTextBoxColumn,
            this.gİDERDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tablo1BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(866, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(30, 275);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(30, 312);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 20);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(281, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(358, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "İSİM VE SOYİSİME GÖRE ARAMA YAP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bilgilerDataSet1
            // 
            this.bilgilerDataSet1.DataSetName = "bilgilerDataSet1";
            this.bilgilerDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tablo1BindingSource
            // 
            this.tablo1BindingSource.DataMember = "Tablo1";
            this.tablo1BindingSource.DataSource = this.bilgilerDataSet1;
            // 
            // tablo1TableAdapter
            // 
            this.tablo1TableAdapter.ClearBeforeFill = true;
            // 
            // aDIDataGridViewTextBoxColumn
            // 
            this.aDIDataGridViewTextBoxColumn.DataPropertyName = "ADI";
            this.aDIDataGridViewTextBoxColumn.HeaderText = "ADI";
            this.aDIDataGridViewTextBoxColumn.Name = "aDIDataGridViewTextBoxColumn";
            this.aDIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sOYADIDataGridViewTextBoxColumn
            // 
            this.sOYADIDataGridViewTextBoxColumn.DataPropertyName = "SOYADI";
            this.sOYADIDataGridViewTextBoxColumn.HeaderText = "SOYADI";
            this.sOYADIDataGridViewTextBoxColumn.Name = "sOYADIDataGridViewTextBoxColumn";
            this.sOYADIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mEMLEKETDataGridViewTextBoxColumn
            // 
            this.mEMLEKETDataGridViewTextBoxColumn.DataPropertyName = "MEMLEKET";
            this.mEMLEKETDataGridViewTextBoxColumn.HeaderText = "MEMLEKET";
            this.mEMLEKETDataGridViewTextBoxColumn.Name = "mEMLEKETDataGridViewTextBoxColumn";
            this.mEMLEKETDataGridViewTextBoxColumn.ReadOnly = true;
            this.mEMLEKETDataGridViewTextBoxColumn.Width = 120;
            // 
            // mESLEKDataGridViewTextBoxColumn
            // 
            this.mESLEKDataGridViewTextBoxColumn.DataPropertyName = "MESLEK";
            this.mESLEKDataGridViewTextBoxColumn.HeaderText = "MESLEK";
            this.mESLEKDataGridViewTextBoxColumn.Name = "mESLEKDataGridViewTextBoxColumn";
            this.mESLEKDataGridViewTextBoxColumn.ReadOnly = true;
            this.mESLEKDataGridViewTextBoxColumn.Width = 120;
            // 
            // gELİRDataGridViewTextBoxColumn
            // 
            this.gELİRDataGridViewTextBoxColumn.DataPropertyName = "GELİR";
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.gELİRDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.gELİRDataGridViewTextBoxColumn.HeaderText = "GELİR";
            this.gELİRDataGridViewTextBoxColumn.Name = "gELİRDataGridViewTextBoxColumn";
            this.gELİRDataGridViewTextBoxColumn.ReadOnly = true;
            this.gELİRDataGridViewTextBoxColumn.Width = 120;
            // 
            // gİDERDataGridViewTextBoxColumn
            // 
            this.gİDERDataGridViewTextBoxColumn.DataPropertyName = "GİDER";
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.gİDERDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.gİDERDataGridViewTextBoxColumn.HeaderText = "GİDER";
            this.gİDERDataGridViewTextBoxColumn.Name = "gİDERDataGridViewTextBoxColumn";
            this.gİDERDataGridViewTextBoxColumn.ReadOnly = true;
            this.gİDERDataGridViewTextBoxColumn.Width = 120;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(866, 384);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private bilgilerDataSet1 bilgilerDataSet1;
        private System.Windows.Forms.BindingSource tablo1BindingSource;
        private bilgilerDataSet1TableAdapters.Tablo1TableAdapter tablo1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOYADIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEMLEKETDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mESLEKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gELİRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gİDERDataGridViewTextBoxColumn;
    }
}