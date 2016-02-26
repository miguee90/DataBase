using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace archivos2015
{
    public partial class Form1 : Form
    {
        private Diccionario diccionario;
        private bool modE,delE,delA,modA,org;
        private Manager manejador;

        public Form1(Manager man)
        {
            InitializeComponent();
            modE = false;
            delE = false;
            delA = false;
            modA = false;
            org = false;
            manejador = man;
            NDic nuevo = new NDic();
            if (nuevo.ShowDialog() == DialogResult.OK)
            {
                this.Text = nuevo.NombreDic;
                inicializaNuevo();
                diccionario = new Diccionario(this.Text);
                manejador.Bases.Add(diccionario);
            }
            else
            {
                inicializaTodo();
            }
            foreach(Diccionario i in manejador.Bases)
            {
                comboBD.Items.Add(i.NomDic);
            }
        }

        #region clicks en el menu
        private void nuevoDiccionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NDic nuevo = new NDic();
            if (nuevo.ShowDialog() == DialogResult.OK)
            {
                this.Text = nuevo.NombreDic;
                inicializaNuevo();
                diccionario = new Diccionario(this.Text);
            }
        }

        private void abriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = Path.GetFileName(openFileDialog1.FileName);
                diccionario = new Diccionario(this.Text);
                //Inicializa campos visibles y activados
                iniciaAbrir();

            }
        }

        private void secuencialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verifica que todas las entidades tengan su clave primara
            if (diccionario.bucaPrimarias())
            {
                if (MessageBox.Show("Cuando abres una organizacion de datos ya no podras modificar el diccionario \n ¿Deseas continuar",
                    "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    secuencial ventana = new secuencial(diccionario);

                    org = true;

                    ventana.ShowDialog();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Aun faltan entidades de clave primaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void indexadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verifica que todas las entidades tengan su clave primara
            if (diccionario.bucaPrimarias())
            {
                if (MessageBox.Show("Cuando abres una organizacion de datos ya no podras modificar el diccionario \n ¿Deseas continuar",
                    "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    Indexada ventana = new Indexada(diccionario);

                    org = true;

                    ventana.ShowDialog();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Aun faltan entidades de clave primaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void multilistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Verifica que todas las entidades tengan su clave primara
            if (diccionario.bucaPrimarias())
            {
                if (MessageBox.Show("Cuando abres una organizacion de datos ya no podras modificar el diccionario \n ¿Deseas continuar",
                    "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    Multillaves multi = new Multillaves(diccionario);

                    org = true;

                    multi.ShowDialog();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Aun faltan entidades de clave primaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private void inicializaNuevo()
        {
            groupEntidad.Visible = true;
            groupAtriubuto.Visible = false;
            groupAtri.Visible = false;
            groupBotonA.Enabled = false;
            buttonMod.Enabled = false;
            buttonDel.Enabled = false;
            groupName.Visible = false;
        }

        private void inicializaTodo()
        {
            groupEntidad.Visible = true;
            groupAtriubuto.Visible = true;
            groupAtri.Visible = true;
            groupBotonA.Enabled = true;
            buttonMod.Enabled = true;
            buttonDel.Enabled = true;
            groupName.Visible = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            groupName.Visible = true;
            textEnt.Focus();
            groupBotones.Text = "Agregar entidad";
            buttonDel.Enabled = true;
            buttonMod.Enabled = true;
            modE = false;
            delE = false;
            modA = false;
        }

        private void textEnt_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2500;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.BackColor = Color.Aqua;
            tt.Show("Presiona ENTER para guardar tu entidad", TB, 120, -45, VisibleTime);
        }

        private void textEnt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textEnt.Text != string.Empty)
                {
                    //Busca si la entidad a agregar esta repetida
                    if (diccionario.buscaEntidadRepetida(textEnt.Text))
                        MessageBox.Show("El nombre de la entidad esta repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        groupAtriubuto.Visible = true;
                        groupBotonA.Enabled = true;
                        buttonAddA.Enabled = true;
                        if (modE)
                        {
                            if (MessageBox.Show("Estas seguro que quieres modificar la entidad " + 
                                dataGridEntidad.SelectedRows[0].Cells[0].Value.ToString()
                                + " por "+textEnt.Text+"?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
                                == DialogResult.OK)
                            {
                                diccionario.modificaEntidad(dataGridEntidad.SelectedRows[0].Cells[0].Value.ToString(), textEnt.Text);
                                llenaDataE();
                                groupName.Visible = false;
                            }
                        }
                        else
                        {
                            diccionario.escribeEntidad(textEnt.Text);
                            textEnt.Text = "";
                            groupName.Visible = false;
                            llenaDataE();
                        }
                    }
                }
            }
        }

        private void llenaDataE()
        {
            List<Entidad> entidades= new List<Entidad>();

            entidades = diccionario.Ents;
            dataGridEntidad.Rows.Clear();

            if(entidades!=null)
                for (int i = 0; i < entidades.Count; i++)
                    dataGridEntidad.Rows.Add(entidades[i].Nombre, entidades[i].ApuntaEnt, entidades[i].ApuntaAt, entidades[i].Dir, entidades[i].ApuntaDat);
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            labelAvisos.Visible = true;
            labelAvisos.Text = "Selecciona la entidad que quieres modificar";
            groupName.Visible = true;
            groupName.Text = "Escrbe el nombre de la nueva entidad";
            modE = true;
            delE = false;
        }
        
        private void dataGridEntidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modE)
                textEnt.Text = dataGridEntidad.SelectedRows[0].Cells[0].Value.ToString();
            groupAtriubuto.Text = dataGridEntidad.SelectedRows[0].Cells[0].Value.ToString();
            llenaDataA();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            labelAvisos.Visible = true;
            labelAvisos.Text = "Da doble clic en la entidad que quieres eliminar";
            groupName.Visible = false;
            groupName.Text = "";
            delE = true;
            modE = false;
        }
        /// <summary>
        /// Doble click en el datagrid de entidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dataGridEntidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (delE)
            {
                if (MessageBox.Show("Estas seguro que deseas eliminar la entidad " +
                    dataGridEntidad.SelectedRows[0].Cells[0].Value.ToString() + "?", "Advertncia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    diccionario.elimnaEntidad(dataGridEntidad.SelectedRows[0].Cells[0].Value.ToString());
                    llenaDataE();
                }
            }
        }

        /// <summary>
        /// boton para agregar nuevo atributo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddA_Click(object sender, EventArgs e)
        {
            groupAtriubuto.Text = dataGridEntidad.SelectedRows[0].Cells[0].Value.ToString();
            groupAtri.Visible = true;
            dataGridAtr.Enabled = true;
            labelAvisosA.Text = "Agregando atributos";
            delA = false;
            modA = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string primEnt = "";
            bool fueError = false;
            Atributo atr;

            if (modA == true)
                diccionario.eliminaAtributo(groupAtriubuto.Text, textNomA.Text);

            if (textNomA.Text == string.Empty || comboTipo.Text == string.Empty
                || (radioPrimaria.Checked == false &&
                radioExterna.Checked == false && radioNinguna.Checked == false))
            {
                MessageBox.Show("Llena todos los campos necesarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                buttonModA.Enabled = true;
                buttonDelA.Enabled = true;

                if (getRadioClv() == 2 && comboEntidad.Text==string.Empty)
                {
                    fueError = true;
                    MessageBox.Show("Enlaza a la entidad con clave primaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (getRadioClv() == 2)
                {
                    primEnt = comboEntidad.Text;
                }
                //Area de insercion de datos
                if(diccionario.buscaAtributoRepetido(groupAtriubuto.Text,textNomA.Text))
                {
                    MessageBox.Show("Atributo repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (getRadioClv() == 1)
                    {
                        //Buscar que la entidad no tenga mas claves primarias
                        if (diccionario.buscaPrimarias(groupAtriubuto.Text))
                        {
                            MessageBox.Show("Ya existe una clave primaria en esta entidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fueError = true;
                        }
                    }

                    if (fueError == false)
                    {
                        if (comboTipo.Text == "string")
                        {
                            //Se crea el objeto Atributo
                            atr = new Atributo(textNomA.Text, comboTipo.Text, (int)numericUpDown1.Value,
                                getRadioClv(), diccionario.getDirEnt(groupAtriubuto.Text), (long)-1, (long)-1, primEnt);
                        }
                        else if (comboTipo.Text == "char")
                        {
                            //Se crea el objeto Atributo
                            atr = new Atributo(textNomA.Text, comboTipo.Text, (int)1,
                                getRadioClv(), diccionario.getDirEnt(groupAtriubuto.Text), (long)-1, (long)-1, primEnt);
                        }
                        else if(comboTipo.Text=="int")
                        {
                            //Se crea el objeto Atributo
                            atr = new Atributo(textNomA.Text, comboTipo.Text, (int)4,
                                getRadioClv(), diccionario.getDirEnt(groupAtriubuto.Text), (long)-1, (long)-1, primEnt);
                        }
                        else
                        {
                            //Se crea el objeto Atributo
                            atr = new Atributo(textNomA.Text, comboTipo.Text, (int)8,
                                getRadioClv(), diccionario.getDirEnt(groupAtriubuto.Text), (long)-1, (long)-1, primEnt);
                        }
                        //se inserta en el diccionario
                        diccionario.insertaAtributo(atr, groupAtriubuto.Text);
                        //actualiza el datagrd
                        llenaDataA();
                        llenaDataE();
                    }
                }
            }
            //Limpia los campos
            limpiaCamposA();
        }

        private void limpiaCamposA()
        {
            textNomA.Text = "";
            comboTipo.Text = "";
            radioNinguna.Checked = true;
            comboEntidad.Text = "";
            numericUpDown1.Value = 1;
        }

        private void comboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboTipo.Text == "string")
            {
                labelTam.Visible = true;
                numericUpDown1.Visible = true;
            }
            else
            {
                labelTam.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private int getRadioClv()
        {
            if (radioPrimaria.Checked == true)
                return 1;
            else if (radioExterna.Checked==true)
                return 2;
            else
                return 3;
        }

        /// <summary>
        /// Llena el datagrid de los atributos
        /// </summary>
        private void llenaDataA()
        {
            List<Atributo> atributos = new List<Atributo>();

            dataGridAtr.Rows.Clear();
            //obtiene los atributos de la entidad que se encuentre seleccionada 
            atributos = diccionario.getAtributos(groupAtriubuto.Text);
            if(atributos!=null)
                for (int i = 0; i < atributos.Count; i++)
                {
                    dataGridAtr.Rows.Add(atributos[i].Nombre,atributos[i].Tipo,atributos[i].Tam,atributos[i].TClave,
                        atributos[i].ApuntaEntidad,atributos[i].ApuntaAtri,atributos[i].Direccion,atributos[i].ApuntaPrim);
                }
        }

        /// <summary>
        /// Click en el boton para eliminar atributos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelA_Click(object sender, EventArgs e)
        {
            groupAtri.Visible = false;
            labelAvisosA.Text = "Da doble click en en el atributo que deseas eliminar";
            delA = true;
            modA = false;
        }

        /// <summary>
        /// Doble click en el datagrid de atributos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridAtr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (delA == true)
            {
                //elimina el atributo seleccionado
                if (MessageBox.Show("Estas seguro de eliminar el atributo " +
                    dataGridAtr.SelectedRows[0].Cells[0].Value.ToString() + "?", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    diccionario.eliminaAtributo(groupAtriubuto.Text,dataGridAtr.SelectedRows[0].Cells[0].Value.ToString());
                    llenaDataE();
                    llenaDataA();
                }
            }
        }

        /// <summary>
        /// Boton de modificar el atributo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModA_Click(object sender, EventArgs e)
        {
            modA = true;
            groupAtri.Visible = true;
            labelAvisosA.Text = "Selecciona el atrubuto que deseas modificar luego da click en guardar";
        }

        /// <summary>
        /// Click para seleccionar el atributo a modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridAtr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modA == true)
            {
                //Carga los atributos en los campos 
                textNomA.Text = dataGridAtr.SelectedRows[0].Cells[0].Value.ToString();
                comboTipo.Text = dataGridAtr.SelectedRows[0].Cells[1].Value.ToString();
                if (dataGridAtr.SelectedRows[0].Cells[1].Value.ToString() == "string")
                {
                    numericUpDown1.Visible = true;
                    labelTam.Visible = true;
                    numericUpDown1.Value = (int)dataGridAtr.SelectedRows[0].Cells[2].Value;
                }
                else
                {
                    numericUpDown1.Visible = false;
                    labelTam.Visible = false;
                }
                setRadio((int)dataGridAtr.SelectedRows[0].Cells[3].Value);
            }
        }

        /// <summary>
        /// Establece uno de los 3 radio buttons
        /// </summary>
        /// <param name="r"></param>
        private void setRadio(int r)
        {
            if (r == 1)
                radioPrimaria.Checked = true;
            else if (r == 2)
                radioExterna.Checked = true;
            else
                radioNinguna.Checked = true;
        }

        private void iniciaAbrir()
        {
            groupEntidad.Visible = true;
            groupAtriubuto.Visible = true;
            groupAtri.Enabled = true;
            dataGridAtr.Enabled = true;
            buttonAddA.Enabled = true;
            buttonModA.Enabled = true;
            buttonDelA.Enabled = true;
            llenaDataE();
            llenaDataA();
        }

        private void comboEntidad_SelectedValueChanged(object sender, EventArgs e)
        {
            string texto = comboEntidad.Text;
            Entidad auxEnt;

            auxEnt = diccionario.getEntByName(texto);
            foreach (Atributo i in auxEnt.Atributos)
            {
                if (i.TClave == 1)
                {
                    textNomA.Text = i.Nombre;
                    comboTipo.Text = i.Tipo;
                    if (i.Tipo == "string")
                        numericUpDown1.Value = Convert.ToInt32(i.Tam);
                }
            }
        }

        /// <summary>
        /// Desactiva los controles cuando se selecciona una clave externa
        /// </summary>
        private void desactivaExterna()
        {
            textNomA.Enabled = false;
            comboTipo.Enabled = false;
            numericUpDown1.Enabled = false;
        }

        private void comboBD_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach(Diccionario i in manejador.Bases)
            {
                if(i.NomDic==comboBD.Text)
                {
                    diccionario = i;
                    llenaDataE();
                    llenaDataA();
                    inicializaTodo();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Diccionario baseActual = manejador.getBDbyName(comboBD.Text);

            if (!baseActual.bucaPrimarias())
            {
                MessageBox.Show("Error todas las entidades deben tener una clave primaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void activaExterna()
        {
            textNomA.Enabled = true;
            comboTipo.Enabled = true;
            numericUpDown1.Enabled = true;
        }

#region radiob-button checked
        private void radioPrimaria_CheckedChanged(object sender, EventArgs e)
        {
            if(radioPrimaria.Checked)
                activaExterna();
        }

        private void radioExterna_CheckedChanged(object sender, EventArgs e)
        {
            List<string> nomEntidades;

            if (radioExterna.Checked == true)
            {
                comboEntidad.Visible = true;
                //Obtiene los nombres de entidades y los coloca en el combo-box
                nomEntidades = diccionario.getNomEnts(groupAtriubuto.Text);
                if (nomEntidades.Count > 0)
                {
                    comboEntidad.DataSource = nomEntidades;
                    desactivaExterna();
                }
                else
                {
                    MessageBox.Show("No hay entidades con claves primaria a que enlazar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                comboEntidad.Visible = false;
        }   

        private void radioNinguna_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNinguna.Checked == true)
                activaExterna();
        }
#endregion

    }
}
