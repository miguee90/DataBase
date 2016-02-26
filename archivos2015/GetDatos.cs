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
        private string dato;
        private Atributo atributo;
        private Diccionario diccionario;
        private Organizacion organizacion;
        private Entidad entidad;
        private Archivo archivo;
        bool noSecu;
        string viejo;
        bool cambioPrim;
        bool modificando;

        public bool CambioPrim
        {
            get { return cambioPrim; }
        }

        public GetDatos(Atributo atri,Diccionario dic,Entidad ent)
        {
            InitializeComponent();
            atributo = atri;
            diccionario = dic;
            entidad = ent;
            noSecu = false;
            viejo = "";
            modificando = false;
            cambioPrim = false;
            groupCaptura.Text = atributo.Nombre+"("+atributo.Tipo+")";
            if (atributo.TClave == 2)
            {
                textCaptura.Visible = false;
                comboExternas.Visible = true;
                //Llena el combo con los datos de clave primaria
                if (!llenaCombo(atributo.ApuntaPrim,diccionario))
                {
                    MessageBox.Show("Error aun no existen datos para llenar la clave externa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dato = "error";
                    this.Close();
                }
            }
        }

        public GetDatos(Atributo atri,string dato,bool mod,Diccionario baseAc,Entidad ent)
        {
            InitializeComponent();
            atributo = atri;
            diccionario = baseAc;
            noSecu = false;
            viejo = dato;
            modificando = mod;
            groupCaptura.Text = atributo.Nombre + "(" + atributo.Tipo + ")";
            textCaptura.Text = dato;
            cambioPrim = false;
            entidad = ent;
            if (atributo.TClave == 2)
            {
                textCaptura.Visible = false;
                comboExternas.Visible = true;
                //Llena el combo con los datos de clave primaria
                if (!llenaCombo(atributo.ApuntaPrim, diccionario))
                {
                    MessageBox.Show("Error aun no existen datos para llenar la clave externa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dato = "error";
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Constructor para modificaciones
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
                }*/
            }
        }

        public string Dato
        {
            get { return dato; }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
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
        }

        private bool llenaCombo(string dirEnt,Diccionario dicc)
        {
            List<string> listaDatos = new List<string>();

            //Obtener la entidad a la que apunta la direccion
            Entidad ent = dicc.getEntByName(dirEnt);
           foreach(List<string> i in ent.ListaRegistros)
                for(int j=0;j<ent.Atributos.Count;j++)
                    if(ent.Atributos[j].TClave==1)
                        listaDatos.Add(i[j]);
            if (listaDatos.Count > 0)
            {
                foreach (string i in listaDatos)
                    comboExternas.Items.Add(i);

                return true;
            }
            else
                return false;
        }

        private bool llenaComboIndexada(long dirEnt)
        {
            List<string> listaDatos = new List<string>();

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

        private string getTextActive()
        {
            string res="";

            if (comboExternas.Visible == true)
                res = comboExternas.Text;
            else if (textCaptura.Visible == true)
                res = textCaptura.Text;

            return res;
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
    }
}
