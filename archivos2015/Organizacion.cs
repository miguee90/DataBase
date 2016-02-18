using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    /// <summary>
    /// Clase organizacion 
    /// contiene funciones para la organizacion
    /// secuencial.
    /// </summary>
    public class Organizacion
    {
        Diccionario diccionario;
        Archivo archivo;

        public Diccionario Dic
        {
            get { return diccionario; }
        }

        public Organizacion(Diccionario dic,string ext)
        {
            string nombre;
            diccionario = dic;
            nombre=diccionario.NomDic.Substring(0,diccionario.NomDic.Length-3);
            archivo = new Archivo(nombre,ext);
        }

        public void abreDesdeArchivo(string nombre)
        {
            archivo = new Archivo("orgs/"+nombre, false);
            diccionario.Entidades = new List<Entidad>();
            diccionario.NomDic = nombre;

            long dir = archivo.getEncabezado();

            while (dir != -1)
            {
                //Obtiene el bloque de la entidad
                Entidad entida = archivo.getBloqueEntidad(dir);
                long nextAr = entida.ApuntaAt;
                //Si tiene atributos
                while (nextAr != -1)
                {
                    Atributo atri;
                    //Obtiene el bloque del atributo
                    atri = archivo.getBloqueAtributo(nextAr);
                    entida.Atributos.Add(atri);
                    nextAr = atri.ApuntaAtri;
                }
                //Si tiene datos
                long nextBloq = entida.ApuntaDat;
                while (nextBloq != -1)
                {
                    Bloque bloq;

                    bloq = archivo.getBloqueDatos(nextBloq);
                    entida.ListBloq.Add(bloq);
                    nextBloq = bloq.ApuntaDato;
                }
                diccionario.Entidades.Add(entida);
                dir = entida.ApuntaEnt;
            }
        }

        /// <summary>
        /// Inserta un bloque en el archivo
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="nomDat"></param>
        public void insertaBloqueDatos(Entidad ent,List<string> nomDat)
        {
            Bloque bloque;
            long dirBloque = 0;

            //toma la direccion que tendra el bloque
            dirBloque = archivo.getLength();
            bloque = new Bloque(dirBloque, (long)-1);
            ent.ListBloq.Add(bloque);
            //escribe en archivo el bloque
            archivo.escribeBloque(bloque);
            //escribe los atributos en archivo
            for(int i=0;i<ent.Atributos.Count;i++)
            {
                insertaAtDato(ent.Atributos[i], nomDat[i]);
            }
            //Reescribe las direcciones de la lista
            reescribeDirsDatos(ent);
        }

        /// <summary>
        /// Modifica datos a excepcion de la clave primaria
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="ent"></param>
        /// <param name="datos"></param>
        public void modificaBloque(long dir, Entidad ent,List<string> datos)
        {
            archivo.setStreamPosition(dir);
            archivo.getLong();
            archivo.getLong();
            for (int a = 0; a < ent.Atributos.Count;a++)
            {
                switch (ent.Atributos[a].Tipo)
                {
                    case "int":
                        if (ent.Atributos[a].TClave != 1)
                            archivo.escribeInt(Convert.ToInt32(datos[a]));
                        else
                            archivo.getInt();
                        break;
                    case "float":
                        if (ent.Atributos[a].TClave != 1)
                            archivo.escribeFloat(Convert.ToDouble(datos[a]));
                        else
                            archivo.getDouble();
                        break;
                    case "char":
                        if (ent.Atributos[a].TClave != 1)
                            archivo.escribeChar(Convert.ToChar(datos[a]));
                        else
                            archivo.getChar();
                        break;
                    case "string":
                        if (ent.Atributos[a].TClave != 1)
                            archivo.escribeString(datos[a], ent.Atributos[a].Tam);
                        else
                            archivo.setStreamPosition(archivo.Positon + ent.Atributos[a].Tam);
                        break;
                }
            }
        }

        /// <summary>
        /// Inserta el dato de acuerdo a su tipo en el archivo
        /// </summary>
        /// <param name="atr"></param>
        /// <param name="value"></param>
        private void insertaAtDato(Atributo atr, string value)
        {
            switch (atr.Tipo)
            {
                case "int":
                    //escribe entero en archivo
                    archivo.escribeInt(Convert.ToInt32(value));
                    break;
                case "float":
                    archivo.escribeFloat(Convert.ToDouble(value));
                    break;
                case "char":
                    archivo.escribeChar(Convert.ToChar(value));
                    break;
                case "string":
                    archivo.escribeString(value,atr.Tam);
                    break;
            }
        }

        private void reescribeDirsDatos(Entidad ent)
        {
            ent.ApuntaDat = ent.ListBloq[0].Direccion;
            //escribe apuntador a datos de una entidad
            archivo.escribePtrDatEnt(ent.Dir, ent.ListBloq[0].Direccion);

            for (int i = 0; i < ent.ListBloq.Count; i++)
            {
                if (i <= (ent.ListBloq.Count - 2))
                {
                    ent.ListBloq[i].ApuntaDato = ent.ListBloq[i + 1].Direccion;
                    //en archivo
                    archivo.escribePtrSigBloq(ent.ListBloq[i].Direccion, ent.ListBloq[i + 1].Direccion);
                }
            }
        }

        public Archivo Archivo
        {
            get { return archivo; }
        }

        public List<string> getDatosPrimarios(long dirEnt)
        {
            List<string> auxList = new List<string>();
            Entidad ent = diccionario.getEnteByDir(dirEnt);
            long dirDatos = ent.ApuntaDat;

            while (dirDatos != -1)
            {
                //Set stream position
                archivo.setStreamPosition(dirDatos);
                archivo.getLong();
                dirDatos = archivo.getLong();
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
                                archivo.getLong();
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


            return auxList;
        }

        public void eliminaDato(string nomEnt,long bloqueDir)
        {
            Entidad ent = diccionario.getEntByName(nomEnt);
            long dirBloq = ent.ApuntaDat;
            string clvPrimaria;

            //busca la clave primaria del bloque que se insertará
            clvPrimaria = getPrimariKey(bloqueDir, nomEnt);
            //busca en todos los datos apuntadores a esa entidad
            eliminaRecursivo(nomEnt, clvPrimaria);

            for(int i =0;i<ent.ListBloq.Count;i++)
            {
                if (ent.ListBloq[i].Direccion == bloqueDir)
                {
                    //Si solo hay un elemento en la lista
                    if (ent.ListBloq.Count == 1)
                    {
                        //Escribe el apuntador de la entidad en -1
                        ent.ApuntaDat = -1;
                        ent.ListBloq.RemoveAt(i);
                        //Reescribe en archivo
                        archivo.escribePtrDatEnt(ent.Dir, (long)-1);
                    }
                    //Si es el primer elemnto
                    else if (i == 0)
                    {
                        //Reescribe el apuntador de entidad
                        ent.ApuntaDat = ent.ListBloq[i + 1].Direccion;
                        
                        //Reescribe en archivo
                        archivo.escribePtrDatEnt(ent.Dir, ent.ListBloq[i+1].Direccion);

                        ent.ListBloq.RemoveAt(i);
                    }
                    //Es el ultimo elemento
                    else if (i == ent.ListBloq.Count - 1)
                    {
                        //Reescribe apuntador a ultimo
                        ent.ListBloq[i - 1].ApuntaDato = -1;
                        //Archivo
                        archivo.escribePtrSigBloq(ent.ListBloq[i - 1].Direccion, (long)-1);
                        ent.ListBloq.RemoveAt(i);
                    }
                    //Si es un elemnto intermedio
                    else
                    {
                        //Reescribe apuntador a siguiente
                        ent.ListBloq[i - 1].ApuntaDato = ent.ListBloq[i + 1].Direccion;
                        //Archivo
                        archivo.escribePtrSigBloq(ent.ListBloq[i - 1].Direccion, ent.ListBloq[i + 1].Direccion);
                        ent.ListBloq.RemoveAt(i);
                    }
                }
            }
        }

        private string getPrimariKey(long dirBloque,string nomEnt)
        {
            Entidad ent = diccionario.getEntByName(nomEnt);
            string clvPrim = "";

            foreach (Bloque b in ent.ListBloq)
            {
                if (b.Direccion == dirBloque)
                {
                    archivo.setStreamPosition(dirBloque);
                    archivo.getLong();
                    archivo.getLong();
                    foreach (Atributo i in ent.Atributos)
                    {
                        switch (i.Tipo)
                        {
                            case "int":
                                if (i.TClave == 1)
                                    return archivo.getInt().ToString();
                                else
                                    archivo.getInt();
                                break;
                            case "float":
                                if (i.TClave == 1)
                                    return archivo.getDouble().ToString();
                                else
                                    archivo.getDouble();
                                break;
                            case "char":
                                if (i.TClave == 1)
                                    return archivo.getChar().ToString();
                                else
                                    archivo.getChar();
                                break;
                            case "string":
                                if (i.TClave == 1)
                                    return archivo.getString(i.Tam);
                                else
                                    archivo.getString(i.Tam);
                                break;
                        }
                    }
                }
            }
            return clvPrim;
        }

        private void eliminaRecursivo(string nomEnt, string clavePrim)
        {
            /*
            Entidad ent = diccionario.getEntByName(nomEnt);
            long auxDir=0;

            foreach (Entidad i in diccionario.Entidades)
                foreach (Atributo j in i.Atributos)
                    if (j.ApuntaPrim == ent.Dir)
                        for (int k = 0; k < i.ListBloq.Count;k++ )
                        {
                            archivo.setStreamPosition(i.ListBloq[k].Direccion);
                            auxDir = archivo.getLong();
                            archivo.getLong();
                            foreach (Atributo l in i.Atributos)
                            {
                                switch (l.Tipo)
                                {
                                    case "int":
                                        if (l.TClave == 2)
                                        {
                                            if (archivo.getInt().ToString() == clavePrim)
                                            {
                                                eliminaDato(i.Nombre, auxDir);
                                                k = -1;
                                            }
                                        }
                                        else
                                            archivo.getInt();
                                        break;
                                    case "float":
                                        if (l.TClave == 2)
                                        {
                                            if (archivo.getDouble().ToString() == clavePrim)
                                            {
                                                eliminaDato(i.Nombre, auxDir);
                                                k = -1;
                                            }
                                        }
                                        else
                                            archivo.getDouble();
                                        break;
                                    case "char":
                                        if (l.TClave == 2)
                                        {
                                            if (archivo.getChar().ToString() == clavePrim)
                                            {
                                                eliminaDato(i.Nombre, auxDir);
                                                k = -1;
                                            }
                                        }
                                        else
                                            archivo.getChar();
                                        break;
                                    case "string":
                                        if (l.TClave == 2)
                                        {
                                            if (archivo.getString(l.Tam) == clavePrim)
                                            {
                                                eliminaDato(i.Nombre, auxDir);
                                                k=-1;
                                            }
                                        }
                                        else

                                            archivo.getString(l.Tam);
                                        break;
                                }
                            }
                        }*/
        }
    }
}
