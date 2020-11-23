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
    public class Estante<T> : ISerializar
    {
        #region atributos
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        

        public delegate void DelegadoEventoPrecio(double precio, Estante<T> estante);
        public event DelegadoEventoPrecio EventoPrecio;
        #endregion
        #region propiedades
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo _capacidad de Estante
        /// </summary>
        public int Capacidad
        {
            get
            {
                return this._capacidad;
            }
            set
            {
                this._capacidad = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura del atributo _elementos de Estante
        /// </summary>
        public List<T> Elementos
        {
            get
            {
                return this._elementos;
            }
        }
        /// <summary>
        /// Propiedad de escritura y lectura del atributo _precioUnitario de Estante
        /// </summary>
        public double PrecioUnitario
        {
            get
            {
                return this._precioUnitario;
            }
            set
            {
                this._precioUnitario = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura del atributo precioTotal
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                double precioTotal = this.PrecioUnitario * this.Elementos.Count;
                if (precioTotal > 55)
                    this.EventoPrecio(precioTotal, this);
                return precioTotal;
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto que inicializa la lista del atributo _elementos de una instancia de Estante
        /// </summary>
        public Estante()
        {
            this._elementos = new List<T>();
        }
        /// <summary>
        ///Constructor que Inicializa el atributo capacidad de una instancia de Estante
        /// </summary>
        /// <param name="capacidad"></param>
        public Estante(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }
        /// <summary>
        /// Constructor que Inicializa el atributo _precioUnitario de una instancia de Estante
        /// </summary>
        /// <param name="precioUnitario"></param>
        /// <param name="capacidad"></param>
        public Estante(double precioUnitario, int capacidad) : this(capacidad)
        {
            this._precioUnitario = precioUnitario;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra el valor de los atributos de una instancia actual de tipo Estante
        /// </summary>
        /// <returns>retorna un string con el valor de los atributos</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("Capacidad: " + this._capacidad);
            retorno.AppendLine("Cantidad total de frutas: " + this._elementos.Count);
            retorno.AppendLine("Precio venta total del estante: " + this.PrecioTotal);
            retorno.AppendLine("Frutas en el estante:\n");
            foreach (T item in this._elementos)
                retorno.AppendLine(item.ToString());

            return retorno.ToString();
        }
        /// <summary>
        /// Esta funcion permite guardar un archivo con serializacion xml con datos de la instancia
        /// </summary>
        /// <param name="datos"></param>
        /// <returns>Retorna true si logro guarduar, caso contrario retorna false </returns>
        public bool Xml(string datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Estante<T>));
                using (TextWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + datos))
                {
                    serializador.Serialize(escritor, this);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al serializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }

        public static Estante<T> operator +(Estante<T> estante, T elemento)
        {
            if (estante._capacidad > estante._elementos.Count)
                estante._elementos.Add(elemento);
            else
                throw new EstanteLlenoException();
            return estante;
        }
        #endregion
    }
}