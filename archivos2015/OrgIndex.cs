using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    /// <summary>
    /// Clase que contiene todas las funciones 
    /// para la manipulacion de la organización 
    /// secuencial indexada.
    /// </summary>
    public class OrgIndex
    {
        Archivo archivo;
        string nombre;
        List<Indice> tablaIndices;

        public Archivo Archivo
        {
            get { return archivo; }
        }

        public OrgIndex(string nom)
        {
            nombre = nom;
            archivo = new Archivo(nombre, "ind");
            tablaIndices = new List<Indice>();
        }

        public List<Indice> getTablaIndices(Entidad ent)
        {
            List<Indice> auxTabInd = new List<Indice>();
            long dirDat = ent.ApuntaDat;

            while (dirDat != -1)
            {
                archivo.setStreamPosition(dirDat);
                long auxInd = archivo.getLong();
                long auxDir = archivo.getLong();
                dirDat = archivo.getLong();
                long auxPtrData = archivo.getLong();

                Indice ind = new Indice(auxInd, auxDir, dirDat, auxPtrData);

                auxTabInd.Add(ind);
            }

            return auxTabInd;
        }

        public bool insertaBloque(Entidad ent,List<string> datos,Diccionario diccionario)
        {
            string tipoPrimaria = getTipoPrimaria(ent);
            //Funcion que obtenga el dato con clave primaria
            string datoPrim=getPrimDat(ent,datos);
            //Funcion que obtiene el indice a partir del dato y su tipo
            string indice=getIndex(datoPrim,tipoPrimaria);

            //Funcion que inserta el indice en la tabla de indices ptrDat(Entidad *)
            Indice ind = insertaOrdenadoTabIndex(ent, indice);
            //Funcion que inserta el bloque de datos a partir de un indice
            return insertaOrdenadoBloque(ent, ind, datos);
        }

        private string getTipoPrimaria(Entidad ent)
        {
            string tipo="";

            foreach (Atributo i in ent.Atributos)
                if (i.TClave == 1)
                    return i.Tipo;
            return tipo;
        }

        private string getIndex(string dato, string tipo)
        {
            string result="";
            string grupo1 = "aAbBcC";
            string grupo2 = "dDeEfF";
            string grupo3 = "gGhHiI";
            string grupo4 = "jJkKlL";
            string grupo5 = "mMnNoO";
            string grupo6 = "pPqQrR";
            string grupo7 = "sStTuU";
            string grupo8 = "vVwWxX";

            //Funcion que crea indices de acuerdo al tipo de datos
            switch (tipo)
            {
                case "int":
                case "float":
                    int auxI = Convert.ToInt32(dato);

                    auxI = auxI / 10;
                    result = Convert.ToString(auxI);
                    break;
                case "char":
                case "string":
                    char auxC = dato[0];
                    if (grupo1.Contains(auxC))
                        result = "1";
                    else if (grupo2.Contains(auxC))
                        result = "2";
                    else if (grupo3.Contains(auxC))
                        result = "3";
                    else if (grupo4.Contains(auxC))
                        result = "4";
                    else if (grupo5.Contains(auxC))
                        result = "5";
                    else if (grupo6.Contains(auxC))
                        result = "6";
                    else if (grupo7.Contains(auxC))
                        result = "7";
                    else if (grupo8.Contains(auxC))
                        result = "8";
                    else
                        result = "9";
                    break;
            }

            return result;
        }

        private string getPrimDat(Entidad ent, List<string> datos)
        {
            string result="";

            for(int i=0;i<ent.Atributos.Count;i++)
                if (ent.Atributos[i].TClave == 1)
                    result = datos[i];

            return result;
        }

        private Indice insertaOrdenadoTabIndex(Entidad ent,string indice)
        {
            long apuntaTab = ent.ApuntaDat;
            long index = 0;
            long dir = 0;
            long ptrNext = 0;
            long ptrDat = 0;
            long dirAnterior = 0;
            Indice auxInd=new Indice();
            bool inserto = false;

            //Caso de que no exista indice en la tabla de indices
            if (apuntaTab == -1)
            {
                auxInd = new Indice(Convert.ToInt64(indice), archivo.getDir(), (long)-1, (long)-1);
                tablaIndices.Add(auxInd);
                //Se escribe en archivo el indice
                archivo.escribeTablaIndices(archivo.getDir(), auxInd);
                //Se escribe el apuntador a datos de la entidad
                archivo.escribePtrDatEnt(ent.Dir, auxInd.Direccion);
                ent.ApuntaDat = auxInd.Direccion;
            }
            //
            else
            {
                while (apuntaTab != -1)
                {
                    archivo.setStreamPosition(apuntaTab);
                    //indice
                    index = archivo.getLong();
                    //Direccion
                    dir=archivo.getLong();
                    //Lee apuntador a siguiente
                    apuntaTab=ptrNext = archivo.getLong();
                    //Lee apuntador a datos
                    ptrDat = archivo.getLong();
                    if (index == Convert.ToInt64(indice))
                    {
                        //Obtiene el indice
                        auxInd = archivo.getIndice(dir);
                        inserto = true;
                        break;
                    }
                    //Si el indice leido es mayor al dato inserta antes de el
                    else if (index > Convert.ToInt64(indice))
                    {
                        //Si se va a insertar en primer lugar
                        if (dirAnterior == 0)
                        {
                            inserto = true;
                            auxInd = new Indice(Convert.ToInt64(indice), archivo.getDir(), dir, (long)-1);
                            archivo.escribeTablaIndices(archivo.getDir(), auxInd);
                            ent.ApuntaDat = auxInd.Direccion;
                            archivo.escribePtrDatEnt(ent.Dir, auxInd.Direccion);
                        }
                        else
                        {
                            inserto = true;
                            auxInd = new Indice(Convert.ToInt64(indice), archivo.getDir(), dir, (long)-1);
                            archivo.escribeTablaIndices(archivo.getDir(), auxInd);
                            //Cambiar apuntador anterior
                            archivo.escribePtrNextTabInd(dirAnterior, auxInd.Direccion);
                            //cambiar apuntador siguiente
                            archivo.escribePtrNextTabInd(auxInd.Direccion, dir);
                        }
                    }
                    dirAnterior = dir;
                }
                //Inserta en ultimo lugar
                if (inserto == false)
                {
                    auxInd = new Indice(Convert.ToInt64(indice), archivo.getDir(), (long)-1, (long)-1);
                    archivo.escribeTablaIndices(archivo.getDir(), auxInd);
                    //Cambiar apuntador anterior
                    archivo.escribePtrNextTabInd(dirAnterior, auxInd.Direccion);
                }
            }
            return auxInd;
        }

        private bool insertaOrdenadoBloque(Entidad ent, Indice ind,List<string> datos)
        {
            bool esRepetido = false;
            bool inserto = false;
            long dirDat = ind.ApuntaDat;
            long dir = 0;
            long dirAnterior = 0;
            string datoLeido;
            
            //Si esta vacio de datos
            if (dirDat == -1)
            {
                archivo.escribePtrDatInd(ind.Direccion, archivo.getDir());
                archivo.setStreamPosition(archivo.getDir());
                //direccion Bloque
                archivo.escribeLong(archivo.getDir());
                //Apuntador siguiente
                archivo.escribeLong((long)-1);
                for (int i = 0; i < ent.Atributos.Count; i++)
                {
                    //Escribe segun el tipo de dato
                    escribeSegunTipo(datos[i], ent.Atributos[i].Tipo,ent.Atributos[i].Tam);
                }
            }
            else
            {
                while(dirDat!=-1)
                {
                    archivo.setStreamPosition(dirDat);
                    dir= archivo.getLong();
                    dirDat = archivo.getLong();
                    for (int i = 0; i < ent.Atributos.Count; i++)
                    {
                        datoLeido = getSegunTipo(ent.Atributos[i].Tipo,ent.Atributos[i].Tam);
                        if(ent.Atributos[i].TClave==1)
                            //Encontró un repetido
                            if (datoLeido == datos[i])
                                return true;
                            else
                            {
                                if (comparaMayor(datoLeido, datos[i],ent.Atributos[i].Tipo))
                                {
                                    inserto = true;
                                    //Si es el primer elemento
                                    if (dirAnterior == 0)
                                    {
                                        //Escribe el apuntador a datos del indice
                                        ind.ApuntaDat = archivo.getDir();
                                        archivo.escribePtrDatInd(ind.Direccion, ind.ApuntaDat);
                                        //Escribe el Bloque
                                        archivo.setStreamPosition(archivo.getDir());
                                        archivo.escribeLong(archivo.getDir());
                                        archivo.escribeLong(dir);
                                        for (int j = 0; j < ent.Atributos.Count; j++)
                                        {
                                            escribeSegunTipo(datos[j], ent.Atributos[j].Tipo,ent.Atributos[j].Tam);
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        //Escribe el apuntador a siguiente del bloque
                                        archivo.escribePtrSigBloq(dirAnterior, archivo.getDir());
                                        archivo.setStreamPosition(archivo.getDir());
                                        //Escribe bloque
                                        archivo.escribeLong(archivo.getDir());
                                        archivo.escribeLong(dir);
                                        for (int j = 0; j < ent.Atributos.Count; j++)
                                        {
                                            escribeSegunTipo(datos[j], ent.Atributos[j].Tipo,ent.Atributos[j].Tam);
                                        }
                                        break;
                                    }
                                }
                            }
                    }
                    dirAnterior = dir;
                }
                //Si es el ultimo lugar
                if (inserto == false)
                {
                    //Escribe el apuntador a siguiente del bloque
                    archivo.escribePtrSigBloq(dirAnterior, archivo.getDir());
                    archivo.setStreamPosition(archivo.getDir());
                    //Escribe bloque
                    archivo.escribeLong(archivo.getDir());
                    archivo.escribeLong((long)-1);
                    for (int j = 0; j < ent.Atributos.Count; j++)
                    {
                        escribeSegunTipo(datos[j], ent.Atributos[j].Tipo,ent.Atributos[j].Tam);
                    }
                }
            }
            return esRepetido;
        }

        private bool comparaMayor(string leido, string aInsertar, string tipo)
        {
            bool esMayor = false;

            switch(tipo)
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
                    int res=String.Compare(leido, aInsertar);
                    if (res > 0)
                        return true;    
                    break;
            }

            return esMayor;
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
                    archivo.escribeChar(dato[0]);
                    break;
                case "string":
                    archivo.escribeString(dato,tam);
                    break;
            }
        }

        private string getSegunTipo(string tipo,long tam)
        {
            long inicio = 0;

            string result = "";
            switch (tipo)
            {
                case "int":
                    result = archivo.getInt().ToString();
                    break;
                case "float":
                    result = archivo.getDouble().ToString();
                    break;
                case "char":
                    result=archivo.getChar().ToString();
                    break;
                case "string":
                    result=archivo.getString((int)tam);
                    break;
            }
            return result;
        }

        public List<Indice> getIndices(Entidad ent)
        {
            List<Indice> auxListInd = new List<Indice>();
            long indi = 0;
            long dire = 0;
            long dirIndex = ent.ApuntaDat;
            long apuntaDat = 0;

            //Recorre los apuntadores de datos
            while (dirIndex != -1)
            {
                archivo.setStreamPosition(dirIndex);
                indi = archivo.getLong();
                dire = archivo.getLong();
                dirIndex = archivo.getLong();
                apuntaDat = archivo.getLong();

                Indice ind = new Indice(indi, dire, dirIndex, apuntaDat);
                auxListInd.Add(ind);
            }

            return auxListInd;
        }

        public List<List<string>> getDatos(long apuntaDat,Entidad ent)
        {
            List<List<string>> listaDatos=new List<List<string>>();
            
            long dirBloq = apuntaDat;

            while (dirBloq != -1)
            {
                List<string> bloque=new List<string>();
                archivo.setStreamPosition(dirBloq);
                bloque.Add(archivo.getLong().ToString());
                dirBloq = archivo.getLong();
                bloque.Add(dirBloq.ToString());
                foreach (Atributo i in ent.Atributos)
                {
                    bloque.Add(getSegunTipo(i.Tipo,i.Tam));
                }
                listaDatos.Add(bloque);
            }


            return listaDatos;
        }

        public void eliminaBloque(Entidad ent, long dirBloq,string clv,string tipo)
        {
            long dirTab = ent.ApuntaDat;
            long dirB = 0,dirInd=0;
            string indice;
            long index = 0,indi=0;
            long dirAct, dirAnt=0;

            indice = getIndex(clv, tipo);
            indi = Convert.ToInt64(indice);

            eliminaRecursivo(ent, clv);

            while (dirTab != -1)
            {
                archivo.setStreamPosition(dirTab);
                //Lee indice
                index=archivo.getLong();
                //Lee Direccion
                dirInd=archivo.getLong();
                //lee apuntador a siguiente indice
                dirTab = archivo.getLong();
                //lee apuntador a datos
                dirB = archivo.getLong();
                if (indi == index)
                {
                    //recorre datos
                    while (dirB != -1)
                    {
                        archivo.setStreamPosition(dirB);
                        //lee direccion
                        dirAct=archivo.getLong();
                        dirB = archivo.getLong();
                        if (dirBloq == dirAct)
                        {
                            //Si es el unico elemento o es el primero
                            if (dirAnt == 0)
                            {
                                //Escribe el apuntador de la tabla de indices
                                archivo.escribePtrDatInd(dirInd, dirB);
                                //Si ya no hay datos se elimina el indice
                                if (dirB == -1)
                                    //Elimina indice(ent,dirInd)
                                    eliminaIndice(ent, dirInd);
                                return;
                            }
                            else
                            {
                                //Reescribe el apuntador a siguiente
                                archivo.escribePtrSigBloq(dirAnt, dirB);
                                return;
                            }
                        }
                        dirAnt = dirAct;
                    }
                }
            }
        }

        private void eliminaIndice(Entidad ent,long dirInd)
        {
            long dirNextInd = ent.ApuntaDat;
            long dirAct = 0;
            long dirAnt = 0;
            long indice = 0;

            while (dirNextInd != -1)
            {
                archivo.setStreamPosition(dirNextInd);
                indice = archivo.getLong();
                dirAct = archivo.getLong();
                dirNextInd = archivo.getLong();
                if (dirAct == dirInd)
                {
                    //Si es el primer indice o solo hay uno
                    if (dirAnt == 0)
                    {
                        //Escribe el apuntador de la entidad
                        ent.ApuntaDat = dirNextInd;
                        archivo.escribePtrDatEnt(ent.Dir, dirNextInd);
                        return;
                    }
                    else
                    {
                        archivo.escribePtrNextTabInd(dirAnt, dirNextInd);
                        return;
                    }
                }
                dirAnt = dirAct;
            }
        }

        private void eliminaRecursivo(Entidad ent, string clave)
        {
            archivo.setStreamPosition(0);
            bool siApunta = false;
            bool siElimina = false;
            long nextEnt = archivo.getLong();
            long dirActE = 0;
            long dirAntE = 0;
            long ptrAtr = 0;
            long ptrInds = 0;
            long ptrDats = 0;
            long dirBloq=0;
            int tClave = 0;
            long apuntaEnt = 0;
            string nomEnt="";
            string nomb = "";
            string tipo="";
            string clav = "";
            Entidad ent2;
         
            //Recorre todas las entidades
            while (nextEnt != -1)
            {
                archivo.setStreamPosition(nextEnt);
                //Nombre
                nomEnt=archivo.getStringS();
                nextEnt = archivo.getLong();
                ptrAtr = archivo.getLong();
                dirActE = archivo.getLong();
                ptrInds = archivo.getLong();
                ent2=new Entidad(nomEnt);
                //recorre atributos si no es la misma entidad
                if (dirActE != ent.Dir)
                {
                    List<Atributo> atrs = new List<Atributo>();
                    while (ptrAtr != -1)
                    {
                        
                        archivo.setStreamPosition(ptrAtr);
                        Atributo atr = new Atributo(
                        archivo.getStringS(),
                        archivo.getStringS(),
                        archivo.getInt(),
                        tClave = archivo.getInt(),
                        archivo.getLong(),
                        ptrAtr = archivo.getLong(),
                        //direccion
                        archivo.getLong(),
                        //Apunta clave prim
                        apuntaEnt=archivo.getLong());

                        atrs.Add(atr);
                        if (ent.Dir == apuntaEnt)
                            siApunta = true;
                    }
                    ent2.Atributos=atrs;
                    //Recorre los indices
                    if (siApunta)
                    {
                        while (ptrInds != -1)
                        {
                            archivo.setStreamPosition(ptrInds);
                            archivo.getLong();
                            archivo.getLong();
                            ptrInds = archivo.getLong();
                            ptrDats = archivo.getLong();
                            //recorre los bloques de datos 
                            while (ptrDats != -1)
                            {
                                //Direccion
                                dirBloq=archivo.getLong();
                                //Apuntador siguiente bloque
                                ptrDats = archivo.getLong();
                                //se recorren los atributos del bloque de datos
                                foreach (Atributo i in atrs)
                                {
                                    if(i.TClave==2)
                                    {
                                        nomb=getSegunTipo(i.Tipo,i.Tam);
                                        if (nomb == clave)
                                            siElimina = true;
                                            
                                    }
                                    if (i.TClave == 1)
                                    {
                                        clav = getSegunTipo(i.Tipo,i.Tam);
                                        tipo = i.Tipo;
                                    }
                                }
                                if(siElimina)
                                    eliminaBloque(ent2, dirBloq, clav, tipo);
                            }
                        }
                    }
                }
                dirAntE = dirActE;
            }
        }

        /// <summary>
        /// Modifica datos a excepcion de la clave primaria
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="ent"></param>
        /// <param name="datos"></param>
        public void modificaBloque(long dir, Entidad ent, List<string> datos)
        {
            archivo.setStreamPosition(dir);
            archivo.getLong();
            archivo.getLong();
            for (int a = 0; a < ent.Atributos.Count; a++)
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
    }
}
