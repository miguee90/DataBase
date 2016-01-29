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
    public partial class Multillaves : Form
    {
        Diccionario diccionario;
        string nombre;
        Multilistas multilistas;
        bool modD, delD;

        public Multillaves(Diccionario dic)
        {
            InitializeComponent();
            diccionario = dic;
            loadComboEnts();
            nombre = diccionario.NomDic.Substring(0, diccionario.NomDic.Length - 3);
            modD = false;
            delD = false;
            multilistas = new Multilistas(nombre);
        }

        private void loadComboEnts()
        {
            foreach (Entidad i in diccionario.Entidades)
                comboEnt.Items.Add(i.Nombre);
        }

        private void comboEnt_SelectedValueChanged(object sender, EventArgs e)
        {
            groupComAtr.Visible = true;
            dataGridData.Visible = true;
            groupBotones.Visible = false;
            comboAtris.Text = "";
            //llena combo de atributos
            llenaComboAtris();
            llenaData("");
        }

        private void llenaComboAtris()
        {
            Entidad ent=diccionario.getEntByName(comboEnt.Text);

            comboAtris.Items.Clear();
            foreach (Atributo i in ent.Atributos)
                comboAtris.Items.Add(i.Nombre);
        }

        private void buttonAddD_Click(object sender, EventArgs e)
        {
            modD = false;
            delD = false;
            labelAvisos.Text = "";
            List<string>dats = new List<string>();
            bool noInserta = false;

            Entidad ent = diccionario.getEntByName(comboEnt.Text);

            foreach (Atributo i in ent.Atributos)
            {
                GetDatos box = new GetDatos(i, diccionario, multilistas.Archivo);
                if (box.Dato == "error")
                {
                    noInserta = true;
                    break;
                }

                box.ShowDialog();
                dats.Add(box.Dato);
            }

            if (!noInserta)
            {
                //Inserta el bloque y los datos del registro
                if (multilistas.insertaBloque(ent, dats, diccionario))
                    MessageBox.Show("La clave primaria esta repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Llena datagrid
                    llenaData(comboAtris.Text);
                }

            }
        }

        public void llenaData(string atributo)
        {
            dataGridData.Rows.Clear();
            int indice = 0;
            int k = 0;
            List<List<string>> renglones = new List<List<string>>();
            //Obtener el indice del atributo
            if (comboAtris.Text != "")
            {
                indice = getIndice(comboAtris.Text);
                Entidad ent = diccionario.getEntByName(comboEnt.Text);

                //Verifica que tenga elementos
                if (ent.Atributos[0].ApuntaEntidad != ent.Dir)
                {
                    //obtiene lista de listas de cadenas con los datos 
                    renglones = getBloqDats(ent.Atributos[indice].ApuntaEntidad, ent, indice);

                    //Carga las las columnas en el datagrid
                    dataGridData.ColumnCount = (ent.Atributos.Count * 2) + 1;
                    for (k = 0; k < ent.Atributos.Count; k++)
                        dataGridData.Columns[k].Name = "ApuntaSig " + k.ToString();
                    dataGridData.Columns[k].Name = "Direccion";
                    k++;
                    for (int i = 0; i < ent.Atributos.Count; i++)
                    {
                        if (ent.Atributos[i].TClave == 1)
                            nombre = "(kp)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                        else if (ent.Atributos[i].TClave == 2)
                            nombre = "(ke)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                        else
                            nombre = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";

                        dataGridData.Columns[k].Name = nombre;
                        k++;
                    }
                    //Inserta los datos en el datagrid
                    foreach (List<string> j in renglones)
                        dataGridData.Rows.Add(j.ToArray());
                }
            }
        }

        private int getIndice(string atributo)
        {
            int resul = 0;

            for (int i = 0; i < diccionario.Entidades[0].Atributos.Count; i++)
            {
                if (diccionario.Entidades[0].Atributos[i].Nombre == atributo)
                    return i;
            }
            
            return resul;
        }

        private List<List<string>> getBloqDats(long dirDats,Entidad ent,int indice)
        {
            long dirNextBloq = 0, dirActual = 0;
            string auxCad = "";
            List<List<string>> rowsData = new List<List<string>>();
            List<string> auxRow = new List<string>();
            dirNextBloq = dirDats;

            while (dirNextBloq != -1)
            {
                auxRow = new List<string>();
                multilistas.Archivo.setStreamPosition(dirNextBloq);
                //Obtiene el bloque de apuntadores
                for (int i = 0; i < ent.Atributos.Count; i++)
                    if (i == indice)
                    {
                        dirNextBloq = multilistas.Archivo.getLong();
                        auxCad = Convert.ToString(dirNextBloq);
                        auxRow.Add(auxCad);
                    }
                    else
                        auxRow.Add(Convert.ToString(multilistas.Archivo.getLong()));
                //Obtiene direccion 
                dirActual = multilistas.Archivo.getLong();
                auxRow.Add(Convert.ToString(dirActual));
                multilistas.Archivo.getLong();
                //Obtiene los datos de cada atributo
                foreach (Atributo i in ent.Atributos)
                    //getByTipo(i.tipo)
                    auxRow.Add(multilistas.getByTipo(i.Tipo, i.Tam));

                rowsData.Add(auxRow);
            }

            return rowsData;
        }

        private void comboAtris_SelectedValueChanged(object sender, EventArgs e)
        {
            groupBotones.Visible = true;

            llenaData(comboAtris.Text);
        }

        private void Multillaves_FormClosing(object sender, FormClosingEventArgs e)
        {
            multilistas.Archivo.cierraArchivo();
        }

        private void buttonDelD_Click(object sender, EventArgs e)
        {
            delD = true;
            modD = false;
            labelAvisos.Text = "Da doble clic en el bloque que desees eliminar";
        }

        private void dataGridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string dirBloq = "";
            Entidad ent = diccionario.getEntByName(comboEnt.Text);
            List<string> dats = new List<string>();
            bool noInserta = false;

            if (delD)
            {
                dirBloq = dataGridData.SelectedRows[0].Cells[ent.Atributos.Count].Value.ToString();

                multilistas.eliminaBloque(dirBloq, ent);

                llenaData(comboAtris.Text);
            }
            else if (modD)
            {
                dirBloq = dataGridData.SelectedRows[0].Cells[ent.Atributos.Count].Value.ToString();

                multilistas.eliminaBloque(dirBloq, ent);


                foreach (Atributo i in ent.Atributos)
                {
                    GetDatos box = new GetDatos(i, diccionario, multilistas.Archivo);
                    if (box.Dato == "error")
                    {
                        noInserta = true;
                        break;
                    }

                    box.ShowDialog();
                    dats.Add(box.Dato);
                }

                if (!noInserta)
                {
                    //Inserta el bloque y los datos del registro
                    if (multilistas.insertaBloque(ent, dats, diccionario))
                        MessageBox.Show("La clave primaria esta repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        //Llena datagrid
                        llenaData(comboAtris.Text);
                    }

                }
            }
        }

        private void buttonModD_Click(object sender, EventArgs e)
        {
            modD = true;
            delD = false;

            labelAvisos.Text = "Da doble clic en el bloque que desees modificar";
        }
    }
}
