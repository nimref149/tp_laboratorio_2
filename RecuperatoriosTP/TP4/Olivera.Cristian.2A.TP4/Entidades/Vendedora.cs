using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
    public sealed class Vendedora
    {
        private List<Producto> listaDeProductos;

        #region Constructor
        /// <summary>
        /// Creo una instancia de vendedora e instancio la lista
        /// </summary>
        public Vendedora()
        {
            this.listaDeProductos = new List<Producto>();
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedaded de lectua y escritura de la lista de productos
        /// </summary>
        public List<Producto> ListaDeProductos
        {
            get
            {
                return this.listaDeProductos;
            }
            set
            {
                this.listaDeProductos = value;
            }
        }

        /// <summary>
        /// Propiedaded de lectura del PrecioProductootal
        /// </summary>
        public float PrecioTotal
        {
            get
            {
                float buffer = 0;

                foreach (Producto auxP in this.listaDeProductos)
                {
                    buffer += auxP.Precio;
                }

                return buffer;
            }
        }
        #endregion

        #region Metodo
        

        /// <summary>
        /// Lee archivo XML y lo graba en un objeto Vendedora
        /// </summary>
        /// <returns>Objeto Vendedora</returns>
        public static Vendedora LeerXml(string path)
        {
            Serializacion<Vendedora> u = new Serializacion<Vendedora>();
            Vendedora vendedora = new Vendedora();

            u.Leer(path, out vendedora);

            return vendedora;
        }
        /// <summary>
        /// Funcion que serializa en formato XML los atributos del objeto Vendedora
        /// </summary>
        /// <param name="vendedora">Objeto Vendedora</param>
        /// <returns>Retorna true si pudo serializar el objeto</returns>
        public static bool GuardarXml(string path, Vendedora vendedora)
        {
            Serializacion<Vendedora> u = new Serializacion<Vendedora>();
            return u.Guardar(path, vendedora);
        }
        #endregion

        #region Sobrecarga de metodos

        /// <summary>
        /// Genero un string con los datos de la vendedora
        /// </summary>
        /// <returns>Retorna string con los datos de la vendedora</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Vendedora:");
            sb.AppendFormat("Cantidad: {0}\nPrecio total: {1}\n", this.listaDeProductos.Count, this.PrecioTotal);
            foreach (Producto auxProducto in this.listaDeProductos)
            {
                sb.Append(auxProducto.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga operadores

        /// <summary>
        /// Compara un objeto vendedora con un objeto producto
        /// </summary>
        /// <param name="v">Objeto Vendedora</param>
        /// <param name="p">Objeto Producto</param>
        /// <returns>Retorna true si el producto se encuentra en la lista de vendedora, caso contrario retorna false</returns>
        public static bool operator ==(Vendedora v, Producto p)
        {
            bool iguales = false;

            if ((object)v != null && (object)p != null)
            {
                foreach (Producto auxProducto in v.listaDeProductos)
                {
                    if (auxProducto.Equals(p))
                    {
                        iguales = true;
                        break;
                    }
                }
            }

            return iguales;
        }

        /// <summary>
        /// Compara un objeto vendedora con un objeto producto
        /// </summary>
        /// <param name="v">Objeto Vendedora</param>
        /// <param name="p">Objeto Producto</param>
        /// <returns>Retorna false si el no producto se encuentra en la lista de vendedora, caso contrario retorna true</returns>
        public static bool operator !=(Vendedora v, Producto p)
        {
            return !(v == p);
        }

        /// <summary>
        /// Agrega un objeto Producto a la lista del objeto Vendedora, siempre y cuando este no se encuentre en la lista
        /// </summary>
        /// <param name="v">Objeto Vendedora</param>
        /// <param name="p">Objeto Producto</param>
        /// <returns></returns>
        public static Vendedora operator +(Vendedora v, Producto p)
        {
            if (v != p)
            {
                v.listaDeProductos.Add(p);
            }
            return v;
        }

        #endregion
    }
}
