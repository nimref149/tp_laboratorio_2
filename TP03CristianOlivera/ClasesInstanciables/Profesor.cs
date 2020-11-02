using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// COnstructor que inicializa el atributo estatico random de la clase Profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor que inicializa los atributos de la clase base Universitario
        /// </summary>
        public Profesor() : this(1, "Sin nombre", "Sin Apellido", "1", ENacionalidad.Argentino)
        { 
        
        }
        /// <summary>
        /// Constructor que inicializa los atributos de la clase base y tambien la lista del atributo clasesDelDia del objeto de tipo Profesor
        /// </summary>
        /// <param name="id">El valor del atributo legajo de la clase base Universitario</param>
        /// <param name="nombre">El valor del atributo nombr e de la clase base Universitario</param>
        /// <param name="apellido">El valor del atributo apellido de la clase base Universitario</param>
        /// <param name="dni">El valor del atributo dni de la clase base Universitario</param>
        /// <param name="nacionalidad">El valor del atributo nacionalidad de la clase base Universitario</param>
        public Profesor(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            //
            this._randomClases();
        }

        
        #endregion

        #region Metodos
        /// <summary>
        /// Usa el metodo Random.Next() para asignar objetos de tipo enumerado Universidad.EClases a la lista de objetos de tipo enumerado Universidad.EClases del atributo clasesDeDia de un objeto de tipo Profesor
        /// </summary>
        private void _randomClases()
        {
            //
            for (int i = 0; i < 2; i++)
            {

                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        /// <summary>
        ///Sobrecarga de metodo ParticiparEnClase() de la clase base Universitario que muestra la lista del atributo clasesDelDia de una instancia actual de tipo Profesor
        /// </summary>
        /// <returns>Retorna un string con el valor del atributo</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");
            //
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(Enum.GetName(typeof(Universidad.EClases), item));
            }

            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga de ToString() que muestra los valores de los atributos de una instancia de tipo Profesor
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        ///  Sobrecarga de metodo MostrarDatos() de la clase base Universitario que muestra el valor de los atributos apellido, nombre, nacionalidad, legajo y el atributo clasesDelDia de la instancia actual de tipo Profesor
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        protected override string MostrarDatos()
        {
            //
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador "==" que compara si un objeto de tipo Profesor es igual a uno de tipo enumerado Universidad.EClases. Seran iguales si el valor del tipo enumerado existe en la lista del atributo clasesDelDia del objeto de tipo Profesor.
        /// </summary>
        /// <param name="i">El objeto de tipo Profesor</param>
        /// <param name="clase">El objeto de tipo enumerado Universidad.EClases</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            //
            foreach (Universidad.EClases claseDelDia in i.clasesDelDia)
            {
                if (claseDelDia == clase)
                {
                    retorno = true;

                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador "!=" que compara si un objeto de tipo Profesor y uno de tipo enumerado Universidad.EClases son distintos
        /// </summary>
        /// <param name="i">El objeto de tipo Profesor</param>
        /// <param name="clase">El objeto de tipo enumerado Universidad.EClases</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {

            return !(i == clase);
        }
        #endregion


    }
}
