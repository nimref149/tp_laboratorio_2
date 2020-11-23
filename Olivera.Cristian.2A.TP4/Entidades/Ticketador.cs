using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Entidades
{
    public class Ticketador<Fruta>
    {
        #region metodos
        /// <summary>
        /// Funcion que crea  un archivo de texto con datos y lo guarda en el escritorio, si no se pudo guardar lanzara una excepcion
        /// </summary>
        /// <param name="precio"></param>
        /// <param name="estante"></param>
        public void ManejadorEventoPrecio(double precio, Estante<Fruta> estante)
        {
            try
            {
                
                using (StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\estante.txt"))
                {
                    escritor.WriteLine(DateTime.Now);
                    escritor.WriteLine("$ " + precio);
                    MessageBox.Show("Se creo el archivo esatante.txt en el escritorio.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al escribir archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
