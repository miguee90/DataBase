using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace archivos2015
{
    public partial class Usuarios : Form
    {
        private Manager manejador;
        public Usuarios()
        {
            InitializeComponent();
        }

        public Usuarios(Manager man)
        {
            manejador = man;
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            foreach (Diccionario i in manejador.Bases)
            {
                comboBD.Items.Add(i.NomDic);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Valida si hay algun campo vacio
            if (validaVacios())
            { 
                MessageBox.Show("Error, debes llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (matchPass())
                {
                    MessageBox.Show("SI");
                }
                else
                    MessageBox.Show("Error, las contraseñas escritas no coinciden", "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool matchPass()
        {
            if (textPass.Text == textRPass.Text)
                return true;
            else
                return false;
        }

        /// <summary>
        /// valida si algun campo esta vacio
        /// </summary>
        /// <returns>false si todos tienen texto, true si hay algun campo vacio</returns>
        private bool validaVacios()
        {
            if (textNombre.Text == "")
                return true;
            else if (textPass.Text == "")
                return true;
            else if (textRPass.Text == "")
                return true;
            else if (comboBD.Text == "")
                return true;
            else
                return false;

        }
        /// <summary>
        /// Activa todas las casillas en caso de seleccionar administrador
        /// </summary>
        /// 
        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAdmin.Checked==true)
            {
                checkBoxAlta.Checked = true;
                checkBoxAlta.Enabled = false;
                checkBoxBajas.Checked = true;
                checkBoxBajas.Enabled = false;
                checkBoxMod.Checked = true;
                checkBoxMod.Enabled = false;
                checkBoxSQL.Checked = true;
                checkBoxSQL.Enabled = false;
                checkBoxConsultas.Checked = true;
                checkBoxConsultas.Enabled = false;
            }
            else
            {
                checkBoxAlta.Checked = false;
                checkBoxAlta.Enabled = true;
                checkBoxBajas.Checked = false;
                checkBoxBajas.Enabled = true;
                checkBoxMod.Checked = false;
                checkBoxMod.Enabled = true;
                checkBoxSQL.Checked = false;
                checkBoxSQL.Enabled = true;
                checkBoxConsultas.Checked = false;
                checkBoxConsultas.Enabled = true;
            }
        }
    }
}
