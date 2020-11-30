using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Pantalla))]
    [XmlInclude(typeof(SmartPhone))]
    public abstract class Producto
    {
        protected int idVentaProducto;
        protected string nombreProducto;
        protected float precio;
        protected string marca;

        #region Constructores
        /// <summary>
        /// Constructor defecto sin parametros para la serializacion XML
        /// </summary>
        public Producto()
        {
        }

        /// <summary>
        /// Constructor de Producto que agrega a atributo idVentaProducto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        public Producto(int id, string nombreProducto, float precio, string marca) : this(nombreProducto, precio, marca)
        {
            this.idVentaProducto = id;
        }


        /// <summary>
        /// Constructor de producto que agrega a atributos nombreProducto, precio, marca
        /// </summary>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        public Producto(string nombreProducto, float precio, string marca)
        {
            this.nombreProducto = nombreProducto;
            this.precio = precio;
            this.marca = marca;
        }
        #endregion

        #region Propiedades
        


        /// <summary>
        /// Propiedad de escritura y lectura de la marca
        /// </summary>
        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del id de venta
        /// </summary>
        public int ID
        {
            get
            {
                return this.idVentaProducto;
            }
            set
            {
                this.idVentaProducto = value;
            }
        }
        

        /// <summary>
        /// Propiedad de escritura y lectura del nombre del producto
        /// </summary>
        public string NombreProducto
        {
            get
            {
                return this.nombreProducto;
            }
            set
            {
                this.nombreProducto = value;
            }
        }
        /// <summary>
        /// Propiedad de escritura y lectura del precio
        /// </summary>
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        ///Funcion que se encarga de obtener los datos del producto
        /// </summary>
        /// <returns>Devuelve un string con los datos del producto</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<--------------------------------------------------------------------------->");
            sb.AppendFormat("Codigo de compra: {0}\nProducto: {1}\nMarca: {2}\nPrecio: {3}", this.idVentaProducto, this.nombreProducto, this.marca, this.precio);
            sb.AppendLine();

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de metodos

        /// <summary>
        /// Funcion que sobreecarga del equals utiliza la sobrecarga del operador ==
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna true si son iguales, false si no lo son</returns>
        public override bool Equals(object obj)
        {
            return obj is Producto && (Producto)obj == this;
        }

        /// <summary>
        /// Funcion que se encarga de obtener los datos del producto
        /// </summary>
        /// <returns>Devuelve un string con los datos del producto</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        
        #endregion


        #region Sobrecarga de operadores
        /// <summary>
        /// Compara dos objetos de tipo Producto. Dos productos seran iguales si su id de venta son iguales
        /// </summary>
        /// <param name="p1">objeto Producto</param>
        /// <param name="p2">objeto Producto</param>
        /// <returns>retorna true si son iguales, false si no lo son</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            bool iguales = false;

            if ((object)p1 != null && (object)p2 != null)
            {
                if (p1.idVentaProducto == p2.idVentaProducto)
                {
                    iguales = true;
                }
            }

            return iguales;
        }

        /// <summary>
        /// Compara dos objetos del tipo Producto
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Retorna true si son distintos, false si no lo son</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
