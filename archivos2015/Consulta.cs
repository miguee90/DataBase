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
    public partial class Consulta : Form
    {
        private Manager manejador;

        public Consulta()
        {
            InitializeComponent();
        }

        public Consulta(Manager man)
        {
            manejador = man;
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            foreach (Diccionario i in manejador.Bases)
                comboBD.Items.Add(i.NomDic);
        }

        private void llenaData()
        {
            dataGridView1.Rows.Clear();
            foreach (User i in manejador.Usuarios)
            {
                if(i.BaseDatos==comboBD.Text)
                    dataGridView1.Rows.Add(i.Nombre, i.Vig_ini.ToShortDateString(), i.Vig_fin.ToShortDateString(), i.Admin, i.Altas, i.Bajas, i.Modificaciones, i.Consultas, i.SQL);
            }
        }

        private void comboBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaData();
            llenaTree();
        }

        private void llenaTree()
        {
            treeView1.Nodes.Clear();
            for (int i = 0; i < manejador.Bases.Count; i++)
            {
                if (manejador.Bases[i].NomDic == comboBD.Text)
                {
                    treeView1.Nodes.Add(manejador.Bases[i].NomDic);
                    for (int j = 0; j < manejador.Bases[i].Entidades.Count; j++)
                    {
                        treeView1.Nodes[i].Nodes.Add(manejador.Bases[i].Entidades[j].Nombre);
                        for (int k = 0; k < manejador.Bases[i].Entidades[j].Atributos.Count; k++)
                        {
                            treeView1.Nodes[i].Nodes[j].Nodes.Add(manejador.Bases[i].Entidades[j].Atributos[k].Nombre);
                        }
                    }
                }
            }
        }
    }
}
