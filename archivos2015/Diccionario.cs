using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace archivos2015
{
    [Serializable]
    /// <summary>
    /// Clase que contiene el archivo
    /// las entidades y el nombre del diccionariom,
    /// y algunas operaciones de diccionario.
    ///
    /// </summary>
    ///
    public class Diccionario
    {
        private List<Entidad> entidades;
        private string nomDic;

        public Diccionario(string nombre)
        {
            entidades = new List<Entidad>();
            nomDic = nombre;
        }


        #region Getters y setters
        public string NomDic
        {
            get { return nomDic; }
            set { nomDic = value; }
        }
        public List<Entidad> Entidades
        {
            get { return entidades; }
            set { entidades = value; }
        }


        public List<Entidad> Ents
        {
            get { return entidades; }
            set { entidades = value; }
        }
#endregion 

        public bool buscaEntidadRepetida( string nombre)
        {
            foreach (Entidad i in entidades)
            {
                if (i.Nombre == nombre)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///Inserta una entidad 
        /// </summary>
        /// <param name="nombre"></param>

        public void escribeEntidad(string nombre)
        {
            Entidad nEntidad = new Entidad(nombre);
            entidades.Add(nEntidad);
            //ordena elementos
            entidades.Sort((p, q) => string.Compare(p.Nombre, q.Nombre));
            //escribe apuntadores
            actualizaPtr();
        }

        private void actualizaPtr()
        {
            for (int i = 0; i < entidades.Count; i++)
                if (i < (entidades.Count - 1))
                    entidades[i].ApuntaEnt = entidades[i + 1].Dir;
        }

        public void modificaEntidad(string vieja,string nueva)
        {
            //Obtiene la direccion de el primer atributo
            Entidad ent;
            long dirAtri,dirEntN;

            ent = getEntByName(vieja);
            dirAtri = ent.ApuntaAt;

            //Primero elimina la entidad anterior
            elimnaEntidad(vieja);
            //despues inserta la entidad nueva
            escribeEntidad(nueva);
            ent = getEntByName(nueva);
            dirEntN = getDirEnt(nueva);
            ent.ApuntaAt = dirAtri;
        }
        /// <summary>
        /// Funcion que se encarga de eliminar una entidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>

        public Entidad elimnaEntidad(string nombre)
        {
            Entidad aux;

            //Desenlaza las claves externas que apunten a esta entidad
            desenlaza(nombre);

            //elimina en memoria
            for (int i = 0; i < entidades.Count; i++)
            {
                if (entidades[i].Nombre == nombre)
                {
                    aux = entidades[i];
                    if (i == 0 && entidades.Count == 1) //Si va a eliminar el unico elemento
                    {
                        entidades.RemoveAt(i);
                        //Cambio de cabecera
                    }
                    else if (i == 0 && entidades.Count>1)    //Elimina con cambio de cabecera si es el primer elemento
                    {
                        entidades.RemoveAt(i);
                        //Cambio de cabecera
                    }

                    else if (entidades[i].ApuntaEnt == -1)   //Si es el ultimo elemento
                    {
                        entidades[i - 1].ApuntaEnt = -1;
                        //Elimna en archivo
                        entidades.RemoveAt(i);

                    }
                    else        //Si es un elemento intermedio de la lista
                    {
                        entidades[i - 1].ApuntaEnt = entidades[i + 1].Dir;
                        //Cambiar direcciones en archivo
                        entidades.RemoveAt(i);
                    }
                    return aux;
                }
            }
            return null;
        }
        /// <summary>
        /// Desenlaza las claves externas que apunten a esta entidad
        /// </summary>
        /// <param name="selfEnt"></param>

        private void desenlaza(string selfEnt)
        {
            long selfDir = getDirEnt(selfEnt);

            foreach (Entidad i in entidades)
                if (i.Nombre != selfEnt)
                    foreach (Atributo j in i.Atributos)
                        if (j.ApuntaPrim == selfDir)
                        {
                            //en memoria
                            j.ApuntaPrim = -1;
                            //en archivo
                            //Cambia tipo de clave
                            j.TClave = 3;
                        }
        }
        /// <summary>
        /// obtiene la direccion de la entidad especificada
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>

        public long getDirEnt(string nombre)
        {
            for (int i=0; i < entidades.Count; i++)
                if (entidades[i].Nombre == nombre)
                    return entidades[i].Dir;

            return (long)-1;
        }
        /// <summary>
        /// Obtiene su direccion en archivo y lo escribe en el
        /// </summary>
        /// <param name="atr"></param>
        /// <param name="nombreEnt"></param>

        public void insertaAtributo(Atributo atr, string nombreEnt)
        {
            //Busca la entidad
             for (int i=0; i < entidades.Count; i++)
                 if (entidades[i].Nombre == nombreEnt)
                 {
                     //Obtiene direccion de archivo 
                     //inserta en el archivo
                     //inserta en memoria
                     entidades[i].insertaAtributo(atr);
                     //ordena atributos en archivo
                     //Cambia el apuntador a atributos de la entidad
                     //En memoria
                     entidades[i].ApuntaAt = entidades[i].Atributos[0].Direccion;
                     //En archivo
                 }
        }
        /// <summary>
        /// obtiene los atributos de la entidad dada
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>Lista de atributos</returns>

        public List<Atributo> getAtributos(string entidad)
        {
            for (int i=0; i < entidades.Count; i++)
                if (entidades[i].Nombre == entidad)
                    return entidades[i].Atributos;

            return null;
        }
        /// <summary>
        /// obtiene el nombre de las entidades con clave primaria
        /// </summary>
        /// <param name="self"></param>
        /// <returns>Lista de cadenas</returns>

        public List<string> getNomEnts(string self)
        {
            List<string> nomEnts = new List<string>();

            for (int i = 0; i < entidades.Count; i++)
                if(entidades[i].Nombre!=self)
                    for (int j = 0; j < entidades[i].Atributos.Count; j++)
                        if(entidades[i].Atributos[j].TClave==1)
                            nomEnts.Add(entidades[i].Nombre);

            return nomEnts;
        }
        /// <summary>
        /// busca si el atributo esta repetido
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="nomAtri"></param>
        /// <returns>cierto, si es repetido falso si no hay repetidos</returns>

        public bool buscaAtributoRepetido(string entidad,string nomAtri)
        {
            for (int i=0; i < entidades.Count; i++)
                if (entidades[i].Nombre == entidad)
                    for (int j = 0; j < entidades[i].Atributos.Count; j++)
                        if (entidades[i].Atributos[j].Nombre == nomAtri)
                            return true;

            return false;
        }
        /// <summary>
        /// busca si la entidad que llega por parametro ya tiene claves primarias
        /// </summary>
        /// <param name="nomEntidad"></param>
        /// <returns>cierto, si encontró al menos una.</returns>

        public bool buscaPrimarias(string nomEntidad)
        {
            foreach (Entidad i in entidades)
                if(i.Nombre==nomEntidad)
                    foreach (Atributo j in i.Atributos)
                        if (j.TClave == 1)
                            return true;

            return false;
        }

        //Funcion que quita un atributo de memoria y de un archivo
        public void eliminaAtributo(string nomEntidad, string nomAtributo)
        {
            foreach(Entidad i in entidades)
                if(i.Nombre==nomEntidad)
                    for(int j=0;j<i.Atributos.Count;j++)
                        //Si econtró el atributo a eliminar
                        if (i.Atributos[j].Nombre == nomAtributo)
                        {
                            if (i.Atributos[j].TClave == 1)
                            {
                                //Desenlaza las claves secundarias a ese atributo
                                desenlazaAtributos(i);
                            }
                            //Si solo hay un atributo
                            if (i.Atributos.Count == 1)
                            {
                                //En archivo
                                //En memoria
                                i.ApuntaAt = -1;
                                i.Atributos.RemoveAt(j);
                            }
                            //Si es el ultimo elemento
                            else if (j == i.Atributos.Count - 1)
                            {
                                //En archivo
                                //En memoria
                                i.Atributos[j - 1].ApuntaAtri = -1;
                                i.Atributos.RemoveAt(j);
                            }
                            //Si es el primer elemento
                            else if (j == 0)
                            {
                                //en archivo
                                //en memoria
                                i.ApuntaAt = i.Atributos[j + 1].Direccion;
                                i.Atributos.RemoveAt(0);
                            }
                            //Si es elemento intermedio
                            else
                            {
                                //en archivo
                                //en memoria
                                i.Atributos[j - 1].ApuntaAtri = i.Atributos[j + 1].Direccion;
                                i.Atributos.RemoveAt(j);
                            }
                        }
        }

        private void desenlazaAtributos(Entidad ent)
        {
            foreach (Entidad i in entidades)
                if (i.Dir != ent.Dir)
                    foreach (Atributo j in i.Atributos)
                        if (j.TClave == 2)
                            if (j.ApuntaPrim == ent.Dir)
                            {
                                //Quita el enlace 
                                j.ApuntaPrim = -1;
                                //Cambia el tipo de clave
                                j.TClave = 3;
                            }
        }

        /// <summary>
        /// Reescribe la totalidad del archivo quitando los elementos eliminados
        /// </summary>
        public void mantenimiento()
        {
            string auxNom = nomDic.Substring(0, nomDic.Length - 3);
            //Se crea un archivo de respaldo
            Archivo respaldo = new Archivo(auxNom+"bk",true);
            List<Entidad> respList = new List<Entidad>();
            respList = entidades;
            string nomEnt="";

            respaldo.escribeCabecera(respList[0].Dir);
            //Cambia direcciones
            foreach (Entidad i in respList)
            {
                //cambia la direccion de la entidad en memoria
                i.Dir = respaldo.getDir();
                //escribe en archivo la direccion de la entidad
                respaldo.escribeEntidad(i);
                //si hay atributos
                if (i.ApuntaAt != -1)
                {
                    //se llena el apuntador de la entidad con la dir del atributo
                    i.ApuntaAt = respaldo.getDir();
                    respaldo.escribePtrAtEnt(i.Dir, i.ApuntaAt);
                    //recorre los atributos
                    foreach (Atributo j in i.Atributos)
                    {
                        j.Direccion = respaldo.getDir();
                        respaldo.escrbeAtributo(j);
                        //si hay otro atributo
                        if (j.ApuntaAtri != -1)
                        {
                            //cambia el apuntador a siguiente 
                            j.ApuntaAtri = respaldo.getDir();
                            respaldo.escribePtrAtAtri(j.Direccion, j.ApuntaAtri);
                        }
                        //cambia la direccion de apunta a entidad
                        j.ApuntaEntidad = i.Dir;
                        //Cambia la direccion de apuntador a entidad
                        respaldo.escribePtrEntAtr(j.Direccion, j.ApuntaEntidad);
                    }
                }
                if (i.ApuntaEnt != -1)
                {
                    i.ApuntaEnt = respaldo.getDir();
                    respaldo.escribePtrEntEnt(i.Dir, i.ApuntaEnt);
                }
            }
            //recorre otra vez para cambiar las direcciones de los apuntadores a claves primarias
            foreach (Entidad i in respList)
                foreach (Atributo j in i.Atributos)
                    if (j.ApuntaPrim != -1)
                    {
                        foreach (Entidad k in respList)
                            if (k.Nombre == nomEnt)
                            {
                                j.ApuntaPrim = k.Dir;
                                respaldo.escribePrimA(j.Direccion, j.ApuntaPrim);
                            }
                    }
        }

        /// <summary>
        /// Crea el diccionario a partir de un archivo existente
        /// </summary>

        /// <summary>
        /// Busca que en todas las entidades exista clave primaria
        /// </summary>
        /// <returns></returns>
        public bool bucaPrimarias()
        {
            bool encontro = false;

            foreach (Entidad i in entidades)
            {
                foreach (Atributo j in i.Atributos)
                    if (j.TClave == 1)
                        encontro = true;
                if (encontro == false)
                    return false;
                else
                    encontro = false;
            }
            encontro = true;

            return encontro;
        }

        public Entidad getEntByName(string nombre)
        {
            foreach (Entidad i in entidades)
                if (i.Nombre == nombre)
                    return i;

            return null;
        }

        /// <summary>
        /// regresa una entidad si se busca por su direccion
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public Entidad getEnteByDir(long dir)
        {
            foreach (Entidad i in entidades)
                if (i.Dir == dir)
                    return i;
            return null;
        }

    }
}
