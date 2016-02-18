using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace archivos2015
{
    public partial class MenuPrincipal : Form
    {
        Manager manejador;
        public MenuPrincipal()
        {
            InitializeComponent();
            if (File.Exists("manejador.txt"))
            {
                FileStream stream = new FileStream("manejador.txt", FileMode.Open);
                BinaryFormatter formater = new BinaryFormatter();
                if (stream != null)
                {
                    manejador = (Manager)(formater.Deserialize(stream));
                    stream.Close();
                }
                else
                    manejador = new Manager();
            }
            else
                manejador = new Manager();
        }

        private void buttonNE_Click(object sender, EventArgs e)
        {
            Form1 estructura = new Form1(manejador);

            estructura.ShowDialog();
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream stream = new FileStream("manejador.txt", FileMode.OpenOrCreate);
            BinaryFormatter formater = new BinaryFormatter();

            formater.Serialize(stream, manejador);
            stream.Close();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios(manejador);

            u.ShowDialog();
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta(manejador);

            consulta.ShowDialog();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Login log = new Login(manejador,"altas");

            log.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Login log = new Login(manejador, "bajas");

            log.ShowDialog();
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            Login log = new Login(manejador, "mod");

            log.ShowDialog();
        }

        private void buttonCons_Click(object sender, EventArgs e)
        {
            Login log = new Login(manejador, "consultas");

            log.ShowDialog();
        }
    }
}
