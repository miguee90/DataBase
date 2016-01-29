using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    /// <summary>
    /// Clase atributo
    /// guarda el tamaño,tipo,nombre y apuntadores de
    /// un atributo de datos
    /// </summary>
    public class Atributo
    {
        private string nombre;
        private string tipo;
        private int tam;
        private int tClave;
        private long ptrEnt;
        private long direccion;
        private long ptrAtri;
        private long apuntaPrim;

        public Atributo(string nom,string tip,int t,int clave,long apuntaEnt,long apuntaAtr,long dir,long ptrPrim)
        {
            nombre = nom;
            tipo = tip;
            tam = t;
            tClave = clave;
            ptrEnt = apuntaEnt;
            ptrAtri = apuntaAtr;
            direccion = dir;
            apuntaPrim = ptrPrim;
        }

        #region getter y setters
        public string Nombre
        {
            get { return nombre; }
        }
        public string Tipo
        {
            get { return tipo; }
        }

        public int Tam
        {
            get { return tam; }
        }

        public int TClave
        {
            get { return tClave; }
            set { tClave = value; }
        }

        public long ApuntaEntidad
        {
            get { return ptrEnt; }
            set { ptrEnt = value; }
        }

        public long ApuntaAtri
        {
            get { return ptrAtri; }
            set { ptrAtri = value; }
        }

        public long Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public long ApuntaPrim
        {
            get { return apuntaPrim; }
            set { apuntaPrim = value; }
        }
        #endregion
    }
}
