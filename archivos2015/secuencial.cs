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

        //***************************Variables base de datos********************************
        Manager manejador;
        string funcion;
        User usuario;
        Diccionario baseActual;

        public secuencial()
        {
            InitializeComponent();
            dats = new List<string>();
            DelD = false;
            modD = false;
        }

        public secuencial(Manager man, string func,User user)
        {
            InitializeComponent();
            dats = new List<string>();
            DelD = false;
            modD = false;
            manejador = man;
            funcion = func;
            usuario = user;
            inicializaFuncion();
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

        /// <summary>
        /// Funcion que permite inicializar la pantalla de acuerdo a si es alta, baja o modificacion
        /// </summary>
        private void inicializaFuncion()
        {
            this.Text = funcion;
            foreach(Diccionario i in manejador.Bases)
            {
                if (usuario.BaseDatos == i.NomDic)
                { 
                    comboBox2.Items.Add(usuario.BaseDatos);
                    baseActual = i;
                }
            }
            switch(funcion)
            {
                case "altas":
                    buttonAddD.Visible = true;
                    buttonDelD.Visible = false;
                    buttonModD.Visible = false;
                    break;
                case "bajas":
                    buttonAddD.Visible = false;
                    buttonDelD.Visible = true;
                    buttonModD.Visible = false;
                    break;
                case "mod":
                    buttonAddD.Visible = false;
                    buttonDelD.Visible = false;
                    buttonModD.Visible = true;
                    break;
            }
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
            ent = baseActual.getEntByName(comboBox1.Text);
            dataGridData.ColumnCount = ent.Atributos.Count;

            for (int i = 0; i < ent.Atributos.Count; i++)
            {
                if(ent.Atributos[i].TClave==1)
                    nombre ="(kp)"+ ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else if(ent.Atributos[i].TClave==2)
                    nombre = "(ke)" + ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                else
                    nombre=ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";

                dataGridData.Columns[i].Name = nombre;
            }

            llenaData(ent);
        }

        //Boton agrega bloque de datos
        private void buttonAddD_Click(object sender, EventArgs e)
        {
            Entidad ent = baseActual.getEntByName(comboBox1.Text);
            bool noInserta = false;
            dats = new List<string>();
            List<string> auxDats = new List<string>();
            DelD = false;
            modD = false;
            labelAvisos.Text = "";

            //Llena bitacora
            llenaBitacora(dats, DateTime.Today.ToShortDateString(), "", "", usuario.Nombre, "", "");

            for (int i=0;i<ent.Atributos.Count-6; i++)
            {
                GetDatos box = new GetDatos(ent.Atributos[i], baseActual,ent);
                if (box.Dato == "error")
                {
                    noInserta = true;
                    break;
                }

                box.ShowDialog();
                auxDats.Add(box.Dato);
            }

            if (!noInserta)
            {
                for(int i =auxDats.Count-1;i>=0;i--)
                    dats.Insert(0, auxDats[i]);
                //Inserta el bloque y los datos del registro
                ent.ListaRegistros.Add(dats);

                //Llena datagrid
                llenaData(ent);
            }
        }

        /// <summary>
        /// llena los datos de la bitacora
        /// </summary>
        public void llenaBitacora(List<string> d,string f_a,string f_b,string f_m,string u_a,string u_b,string u_m)
        {
            List<string> datos = d;

            datos.Add(f_a);
            datos.Add(f_b);
            datos.Add(f_m);
            datos.Add(u_a);
            datos.Add(u_b);
            datos.Add(u_m);
        }

        //Llena el datagrid
        private void llenaData(Entidad ent)
        {
            dataGridData.Rows.Clear();
            foreach(List<string> i in ent.ListaRegistros)
                dataGridData.Rows.Add(i.ToArray());
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
                Entidad ent = baseActual.getEntByName(comboBox1.Text);
                bool noInserta = false;
                bool cambia = false;
                dats = new List<string>();
                List<string> dataList = new List<string>();
                int k = 0;

                if (MessageBox.Show("¿Estas seguro que quieres modificar el bloque?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    //Recorre las columnas del datagrid para obtener los datos
                    for (int i = 0; i < dataGridData.Columns.Count-6; i++)
                    {
                        dataList.Add(dataGridData.SelectedRows[0].Cells[i].Value.ToString());
                    }
 
                    for(int i=0; i< ent.Atributos.Count-6;i++)
                    {
                        GetDatos box = new GetDatos(ent.Atributos[i],dataList[k],modD,baseActual,ent);
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
                        ent.modDatos(dats,usuario,dataList);
                        llenaData(ent);
                    }
                    else if (!noInserta)
                    {
                        //Mofica en cascada
                        ent.modDatCascada(dats, usuario, baseActual,dataList);
                        //Llena datagrid
                        llenaData(ent);
                    }
                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            groupBoxCombo1.Visible = true;
            foreach (Entidad i in baseActual.Entidades)
            {
                comboBox1.Items.Add(i.Nombre);
            }
        }

        //Boton que activa la modificacion del bloque
        private void buttonModD_Click(object sender, EventArgs e)
        {
            modD = true;
            DelD = false;
            labelAvisos.Text = "Da doble click en el bloque que deseas modificar";
        }
    }
}
