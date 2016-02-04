using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivos2015
{
    [Serializable]
    /// <summary>
    /// Clase entidad
    /// </summary>
    public class Entidad
    {
        private long ptr_atributos;
        private long direccion;
        private long ptr_entidad;
        private List<Atributo> atributos;
        private long ptr_datos;
        private string nombre;
        List<Bloque> bloques;

        public Entidad(string nom)
        {
            nombre = nom;
            atributos = new List<Atributo>();
            bloques = new List<Bloque>();
        }

        public void insertaAtributo(Atributo atr)
        {
            atributos.Add(atr);
            //ordena los atributos en orden alfabetico
            atributos.Sort((p, q) => string.Compare(p.Nombre, q.Nombre));
            //actualiza apuntadores a atributos
            actualizaPtrs();
        }

        private void actualizaPtrs()
        {
            for (int i = 0; i < atributos.Count; i++)
                if(i<=(atributos.Count-2))
                    atributos[i].ApuntaAtri = atributos[i + 1].Direccion;
        }

        #region Getter y setters
        public string Nombre
        {
            get{ return nombre; }
        }

        public List<Bloque> ListBloq
        {
            get { return bloques; }
        }

        public long ApuntaEnt
        {
            get { return ptr_entidad; }
            set { ptr_entidad = value; }
        }

        public long ApuntaAt
        {
            get { return ptr_atributos; }
            set { ptr_atributos = value; }
        }

        public long Dir
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public long ApuntaDat
        {
            get{ return ptr_datos; }
            set { ptr_datos = value; }
        }

        public List<Atributo> Atributos
        {
            get { return atributos; }
            set { atributos = value; }
        }
        #endregion
    }
}
