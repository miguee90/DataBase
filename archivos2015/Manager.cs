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

        /// <summary>
        /// Obtiene una base de datos por medio de su nombre
        /// </summary>
        /// <param name="nombre">El nombre de la base de datos que desea buscar.</param>
        /// <returns>Regresa la base de datos del tipo diccionario.</returns>
        public Diccionario getBDbyName(string nombre)
        {
            Diccionario baseVacia = null;

            foreach(Diccionario i in bases)
                if(i.NomDic==nombre)
                    return i;

            return baseVacia;
        }

        #region Getter y setters
        public List<Diccionario> Bases
        {
            get { return bases; }
            set { bases = value; }
        }

        public List<User> Usuarios
        {
            get { return usuarios; }
        }
        #endregion
    }
}
