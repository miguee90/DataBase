namespace archivos2015
{
    partial class Indexada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Indexada));
            this.groupBoxTodo = new System.Windows.Forms.GroupBox();
            this.labelAviso = new System.Windows.Forms.Label();
            this.groupTabInd = new System.Windows.Forms.GroupBox();
            this.dataGridIndices = new System.Windows.Forms.DataGridView();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNexInd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPtrDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelAvisos = new System.Windows.Forms.Label();
            this.groupBotones = new System.Windows.Forms.GroupBox();
            this.buttonDelD = new System.Windows.Forms.Button();
            this.buttonModD = new System.Windows.Forms.Button();
            this.buttonAddD = new System.Windows.Forms.Button();
            this.dataGridData = new System.Windows.Forms.DataGridView();
            this.groupBoxCombo = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxTodo.SuspendLayout();
            this.groupTabInd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIndices)).BeginInit();
            this.groupBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridData)).BeginInit();
            this.groupBoxCombo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTodo
            // 
            this.groupBoxTodo.Controls.Add(this.labelAviso);
            this.groupBoxTodo.Controls.Add(this.groupTabInd);
            this.groupBoxTodo.Controls.Add(this.labelAvisos);
            this.groupBoxTodo.Controls.Add(this.groupBotones);
            this.groupBoxTodo.Controls.Add(this.dataGridData);
            this.groupBoxTodo.Controls.Add(this.groupBoxCombo);
            this.groupBoxTodo.Location = new System.Drawing.Point(52, 42);
            this.groupBoxTodo.Name = "groupBoxTodo";
            this.groupBoxTodo.Size = new System.Drawing.Size(900, 568);
            this.groupBoxTodo.TabIndex = 0;
            this.groupBoxTodo.TabStop = false;
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Location = new System.Drawing.Point(404, 156);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(0, 13);
            this.labelAviso.TabIndex = 6;
            // 
            // groupTabInd
            // 
            this.groupTabInd.Controls.Add(this.dataGridIndices);
            this.groupTabInd.Location = new System.Drawing.Point(29, 165);
            this.groupTabInd.Name = "groupTabInd";
            this.groupTabInd.Size = new System.Drawing.Size(331, 344);
            this.groupTabInd.TabIndex = 5;
            this.groupTabInd.TabStop = false;
            this.groupTabInd.Text = "Tabla de indices";
            this.groupTabInd.Visible = false;
            // 
            // dataGridIndices
            // 
            this.dataGridIndices.AllowUserToAddRows = false;
            this.dataGridIndices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridIndices.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridIndices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIndices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.ColumnDir,
            this.ColumnNexInd,
            this.ColumnPtrDat});
            this.dataGridIndices.Location = new System.Drawing.Point(23, 24);
            this.dataGridIndices.Name = "dataGridIndices";
            this.dataGridIndices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIndices.Size = new System.Drawing.Size(286, 298);
            this.dataGridIndices.TabIndex = 2;
            this.dataGridIndices.Visible = false;
            this.dataGridIndices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridIndices_CellClick);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.HeaderText = "Indice";
            this.ColumnIndex.Name = "ColumnIndex";
            // 
            // ColumnDir
            // 
            this.ColumnDir.HeaderText = "Direccion";
            this.ColumnDir.Name = "ColumnDir";
            // 
            // ColumnNexInd
            // 
            this.ColumnNexInd.HeaderText = "Siguiente Indice";
            this.ColumnNexInd.Name = "ColumnNexInd";
            // 
            // ColumnPtrDat
            // 
            this.ColumnPtrDat.HeaderText = "Apuntador Datos";
            this.ColumnPtrDat.Name = "ColumnPtrDat";
            // 
            // labelAvisos
            // 
            this.labelAvisos.AutoSize = true;
            this.labelAvisos.Location = new System.Drawing.Point(157, 165);
            this.labelAvisos.Name = "labelAvisos";
            this.labelAvisos.Size = new System.Drawing.Size(0, 13);
            this.labelAvisos.TabIndex = 3;
            // 
            // groupBotones
            // 
            this.groupBotones.Controls.Add(this.buttonDelD);
            this.groupBotones.Controls.Add(this.buttonModD);
            this.groupBotones.Controls.Add(this.buttonAddD);
            this.groupBotones.Location = new System.Drawing.Point(476, 35);
            this.groupBotones.Name = "groupBotones";
            this.groupBotones.Size = new System.Drawing.Size(377, 104);
            this.groupBotones.TabIndex = 2;
            this.groupBotones.TabStop = false;
            this.groupBotones.Visible = false;
            // 
            // buttonDelD
            // 
            this.buttonDelD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDelD.BackgroundImage = global::archivos2015.Properties.Resources.del;
            this.buttonDelD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelD.Location = new System.Drawing.Point(282, 19);
            this.buttonDelD.Name = "buttonDelD";
            this.buttonDelD.Size = new System.Drawing.Size(75, 75);
            this.buttonDelD.TabIndex = 3;
            this.buttonDelD.UseVisualStyleBackColor = false;
            this.buttonDelD.Click += new System.EventHandler(this.buttonDelD_Click);
            // 
            // buttonModD
            // 
            this.buttonModD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonModD.BackgroundImage = global::archivos2015.Properties.Resources.minus;
            this.buttonModD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModD.Location = new System.Drawing.Point(155, 19);
            this.buttonModD.Name = "buttonModD";
            this.buttonModD.Size = new System.Drawing.Size(75, 75);
            this.buttonModD.TabIndex = 2;
            this.buttonModD.UseVisualStyleBackColor = false;
            this.buttonModD.Click += new System.EventHandler(this.buttonModD_Click);
            // 
            // buttonAddD
            // 
            this.buttonAddD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAddD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddD.BackgroundImage")));
            this.buttonAddD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonAddD.Location = new System.Drawing.Point(18, 19);
            this.buttonAddD.Name = "buttonAddD";
            this.buttonAddD.Size = new System.Drawing.Size(75, 75);
            this.buttonAddD.TabIndex = 1;
            this.buttonAddD.UseVisualStyleBackColor = false;
            this.buttonAddD.Click += new System.EventHandler(this.buttonAddD_Click);
            // 
            // dataGridData
            // 
            this.dataGridData.AllowUserToAddRows = false;
            this.dataGridData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridData.Location = new System.Drawing.Point(391, 189);
            this.dataGridData.Name = "dataGridData";
            this.dataGridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridData.Size = new System.Drawing.Size(503, 320);
            this.dataGridData.TabIndex = 1;
            this.dataGridData.Visible = false;
            this.dataGridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridData_CellDoubleClick);
            // 
            // groupBoxCombo
            // 
            this.groupBoxCombo.Controls.Add(this.comboBox1);
            this.groupBoxCombo.Location = new System.Drawing.Point(103, 35);
            this.groupBoxCombo.Name = "groupBoxCombo";
            this.groupBoxCombo.Size = new System.Drawing.Size(257, 82);
            this.groupBoxCombo.TabIndex = 0;
            this.groupBoxCombo.TabStop = false;
            this.groupBoxCombo.Text = "Selecciona la entidad";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(46, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Secuencial(.sec)|*.sec";
            // 
            // Indexada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 622);
            this.Controls.Add(this.groupBoxTodo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Indexada";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indexada";
            this.groupBoxTodo.ResumeLayout(false);
            this.groupBoxTodo.PerformLayout();
            this.groupTabInd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIndices)).EndInit();
            this.groupBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridData)).EndInit();
            this.groupBoxCombo.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTodo;
        private System.Windows.Forms.GroupBox groupBoxCombo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBotones;
        private System.Windows.Forms.DataGridView dataGridData;
        private System.Windows.Forms.Button buttonAddD;
        private System.Windows.Forms.Button buttonModD;
        private System.Windows.Forms.Button buttonDelD;
        private System.Windows.Forms.Label labelAvisos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupTabInd;
        private System.Windows.Forms.DataGridView dataGridIndices;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNexInd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPtrDat;
        private System.Windows.Forms.Label labelAviso;
    }
}