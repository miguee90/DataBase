using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace archivos2015
{
    /// <summary>
    /// Clase que valida los tipos de datos
    /// en la captura de datos para el inserta.
    /// </summary>
    public class Validaciones
    {
        public Validaciones()
        {

        }

        public static bool validaEnteros(string text)
        {
            try
            {
                int d=Convert.ToInt32(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool validaFlotantes(string text)
        {
            try
            {
                double d = Convert.ToDouble(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool validaChar(string text)
        {
            try
            {
                double d = Convert.ToChar(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
