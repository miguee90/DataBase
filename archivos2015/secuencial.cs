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
    public partial class secuencial : Form
    {
        Diccionario diccionario;
        Organizacion organizacion;
        List<string> dats;
        bool DelD,modD;

        public secuencial()
        {
            InitializeComponent();
            dats = new List<string>();
            DelD = false;
            modD = false;
        }

        public secuencial(Diccionario dicc)
        {
            InitializeComponent();
            diccionario = dicc;
            organizacion = new Organizacion(diccionario, "sec");
            loadComboEnts();
            dats = new List<string>();
            DelD = false;
            modD = false;
        }
        //Abrir organizacion desde un archivo
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.Text = Path.GetFileName(openFileDialog1.FileName);
                //Organizacion se abre desde la funcion(this.text)
                organizacion.abreDesdeArchivo(this.Text);
            }
        }
        //Carga las entidades en el combo
        private void loadComboEnts()
        {
            foreach (Entidad i in organizacion.Dic.Entidades)
                comboBox1.Items.Add(i.Nombre);
        }
        //Carga los datos cada vez que se selecciona la entidad
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Entidad ent;
            string nombre;
            dataGridData.Visible = true;
            groupBotones.Visible = true;

            //Carga las las columnas en el datagrid
            ent = organizacion.Dic.getEntByName(comboBox1.Text);
            dataGridData.ColumnCount = ent.Atributos.Count+2;
            dataGridData.Columns[0].Name = "Direccion";
            dataGridData.Columns[1].Name = "Apunta siguiente bloque";

            for (int i = 0; i < ent.Atributos.Count; i++)
            {
                if(ent.Atributos[i].TClave==1)
                    nombre ="(kp)"+ ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else if(ent.Atributos[i].TClave==2)
                    nombre = "(ke)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else
                    nombre=ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";

                dataGridData.Columns[i + 2].Name = nombre;
            }

            llenaData(ent);
        }
        //Boton agrega bloque de datos
        private void buttonAddD_Click(object sender, EventArgs e)
        {
            Entidad ent = organizacion.Dic.getEntByName(comboBox1.Text);
            bool noInserta = false;
            dats = new List<string>();
            DelD = false;
            modD = false;
            labelAvisos.Text = "";

            foreach (Atributo i in ent.Atributos)
            {
                GetDatos box = new GetDatos(i, organizacion);
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
                organizacion.insertaBloqueDatos(ent, dats);
                //Llena datagrid
                llenaData(ent);
            }
        }
        //Llena el datagrid
        private void llenaData(Entidad ent)
        {
            List<string> registro = new List<string>();
            long dirBloq = ent.ApuntaDat;
            long magdiel = 0;
            string auxCad = "";

            dataGridData.Rows.Clear();

            while (dirBloq != -1)
            {
                organizacion.Archivo.setStreamPosition(dirBloq);
                registro.Add(organizacion.Archivo.getLong().ToString());
                dirBloq=organizacion.Archivo.getLong();
                registro.Add(dirBloq.ToString());
                foreach (Atributo i in ent.Atributos)
                {
                    switch (i.Tipo)
                    {
                        case "int":
                            registro.Add(organizacion.Archivo.getInt().ToString());
                            break;
                        case "float":
                            registro.Add(organizacion.Archivo.getDouble().ToString());
                            break;
                        case "char":
                            registro.Add(organizacion.Archivo.getChar().ToString());
                            break;
                        case "string":
                            magdiel = organizacion.Archivo.Positon;
                            auxCad = organizacion.Archivo.getString(i.Tam);
                            registro.Add(auxCad);
                            organizacion.Archivo.setStreamPosition(magdiel + i.Tam);
                            break;
                    }
                }
                //Agregar al data grid los elementos de la lista de cadenas
                dataGridData.Rows.Add(registro.ToArray());
                registro = new List<string>();
            }
        }
        //Boton que activa la bandera de eliminacion
        private void buttonDelD_Click(object sender, EventArgs e)
        {
            labelAvisos.Text = "Da doble click en el registro que deseas eliminar";
            DelD = true;
        }
        //Evento del doble click en el datagrid
        private void dataGridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DelD == true)
            {
                if (MessageBox.Show("¿Estas seguro que quieres eliminar el bloque?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    long dir = Convert.ToInt64(dataGridData.SelectedRows[0].Cells[0].Value);
                    Entidad ent = diccionario.getEntByName(comboBox1.Text);

                    //Elimina un registro de datos
                    organizacion.eliminaDato(comboBox1.Text, Convert.ToInt64(dataGridData.SelectedRows[0].Cells[0].Value));
                    llenaData(ent);
                }
            }
            else if (modD == true)
            {
                Entidad ent = diccionario.getEntByName(comboBox1.Text);
                bool noInserta = false;
                bool cambia = false;
                dats = new List<string>();
                List<string> dataList = new List<string>();
                int k = 0;

                if (MessageBox.Show("¿Estas seguro que quieres modificar el bloque?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    //Recorre las columnas del datagrid para obtener los datos
                    for (int i = 0; i < dataGridData.Columns.Count; i++)
                    {
                        dataList.Add(dataGridData.SelectedRows[0].Cells[i].Value.ToString());
                    }
 
                    foreach (Atributo i in ent.Atributos)
                    {
                        GetDatos box = new GetDatos(i, organizacion,dataList[k+2],modD);
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
                        //Escribe solo los bloques menos la clave primaria
                        organizacion.modificaBloque(Convert.ToInt64(dataGridData.SelectedRows[0].Cells[0].Value), ent, dats);
                        llenaData(ent);
                    }
                    else if (!noInserta)
                    {
                        //Elimina un registro de datos
                        organizacion.eliminaDato(comboBox1.Text, Convert.ToInt64(dataGridData.SelectedRows[0].Cells[0].Value));
                        //Inserta el bloque y los datos del registro
                        organizacion.insertaBloqueDatos(ent, dats);
                        //Llena datagrid
                        llenaData(ent);
                    }
                }
            }
        }
        //Boton que activa la modificacion del bloque
        private void buttonModD_Click(object sender, EventArgs e)
        {
            modD = true;
            DelD = false;
            labelAvisos.Text = "Da doble click en el bloque que deseas modificar";
        }

        private void secuencial_FormClosing(object sender, FormClosingEventArgs e)
        {
            string nombre=diccionario.NomDic.Substring(0,diccionario.NomDic.Length-3);
            organizacion.Archivo.cierraArchivo();
            if (File.Exists("orgs/" + nombre + "sec"))
                File.Delete("orgs/" + nombre + "sec");
            File.Copy(nombre + "sec", "orgs/" + nombre + "sec");
        }
    }
}
