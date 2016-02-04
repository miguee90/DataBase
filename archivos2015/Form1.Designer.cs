namespace archivos2015
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupEntidad = new System.Windows.Forms.GroupBox();
            this.labelAvisos = new System.Windows.Forms.Label();
            this.dataGridEntidad = new System.Windows.Forms.DataGridView();
            this.groupName = new System.Windows.Forms.GroupBox();
            this.textEnt = new System.Windows.Forms.TextBox();
            this.groupBotones = new System.Windows.Forms.GroupBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonMod = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupAtriubuto = new System.Windows.Forms.GroupBox();
            this.labelAvisosA = new System.Windows.Forms.Label();
            this.groupAtri = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboEntidad = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelTam = new System.Windows.Forms.Label();
            this.radioNinguna = new System.Windows.Forms.RadioButton();
            this.radioExterna = new System.Windows.Forms.RadioButton();
            this.radioPrimaria = new System.Windows.Forms.RadioButton();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.textNomA = new System.Windows.Forms.TextBox();
            this.labelNombreA = new System.Windows.Forms.Label();
            this.dataGridAtr = new System.Windows.Forms.DataGridView();
            this.groupBotonA = new System.Windows.Forms.GroupBox();
            this.buttonDelA = new System.Windows.Forms.Button();
            this.buttonModA = new System.Windows.Forms.Button();
            this.buttonAddA = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNameA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBD = new System.Windows.Forms.ComboBox();
            this.groupEntidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidad)).BeginInit();
            this.groupName.SuspendLayout();
            this.groupBotones.SuspendLayout();
            this.groupAtriubuto.SuspendLayout();
            this.groupAtri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtr)).BeginInit();
            this.groupBotonA.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupEntidad
            // 
            this.groupEntidad.Controls.Add(this.labelAvisos);
            this.groupEntidad.Controls.Add(this.dataGridEntidad);
            this.groupEntidad.Controls.Add(this.groupName);
            this.groupEntidad.Controls.Add(this.groupBotones);
            this.groupEntidad.Location = new System.Drawing.Point(22, 34);
            this.groupEntidad.Name = "groupEntidad";
            this.groupEntidad.Size = new System.Drawing.Size(495, 571);
            this.groupEntidad.TabIndex = 0;
            this.groupEntidad.TabStop = false;
            this.groupEntidad.Text = "Entidades";
            this.groupEntidad.Visible = false;
            // 
            // labelAvisos
            // 
            this.labelAvisos.AutoSize = true;
            this.labelAvisos.Location = new System.Drawing.Point(64, 233);
            this.labelAvisos.Name = "labelAvisos";
            this.labelAvisos.Size = new System.Drawing.Size(0, 13);
            this.labelAvisos.TabIndex = 3;
            this.labelAvisos.Visible = false;
            // 
            // dataGridEntidad
            // 
            this.dataGridEntidad.AllowUserToAddRows = false;
            this.dataGridEntidad.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridEntidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridEntidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEntidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName});
            this.dataGridEntidad.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridEntidad.Location = new System.Drawing.Point(6, 285);
            this.dataGridEntidad.Name = "dataGridEntidad";
            this.dataGridEntidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEntidad.Size = new System.Drawing.Size(483, 280);
            this.dataGridEntidad.TabIndex = 2;
            this.dataGridEntidad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEntidad_CellClick);
            this.dataGridEntidad.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEntidad_CellDoubleClick);
            // 
            // groupName
            // 
            this.groupName.Controls.Add(this.textEnt);
            this.groupName.Location = new System.Drawing.Point(46, 134);
            this.groupName.Name = "groupName";
            this.groupName.Size = new System.Drawing.Size(390, 66);
            this.groupName.TabIndex = 1;
            this.groupName.TabStop = false;
            this.groupName.Text = "Nombre de la nueva entidad";
            // 
            // textEnt
            // 
            this.textEnt.Location = new System.Drawing.Point(6, 29);
            this.textEnt.Name = "textEnt";
            this.textEnt.Size = new System.Drawing.Size(367, 20);
            this.textEnt.TabIndex = 0;
            this.textEnt.Enter += new System.EventHandler(this.textEnt_Enter);
            this.textEnt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEnt_KeyDown);
            // 
            // groupBotones
            // 
            this.groupBotones.Controls.Add(this.buttonDel);
            this.groupBotones.Controls.Add(this.buttonMod);
            this.groupBotones.Controls.Add(this.buttonAdd);
            this.groupBotones.Location = new System.Drawing.Point(40, 19);
            this.groupBotones.Name = "groupBotones";
            this.groupBotones.Size = new System.Drawing.Size(396, 100);
            this.groupBotones.TabIndex = 0;
            this.groupBotones.TabStop = false;
            // 
            // buttonDel
            // 
            this.buttonDel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDel.BackgroundImage = global::archivos2015.Properties.Resources.del;
            this.buttonDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDel.Location = new System.Drawing.Point(304, 19);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 75);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.UseVisualStyleBackColor = false;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonMod
            // 
            this.buttonMod.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMod.BackgroundImage = global::archivos2015.Properties.Resources.minus;
            this.buttonMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMod.Location = new System.Drawing.Point(153, 19);
            this.buttonMod.Name = "buttonMod";
            this.buttonMod.Size = new System.Drawing.Size(75, 75);
            this.buttonMod.TabIndex = 1;
            this.buttonMod.UseVisualStyleBackColor = false;
            this.buttonMod.Click += new System.EventHandler(this.buttonMod_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAdd.BackgroundImage")));
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(6, 19);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 75);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupAtriubuto
            // 
            this.groupAtriubuto.Controls.Add(this.labelAvisosA);
            this.groupAtriubuto.Controls.Add(this.groupAtri);
            this.groupAtriubuto.Controls.Add(this.dataGridAtr);
            this.groupAtriubuto.Controls.Add(this.groupBotonA);
            this.groupAtriubuto.Location = new System.Drawing.Point(523, 34);
            this.groupAtriubuto.Name = "groupAtriubuto";
            this.groupAtriubuto.Size = new System.Drawing.Size(486, 571);
            this.groupAtriubuto.TabIndex = 1;
            this.groupAtriubuto.TabStop = false;
            this.groupAtriubuto.Text = "Atributos";
            this.groupAtriubuto.Visible = false;
            // 
            // labelAvisosA
            // 
            this.labelAvisosA.AutoSize = true;
            this.labelAvisosA.Location = new System.Drawing.Point(38, 267);
            this.labelAvisosA.Name = "labelAvisosA";
            this.labelAvisosA.Size = new System.Drawing.Size(0, 13);
            this.labelAvisosA.TabIndex = 5;
            // 
            // groupAtri
            // 
            this.groupAtri.Controls.Add(this.buttonSave);
            this.groupAtri.Controls.Add(this.comboEntidad);
            this.groupAtri.Controls.Add(this.numericUpDown1);
            this.groupAtri.Controls.Add(this.labelTam);
            this.groupAtri.Controls.Add(this.radioNinguna);
            this.groupAtri.Controls.Add(this.radioExterna);
            this.groupAtri.Controls.Add(this.radioPrimaria);
            this.groupAtri.Controls.Add(this.comboTipo);
            this.groupAtri.Controls.Add(this.labelTipo);
            this.groupAtri.Controls.Add(this.textNomA);
            this.groupAtri.Controls.Add(this.labelNombreA);
            this.groupAtri.Location = new System.Drawing.Point(25, 125);
            this.groupAtri.Name = "groupAtri";
            this.groupAtri.Size = new System.Drawing.Size(444, 137);
            this.groupAtri.TabIndex = 4;
            this.groupAtri.TabStop = false;
            this.groupAtri.Text = "Agregar nuevo atributo";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonSave.Location = new System.Drawing.Point(164, 107);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 29);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboEntidad
            // 
            this.comboEntidad.FormattingEnabled = true;
            this.comboEntidad.Location = new System.Drawing.Point(332, 89);
            this.comboEntidad.Name = "comboEntidad";
            this.comboEntidad.Size = new System.Drawing.Size(106, 21);
            this.comboEntidad.TabIndex = 9;
            this.comboEntidad.Visible = false;
            this.comboEntidad.SelectedValueChanged += new System.EventHandler(this.comboEntidad_SelectedValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(72, 98);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Visible = false;
            // 
            // labelTam
            // 
            this.labelTam.AutoSize = true;
            this.labelTam.Location = new System.Drawing.Point(6, 100);
            this.labelTam.Name = "labelTam";
            this.labelTam.Size = new System.Drawing.Size(46, 13);
            this.labelTam.TabIndex = 7;
            this.labelTam.Text = "Tamaño";
            this.labelTam.Visible = false;
            // 
            // radioNinguna
            // 
            this.radioNinguna.AutoSize = true;
            this.radioNinguna.Location = new System.Drawing.Point(353, 66);
            this.radioNinguna.Name = "radioNinguna";
            this.radioNinguna.Size = new System.Drawing.Size(65, 17);
            this.radioNinguna.TabIndex = 6;
            this.radioNinguna.TabStop = true;
            this.radioNinguna.Text = "Ninguna";
            this.radioNinguna.UseVisualStyleBackColor = true;
            this.radioNinguna.CheckedChanged += new System.EventHandler(this.radioNinguna_CheckedChanged);
            // 
            // radioExterna
            // 
            this.radioExterna.AutoSize = true;
            this.radioExterna.Location = new System.Drawing.Point(353, 47);
            this.radioExterna.Name = "radioExterna";
            this.radioExterna.Size = new System.Drawing.Size(61, 17);
            this.radioExterna.TabIndex = 5;
            this.radioExterna.TabStop = true;
            this.radioExterna.Text = "Externa";
            this.radioExterna.UseVisualStyleBackColor = true;
            this.radioExterna.CheckedChanged += new System.EventHandler(this.radioExterna_CheckedChanged);
            // 
            // radioPrimaria
            // 
            this.radioPrimaria.AutoSize = true;
            this.radioPrimaria.Location = new System.Drawing.Point(353, 25);
            this.radioPrimaria.Name = "radioPrimaria";
            this.radioPrimaria.Size = new System.Drawing.Size(62, 17);
            this.radioPrimaria.TabIndex = 4;
            this.radioPrimaria.TabStop = true;
            this.radioPrimaria.Text = "Primaria";
            this.radioPrimaria.UseVisualStyleBackColor = true;
            this.radioPrimaria.CheckedChanged += new System.EventHandler(this.radioPrimaria_CheckedChanged);
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            "int",
            "float",
            "char",
            "string"});
            this.comboTipo.Location = new System.Drawing.Point(72, 63);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(121, 21);
            this.comboTipo.TabIndex = 3;
            this.comboTipo.SelectedValueChanged += new System.EventHandler(this.comboTipo_SelectedValueChanged);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(6, 66);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(28, 13);
            this.labelTipo.TabIndex = 2;
            this.labelTipo.Text = "Tipo";
            // 
            // textNomA
            // 
            this.textNomA.Location = new System.Drawing.Point(72, 24);
            this.textNomA.Name = "textNomA";
            this.textNomA.Size = new System.Drawing.Size(250, 20);
            this.textNomA.TabIndex = 1;
            // 
            // labelNombreA
            // 
            this.labelNombreA.AutoSize = true;
            this.labelNombreA.Location = new System.Drawing.Point(6, 27);
            this.labelNombreA.Name = "labelNombreA";
            this.labelNombreA.Size = new System.Drawing.Size(44, 13);
            this.labelNombreA.TabIndex = 0;
            this.labelNombreA.Text = "Nombre";
            // 
            // dataGridAtr
            // 
            this.dataGridAtr.AllowUserToAddRows = false;
            this.dataGridAtr.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridAtr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridAtr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAtr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNameA,
            this.ColumnTipo,
            this.ColumnTam,
            this.ColumnClv});
            this.dataGridAtr.Enabled = false;
            this.dataGridAtr.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridAtr.Location = new System.Drawing.Point(3, 285);
            this.dataGridAtr.Name = "dataGridAtr";
            this.dataGridAtr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAtr.Size = new System.Drawing.Size(483, 280);
            this.dataGridAtr.TabIndex = 3;
            this.dataGridAtr.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAtr_CellClick);
            this.dataGridAtr.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAtr_CellDoubleClick);
            // 
            // groupBotonA
            // 
            this.groupBotonA.Controls.Add(this.buttonDelA);
            this.groupBotonA.Controls.Add(this.buttonModA);
            this.groupBotonA.Controls.Add(this.buttonAddA);
            this.groupBotonA.Location = new System.Drawing.Point(25, 19);
            this.groupBotonA.Name = "groupBotonA";
            this.groupBotonA.Size = new System.Drawing.Size(396, 100);
            this.groupBotonA.TabIndex = 1;
            this.groupBotonA.TabStop = false;
            // 
            // buttonDelA
            // 
            this.buttonDelA.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDelA.BackgroundImage = global::archivos2015.Properties.Resources.del;
            this.buttonDelA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelA.Enabled = false;
            this.buttonDelA.Location = new System.Drawing.Point(304, 19);
            this.buttonDelA.Name = "buttonDelA";
            this.buttonDelA.Size = new System.Drawing.Size(75, 75);
            this.buttonDelA.TabIndex = 2;
            this.buttonDelA.UseVisualStyleBackColor = false;
            this.buttonDelA.Click += new System.EventHandler(this.buttonDelA_Click);
            // 
            // buttonModA
            // 
            this.buttonModA.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonModA.BackgroundImage = global::archivos2015.Properties.Resources.minus;
            this.buttonModA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModA.Enabled = false;
            this.buttonModA.Location = new System.Drawing.Point(153, 19);
            this.buttonModA.Name = "buttonModA";
            this.buttonModA.Size = new System.Drawing.Size(75, 75);
            this.buttonModA.TabIndex = 1;
            this.buttonModA.UseVisualStyleBackColor = false;
            this.buttonModA.Click += new System.EventHandler(this.buttonModA_Click);
            // 
            // buttonAddA
            // 
            this.buttonAddA.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAddA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddA.BackgroundImage")));
            this.buttonAddA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddA.Enabled = false;
            this.buttonAddA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonAddA.Location = new System.Drawing.Point(6, 19);
            this.buttonAddA.Name = "buttonAddA";
            this.buttonAddA.Size = new System.Drawing.Size(75, 75);
            this.buttonAddA.TabIndex = 0;
            this.buttonAddA.UseVisualStyleBackColor = false;
            this.buttonAddA.Click += new System.EventHandler(this.buttonAddA_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Diccionario(.dic)|*.dic";
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnName.HeaderText = "Nombre";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 69;
            // 
            // ColumnNameA
            // 
            this.ColumnNameA.HeaderText = "Nombre";
            this.ColumnNameA.Name = "ColumnNameA";
            this.ColumnNameA.ReadOnly = true;
            // 
            // ColumnTipo
            // 
            this.ColumnTipo.HeaderText = "Tipo de dato";
            this.ColumnTipo.Name = "ColumnTipo";
            this.ColumnTipo.ReadOnly = true;
            // 
            // ColumnTam
            // 
            this.ColumnTam.HeaderText = "Tamaño";
            this.ColumnTam.Name = "ColumnTam";
            this.ColumnTam.ReadOnly = true;
            // 
            // ColumnClv
            // 
            this.ColumnClv.HeaderText = "Clave";
            this.ColumnClv.Name = "ColumnClv";
            this.ColumnClv.ReadOnly = true;
            // 
            // comboBD
            // 
            this.comboBD.FormattingEnabled = true;
            this.comboBD.Location = new System.Drawing.Point(46, 7);
            this.comboBD.Name = "comboBD";
            this.comboBD.Size = new System.Drawing.Size(121, 21);
            this.comboBD.TabIndex = 2;
            this.comboBD.Text = "Bases de datos";
            this.comboBD.SelectedValueChanged += new System.EventHandler(this.comboBD_SelectedValueChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 632);
            this.Controls.Add(this.comboBD);
            this.Controls.Add(this.groupAtriubuto);
            this.Controls.Add(this.groupEntidad);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diccionario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupEntidad.ResumeLayout(false);
            this.groupEntidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEntidad)).EndInit();
            this.groupName.ResumeLayout(false);
            this.groupName.PerformLayout();
            this.groupBotones.ResumeLayout(false);
            this.groupAtriubuto.ResumeLayout(false);
            this.groupAtriubuto.PerformLayout();
            this.groupAtri.ResumeLayout(false);
            this.groupAtri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtr)).EndInit();
            this.groupBotonA.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupEntidad;
        private System.Windows.Forms.GroupBox groupAtriubuto;
        private System.Windows.Forms.GroupBox groupBotones;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonMod;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridEntidad;
        private System.Windows.Forms.GroupBox groupName;
        private System.Windows.Forms.TextBox textEnt;
        private System.Windows.Forms.GroupBox groupAtri;
        private System.Windows.Forms.RadioButton radioNinguna;
        private System.Windows.Forms.RadioButton radioExterna;
        private System.Windows.Forms.RadioButton radioPrimaria;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.TextBox textNomA;
        private System.Windows.Forms.Label labelNombreA;
        private System.Windows.Forms.DataGridView dataGridAtr;
        private System.Windows.Forms.GroupBox groupBotonA;
        private System.Windows.Forms.Button buttonDelA;
        private System.Windows.Forms.Button buttonModA;
        private System.Windows.Forms.Button buttonAddA;
        private System.Windows.Forms.ComboBox comboEntidad;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelTam;
        private System.Windows.Forms.Label labelAvisos;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelAvisosA;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNameA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClv;
        private System.Windows.Forms.ComboBox comboBD;
    }
}

