namespace archivos2015
{
    partial class MenuPrincipal
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
            this.groupEstructura = new System.Windows.Forms.GroupBox();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonCE = new System.Windows.Forms.Button();
            this.buttonNE = new System.Windows.Forms.Button();
            this.groupMant = new System.Windows.Forms.GroupBox();
            this.buttonCons = new System.Windows.Forms.Button();
            this.buttonMod = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.groupSQL = new System.Windows.Forms.GroupBox();
            this.groupEstructura.SuspendLayout();
            this.groupMant.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupEstructura
            // 
            this.groupEstructura.Controls.Add(this.buttonUsers);
            this.groupEstructura.Controls.Add(this.buttonCE);
            this.groupEstructura.Controls.Add(this.buttonNE);
            this.groupEstructura.Location = new System.Drawing.Point(40, 68);
            this.groupEstructura.Name = "groupEstructura";
            this.groupEstructura.Size = new System.Drawing.Size(302, 123);
            this.groupEstructura.TabIndex = 0;
            this.groupEstructura.TabStop = false;
            this.groupEstructura.Text = "Estructura";
            // 
            // buttonUsers
            // 
            this.buttonUsers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonUsers.Location = new System.Drawing.Point(207, 32);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(76, 75);
            this.buttonUsers.TabIndex = 2;
            this.buttonUsers.Text = "Usuarios";
            this.buttonUsers.UseVisualStyleBackColor = false;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonCE
            // 
            this.buttonCE.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCE.Location = new System.Drawing.Point(112, 32);
            this.buttonCE.Name = "buttonCE";
            this.buttonCE.Size = new System.Drawing.Size(76, 75);
            this.buttonCE.TabIndex = 1;
            this.buttonCE.Text = "Consulta estructura";
            this.buttonCE.UseVisualStyleBackColor = false;
            this.buttonCE.Click += new System.EventHandler(this.buttonCE_Click);
            // 
            // buttonNE
            // 
            this.buttonNE.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNE.Location = new System.Drawing.Point(20, 32);
            this.buttonNE.Name = "buttonNE";
            this.buttonNE.Size = new System.Drawing.Size(76, 75);
            this.buttonNE.TabIndex = 0;
            this.buttonNE.Text = "Nueva estructura";
            this.buttonNE.UseVisualStyleBackColor = false;
            this.buttonNE.Click += new System.EventHandler(this.buttonNE_Click);
            // 
            // groupMant
            // 
            this.groupMant.Controls.Add(this.buttonCons);
            this.groupMant.Controls.Add(this.buttonMod);
            this.groupMant.Controls.Add(this.buttonDelete);
            this.groupMant.Controls.Add(this.buttonInsert);
            this.groupMant.Location = new System.Drawing.Point(402, 68);
            this.groupMant.Name = "groupMant";
            this.groupMant.Size = new System.Drawing.Size(412, 123);
            this.groupMant.TabIndex = 3;
            this.groupMant.TabStop = false;
            this.groupMant.Text = "Mantenimiento";
            // 
            // buttonCons
            // 
            this.buttonCons.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCons.Location = new System.Drawing.Point(316, 32);
            this.buttonCons.Name = "buttonCons";
            this.buttonCons.Size = new System.Drawing.Size(76, 75);
            this.buttonCons.TabIndex = 3;
            this.buttonCons.Text = "Consultas";
            this.buttonCons.UseVisualStyleBackColor = false;
            this.buttonCons.Click += new System.EventHandler(this.buttonCons_Click);
            // 
            // buttonMod
            // 
            this.buttonMod.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMod.Location = new System.Drawing.Point(207, 32);
            this.buttonMod.Name = "buttonMod";
            this.buttonMod.Size = new System.Drawing.Size(91, 75);
            this.buttonMod.TabIndex = 2;
            this.buttonMod.Text = "Modificaciones";
            this.buttonMod.UseVisualStyleBackColor = false;
            this.buttonMod.Click += new System.EventHandler(this.buttonMod_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDelete.Location = new System.Drawing.Point(112, 32);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(76, 75);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Bajas";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonInsert.Location = new System.Drawing.Point(20, 32);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(76, 75);
            this.buttonInsert.TabIndex = 0;
            this.buttonInsert.Text = "Altas";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // groupSQL
            // 
            this.groupSQL.Location = new System.Drawing.Point(272, 276);
            this.groupSQL.Name = "groupSQL";
            this.groupSQL.Size = new System.Drawing.Size(302, 123);
            this.groupSQL.TabIndex = 3;
            this.groupSQL.TabStop = false;
            this.groupSQL.Text = "SQL";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(846, 457);
            this.Controls.Add(this.groupSQL);
            this.Controls.Add(this.groupMant);
            this.Controls.Add(this.groupEstructura);
            this.Name = "MenuPrincipal";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mike SQL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.groupEstructura.ResumeLayout(false);
            this.groupMant.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupEstructura;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonCE;
        private System.Windows.Forms.Button buttonNE;
        private System.Windows.Forms.GroupBox groupMant;
        private System.Windows.Forms.Button buttonCons;
        private System.Windows.Forms.Button buttonMod;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.GroupBox groupSQL;
    }
}