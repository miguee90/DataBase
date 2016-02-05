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
            llenaData();
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
                    if (verFechas())
                        if (veriPermisos())
                        {
                            User usuario = new User(textNombre.Text, textPass.Text, dateTimePicker1.Value, dateTimePicker2.Value, comboBD.Text,
                                checkBoxAdmin.Checked, checkBoxAlta.Checked, checkBoxBajas.Checked, checkBoxMod.Checked, checkBoxConsultas.Checked,
                                checkBoxSQL.Checked);
                            manejador.Usuarios.Add(usuario);
                            llenaData();
                            MessageBox.Show("El usuario ha sido guardado con éxto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("Error, debes seleccionar al menos un permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Error, Por favor verifica que el rango de fechas sea valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Error, las contraseñas escritas no coinciden", "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Llena el datagrid
        /// </summary>
        private void llenaData()
        {
            dataGridView1.Rows.Clear();
            foreach (User i in manejador.Usuarios)
            {
                dataGridView1.Rows.Add(i.Nombre, i.Vig_ini.ToShortDateString(), i.Vig_fin.ToShortDateString(), i.BaseDatos, i.Admin, i.Altas, i.Bajas, i.Modificaciones, i.Consultas, i.SQL);
            }
        }

        /// <summary>
        /// Verifica que tenga por lo menos un permiso
        /// </summary>
        /// <returns></returns>
        private bool veriPermisos()
        {
            if (checkBoxAdmin.Checked || checkBoxAlta.Checked || checkBoxBajas.Checked || checkBoxMod.Checked || checkBoxConsultas.Checked || checkBoxSQL.Checked)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica si las fechas tienen un rango correcto
        /// </summary>
        /// <returns></returns>
        private bool verFechas()
        {
            if (DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value) >= 0 || DateTime.Compare(dateTimePicker2.Value, DateTime.Today) <= 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Valida que los campos de contraseña sean iguales
        /// </summary>
        /// <returns></returns>
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
