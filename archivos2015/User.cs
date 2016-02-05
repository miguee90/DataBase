using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    [Serializable]
    public class User
    {
        private string nombre;
        private string password;
        private DateTime vig_ini;
        private DateTime vig_fin;
        private string baseDatos;
        private bool admin;
        private bool alta;
        private bool baja;
        private bool mod;
        private bool consulta;
        private bool sql;

        public User(string nom,string pass,DateTime fIni,DateTime fFIn,string bd,bool adm,bool a,bool b,bool m,bool cons,bool s)
        {
            nombre = nom;
            password = pass;
            vig_ini = fIni;
            vig_fin = fFIn;
            baseDatos = bd;
            admin = adm;
            alta = a;
            baja = b;
            mod = m;
            consulta = cons;
            sql = s;
        }

        #region GETERS Y SETERS
        public string Nombre
        {
            get{return nombre;}
            set{ nombre=value;}
        }

        public string Password
        {
            get { return password; }
        }

        public DateTime Vig_ini
        {
            get { return vig_ini; }
        }

        public DateTime Vig_fin
        {
            get { return vig_fin; }
        }

        public string BaseDatos
        {
            get { return baseDatos; }
        }

        public bool Admin
        {
            get { return admin; }
        }

        public bool Altas
        {
            get { return alta; }
        }

        public bool Bajas
        {
            get { return baja; }
        }

        public bool Modificaciones
        {
            get { return mod; }
        }

        public bool Consultas
        {
            get { return consulta; }
        }

        public bool SQL
        {
            get { return sql; }
        }
        #endregion
    }
}
