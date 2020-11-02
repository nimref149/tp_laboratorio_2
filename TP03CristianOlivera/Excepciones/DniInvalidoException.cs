using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor que inicializa el atributo message de clase base Exception
        /// </summary>
        public DniInvalidoException() : base("La nacionalidad no se condice con el numero de DNI") 
        {
        
        }

        /// <summary>//
        /// Constructor que inicializa los atributos message de clase base Exception, al dar el valor de la propiedad de Message de una excepcion
        /// </summary>
        /// <param name="e">La excepcion que contiene el mensaje que va a utilizar la instancia de la clase base</param>
        public DniInvalidoException(Exception e) : this(e.Message) 
        {
        
        }

        /// <summary>
        /// Constructor que inicializa los atributos message de la clase base Exception, dando el valor de un string
        /// </summary>
        /// <param name="mensaje">El mensaje que va a utilizar la instancia de la clase base</param>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
        
        }

        /// <summary>
        /// Constructor que inicializa los atributos message e innerException de la clase base Exception
        /// </summary>
        /// <param name="mensaje">El valor del atributo message de la clase base Exception</param>
        /// <param name="e">El valor del atributo innerException de la clase base Exception</param>
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e) 
        {
        
        }

    }
}
