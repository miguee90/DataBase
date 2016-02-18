using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace archivos2015
{
    public partial class Indexada : Form
    {
        Diccionario diccionario;
        List<string> dats;
        bool DelD,modD;
        List<Indice> tablaIndices;
        OrgIndex indexada;

        public Indexada()
        {
            InitializeComponent();
            dats = new List<string>();
            DelD = false;
            modD = false;

        }

        public Indexada(Diccionario dicc)
        {
            InitializeComponent();
            this.Text = "Secuencial Indexada";
            diccionario = dicc;
            loadComboEnts();
            dats = new List<string>();
            tablaIndices = new List<Indice>();
            string nombre = diccionario.NomDic.Substring(0, diccionario.NomDic.Length-3);
            indexada = new OrgIndex(nombre);
            modD = false;
            DelD = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupTabInd.Visible = true;
            dataGridIndices.Visible = true;
            dataGridData.Visible = true;
            groupBotones.Visible = true;
            Entidad ent = diccionario.getEntByName(comboBox1.Text);
            string nombre = "";

            tablaIndices = indexada.getTablaIndices(ent);

            //Carga las las columnas en el datagrid
            ent = diccionario.getEntByName(comboBox1.Text);
            dataGridData.ColumnCount = ent.Atributos.Count + 2;
            dataGridData.Columns[0].Name = "Direccion";
            dataGridData.Columns[1].Name = "Apunta siguiente bloque";

            for (int i = 0; i < ent.Atributos.Count; i++)
            {
                if (ent.Atributos[i].TClave == 1)
                    nombre = "(kp)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else if (ent.Atributos[i].TClave == 2)
                    nombre = "(ke)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else
                    nombre = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";

                dataGridData.Columns[i + 2].Name = nombre;
            }

            dataGridData.Rows.Clear();
            llenaDataTabIndex(ent);
        }

        public void llenaDataTabIndex(Entidad ent)
        {
            dataGridIndices.Rows.Clear();
            //Obtiene la tabla de indices (Entidad Ent)
            tablaIndices = indexada.getTablaIndices(ent);

            foreach (Indice i in tablaIndices)
            {
                dataGridIndices.Rows.Add(i.Ind.ToString(), i.Direccion.ToString(), i.ApuntaSig.ToString(), i.ApuntaDat.ToString());
            }
            dataGridData.Rows.Clear();
        }

        private void loadComboEnts()
        {
            foreach (Entidad i in diccionario.Entidades)
                comboBox1.Items.Add(i.Nombre);
        }

        private void buttonAddD_Click(object sender, EventArgs e)
        {
            bool noInserta = false;
            DelD = false;
            modD = false;
            dats = new List<string>();
            Entidad ent = diccionario.getEntByName(comboBox1.Text);
            labelAviso.Text = "";
            /*
            foreach (Atributo i in ent.Atributos)
            {
                GetDatos box = new GetDatos(i, diccionario);
                if (box.Dato == "error")
                {
                    noInserta = true;
                    break;
                }

                box.ShowDialog();
                dats.Add(box.Dato);
            }*/

            if (!noInserta)
            {
                //Inserta el bloque y los datos del registro
                if (indexada.insertaBloque(ent, dats, diccionario))
                    MessageBox.Show("La clave primaria esta repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Llena datagrid
                    llenaDataTabIndex(ent);
                }
                
            }
        }

        private void dataGridIndices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            long apuntaDat = Convert.ToInt64(dataGridIndices.SelectedRows[0].Cells[3].Value);
            Entidad ent = diccionario.getEntByName(comboBox1.Text);
            List<List<string>> listaDatos;
            dataGridData.Rows.Clear();
            dataGridData.Visible = true;

            //llena data de datos(apuntaDat,Ent)
            listaDatos = indexada.getDatos(apuntaDat, ent);

            foreach (List<string> i in listaDatos)
            {
                dataGridData.Rows.Add(i.ToArray());
            }
        }

        private void buttonDelD_Click(object sender, EventArgs e)
        {
            DelD = true;

            labelAviso.Text = "Selecciona primero el indice despues da dos clicks en el registro que quieras eliminar";

        }

        private void dataGridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool noInserta = false;
            dats = new List<string>();
            Entidad ent2 = diccionario.getEntByName(comboBox1.Text);
            List<string> dataList = new List<string>();
            bool cambia = false;

            if (DelD == true)
            {
                if (MessageBox.Show("¿Estas seguro que deseas eliminar el dato " + dataGridData.SelectedRows[0].Cells[0].Value.ToString() + " ?",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    Entidad ent = diccionario.getEntByName(comboBox1.Text);
                    long dirBloqueD = Convert.ToInt64(dataGridData.SelectedRows[0].Cells[0].Value);
                    string clv = "";
                    string tipo = "";
                    //Recorre los atributos para obtener la clave primaria
                    for (int i = 0; i < ent.Atributos.Count; i++)
                    {
                        if (ent.Atributos[i].TClave == 1)
                        {
                            clv = dataGridData.SelectedRows[0].Cells[i + 2].Value.ToString();
                            tipo = ent.Atributos[i].Tipo;
                        }
                    }
                    //Elimina Bloque(Ent,dirBloque,clv,tipo)
                    indexada.eliminaBloque(ent, dirBloqueD, clv, tipo);
                    llenaDataTabIndex(ent);
                    dataGridData.Visible = false;
                }
            }
            else if (modD == true)
            {
                if (MessageBox.Show("¿Estas seguro que deseas modificar el dato " + dataGridData.SelectedRows[0].Cells[0].Value.ToString() + " ?",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    Entidad ent = diccionario.getEntByName(comboBox1.Text);
                    long dirBloqueD = Convert.ToInt64(dataGridData.SelectedRows[0].Cells[0].Value);
                    string clv = "";
                    string tipo = "";
                    int k = 0;

                    //Recorre el renglon para obtener los datos
                    for (int i = 0; i < dataGridData.Columns.Count; i++)
                    {
                        dataList.Add(dataGridData.SelectedRows[0].Cells[i].Value.ToString());
                    }

                    //Recorre los atributos para obtener la clave primaria
                    for (int i = 0; i < ent.Atributos.Count; i++)
                    {
                        if (ent.Atributos[i].TClave == 1)
                        {
                            clv = dataGridData.SelectedRows[0].Cells[i + 2].Value.ToString();
                            tipo = ent.Atributos[i].Tipo;
                        }
                    }

                    //Inserta
                    foreach (Atributo i in ent2.Atributos)
                    {
                        GetDatos box = new GetDatos(i, diccionario, indexada.Archivo,dataList[k+2],modD);
                        if (box.Dato == "error")
                        {
                            noInserta = true;
                            break;
                        }

                        box.ShowDialog();
                        if (box.CambioPrim == true)
                            cambia = true;

                        dats.Add(box.Dato);
                        k += 1;
                    }

                    if (!cambia)
                    {
                        //Modifiica los datos menos la clave primaria
                        indexada.modificaBloque(Convert.ToInt64(dataGridData.SelectedRows[0].Cells[0].Value), ent, dats);

                        llenaDataTabIndex(ent);
                    }
                    else if (!noInserta)
                    {
                        //Elimina Bloque(Ent,dirBloque,clv,tipo)
                        indexada.eliminaBloque(ent, dirBloqueD, clv, tipo);
                        //Inserta el bloque y los datos del registro
                        if (indexada.insertaBloque(ent2, dats, diccionario))
                            MessageBox.Show("La clave primaria esta repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            //Llena datagrid
                            llenaDataTabIndex(ent2);
                        }

                    }
                }
            }
        }

        private void buttonModD_Click(object sender, EventArgs e)
        {
            modD = true;
            DelD = false;

            labelAviso.Text = "Selecciona primero el indice despues da dos clicks en el registro que quieras modificar";
        }
    }
}