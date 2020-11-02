using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos

        private int legajo;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa el atributo legajo de un objeto de tipo Universitario y tambien los atributos de la clase base Persona
        /// </summary>
        public Universitario() : base("", "", ENacionalidad.Argentino)
        { 
        
        }

        /// <summary>
        /// Constructor que inicializa el atributo legajo de un objeto de tipo Universitario y tambien los atributos de la clase base Persona
        /// </summary>
        /// <param name="legajo">El valor del atributo legajo del objeto de tipo Universitario</param>
        /// <param name="nombre">El valor del atributo nombre de la clase base Persona</param>
        /// <param name="apellido">El valor del atributo apellido de la clase base Persona</param>
        /// <param name="dni">El valor del atributo dni de la clase base Persona</param>
        /// <param name="nacionalidad">El valor del atributo nacionalidad de la clase base Persona</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {

            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga de metodo Equals() que verifica si un objeto es del mismo tipo que la instancia actual
        /// </summary>
        /// <param name="obj">El objeto a comparar</param>
        /// <returns>Retorna true si son del mismo tipo, caso contrario retorna false</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj != null)
            {
                retorno = (obj.GetType() == this.GetType());
            }

            return retorno;
        }
        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns>Retorna un string</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga de MostrarDatos() de la clase base Persona que muestra valor de los atributos apellido, nombre, nacionalidad y legajo de la instancia actual
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        protected virtual string MostrarDatos()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());

            sb.AppendLine("\nLEGAJO NUMERO: " + this.legajo);

            return sb.ToString();
        }

        
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador "==" que verifica si dos objetos de tipo Universitario son iguales. 
        /// Que seran iguales si son del mismo tipo y si el valor de sus legajos o DNIs son iguales
        /// </summary>
        /// <param name="pg1">objeto de tipo Universitario</param>
        /// <param name="pg2">otro objeto de tipo Universitario</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            return pg1.Equals(pg2) && ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI));

        }

        /// <summary>
        /// Sobrecarga del operador "!=" que verifica si dos objetos de tipo Universitario son distintos
        /// </summary>
        /// <param name="pg1">objeto de tipo Universitario</param>
        /// <param name="pg2">otro objeto de tipo Universitario</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {

            return !(pg1 == pg2);
        }
        #endregion



    }
}
