using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    [Serializable]
    /// <summary>
    /// Clase entidad
    /// </summary>
    public class Entidad
    {
        private long ptr_atributos;
        private long direccion;
        private long ptr_entidad;
        private List<Atributo> atributos;
        private long ptr_datos;
        private string nombre;
        List<Bloque> bloques;
        /*****************************************BD*********************************************/
        private List<List<string>> listaRegistros = new List<List<string>>();

        public Entidad(string nom)
        {
            nombre = nom;
            atributos = new List<Atributo>();
            bloques = new List<Bloque>();
            Atributo fechaA = new Atributo("fecha_A", "string", 8, 3, 0, 0, 0, "");
            Atributo fechaB = new Atributo("fecha_B", "string", 8, 3, 0, 0, 0, "");
            Atributo fechaM = new Atributo("fecha_M", "string", 8, 3, 0, 0, 0, "");
            Atributo usuarioA = new Atributo("usuario_A", "string", 8, 3, 0, 0, 0, "");
            Atributo usuarioB = new Atributo("usuario_B", "string", 8, 3, 0, 0, 0, "");
            Atributo usuarioM = new Atributo("usuario_M", "string", 8, 3, 0, 0, 0, "");
            atributos.Add(fechaA);
            atributos.Add(fechaB);
            atributos.Add(fechaM);
            atributos.Add(usuarioA);
            atributos.Add(usuarioB);
            atributos.Add(usuarioM);
            listaRegistros = new List<List<string>>();
        }

        public void insertaAtributo(Atributo atr)
        {
            atributos.Insert(0, atr);
        }

        private void actualizaPtrs()
        {
            for (int i = 0; i < atributos.Count; i++)
                if(i<=(atributos.Count-2))
                    atributos[i].ApuntaAtri = atributos[i + 1].Direccion;
        }

        /// <summary>
        /// Modifica datos
        /// </summary>
        /// <param name="dats"></param>
        public void modDatos(List<string> dats,User user,List<string> viejo)
        {
            List<string> registro = getRegMod(viejo);
            int i = 0;
            int k = 0;

            for(;i<dats.Count;i++)
            {
                registro[i] = dats[i];
                k++;
            }
            //Fecha de modificacion
            registro[k + 2] = DateTime.Today.ToShortDateString();
            registro[k + 5] = user.Nombre;
        }

        public void modDatCascada(List<string> dats,User user,Diccionario dic,List<string> regV)
        {
            string clavePrim="",claveOldPrim="";

            List<string> registroViejo = getRegMod(regV);

            for (int i = 0; i < atributos.Count; i++)
                if (atributos[i].TClave == 1)
                {
                    clavePrim = dats[i];
                    claveOldPrim = registroViejo[i];
                }
            //Modifica la bitacora
            modDatos(dats, user,regV);

            //Algoritmo para buscar y modificar en casacada
            for(int i =0;i<dic.Entidades.Count;i++)
            {
                for(int j=0;j<dic.Entidades[i].atributos.Count;j++)
                {
                    if(dic.Entidades[i].atributos[j].ApuntaPrim==nombre)
                    {
                        for(int k=0;k<dic.Entidades[i].listaRegistros.Count;k++)
                        {
                            if(dic.Entidades[i].listaRegistros[k][j]==claveOldPrim)
                            {
                                dic.Entidades[i].listaRegistros[k][j] = clavePrim;
                            }
                        }
                    }
                }
            }
        }

        private List<string> getRegMod(List<string> dats)
        {
            List<string> resnull = new List<string>();

            for(int i=0;i<listaRegistros.Count;i++)
            { 
                for(int j=0;j<atributos.Count;j++)
                {
                    if(atributos[j].TClave==1)
                    {
                        if (dats[j] == listaRegistros[i][j])
                            return listaRegistros[i];
                    }
                }
            }

            return resnull;
        }

        public void eliminaReg(List<string> regViejo, Diccionario baseDatos)
        {

            eliminaCascada(baseDatos, nombre, regViejo);

            for (int i = 0; i < listaRegistros.Count; i++)
                for (int j = 0; j < atributos.Count-6; j++)
                    if (atributos[j].TClave == 1)
                        if (regViejo[j] == listaRegistros[i][j])
                            listaRegistros.RemoveAt(i);
        }

        public void eliminaRegLog(List<string> regViejo, Diccionario baseDatos,User user)
        {

            eliminaCascadaLog(baseDatos, nombre, regViejo,user);

            for (int i = 0; i < listaRegistros.Count; i++)
                for (int j = 0; j < atributos.Count - 6; j++)
                    if (atributos[j].TClave == 1)
                        if (regViejo[j] == listaRegistros[i][j])
                        {
                            listaRegistros[i][listaRegistros[i].Count - 5] = DateTime.Today.ToShortDateString();
                            listaRegistros[i][listaRegistros[i].Count - 2] = user.Nombre;
                        }
        }

        private void eliminaCascada(Diccionario baseDatos,string entidad,List<string> datos)
        {
            List<string> aux = new List<string>();
            Entidad enti = baseDatos.getEntByName(entidad);

            foreach (Entidad i in baseDatos.Entidades)
                if (i.nombre != entidad)
                    for (int j = 0; j < i.Atributos.Count-6; j++)
                        if (i.atributos[j].ApuntaPrim == entidad)
                            for(int l=0;l<enti.atributos.Count;l++)
                                if(enti.atributos[l].TClave==1)
                                    for (int k=0;k<enti.ListaRegistros.Count;k++)
                                        if (datos[l] == i.listaRegistros[k][j])
                                        {
                                            aux = i.listaRegistros[k];
                                            i.ListaRegistros.Remove(i.listaRegistros[k]);
                                            eliminaCascada(baseDatos, i.nombre, aux);
                                            return;
                                        }

        }

        private void eliminaCascadaLog(Diccionario baseDatos, string entidad, List<string> datos,User user)
        {
            List<string> aux = new List<string>();
            Entidad enti = baseDatos.getEntByName(entidad);

            foreach (Entidad i in baseDatos.Entidades)
                if (i.nombre != entidad)
                    for (int j = 0; j < i.Atributos.Count - 6; j++)
                        if (i.atributos[j].ApuntaPrim == entidad)
                            for (int l = 0; l < enti.atributos.Count; l++)
                                if (enti.atributos[l].TClave == 1)
                                    for (int k = 0; k < enti.ListaRegistros.Count; k++)
                                        if (datos[l] == i.listaRegistros[k][j])
                                        {
                                            i.ListaRegistros[k][i.ListaRegistros[k].Count - 5] = DateTime.Today.ToShortDateString();
                                            i.ListaRegistros[k][i.ListaRegistros[k].Count - 2] = user.Nombre;
                                            eliminaCascadaLog(baseDatos, i.nombre, i.ListaRegistros[k], user);
                                            return;
                                        }

        }

        #region Getter y setters
        public string Nombre
        {
            get{ return nombre; }
        }

        public List<Bloque> ListBloq
        {
            get { return bloques; }
        }

        public List<List<string>> ListaRegistros
        {
            get { return listaRegistros; }
        }

        public long ApuntaEnt
        {
            get { return ptr_entidad; }
            set { ptr_entidad = value; }
        }

        public long ApuntaAt
        {
            get { return ptr_atributos; }
            set { ptr_atributos = value; }
        }

        public long Dir
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public long ApuntaDat
        {
            get{ return ptr_datos; }
            set { ptr_datos = value; }
        }

        public List<Atributo> Atributos
        {
            get { return atributos; }
            set { atributos = value; }
        }
        #endregion
    }
}
