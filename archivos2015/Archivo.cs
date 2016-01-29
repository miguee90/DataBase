using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    /// <summary>
    /// Clase archivo, se encarga de todas las operaciones 
    /// en archivo(escribe,lee y elimina).
    /// </summary>
    public class Archivo
    {
        FileStream stream;
        BinaryReader reader;
        BinaryWriter writer;

        /// <summary>
        /// Constructores para la clase archivo
        /// </summary>
        /// <param name="nombre">Nombre del archivo</param>
        /// <param name="ext">extencion del archivo</param>
        public Archivo(string nombre,string ext)
        {
            if(File.Exists(nombre+ext))
                File.Delete(nombre+ext);
            File.Copy(nombre + "dic", nombre + ext);
            stream = new FileStream(nombre+ext, FileMode.Open);
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }

        public Archivo(string nombre,bool nOv)
        {
            if (nOv == true)
            {
                stream = new FileStream(nombre, FileMode.Create);
                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);
                stream.Position = 0;
                long vacio = -1;
                writer.Write(vacio);
            }
            else
            {
                stream = new FileStream(nombre, FileMode.OpenOrCreate);
                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);
            }
        }
        /// <summary>
        /// Escribe todo el bloque que compone una entidad
        /// </summary>
        /// <param name="ent">Onjeto de tipo entidad</param>
        public void escribeEntidad(Entidad ent)
        {
            stream.Position = stream.Length;
            writer.Write(ent.Nombre);
            writer.Write(ent.ApuntaEnt);
            writer.Write(ent.ApuntaAt);
            writer.Write(ent.Dir);
            writer.Write(ent.ApuntaDat);
        }

        public void rescribeDirs(List<Entidad> lista)
        {
            stream.Position = 0;
            writer.Write(lista[0].Dir);
            for (int i=0;i<lista.Count;i++)
            {
                if (i < (lista.Count - 1))
                {
                    stream.Position = lista[i].Dir;
                    reader.ReadString();
                    writer.Write(lista[i + 1].Dir);
                }
                else
                {
                    stream.Position = lista[i].Dir;
                    reader.ReadString();
                    writer.Write((long)-1);
                }
            }
        }

        public void escribeCabecera(long dir)
        {
            stream.Position = 0;
            writer.Write(dir);
        }

        public void cambiaPtrEntidad(long dirEnt, long difDir)
        {
            stream.Position = dirEnt;
            reader.ReadString();
            writer.Write(difDir);
        }
        /// <summary>
        /// Escribe un bloque de atributo en el archivo
        /// </summary>
        /// <param name="atr"></param>

        public void escrbeAtributo(Atributo atr)
        {
            stream.Position = stream.Length;
            writer.Write(atr.Nombre);
            writer.Write(atr.Tipo);
            writer.Write(atr.Tam);
            writer.Write(atr.TClave);
            writer.Write(atr.ApuntaEntidad);
            writer.Write(atr.ApuntaAtri);
            writer.Write(atr.Direccion);
            writer.Write(atr.ApuntaPrim);
        }
        /// <summary>
        /// ordena los apuntadores de una lista de atributos
        /// </summary>
        /// <param name="atributos"></param>

        public void ordenaPtrs(List<Atributo> atributos)
        {
            for (int i = 0; i < atributos.Count; i++)
            {
                stream.Position = atributos[i].Direccion;
                reader.ReadString();
                reader.ReadString();
                reader.ReadInt32();
                reader.ReadInt32();
                reader.ReadDouble();
                writer.Write(atributos[i].ApuntaAtri);
            }
        }
        /// <summary>
        /// Reescribe el apuntador de un atributo en una entidad
        /// </summary>
        /// <param name="dirEntidad"></param>
        /// <param name="dirAtr"></param>

        public void escribePtrAtEnt(long dirEntidad,long dirAtr)
        {
            stream.Position = dirEntidad;
            reader.ReadString();
            reader.ReadInt64();
            writer.Write(dirAtr);
        }
        /// <summary>
        /// Reescribe el apuntador de un atributo en un atributo
        /// </summary>
        /// <param name="dirAt"></param>
        /// <param name="apuntaAt"></param>

        public void escribePtrAtAtri(long dirAt, long apuntaAt)
        {
            stream.Position = dirAt;
            reader.ReadString();
            reader.ReadString();
            reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt64();
            writer.Write(apuntaAt);
        }
        /// <summary>
        /// Escribe el apuntador de a datos(ptrEntidad) de un atributo
        /// </summary>
        /// <param name="dirAtr"></param>
        /// <param name="ptrDat"></param>

        public void escribePtrDatAtr(long dirAtr, long ptrDat)
        {
            stream.Position = dirAtr;
            //nombre
            reader.ReadString();
            //tipo dato
            reader.ReadString();
            //tamaño
            reader.ReadInt32();
            //Clave
            reader.ReadInt32();
            //Apuntador entidad
            writer.Write(ptrDat);
        }
        /// <summary>
        /// Escribe el campo tipo clave
        /// </summary>
        /// <param name="dirAt"></param>
        /// <param name="tClave"></param>

        public void escribeTClave(long dirAt, int tClave)
        {
            stream.Position = dirAt;
            reader.ReadString();
            reader.ReadString();
            reader.ReadInt32();
            writer.Write(tClave);
        }

        /// <summary>
        /// Escribe el apuntador a clave primaria 
        /// </summary>
        /// <param name="dirAt"></param>
        /// <param name="dirPtr"></param>

        public void escribePrimA(long dirAt, long dirPtr)
        {
            stream.Position = dirAt;
            reader.ReadString();
            reader.ReadString();
            reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt64();
            reader.ReadInt64();
            reader.ReadInt64();
            writer.Write(dirPtr);
        }
        /// <summary>
        /// Escribe apuntador a una entidad en un atributo
        /// </summary>
        /// <param name="dirAt"></param>
        /// <param name="dirPtr"></param>

        public void escribePtrEntAtr(long dirAt,long dirPtr)
        {
            stream.Position = dirAt;
            reader.ReadString();
            reader.ReadString();
            reader.ReadInt32();
            reader.ReadInt32();
            writer.Write(dirPtr);
        }
        /// <summary>
        /// Escribe apuntador a entidad en una entidad
        /// </summary>
        /// <param name="dirEnt"></param>
        /// <param name="ditPtr"></param>

        public void escribePtrEntEnt(long dirEnt, long ditPtr)
        {
            stream.Position = dirEnt;
            reader.ReadString();
            writer.Write(ditPtr);
        }
        /// <summary>
        /// Obtiene el nombre de la entidad especificada por la direccion
        /// </summary>
        /// <param name="dirVieja"></param>
        /// <returns></returns>

        public string getEntApuntada(long dirVieja)
        {
            stream.Position = dirVieja;
            return reader.ReadString();
        }

        public void cierraArchivo()
        {
            reader.Close();
            writer.Close();
            stream.Close();
        }

        public long getEncabezado()
        {
            stream.Position = 0;
            long result=reader.ReadInt64();
            return result;
        }

        public Entidad getBloqueEntidad(long direccion)
        {
            Entidad ent;

            stream.Position = direccion;
            string nombre = reader.ReadString();
            long uno = reader.ReadInt64();
            long dos = reader.ReadInt64();
            long tres = reader.ReadInt64();
            long cuatro = reader.ReadInt64();
            ent = new Entidad(nombre, uno, dos, tres, cuatro);

            return ent;
        }

        public Atributo getBloqueAtributo(long direccion)
        {
            stream.Position=direccion;
            string nombre = reader.ReadString();
            string uno = reader.ReadString();
            int dos = reader.ReadInt32();
            int tres = reader.ReadInt32();
            long cuatro = reader.ReadInt64();
            long cinco = reader.ReadInt64();
            long seis = reader.ReadInt64();
            long siete = reader.ReadInt64();

            Atributo atr = new Atributo(nombre, uno, dos,
                tres, cuatro, cinco, seis, siete);

            return atr;
        }

        public Bloque getBloqueDatos(long direccion)
        {
            stream.Position = direccion;
            Bloque bl = new Bloque(reader.ReadInt64(), reader.ReadInt64());
            return bl;
        }

        public void setStreamPosition(long dir)
        {
            stream.Position = dir;
        }

        public long getLength()
        {
            return stream.Length;
        }

        public void escribeBloque(Bloque bl)
        {
            stream.Position = stream.Length;
            writer.Write(bl.Direccion);
            writer.Write(bl.ApuntaDato);
        }

        public void escribePtrDatEnt(long dirEnt, long apuntaDat)
        {
            stream.Position = dirEnt;
            reader.ReadString();
            reader.ReadInt64();
            reader.ReadInt64();
            reader.ReadInt64();
            writer.Write(apuntaDat);
        }

        public void escribePtrSigBloq(long dirBloq, long ptrSig)
        {
            stream.Position = dirBloq;
            reader.ReadInt64();
            writer.Write(ptrSig);
        }

        public void escribeTablaIndices(long dir,Indice ind)
        {
            stream.Position = dir;
            writer.Write(ind.Ind);
            writer.Write(ind.Direccion);
            writer.Write(ind.ApuntaSig);
            writer.Write(ind.ApuntaDat);
        }

        public void escribePtrNextTabInd(long dirTab, long ptrNext)
        {
            stream.Position = dirTab;
            reader.ReadInt64();
            reader.ReadInt64();
            writer.Write(ptrNext);
        }

        public void escribePtrDatInd(long dirInd, long ptrDat)
        {
            stream.Position = dirInd;
            reader.ReadInt64();
            reader.ReadInt64();
            reader.ReadInt64();
            writer.Write(ptrDat);
        }

        public Indice getIndice(long dirInd)
        {
            stream.Position=dirInd;
            Indice aux = new Indice(getLong(), getLong(), getLong(), getLong());

            return aux;
        }

        #region Get y write tipos de datos
        public void escribeInt(int val)
        {
            writer.Write(val);
        }

        public void escribeFloat(double val)
        {
            writer.Write(val);
        }

        public void escribeLong(long val)
        {
            writer.Write(val);
        }

        public void escribeChar(char val)
        {
            writer.Write(val);
        }

        public void escribeString(string val,int tam)
        {
            long inicio = stream.Position;

            writer.Write(val);
            stream.Position = inicio + tam-1;
            writer.Write(Convert.ToChar("."));
        }

        public int getInt()
        {
            return reader.ReadInt32();
        }

        public long getLong()
        {
            return reader.ReadInt64();
        }

        public double getDouble()
        {
            return reader.ReadDouble();
        }

        public char getChar()
        {
            return reader.ReadChar();
        }

        public string getStringS()
        {
            return reader.ReadString();
        }

        public string getString(int tam)
        {
            long inicio = stream.Position;
            string aux=reader.ReadString();
            stream.Position = inicio + tam;

            return aux;
        }
        #endregion

        #region Getters y setters
        public long getDir()
        {
            return stream.Length;
        }

        public long Positon
        {
            get { return stream.Position; }
        }
        #endregion
    }
}
