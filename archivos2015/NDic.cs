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
    public partial class NDic : Form
    {
        private string nombre;

        public NDic()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            nombre = textBox1.Text;
            if (nombre.Length == 0)
            {
                MessageBox.Show("Error, ingrese el nombre del diccionario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public string NombreDic
        {
            get
            {
                return nombre;
            }
        }
    }
}
