using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    class Multilistas
    {
        private Archivo archivo;
        private string nombre;

        public Archivo Archivo
        {
            get { return archivo; }
        }

        public Multilistas(string nom)
        {
            nombre = nom;
            archivo = new Archivo(nombre, "mul");
        }

        /// <summary>
        /// Funcion que es llamada desde la form para insertar un bloque
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="dats"></param>
        /// <param name="diccionario"></param>
        /// <returns></returns>
        public bool insertaBloque(Entidad ent,List<string> dats,Diccionario diccionario)
        {
            bool res = false;
            long dirBloqNuevo = 0;
            //Primero escribe el bloque en el archivo
            dirBloqNuevo = escribeBloqueMulti(ent, dats);

            for (int i = 0; i < ent.Atributos.Count; i++)
                //Inserta ordenado(atributo,dato,dirBloque)
                insertaOrdenado(ent, ent.Atributos[i], dats[i], dirBloqNuevo, i, ent.Atributos[i].Tipo);

            return res;
        }

        public void eliminaBloque(string dirBloq,Entidad ent)
        {
            for (int i = 0; i < ent.Atributos.Count; i++)
                //Elimina (atributo,dato,dirBloque)
                eliminaOrdenado(ent, ent.Atributos[i], dirBloq, i);
        }

        private void eliminaOrdenado(Entidad ent, Atributo a, string dirBloq, int indice)
        {
            string datoLeido;
            long dirNextBloq = a.ApuntaEntidad; ;
            long dirActual = 0;
            long dirAnt = 0;

                while (dirNextBloq != -1)
                {
                    archivo.setStreamPosition(dirNextBloq);
                    //Recorre los atributos
                    dirNextBloq=recorrePtrs(dirNextBloq, ent,indice);
                    dirActual = archivo.getLong();
                    archivo.getLong();
                    //Obtiene el dato a ordenar
                    datoLeido = getDatoByIndice(indice,Convert.ToInt64( dirBloq), ent);
                    if (dirActual==Convert.ToInt64(dirBloq))
                    {
                        //Si es el primer lugar
                        if (dirAnt == 0)
                        {
                            a.ApuntaEntidad = dirNextBloq;
                            archivo.escribePtrDatAtr(a.Direccion, dirNextBloq);
                            break;
                        }
                        //Si es un elemento intermedio
                        else
                        {
                            //reescribe el apuntador del bloque anterior
                            escribePtrNextBloq(dirAnt, indice, ent, dirNextBloq);
                            break;
                        }
                    }
                    dirAnt = dirActual;
                }
        }

        private long escribeBloqueMulti(Entidad ent,List<string> listDats)
        {
            long dirNBloque = 0;

            //****Escribe el bloque en el archivo con sus apuntadores****
            dirNBloque = archivo.getDir();
            archivo.setStreamPosition(archivo.getDir());
            //ciclo que escribe N veces los apuntadores necesarios
            for (int i = 0; i < ent.Atributos.Count; i++)
                archivo.escribeLong((long)-1);
            archivo.escribeLong(dirNBloque);
            archivo.escribeLong((long)-1);
            //escribe los datos correspondientes al tipo de atributo
             for (int i = 0; i < ent.Atributos.Count; i++)
                escribeSegunTipo(listDats[i], ent.Atributos[i].Tipo, ent.Atributos[i].Tam);

             return dirNBloque;
        }

        private void escribeSegunTipo(string dato,string tipo,int tam)
        {
            switch (tipo)
            {
                case "int":
                    archivo.escribeInt(Convert.ToInt32(dato));
                    break;
                case "float":
                    archivo.escribeFloat(Convert.ToDouble(dato));
                    break;
                case "char":
                    archivo.escribeFloat(Convert.ToChar(dato));
                    break;
                case "string":
                    archivo.escribeString(dato, tam);
                    break;
            }
        }

        /// <summary>
        /// inserta ordenado de acuerdo al tipo de dato que es el atributo
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="a"></param>
        /// <param name="dato"></param>
        /// <param name="dirBloq"></param>
        /// <param name="indice"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private bool insertaOrdenado(Entidad ent,Atributo a,string dato,long dirBloq,int indice,string tipo)
        {
            bool esRepe = false;
            string datoLeido;
            long dirNextBloq = a.ApuntaEntidad; ;
            long dirActual = 0;
            long dirDats = a.ApuntaEntidad;
            long dirAnt = 0;
            bool inserto = false;

            //Si no hay ningun dato inserta al inicio
            if (dirDats == ent.Dir)
            {
                a.ApuntaEntidad = dirBloq;
                archivo.escribePtrDatAtr(a.Direccion, dirBloq);
                inserto = true;
            }
            else
            {
                while (dirNextBloq != -1)
                {
                    archivo.setStreamPosition(dirNextBloq);
                    //Recorre los atributos
                    dirNextBloq=recorrePtrs(dirNextBloq, ent,indice);
                    dirActual = archivo.getLong();
                    archivo.getLong();
                    //Obtiene el dato a ordenar
                    datoLeido = getDatoByIndice(indice, dirBloq, ent);
                    if (comparaMayor(datoLeido, dato, tipo))
                    {
                        //Si es el primer lugar
                        if (dirAnt == 0)
                        {
                            a.ApuntaEntidad = dirBloq;
                            archivo.escribePtrDatAtr(a.Direccion, dirBloq);
                            //Nuevo apunta a las anteriores
                            //Escribe en el apuntador de acuerdo al indice
                            escribePtrNextBloq(dirBloq, indice, ent, dirActual);
                            inserto = true;
                            break;
                        }
                        //Si es un elemento intermedio
                        else
                        {
                            //reescribe el apuntador del bloque anterior
                            escribePtrNextBloq(dirAnt, indice, ent, dirBloq);
                            //escribe el apuntador a siguiente mio
                            escribePtrNextBloq(dirBloq, indice, ent, dirActual);
                            inserto = true;
                            break;
                        }
                    }
                    dirAnt = dirActual;
                }
                //Inserta al final 
                if (inserto == false)
                {
                    //reescribe el apuntador del bloque anterior
                    escribePtrNextBloq(dirAnt, indice, ent, dirBloq);
                    //escribe el apuntador a siguiente mio
                    escribePtrNextBloq(dirBloq, indice, ent, (long)-1);
                }
            }

            return esRepe;
        }

        /// <summary>
        /// escribe el apuntador a siguiente bloque por indice
        /// </summary>
        /// <param name="dirBloq"></param>
        /// <param name="indice"></param>
        /// <param name="ent"></param>
        /// <param name="dirNext"></param>
        private void escribePtrNextBloq(long dirBloq, int indice, Entidad ent,long dirNext)
        {
            archivo.setStreamPosition(dirBloq);
            for (int i = 0; i < ent.Atributos.Count; i++)
            {
                if (i == indice)
                    archivo.escribeLong(dirNext);
                else
                    archivo.getLong();
            }
        }

        /// <summary>
        /// Compara los datos que se le envian regresa si el dato a insertar es menor
        /// </summary>
        /// <param name="leido"></param>
        /// <param name="aInsertar"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private bool comparaMayor(string leido, string aInsertar, string tipo)
        {
            bool esMayor = false;

            switch (tipo)
            {
                case "int":
                    if (Convert.ToInt32(leido) > Convert.ToInt32(aInsertar))
                        return true;
                    break;
                case "float":
                    if (Convert.ToDouble(leido) > Convert.ToDouble(aInsertar))
                        return true;
                    break;
                case "char":
                case "string":
                    int res = String.Compare(leido, aInsertar);
                    if (res > 0)
                        return true;
                    break;
            }

            return esMayor;
        }

        private string getDatoByIndice(int indice,long dirBloq,Entidad ent)
        {
            string result="";

            //Recorre los atributos de acuerdo al tipo
            for (int i = 0; i < ent.Atributos.Count; i++)
            {
                switch (ent.Atributos[i].Tipo)
                {
                    case "int":
                        if (indice == i)
                            result = Convert.ToString(archivo.getInt());
                        else
                            archivo.getInt();
                        break;
                    case "float":
                        if (indice == i)
                            result = Convert.ToString(archivo.getDouble());
                        else
                            archivo.getDouble();
                        break;
                    case "char":
                        if (indice == i)
                            result = Convert.ToString(archivo.getChar());
                        else
                            archivo.getChar();
                        break;
                    case "string":
                        if (indice == i)
                            result = archivo.getString(ent.Atributos[i].Tam);
                        else
                            archivo.getString(ent.Atributos[i].Tam);
                        break;
                }
            }

            return result;
        }

        private long recorrePtrs(long dirBloq,Entidad ent,int indice)
        {
            long ptrSig = 0;
            for (int i = 0; i < ent.Atributos.Count; i++)
                if (i == indice)
                    ptrSig = archivo.getLong();
                else
                    archivo.getLong();

            return ptrSig;
        }

        public string getByTipo(string tipo,int tam)
        {
            string result = "";
            switch (tipo)
            {
                case "int":
                    result= Convert.ToString(archivo.getInt());
                    break;
                case "float":
                    result = Convert.ToString(archivo.getDouble());
                    break;
                case "char":
                    result = Convert.ToString(archivo.getChar());
                    break;
                case "string":
                    result = archivo.getString(tam);
                    break;
            }
            return result;
        }

    }
}