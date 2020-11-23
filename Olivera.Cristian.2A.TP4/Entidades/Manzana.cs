using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        #region atributos
        protected string _provinciaOrigen;
        #endregion

        #region propiedades
        /// <summary>
        /// Propeidad de lectura 
        /// </summary>
        public string Nombre
        {
            get
            {
                return "Manzana";
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo _provinciaOrigen 
        /// </summary>
        public string Provincia
        {
            get
            {
                return this._provinciaOrigen;
            }
            set
            {
                this._provinciaOrigen = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura
        /// </summary>
        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        public Manzana()
            : this("", 0, "")
        {
        }
        /// <summary>
        /// Constructor que inicializa el atributo _provinciaOrigen de un objeto de tipo Manzana
        /// </summary>
        /// <param name="color"></param>
        /// <param name="peso"></param>
        /// <param name="provinciaOrigen"></param>
        public Manzana(string color, double peso, string provinciaOrigen)
            : base(color, peso)
        {
            this.Provincia = provinciaOrigen;
        }
        #endregion
        #region metodos
        /// <summary>
        /// Muestra el valor de los atributos _provinciaOrigen y los atributos de la clase base  de esta  instancia
        /// </summary>
        /// <returns></returns>
        protected override string FrutaToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(this.Nombre);
            datos.Append(base.FrutaToString());
            datos.AppendLine("Provincia de origen: " + this._provinciaOrigen);
            datos.AppendLine("Tiene carozo: " + this.TieneCarozo);

            return datos.ToString();
        }
        /// <summary>
        /// Sobrecarga de ToString(). Muestra los valores de los atributos de una instancia de tipo Fruta
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.FrutaToString();
        }
        /// <summary>
        /// Esta funcion permite guardar un archivo con serializacion xml con datos de la instancia
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Xml(string datos)
        {
            bool sePudo = false;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Manzana));

                using (TextWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + datos))
                {
                    serializador.Serialize(escritor, this);
                    sePudo = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al serializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sePudo;
        }
        /// <summary>
        /// Esta funcion permite leer un archivo con serializacion xml con datos guardados
        /// </summary>
        /// <param name="datos"></param>
        /// <param name="fruta"></param>
        /// <returns></returns>
        bool IDeserializar.Xml(string datos, out Fruta fruta)
        {
            bool sePudo = false;
            fruta = null;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Manzana));

                using (TextReader lector = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + datos))
                {
                    fruta = (Fruta)serializador.Deserialize(lector);
                    sePudo = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al deserializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sePudo;
        }
        #endregion
    }
}
