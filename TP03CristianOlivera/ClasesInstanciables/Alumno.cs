using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado de estado de cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa los atributos de la clase base Universitario
        /// </summary>
        public Alumno() : base(1, "", "", "1", ENacionalidad.Argentino)
        {
        
        }

        /// <summary>
        /// Constructor que inicializa el atributo clasesQueToma y tambien los atributos de la clase base Universitario
        /// </summary>
        /// <param name="id">El valor del atributo id de la clase base</param>
        /// <param name="nombre">El valor del atributo nombre de la clase base</param>
        /// <param name="apellido">El valor del atributo apellido de la clase base</param>
        /// <param name="dni">El valor del atributo dni de la clase base</param>
        /// <param name="nacionalidad">El valor del atributo nacionalidad de la clase base</param>
        /// <param name="clasesQueToma">El valor del atributo clasesQueToma de la clase Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }

        /// <summary>
        /// Constructor que inicializa los atributos clasesQueToma y estadoCuenta, tambien los atributos de la clase base Universitario
        /// </summary>
        /// <param name="id">El valor del atributo id de la clase base</param>
        /// <param name="nombre">El valor del atributo nombre de la clase base</param>
        /// <param name="apellido">El valor del atributo apellido de la clase base</param>
        /// <param name="dni">El valor del atributo dni de la clase base</param>
        /// <param name="nacionalidad">El valor del atributo nacionalidad de la clase base</param>
        /// <param name="clasesQueToma">El valor del atributo clasesQueToma de la clase Alumno</param>
        /// <param name="estadoCuenta">El valor del atributo estadoCuenta de la clase Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga del metodo MostrarDatos() de la clase base Universitario 
        /// que muestra el valor de los atributos apellido, nombre, nacionalidad, legajo y estadoCuenta de la instancia actual Alumno
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        protected override string MostrarDatos()
        {
            //
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            switch (this.estadoCuenta)//
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("ESTADO DE CUENTA: Cuota al día");

                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("ESTADO DE CUENTA: Deudor");

                    break;
                    //
                case EEstadoCuenta.Becado:
                    sb.AppendLine("ESTADO DE CUENTA: Becado");
                    break;
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString() que muestra el valor de los atributos de la instancia actual Alumno
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobrecarga de ParticiparEnClase() de la clase base Universitario, 
        /// que muestra el atributo clasesQueToma de la instancia actual de tipo Alumno
        /// </summary>
        /// <returns>Retorna un string con el valor del atributo</returns>
        protected override string ParticiparEnClase()
        {
            //
            return "TOMA CLASES DE: " + this.clasesQueToma;
        }

        
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga de operador "==" que compara si dos objetos de tipo Alumno y Universidad.EClases son iguales. 
        /// Seran iguales si el valor de clasesQueToma de Alumno es igual al valor del enumerador tipo Universidad.EClases, y si el estadoCuenta de Alumno es distinto de EEstadoCuenta.Deudor 
        /// </summary>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <param name="clase">El objeto de tipo Universidad.EClases</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.clasesQueToma == clase) && (a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Sobrecarga de operador != que compara si dos objetos de tipo Alumno y Universidad.EClases son distintos
        /// </summary>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <param name="clase">El objeto de tipo Universidad.EClases</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {

            return a.clasesQueToma != clase;
        }
        #endregion

        

        
    }
}
