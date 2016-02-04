using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    [Serializable]
    public class Bloque
    {
        private long direccion;
        private long ptrSigDato;

        public Bloque(long dir,long next)
        {
            direccion = dir;
            ptrSigDato = next;
        }

#region getters y setters
        public long Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public long ApuntaDato
        {
            get { return ptrSigDato; }
            set { ptrSigDato = value; }
        }
#endregion
    }
}
