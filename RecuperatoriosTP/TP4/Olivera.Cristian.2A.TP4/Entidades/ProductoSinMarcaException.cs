using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoSinMarcaException : Exception
    {
        /// <summary>
        /// Constructor defecto que llama al constructor base
        /// </summary>
        public ProductoSinMarcaException() : base()
        {
        }

        /// <summary>
        /// Constructor que le pasa un mensaje al constructor base
        /// </summary>
        /// <param name="mensaje">mensaje a pasar al constructor base</param>
        public ProductoSinMarcaException(string mensaje) : base(mensaje)
        {
        }
    }
}
