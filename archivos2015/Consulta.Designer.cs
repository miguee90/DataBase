namespace archivos2015
{
    partial class Consulta
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
            this.groupCons = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAltas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBajas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSQL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.comboBD = new System.Windows.Forms.ComboBox();
            this.labelI = new System.Windows.Forms.Label();
            this.groupCons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCons
            // 
            this.groupCons.Controls.Add(this.labelI);
            this.groupCons.Controls.Add(this.label1);
            this.groupCons.Controls.Add(this.dataGridView1);
            this.groupCons.Controls.Add(this.treeView1);
            this.groupCons.Controls.Add(this.comboBD);
            this.groupCons.Location = new System.Drawing.Point(38, 12);
            this.groupCons.Name = "groupCons";
            this.groupCons.Size = new System.Drawing.Size(775, 433);
            this.groupCons.TabIndex = 0;
            this.groupCons.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Usuarios con permiso en la base de datos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColVI,
            this.ColVF,
            this.ColAdm,
            this.ColAltas,
            this.ColBajas,
            this.ColMod,
            this.ColSQL,
            this.ColCons});
            this.dataGridView1.Location = new System.Drawing.Point(355, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(420, 316);
            this.dataGridView1.TabIndex = 11;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Nombre";
            this.ColName.Name = "ColName";
            // 
            // ColVI
            // 
            this.ColVI.HeaderText = "Vigencia inicial";
            this.ColVI.Name = "ColVI";
            // 
            // ColVF
            // 
            this.ColVF.HeaderText = "Vigencia final";
            this.ColVF.Name = "ColVF";
            // 
            // ColAdm
            // 
            this.ColAdm.HeaderText = "Administrador";
            this.ColAdm.Name = "ColAdm";
            // 
            // ColAltas
            // 
            this.ColAltas.HeaderText = "Altas";
            this.ColAltas.Name = "ColAltas";
            // 
            // ColBajas
            // 
            this.ColBajas.HeaderText = "Bajas";
            this.ColBajas.Name = "ColBajas";
            // 
            // ColMod
            // 
            this.ColMod.HeaderText = "Modificaciones";
            this.ColMod.Name = "ColMod";
            // 
            // ColSQL
            // 
            this.ColSQL.HeaderText = "SQL";
            this.ColSQL.Name = "ColSQL";
            // 
            // ColCons
            // 
            this.ColCons.HeaderText = "Consultas";
            this.ColCons.Name = "ColCons";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(35, 105);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(285, 292);
            this.treeView1.TabIndex = 1;
            // 
            // comboBD
            // 
            this.comboBD.FormattingEnabled = true;
            this.comboBD.Location = new System.Drawing.Point(35, 23);
            this.comboBD.Name = "comboBD";
            this.comboBD.Size = new System.Drawing.Size(131, 21);
            this.comboBD.TabIndex = 0;
            this.comboBD.Text = "Base de datos";
            this.comboBD.SelectedIndexChanged += new System.EventHandler(this.comboBD_SelectedIndexChanged);
            // 
            // labelI
            // 
            this.labelI.AutoSize = true;
            this.labelI.Location = new System.Drawing.Point(33, 71);
            this.labelI.Name = "labelI";
            this.labelI.Size = new System.Drawing.Size(200, 13);
            this.labelI.TabIndex = 13;
            this.labelI.Text = "Claves: 1- Pimaria 2- Foranea 3- Ninguna";
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(846, 457);
            this.Controls.Add(this.groupCons);
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.Consulta_Load);
            this.groupCons.ResumeLayout(false);
            this.groupCons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCons;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAltas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCons;
        private System.Windows.Forms.Label labelI;
    }
}