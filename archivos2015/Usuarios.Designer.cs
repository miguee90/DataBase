namespace archivos2015
{
    partial class Usuarios
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
            this.groupUsers = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupPermisos = new System.Windows.Forms.GroupBox();
            this.checkBoxConsultas = new System.Windows.Forms.CheckBox();
            this.checkBoxSQL = new System.Windows.Forms.CheckBox();
            this.checkBoxMod = new System.Windows.Forms.CheckBox();
            this.checkBoxBajas = new System.Windows.Forms.CheckBox();
            this.checkBoxAlta = new System.Windows.Forms.CheckBox();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.comboBD = new System.Windows.Forms.ComboBox();
            this.labelBD = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAltas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBajas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSQL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.labelVF = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelVI = new System.Windows.Forms.Label();
            this.textRPass = new System.Windows.Forms.TextBox();
            this.labelRPass = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.groupUsers.SuspendLayout();
            this.groupPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupUsers
            // 
            this.groupUsers.Controls.Add(this.buttonSave);
            this.groupUsers.Controls.Add(this.groupPermisos);
            this.groupUsers.Controls.Add(this.comboBD);
            this.groupUsers.Controls.Add(this.labelBD);
            this.groupUsers.Controls.Add(this.dataGridView1);
            this.groupUsers.Controls.Add(this.dateTimePicker2);
            this.groupUsers.Controls.Add(this.labelVF);
            this.groupUsers.Controls.Add(this.dateTimePicker1);
            this.groupUsers.Controls.Add(this.labelVI);
            this.groupUsers.Controls.Add(this.textRPass);
            this.groupUsers.Controls.Add(this.labelRPass);
            this.groupUsers.Controls.Add(this.textPass);
            this.groupUsers.Controls.Add(this.labelPass);
            this.groupUsers.Controls.Add(this.labelNombre);
            this.groupUsers.Controls.Add(this.textNombre);
            this.groupUsers.Location = new System.Drawing.Point(29, 19);
            this.groupUsers.Name = "groupUsers";
            this.groupUsers.Size = new System.Drawing.Size(872, 520);
            this.groupUsers.TabIndex = 0;
            this.groupUsers.TabStop = false;
            this.groupUsers.Text = "Usuarios";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSave.Location = new System.Drawing.Point(382, 243);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(104, 31);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupPermisos
            // 
            this.groupPermisos.Controls.Add(this.checkBoxConsultas);
            this.groupPermisos.Controls.Add(this.checkBoxSQL);
            this.groupPermisos.Controls.Add(this.checkBoxMod);
            this.groupPermisos.Controls.Add(this.checkBoxBajas);
            this.groupPermisos.Controls.Add(this.checkBoxAlta);
            this.groupPermisos.Controls.Add(this.checkBoxAdmin);
            this.groupPermisos.Location = new System.Drawing.Point(505, 68);
            this.groupPermisos.Name = "groupPermisos";
            this.groupPermisos.Size = new System.Drawing.Size(294, 149);
            this.groupPermisos.TabIndex = 14;
            this.groupPermisos.TabStop = false;
            this.groupPermisos.Text = "Permisos";
            // 
            // checkBoxConsultas
            // 
            this.checkBoxConsultas.AutoSize = true;
            this.checkBoxConsultas.Location = new System.Drawing.Point(191, 60);
            this.checkBoxConsultas.Name = "checkBoxConsultas";
            this.checkBoxConsultas.Size = new System.Drawing.Size(72, 17);
            this.checkBoxConsultas.TabIndex = 5;
            this.checkBoxConsultas.Text = "Consultas";
            this.checkBoxConsultas.UseVisualStyleBackColor = true;
            // 
            // checkBoxSQL
            // 
            this.checkBoxSQL.AutoSize = true;
            this.checkBoxSQL.Location = new System.Drawing.Point(191, 28);
            this.checkBoxSQL.Name = "checkBoxSQL";
            this.checkBoxSQL.Size = new System.Drawing.Size(47, 17);
            this.checkBoxSQL.TabIndex = 4;
            this.checkBoxSQL.Text = "SQL";
            this.checkBoxSQL.UseVisualStyleBackColor = true;
            // 
            // checkBoxMod
            // 
            this.checkBoxMod.AutoSize = true;
            this.checkBoxMod.Location = new System.Drawing.Point(17, 115);
            this.checkBoxMod.Name = "checkBoxMod";
            this.checkBoxMod.Size = new System.Drawing.Size(97, 17);
            this.checkBoxMod.TabIndex = 3;
            this.checkBoxMod.Text = "Modificaciones";
            this.checkBoxMod.UseVisualStyleBackColor = true;
            // 
            // checkBoxBajas
            // 
            this.checkBoxBajas.AutoSize = true;
            this.checkBoxBajas.Location = new System.Drawing.Point(17, 87);
            this.checkBoxBajas.Name = "checkBoxBajas";
            this.checkBoxBajas.Size = new System.Drawing.Size(52, 17);
            this.checkBoxBajas.TabIndex = 2;
            this.checkBoxBajas.Text = "Bajas";
            this.checkBoxBajas.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlta
            // 
            this.checkBoxAlta.AutoSize = true;
            this.checkBoxAlta.Location = new System.Drawing.Point(17, 60);
            this.checkBoxAlta.Name = "checkBoxAlta";
            this.checkBoxAlta.Size = new System.Drawing.Size(49, 17);
            this.checkBoxAlta.TabIndex = 1;
            this.checkBoxAlta.Text = "Altas";
            this.checkBoxAlta.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(17, 28);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(89, 17);
            this.checkBoxAdmin.TabIndex = 0;
            this.checkBoxAdmin.Text = "Administrador";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            this.checkBoxAdmin.CheckedChanged += new System.EventHandler(this.checkBoxAdmin_CheckedChanged);
            // 
            // comboBD
            // 
            this.comboBD.FormattingEnabled = true;
            this.comboBD.Location = new System.Drawing.Point(679, 27);
            this.comboBD.Name = "comboBD";
            this.comboBD.Size = new System.Drawing.Size(121, 21);
            this.comboBD.TabIndex = 13;
            // 
            // labelBD
            // 
            this.labelBD.AutoSize = true;
            this.labelBD.Location = new System.Drawing.Point(565, 30);
            this.labelBD.Name = "labelBD";
            this.labelBD.Size = new System.Drawing.Size(75, 13);
            this.labelBD.TabIndex = 12;
            this.labelBD.Text = "Base de datos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColVI,
            this.ColVF,
            this.ColBD,
            this.ColAdm,
            this.ColAltas,
            this.ColBajas,
            this.ColMod,
            this.ColSQL,
            this.ColCons});
            this.dataGridView1.Location = new System.Drawing.Point(0, 290);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(872, 224);
            this.dataGridView1.TabIndex = 10;
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
            // ColBD
            // 
            this.ColBD.HeaderText = "Base de datos";
            this.ColBD.Name = "ColBD";
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
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(170, 155);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // labelVF
            // 
            this.labelVF.AutoSize = true;
            this.labelVF.Location = new System.Drawing.Point(51, 161);
            this.labelVF.Name = "labelVF";
            this.labelVF.Size = new System.Drawing.Size(73, 13);
            this.labelVF.TabIndex = 8;
            this.labelVF.Text = "Vigencia Final";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(170, 122);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // labelVI
            // 
            this.labelVI.AutoSize = true;
            this.labelVI.Location = new System.Drawing.Point(51, 128);
            this.labelVI.Name = "labelVI";
            this.labelVI.Size = new System.Drawing.Size(78, 13);
            this.labelVI.TabIndex = 6;
            this.labelVI.Text = "Vigencia Inicial";
            // 
            // textRPass
            // 
            this.textRPass.Location = new System.Drawing.Point(170, 93);
            this.textRPass.Name = "textRPass";
            this.textRPass.Size = new System.Drawing.Size(171, 20);
            this.textRPass.TabIndex = 5;
            this.textRPass.UseSystemPasswordChar = true;
            // 
            // labelRPass
            // 
            this.labelRPass.AutoSize = true;
            this.labelRPass.Location = new System.Drawing.Point(51, 96);
            this.labelRPass.Name = "labelRPass";
            this.labelRPass.Size = new System.Drawing.Size(100, 13);
            this.labelRPass.TabIndex = 4;
            this.labelRPass.Text = "Repetir  contraseña";
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(170, 65);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(171, 20);
            this.textPass.TabIndex = 3;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(51, 68);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(61, 13);
            this.labelPass.TabIndex = 2;
            this.labelPass.Text = "Contraseña";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(51, 34);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(170, 27);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(291, 20);
            this.textNombre.TabIndex = 0;
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(927, 551);
            this.Controls.Add(this.groupUsers);
            this.Name = "Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            this.groupUsers.ResumeLayout(false);
            this.groupUsers.PerformLayout();
            this.groupPermisos.ResumeLayout(false);
            this.groupPermisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupUsers;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox textRPass;
        private System.Windows.Forms.Label labelRPass;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label labelVF;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelVI;
        private System.Windows.Forms.GroupBox groupPermisos;
        private System.Windows.Forms.CheckBox checkBoxConsultas;
        private System.Windows.Forms.CheckBox checkBoxSQL;
        private System.Windows.Forms.CheckBox checkBoxMod;
        private System.Windows.Forms.CheckBox checkBoxBajas;
        private System.Windows.Forms.CheckBox checkBoxAlta;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.ComboBox comboBD;
        private System.Windows.Forms.Label labelBD;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAltas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCons;
    }
}