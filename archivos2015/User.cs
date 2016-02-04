using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    [Serializable]
    class User
    {
        private string nombre;
        private string password;
        private DateTime vig_ini;
        private DateTime vig_fin;
        private string baseDatos;

        public User(string nom,string pass,DateTime fIni,DateTime fFIn,string bd)
        {

        }
    }
}
