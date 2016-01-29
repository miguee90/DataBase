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

        public static bool validaEnteros(TextBox text)
        {
            try
            {
                int d=Convert.ToInt32(text.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool validaFlotantes(TextBox text)
        {
            try
            {
                double d = Convert.ToDouble(text.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool validaChar(TextBox text)
        {
            try
            {
                double d = Convert.ToChar(text.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
