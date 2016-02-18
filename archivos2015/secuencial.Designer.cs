namespace archivos2015
{
    partial class secuencial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(secuencial));
            this.groupBoxTodo = new System.Windows.Forms.GroupBox();
            this.labelAvisos = new System.Windows.Forms.Label();
            this.groupBotones = new System.Windows.Forms.GroupBox();
            this.buttonDelD = new System.Windows.Forms.Button();
            this.buttonModD = new System.Windows.Forms.Button();
            this.buttonAddD = new System.Windows.Forms.Button();
            this.dataGridData = new System.Windows.Forms.DataGridView();
            this.groupBoxCombo1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBoxTodo.SuspendLayout();
            this.groupBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridData)).BeginInit();
            this.groupBoxCombo1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTodo
            // 
            this.groupBoxTodo.Controls.Add(this.groupBox1);
            this.groupBoxTodo.Controls.Add(this.labelAvisos);
            this.groupBoxTodo.Controls.Add(this.groupBotones);
            this.groupBoxTodo.Controls.Add(this.dataGridData);
            this.groupBoxTodo.Controls.Add(this.groupBoxCombo1);
            this.groupBoxTodo.Location = new System.Drawing.Point(52, 42);
            this.groupBoxTodo.Name = "groupBoxTodo";
            this.groupBoxTodo.Size = new System.Drawing.Size(900, 568);
            this.groupBoxTodo.TabIndex = 0;
            this.groupBoxTodo.TabStop = false;
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
            this.dataGridData.Location = new System.Drawing.Point(134, 200);
            this.dataGridData.Name = "dataGridData";
            this.dataGridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridData.Size = new System.Drawing.Size(662, 320);
            this.dataGridData.TabIndex = 1;
            this.dataGridData.Visible = false;
            this.dataGridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridData_CellDoubleClick);
            // 
            // groupBoxCombo1
            // 
            this.groupBoxCombo1.Controls.Add(this.comboBox1);
            this.groupBoxCombo1.Location = new System.Drawing.Point(247, 67);
            this.groupBoxCombo1.Name = "groupBoxCombo1";
            this.groupBoxCombo1.Size = new System.Drawing.Size(187, 62);
            this.groupBoxCombo1.TabIndex = 0;
            this.groupBoxCombo1.TabStop = false;
            this.groupBoxCombo1.Text = "Selecciona la tabla";
            this.groupBoxCombo1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
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
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Secuencial(.sec)|*.sec";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Location = new System.Drawing.Point(24, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecciona la base de datos";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(10, 28);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(161, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // secuencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 622);
            this.Controls.Add(this.groupBoxTodo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "secuencial";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secuencial";
            this.groupBoxTodo.ResumeLayout(false);
            this.groupBoxTodo.PerformLayout();
            this.groupBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridData)).EndInit();
            this.groupBoxCombo1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTodo;
        private System.Windows.Forms.GroupBox groupBoxCombo1;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}