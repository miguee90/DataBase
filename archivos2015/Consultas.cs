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
    public partial class Consultas : Form
    {
        Manager manejador;
        Diccionario baseActual;

        public Consultas()
        {
            InitializeComponent();
        }
        public Consultas(Manager man,string baseDatos)
        {
            InitializeComponent();
            manejador = man;
            baseActual = manejador.getBDbyName(baseDatos);
            llenaComboTablas();
        }

        private void llenaComboTablas()
        {
            foreach(Entidad i in baseActual.Entidades)
                comboTablas.Items.Add(i.Nombre);
        }

        private void comboClaves_SelectedValueChanged(object sender, EventArgs e)
        {
            groupParams.Visible = true;
            buttonFind.Visible = true;
        }

        /// <summary>
        /// Evento que sucede cuando se cambia el valor del combobox de tablas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboTablas_SelectedValueChanged(object sender, EventArgs e)
        {
            groupClaves.Visible = true;
            //Lena combo de claves
            llenaComboClaves();
            llenaDataFull();
        }

        /// <summary>
        /// llena el combo con llaves primarias y foraneas
        /// </summary>
        private void llenaComboClaves()
        {
            Entidad ent = baseActual.getEntByName(comboTablas.Text);

            comboClaves.Items.Clear();
            foreach (Atributo i in ent.Atributos)
                if (i.TClave == 1)
                    comboClaves.Items.Add(i.Nombre + "(Kp)");
                else if (i.TClave == 2)
                    comboClaves.Items.Add(i.Nombre + "(Kf)");
        }

        /// <summary>
        /// Llena el datagrid con todos los datos que tenga una entidad
        /// </summary>
        private void llenaDataFull()
        {
            Entidad ent = baseActual.getEntByName(comboTablas.Text);
            string nombre;

            dataGridData.ColumnCount = ent.Atributos.Count;

            for (int i = 0; i < ent.Atributos.Count; i++)
            {
                if (ent.Atributos[i].TClave == 1)
                    nombre = "(kp)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else if (ent.Atributos[i].TClave == 2)
                    nombre = "(ke)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else
                    nombre = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";

                dataGridData.Columns[i].Name = nombre;
            }

            dataGridData.Rows.Clear();
            foreach(List<string> i in ent.ListaRegistros)
                dataGridData.Rows.Add(i.ToArray());

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if(textParams.Text==""||textParams.Text=="")
                MessageBox.Show("Error, Debes de ingresar un parametro de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //Llenar el data grid con los registros encontrados
                consultaRegistros(comboClaves.Text, textParams.Text);
            }
        }

        private void consultaRegistros(string clave,string parametro)
        {
            bool esPrim = false;
            Entidad ent = baseActual.getEntByName(comboTablas.Text);
            List<List<string>> encontrados = new List<List<string>>();

            if (clave.Contains("Kp"))
                esPrim = true;
            else if (clave.Contains("Kf"))
                esPrim = false;

            if (esPrim)
            {
                for (int i = 0; i < ent.ListaRegistros.Count; i++)
                    for (int j = 0; j < ent.Atributos.Count; j++)
                        if (ent.Atributos[j].TClave == 1 && ent.ListaRegistros[i][j] == parametro)
                            encontrados.Add(ent.ListaRegistros[i]);
            }
            else
            {
                for (int k = 0; k < ent.ListaRegistros.Count; k++)
                    for (int l = 0; l < ent.Atributos.Count; l++)
                        if (ent.Atributos[l].TClave == 2 && ent.ListaRegistros[k][l] == parametro)
                            encontrados.Add(ent.ListaRegistros[k]);
            }

            //LLena el datagrid con los encontrados
            llenaDataConsulta(encontrados);
        }

        private void llenaDataConsulta(List<List<string>> encontrados)
        {
            dataGridData.Rows.Clear();
            foreach (List<string> i in encontrados)
                dataGridData.Rows.Add(i.ToArray());
        }
    }
}
