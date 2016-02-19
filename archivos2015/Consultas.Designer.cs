namespace archivos2015
{
    partial class Consultas
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
            this.groupTablas = new System.Windows.Forms.GroupBox();
            this.groupClaves = new System.Windows.Forms.GroupBox();
            this.groupParams = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textParams = new System.Windows.Forms.TextBox();
            this.comboTablas = new System.Windows.Forms.ComboBox();
            this.comboClaves = new System.Windows.Forms.ComboBox();
            this.dataGridData = new System.Windows.Forms.DataGridView();
            this.groupTablas.SuspendLayout();
            this.groupClaves.SuspendLayout();
            this.groupParams.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTablas
            // 
            this.groupTablas.Controls.Add(this.comboTablas);
            this.groupTablas.Location = new System.Drawing.Point(24, 14);
            this.groupTablas.Name = "groupTablas";
            this.groupTablas.Size = new System.Drawing.Size(182, 67);
            this.groupTablas.TabIndex = 0;
            this.groupTablas.TabStop = false;
            this.groupTablas.Text = "Tablas";
            // 
            // groupClaves
            // 
            this.groupClaves.Controls.Add(this.comboClaves);
            this.groupClaves.Location = new System.Drawing.Point(249, 14);
            this.groupClaves.Name = "groupClaves";
            this.groupClaves.Size = new System.Drawing.Size(198, 67);
            this.groupClaves.TabIndex = 1;
            this.groupClaves.TabStop = false;
            this.groupClaves.Text = "Claves";
            this.groupClaves.Visible = false;
            // 
            // groupParams
            // 
            this.groupParams.Controls.Add(this.textParams);
            this.groupParams.Location = new System.Drawing.Point(480, 14);
            this.groupParams.Name = "groupParams";
            this.groupParams.Size = new System.Drawing.Size(193, 67);
            this.groupParams.TabIndex = 1;
            this.groupParams.TabStop = false;
            this.groupParams.Text = "Parametros de busqueda";
            this.groupParams.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.groupParams);
            this.groupBox1.Controls.Add(this.groupClaves);
            this.groupBox1.Controls.Add(this.groupTablas);
            this.groupBox1.Location = new System.Drawing.Point(15, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 144);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonFind.Location = new System.Drawing.Point(249, 90);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(198, 43);
            this.buttonFind.TabIndex = 2;
            this.buttonFind.Text = "Buscar";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Visible = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // textParams
            // 
            this.textParams.Location = new System.Drawing.Point(23, 31);
            this.textParams.Name = "textParams";
            this.textParams.Size = new System.Drawing.Size(153, 20);
            this.textParams.TabIndex = 0;
            // 
            // comboTablas
            // 
            this.comboTablas.FormattingEnabled = true;
            this.comboTablas.Location = new System.Drawing.Point(29, 30);
            this.comboTablas.Name = "comboTablas";
            this.comboTablas.Size = new System.Drawing.Size(120, 21);
            this.comboTablas.TabIndex = 3;
            this.comboTablas.SelectedValueChanged += new System.EventHandler(this.comboTablas_SelectedValueChanged);
            // 
            // comboClaves
            // 
            this.comboClaves.FormattingEnabled = true;
            this.comboClaves.Location = new System.Drawing.Point(21, 30);
            this.comboClaves.Name = "comboClaves";
            this.comboClaves.Size = new System.Drawing.Size(120, 21);
            this.comboClaves.TabIndex = 4;
            this.comboClaves.SelectedValueChanged += new System.EventHandler(this.comboClaves_SelectedValueChanged);
            // 
            // dataGridData
            // 
            this.dataGridData.AllowUserToAddRows = false;
            this.dataGridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridData.Location = new System.Drawing.Point(15, 196);
            this.dataGridData.Name = "dataGridData";
            this.dataGridData.ReadOnly = true;
            this.dataGridData.Size = new System.Drawing.Size(694, 367);
            this.dataGridData.TabIndex = 3;
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(730, 585);
            this.Controls.Add(this.dataGridData);
            this.Controls.Add(this.groupBox1);
            this.Name = "Consultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.groupTablas.ResumeLayout(false);
            this.groupClaves.ResumeLayout(false);
            this.groupParams.ResumeLayout(false);
            this.groupParams.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTablas;
        private System.Windows.Forms.ComboBox comboTablas;
        private System.Windows.Forms.GroupBox groupClaves;
        private System.Windows.Forms.ComboBox comboClaves;
        private System.Windows.Forms.GroupBox groupParams;
        private System.Windows.Forms.TextBox textParams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.DataGridView dataGridData;
    }
}