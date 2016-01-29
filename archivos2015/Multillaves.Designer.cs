namespace archivos2015
{
    partial class Multillaves
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Multillaves));
            this.groupBoxTodo = new System.Windows.Forms.GroupBox();
            this.groupComAtr = new System.Windows.Forms.GroupBox();
            this.comboAtris = new System.Windows.Forms.ComboBox();
            this.labelAvisos = new System.Windows.Forms.Label();
            this.groupBotones = new System.Windows.Forms.GroupBox();
            this.buttonDelD = new System.Windows.Forms.Button();
            this.buttonModD = new System.Windows.Forms.Button();
            this.buttonAddD = new System.Windows.Forms.Button();
            this.dataGridData = new System.Windows.Forms.DataGridView();
            this.groupBoxCombo = new System.Windows.Forms.GroupBox();
            this.comboEnt = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxTodo.SuspendLayout();
            this.groupComAtr.SuspendLayout();
            this.groupBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridData)).BeginInit();
            this.groupBoxCombo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTodo
            // 
            this.groupBoxTodo.Controls.Add(this.groupComAtr);
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
            // groupComAtr
            // 
            this.groupComAtr.Controls.Add(this.comboAtris);
            this.groupComAtr.Location = new System.Drawing.Point(263, 55);
            this.groupComAtr.Name = "groupComAtr";
            this.groupComAtr.Size = new System.Drawing.Size(216, 68);
            this.groupComAtr.TabIndex = 1;
            this.groupComAtr.TabStop = false;
            this.groupComAtr.Text = "Selecciona Atributo con el cual ordenar";
            this.groupComAtr.Visible = false;
            // 
            // comboAtris
            // 
            this.comboAtris.FormattingEnabled = true;
            this.comboAtris.Location = new System.Drawing.Point(29, 28);
            this.comboAtris.Name = "comboAtris";
            this.comboAtris.Size = new System.Drawing.Size(161, 21);
            this.comboAtris.TabIndex = 0;
            this.comboAtris.SelectedValueChanged += new System.EventHandler(this.comboAtris_SelectedValueChanged);
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
            this.groupBotones.Location = new System.Drawing.Point(507, 36);
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
            // groupBoxCombo
            // 
            this.groupBoxCombo.Controls.Add(this.comboEnt);
            this.groupBoxCombo.Location = new System.Drawing.Point(31, 54);
            this.groupBoxCombo.Name = "groupBoxCombo";
            this.groupBoxCombo.Size = new System.Drawing.Size(196, 68);
            this.groupBoxCombo.TabIndex = 0;
            this.groupBoxCombo.TabStop = false;
            this.groupBoxCombo.Text = "Selecciona la entidad";
            // 
            // comboEnt
            // 
            this.comboEnt.FormattingEnabled = true;
            this.comboEnt.Location = new System.Drawing.Point(20, 29);
            this.comboEnt.Name = "comboEnt";
            this.comboEnt.Size = new System.Drawing.Size(161, 21);
            this.comboEnt.TabIndex = 0;
            this.comboEnt.SelectedValueChanged += new System.EventHandler(this.comboEnt_SelectedValueChanged);
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
            // Multillaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 622);
            this.Controls.Add(this.groupBoxTodo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Multillaves";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multillaves";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Multillaves_FormClosing);
            this.groupBoxTodo.ResumeLayout(false);
            this.groupBoxTodo.PerformLayout();
            this.groupComAtr.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboEnt;
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
        private System.Windows.Forms.GroupBox groupComAtr;
        private System.Windows.Forms.ComboBox comboAtris;
    }
}