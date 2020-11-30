using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Serializacion<T> : IArchivo<T>
    {
        /// <summary>
        /// Funcion que serializa en formato XML el tipo de dato generico T
        /// </summary>
        /// <param name="path">path donde escribir el archivo</param>
        /// <param name="datos">datos a serializar</param>
        /// <returns>Retorna true si se pudo guardar el archivo, caso contrario retorna false</returns>
        public bool Guardar(string path, T datos)
        {
            bool guardado = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
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
        /// Funcion que deserializa un archivo .xml
        /// </summary>
        /// <param name="path">path donde leer el archivo</param>
        /// <param name="datos">donde se guardan los datos</param>
        /// <returns>Retorna true si se pudo leer el archivo, caso contrario retorna false</returns>
        public bool Leer(string path, out T datos)
        {
            bool leido = false;
            datos = default;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
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
