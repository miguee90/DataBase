using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    [Serializable]
    public class Manager
    {
        private List<User> usuarios;
        private List<Diccionario> bases;

        public Manager()
        {
            bases = new List<Diccionario>();
            usuarios = new List<User>();
        }

        #region Getter y setters
        public List<Diccionario> Bases
        {
            get { return bases; }
            set { bases = value; }
        }
        #endregion
    }
}
