using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura/escritura del atributo alumnos de Jornada
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura/escritura del atributo instructor de Jornada
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura/escritura del atributo clase de Jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        
        #endregion

        #region Constructores
        /// <summary>
        /// Consctructor que inicializa la lista del atributo alumnos de una instancia de Jornada
        /// </summary>
        Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que inicializa los atributos clase e instructor de una instancia de Jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        ///Sobrecarga del metodo ToString() que muestra el valor de los atributos clase, instructor y alumnos de una instancia actual de tipo Jornada
        /// </summary>
        /// <returns>Retorna un string con el valor de los atributos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE: " + this.Clase + " POR " + this.Instructor.ToString());

            sb.AppendLine("ALUMNOS:");

            foreach (Alumno alumnoEnJornada in this.Alumnos)
            {
                sb.AppendLine(alumnoEnJornada.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo estatico que lee de un archivo de texto los datos contenidos y los devuelve
        /// </summary>
        /// <returns>Retorna un string con los datos contenidos en el archivo de texto</returns>
        public static string Leer()
        {
            Texto jornadaAGuardar = new Texto();
            //
            if (!jornadaAGuardar.Leer("Jornada.txt", out string jornada))
            {
                throw new ArchivosException(new Exception());
            }

            return jornada;
        }
        /// <summary>
        /// Metodo estatico que guarda en un archivo de texto los datos contenidos en un objeto de tipo Jornada
        /// </summary>
        /// <param name="jornada">El objeto de tipo Jornada cuyos datos se guardaran en el archivo de texto</param>
        /// <returns>Retorna true si logro guardar el objeto de tipo Jornada, caso contrario retorna false</returns>
        public static bool Guardar(Jornada jornada)
        {
            //
            Texto jornadaAGuardar = new Texto();

            return jornadaAGuardar.Guardar("Jornada.txt", jornada.ToString());
        }

        
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador "==" que compara si un objeto de tipo Jornada y otro de tipo Alumno son iguales
        /// Seran iguales si el atributo de clasesQueToma del objeto de tipo Alumno es igual al de clase del objeto de tipo Jornada
        /// </summary>
        /// <param name="j">El objeto de tipo Jornada</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {//

            return (!(a != j.Clase));
        }

        /// <summary>
        /// Sobrecarga del operador "!=" que comparara si un objeto de tipo Jornada y otro de tipo Alumno son distintos
        /// </summary>
        /// <param name="j">El objeto de tipo Jornada</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador "+" que agrega un objeto de tipo Alumno a la lista del atributo alumnos de un objeto de tipo Jornada. 
        /// El alumno solo se agregara si no existe en la lista
        /// </summary>
        /// <param name="j">El objeto de tipo Jornada</param>
        /// <param name="a">El objeto de tipo Alumno</param>
        /// <returns>Retorna un objeto de tipo Jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool retorno = false;
            //
            foreach (Alumno alumnoEnJornada in j.Alumnos)
            {
                if (alumnoEnJornada == a)
                {
                    retorno = true;

                    break;
                }
            }
            if (retorno == false)
            {
                j.Alumnos.Add(a);
            }
            //n
            return j;
        }
        #endregion

        
    }
}
