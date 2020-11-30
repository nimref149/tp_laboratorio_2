using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Funcion que guarda en un archivo de texto el string 'datos' pasado por parametro
        /// </summary>
        /// <param name="path">directorio donde se va a escribir el archivo</param>
        /// <param name="datos">datos a escribir en el archivo</param>
        /// <returns>retorna true si se pudo guardar, caso contrario retorna false</returns>
        public bool Guardar(string path, string datos)
        {
            bool guardado = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(datos);
                    guardado = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return guardado;
        }

        /// <summary>
        /// Funcion que lee un archivo de texto y guarda sus datos en el string 'datos' pasado por parametro
        /// </summary>
        /// <param name="path">directorio donde se va a leer el archivo</param>
        /// <param name="datos">datos a escribir en el archivo</param>
        /// <returns>retorna true si se pudo leer, caso contrario retorna false</returns>
        public bool Leer(string path, out string datos)
        {
            bool leido = false;
            datos = default;

            try
            {
                using (StreamReader lector = new StreamReader(path))
                {
                    datos = lector.ReadToEnd();
                    leido = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return leido;
        }
    }
}
