using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    /// <summary>
    /// Clase Indice
    /// contiene los atributos de un indice dentro de la tabla de indices
    /// secuencial indexada
    /// </summary>
    public class Indice
    {
        private long direccion;
        private long apuntaSig;
        private long indice;
        private long apuntaDat;

        public Indice()
        {
            direccion = -1;
            apuntaDat = -1;
            indice = -1;
            apuntaSig = -1;
        }

        public Indice(long ind, long dir, long ptrSig, long ptrDat)
        {
            indice = ind;
            direccion = dir;
            apuntaSig = ptrSig;
            apuntaDat = ptrDat;
        }

        #region getter y setters

        public long Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public long ApuntaSig
        {
            get { return apuntaSig; }
            set { apuntaSig = value; }
        }

        public long Ind
        {
            get { return indice; }
            set { indice = value; }
        }

        public long ApuntaDat
        {
            get { return apuntaDat; }
            set { apuntaDat = value; }
        }

        #endregion
    }
}
