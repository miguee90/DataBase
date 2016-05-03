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
    public partial class GetDatos : Form
    {
        private List<string> dato;
        private Atributo atributo;
        private List<Atributo> atributos;
        private Diccionario diccionario;
        private Organizacion organizacion;
        private Entidad entidad;
        private Archivo archivo;
        bool noSecu;
        string viejo;
        List<string> viejos;
        bool cambioPrim;
        bool modificando;

        public bool CambioPrim
        {
            get { return cambioPrim; }
        }

        /// <summary>
        /// Constructor para inserciones
        /// </summary>
        /// <param name="atri"></param>
        /// <param name="dic"></param>
        /// <param name="ent"></param>
        public GetDatos(List<Atributo> atri, Diccionario dic, Entidad ent)
        {
            InitializeComponent();
            atributos = atri;
            diccionario = dic;
            entidad = ent;
            noSecu = false;
            viejo = "";
            modificando = false;
            cambioPrim = false;
            dato = new List<string>();

            dataGridView1.ColumnCount = ent.Atributos.Count-6;
            for(int i=0; i<ent.Atributos.Count-6;i++)
            { 
                if(ent.Atributos[i].TClave==2)
                {
                    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                    List<String> itemCodeList = llenaCombo(ent.Atributos[i].ApuntaPrim, diccionario);
                    if(itemCodeList.Count==0)
                    {
                        MessageBox.Show("Error aun no existen datos para llenar la clave externa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dato.Add("error");
                        this.Close();
                    }
                    combo.DataSource = itemCodeList;
                    combo.HeaderText = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                    combo.Name = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                    combo.Width = 100;
                    dataGridView1.Columns.Insert(0, combo);
                    dataGridView1.ColumnCount--;
                }
                else
                {
                    dataGridView1.Columns[i].Name = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                }
            }
        }

        /// <summary>
        /// Sobrecarga de constructor para modificaciones
        /// </summary>
        /// <param name="atri"></param>
        /// <param name="dato"></param>
        /// <param name="mod"></param>
        /// <param name="baseAc"></param>
        /// <param name="ent"></param>
        public GetDatos(List<Atributo> atri,List<string> dat,bool mod,Diccionario baseAc,Entidad ent)
        {
            InitializeComponent();
            atributos = atri;
            diccionario = baseAc;
            noSecu = false;
            viejos = dat;
            modificando = mod;
            dato = new List<string>();
            cambioPrim = false;
            entidad = ent;

            dataGridView1.ColumnCount = ent.Atributos.Count - 6;

            for (int i = 0; i < ent.Atributos.Count - 6; i++)
            {
                if (ent.Atributos[i].TClave == 2)
                {
                    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                    List<String> itemCodeList = llenaCombo(ent.Atributos[i].ApuntaPrim, diccionario);
                    if (itemCodeList.Count == 0)
                    {
                        MessageBox.Show("Error aun no existen datos para llenar la clave externa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dato.Add("error");
                        this.Close();
                    }
                    combo.DataSource = itemCodeList;
                    combo.HeaderText = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                    combo.Name = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                    combo.Width = 100;
                    dataGridView1.Columns.Insert(0, combo);
                    dataGridView1.ColumnCount--;
                }
                else
                {
                    dataGridView1.Columns[i].Name = ent.Atributos[i].Nombre + "(" + ent.Atributos[i].Tipo + ")";
                    dataGridView1.Rows[0].Cells[i].Value = viejos[i];
                }
            }

        }

        /// <summary>
        /// Constructor para ?
        /// </summary>
        /// <param name="atri"></param>
        /// <param name="dicc"></param>
        /// <param name="arch"></param>
        /// <param name="dato"></param>
        /// <param name="mod"></param>
        public GetDatos(Atributo atri, Diccionario dicc, Archivo arch,string dato,bool mod)
        {
            InitializeComponent();
            atributo = atri;
            diccionario = dicc;
            archivo = arch;
            noSecu = true;
            modificando = false;
            cambioPrim = false;
            viejo = dato;
            modificando = mod;
            /*
            textCaptura.Text = dato;
            groupCaptura.Text = atributo.Nombre + "(" + atributo.Tipo + ")";
            if (atributo.TClave == 2)
            {
                textCaptura.Visible = false;
                comboExternas.Visible = true;
                /*Llena el combo con los datos de clave primaria
                if (!llenaComboIndexada(atributo.ApuntaPrim))
                {
                    MessageBox.Show("Error aun no existen datos para llenar la clave externa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dato = "error";
                    this.Close();
                }
            }*/
        }

        public List<string> Dato
        {
            get { return dato; }
        }

        /// <summary>
        /// Boton que almacena los datos insertados o modificados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            dato = new List<string>();
            bool killoop = false;

            for(int i=0;i<entidad.Atributos.Count-6;i++)
            {
                if(modificando)
                    if (entidad.Atributos[i].TClave == 1 && (viejos[i] != dataGridView1.Rows[0].Cells[i].Value.ToString()))
                        cambioPrim = true;
                switch (entidad.Atributos[i].Tipo)
                {
                    case "int":
                        if (entidad.Atributos[i].TClave == 1 && buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) &&  modificando == false || (entidad.Atributos[i].TClave == 1&&buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) && cambioPrim))
                        { 
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            killoop = true;
                        }
                        else
                        {
                            if (entidad.Atributos[i].TClave == 2)
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else if (Validaciones.validaEnteros(dataGridView1.Rows[0].Cells[i].Value.ToString()))
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else
                            {
                                MessageBox.Show("El tipo de datos debe ser entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                killoop = true;
                            }
                        }
                        break;
                    case "float":
                        if (buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) && entidad.Atributos[i].TClave == 1 && modificando == false || (entidad.Atributos[i].TClave == 1 && buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) && cambioPrim))
                        { 
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            killoop = true;
                        }
                        else
                        {
                            if (entidad.Atributos[i].TClave == 2)
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else if (Validaciones.validaFlotantes(dataGridView1.Rows[0].Cells[i].Value.ToString()))
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else
                                MessageBox.Show("El tipo de datos debe ser flotante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            killoop = true;
                        }
                        break;
                    case "char":
                        if (buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) && entidad.Atributos[i].TClave == 1 && modificando == false || (entidad.Atributos[i].TClave == 1 && buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) && cambioPrim))
                        { 
                            killoop = true;
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (entidad.Atributos[i].TClave == 2)
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else if (Validaciones.validaChar(dataGridView1.Rows[0].Cells[i].Value.ToString()))
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else
                            {
                                MessageBox.Show("El tipo de dato debe ser caracter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                killoop = true;
                            }
                        }
                        break;
                    case "string":
                        if (buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) && entidad.Atributos[i].TClave == 1 && modificando == false || (entidad.Atributos[i].TClave == 1 && buscaClavePrimRepetida(dataGridView1.Rows[0].Cells[i].Value.ToString()) && cambioPrim))
                        { 
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            killoop = true;
                        }
                        else
                        {
                            if (entidad.Atributos[i].TClave == 2)
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else if (entidad.Atributos[i].Tam > dataGridView1.Rows[0].Cells[i].Value.ToString().Length)
                                dato.Add(dataGridView1.Rows[0].Cells[i].Value.ToString());
                            else
                            {
                                MessageBox.Show("El tamaño de la cadena excede el tamaño", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                killoop = true;
                            }
                        }
                        break;
                }

                if (killoop)
                    break;
            }
            
            if(!killoop)
                this.Close();

            /*
            if (noSecu)
            {
                if (atributo.TClave == 1)
                {
                    if (viejo != textCaptura.Text)
                        cambioPrim = true;
                    else
                        cambioPrim = false;
                }
                switch (atributo.Tipo)
                {
                    case "int":
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (Validaciones.validaEnteros(textCaptura))
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tipo de datos debe ser entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "float":
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (Validaciones.validaFlotantes(textCaptura))
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tipo de datos debe ser flotante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "char":
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (Validaciones.validaChar(textCaptura))
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tipo de dato debe ser caracter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "string":
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (atributo.Tam > textCaptura.Text.Length)
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tamaño de la cadena excede el tamaño", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                switch (atributo.Tipo)
                {
                    case "int":
                        if (atributo.TClave == 1)
                        {
                            if (viejo != textCaptura.Text)
                                cambioPrim = true;
                            else
                                cambioPrim = false;
                        }
                        if (buscaClavePrimRepetida(getTextActive()) && atributo.TClave == 1&&modificando==false||(buscaClavePrimRepetida(getTextActive())&&cambioPrim))
                        {
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (Validaciones.validaEnteros(textCaptura))
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tipo de datos debe ser entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "float":
                        if (atributo.TClave == 1)
                        {
                            if (viejo != textCaptura.Text)
                                cambioPrim = true;
                            else
                                cambioPrim = false;
                        }
                        if (buscaClavePrimRepetida(getTextActive()) && atributo.TClave == 1&&modificando==false||(buscaClavePrimRepetida(getTextActive())&&cambioPrim))
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (Validaciones.validaFlotantes(textCaptura))
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tipo de datos debe ser flotante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "char":
                        if (atributo.TClave == 1)
                        {
                            if (viejo != textCaptura.Text)
                                cambioPrim = true;
                            else
                                cambioPrim = false;
                        }
                        if (buscaClavePrimRepetida(getTextActive()) && atributo.TClave == 1&&modificando==false||(buscaClavePrimRepetida(getTextActive())&&cambioPrim))
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (Validaciones.validaChar(textCaptura))
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tipo de dato debe ser caracter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "string":
                        if (atributo.TClave == 1)
                        {
                            if (viejo != textCaptura.Text)
                                cambioPrim = true;
                            else
                                cambioPrim = false;
                        }
                        if (buscaClavePrimRepetida(getTextActive()) && atributo.TClave == 1&&modificando==false||(buscaClavePrimRepetida(getTextActive())&&cambioPrim))
                            MessageBox.Show("Error clave primaria repetida", "Repetida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (atributo.TClave == 2)
                            {
                                dato = comboExternas.Text;
                                this.Close();
                            }
                            else if (atributo.Tam > textCaptura.Text.Length)
                            {
                                dato = textCaptura.Text;
                                this.Close();
                            }
                            else
                                MessageBox.Show("El tamaño de la cadena excede el tamaño", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            */
        }

        private List<string> llenaCombo(string dirEnt,Diccionario dicc)
        {
            List<string> listaDatos = new List<string>();

            //Obtener la entidad a la que apunta la direccion
            Entidad ent = dicc.getEntByName(dirEnt);
           foreach(List<string> i in ent.ListaRegistros)
                for(int j=0;j<ent.Atributos.Count;j++)
                    if(ent.Atributos[j].TClave==1)
                        listaDatos.Add(i[j]);

            return listaDatos;
            
        }

        private bool llenaComboIndexada(long dirEnt)
        {
            List<string> listaDatos = new List<string>();
            /*
            //Obtener la entidad a la que apunta la direccion
            Entidad ent = diccionario.getEnteByDir(dirEnt);
            //Obtener los datos que que esten en esa entidad
            if (ent.ApuntaDat == -1)
                return false;
            else
            {
                //Obtiene todos los datos en una lista de cadenas
                listaDatos = getDatosPrimariosIndex(ent);

                foreach (string i in listaDatos)
                {
                    comboExternas.Items.Add(i);
                }
            }
            */
            return true;
        }

        private bool buscaClavePrimRepetida(string nNom)
        {
            bool repetido = false;
            Entidad ent = entidad;

            for(int i=0;i<ent.ListaRegistros.Count;i++)
                for(int j=0;j<ent.Atributos.Count;j++)
                    if(ent.Atributos[j].TClave==1)
                        if(ent.ListaRegistros[i][j]==nNom)
                            repetido = true;

            return repetido;
        }

        private List<string> getDatosPrimariosIndex(Entidad ent)
        {
            List<string> auxList = new List<string>();
            long dirDat = ent.ApuntaDat;
            long apuntaDat=0;

            while (dirDat != -1)
            {
                archivo.setStreamPosition(dirDat);
                //lee indice
                archivo.getLong();
                //Lee direccion
                archivo.getLong();
                dirDat = archivo.getLong();
                apuntaDat = archivo.getLong();
                //Ciclo que recorre los datos en busca de atributos primarios
                while (apuntaDat != -1)
                {
                    archivo.setStreamPosition(apuntaDat);
                    //Lee la direccion
                    archivo.getLong();
                    apuntaDat = archivo.getLong();
                    foreach (Atributo i in ent.Atributos)
                    {
                        switch (i.Tipo)
                        {
                            case "int":
                                if (i.TClave == 1)
                                    auxList.Add(archivo.getInt().ToString());
                                else
                                    archivo.getInt();
                                break;
                            case "float":
                                if (i.TClave == 1)
                                    auxList.Add(archivo.getDouble().ToString());
                                else
                                    archivo.getDouble();
                                break;
                            case "char":
                                if (i.TClave == 1)
                                    auxList.Add(archivo.getChar().ToString());
                                else
                                    archivo.getChar();
                                break;
                            case "string":
                                if (i.TClave == 1)
                                    auxList.Add(archivo.getString(i.Tam));
                                else
                                    archivo.getString(i.Tam);
                                break;
                        }
                    }
                }
            }
            return auxList;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            dato.Add("error");
            this.Close();
        }
    }
}
