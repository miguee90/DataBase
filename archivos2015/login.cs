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
    public partial class Login : Form
    {
        Manager manejador;
        string permiso;
        User user;

        public Login()
        {
            InitializeComponent();
        }

        public Login(Manager man,string perm)
        {
            manejador = man;
            permiso = perm;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool noExiste = false;
            bool puede = true;

            if(textBoxUser.Text==""||textBoxPass.Text=="")
                MessageBox.Show("Error, por favor llena todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                foreach(User i in manejador.Usuarios)
                {
                    if(i.Nombre==textBoxUser.Text&&textBoxPass.Text==i.Password)
                    {
                        user = i;
                        if (!i.Admin)
                        {
                            switch(permiso)
                            {
                                case "altas":
                                    if (!i.Altas)
                                        puede = false;
                                break;
                                case "bajas":
                                    if (!i.Bajas)
                                        puede = false;
                                break;
                                case "mod":
                                    if (!i.Modificaciones)
                                        puede = false;
                                break;
                                case "consultas":
                                    if (!i.Consultas)
                                        puede = false;
                                break;
                            }
                        }
                        if (puede)
                        {
                            if (DateTime.Compare(i.Vig_fin, DateTime.Today) < 0)
                                MessageBox.Show("Error, la vigencia de este usuario ha caducado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                noExiste = true;
                                if(permiso=="consultas")
                                {
                                    //Vista para consultas
                                    Consultas con = new Consultas(manejador, user.BaseDatos);
                                    con.ShowDialog();
                                    this.Close();
                                }
                                else
                                { 
                                    secuencial datos = new secuencial(manejador,permiso,i);
                                    datos.ShowDialog();
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Error, no tiene los permisos para acceder a esta funcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(noExiste==false)
                    MessageBox.Show("Error, verifica el nombre de usuario y/o contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
