using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{//
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        //
        #region Enumerados

        /// <summary>
        /// Enumerado de nacionalidad
        /// </summary>
        public enum ENacionalidad
        {

            Argentino, Extranjero
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura/escritura para atributo apellido de Persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura/escritura para atributo nombre de Persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura/escritura del atributo DNI de persona
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura para  atributo nacionalidad de Persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            //
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }



        /// <summary>
        /// Propiedad solo escritura para atributo dni de Persona
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int dni = ValidarDni(this.Nacionalidad, value);
                //l
                if (dni != -1)
                {
                    this.DNI = dni;
                }
                else
                {
                    this.DNI = 1;
                }

            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que inicializa los atributos de un objeto de tipo Persona
        /// </summary>
        public Persona()
        {
            this.Apellido = "";
            this.DNI = 1;
            this.Nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        /// <summary>
        /// Constructor q inicializa los atributos nombre, apellido y nacionalidad de un objeto de tipo Persona
        /// </summary>
        /// <param name="nombre">el valor del atributo nombre del objeto de tipo Persona</param>
        /// <param name="apellido">el valor del atributo apellido del objeto de tipo Persona</param>
        /// <param name="nacionalidad">el valor del atributo nacionalidad del objeto de tipo Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Consctructor que inicializa los atributos nombre, apellido, dni y nacionalidad de un objeto de tipo Persona
        /// </summary>
        /// <param name="nombre">el valor del atributo nombre del objeto de tipo Persona</param>
        /// <param name="apellido">el valor del atributo apellido del objeto de tipo Persona</param>
        /// <param name="dni">el valor del atributo dni del objeto de tipo Persona</param>
        /// <param name="nacionalidad">el valor del atributo nacionalidad del objeto de tipo Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }
        /// <summary>
        /// Constructor que inicializa los atributos nombre, apellido, dni y nacionalidad de un objeto de tipo Persona
        /// </summary>
        /// <param name="nombre">el valor del atributo nombre del objeto de tipo Persona</param>
        /// <param name="apellido">el valor del atributo apellido del objeto de tipo Persona</param>
        /// <param name="dni">el valor del atributo dni del objeto de tipo Persona</param>
        /// <param name="nacionalidad">el valor del atributo nacionalidad del objeto de tipo Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        #endregion

        #region Metodos
        /// <summary>
        /// Sobrescritura del método ToString() que expone
        /// los datos de la Persona.
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);

            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que Valida que el valor ingresado para el atributo dni sea valido en base a los rangos permitidos para cada nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> valor del atributo nacionalidad del objeto de tipo Persona</param>
        /// <param name="dato"> dato a validar para el atributo dni del objeto de tipo Persona</param>
        /// <returns>Retorna -1 si el valor del dato no se condice con la nacionalidad del objeto, caso contrario retorna el dato</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = -1;

            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                retorno = dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                retorno = dato;
            }

            return retorno;
        }

        /// <summary>
        /// Metodo que valida que el valor ingresado para el atributo dni sea valido de acuerdo a los rangos permitidos para cada nacionalidad, que no tenga mas que 8 caracteres y que sean numeros
        /// </summary>
        /// <param name="nacionalidad"> valor del atributo nacionalidad del objeto de tipo Persona</param>
        /// <param name="dato"> dato a validar para el atributo dni del objeto de tipo Persona</param>
        /// <returns>Retorna -1 si el dato tiene mas de 8 caracteres o si el valor no es valido de acuerdo a la nacionalidad, 0 si no logro convertir del string a un entero, caso contrario retorna el dato</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numeroValidado = -1;

            try
            {
                //
                if (dato.Length > 8)
                {
                    throw new DniInvalidoException("El dni ingresado tiene mas caracteres de los permitidos");
                }
                if (int.TryParse(dato, out numeroValidado) == false)
                {
                    throw new DniInvalidoException();
                }
                else if (ValidarDni(nacionalidad, numeroValidado) == -1)
                {
                    throw new NacionalidadInvalidaException();
                }
                else
                {
                    numeroValidado = ValidarDni(nacionalidad, numeroValidado);
                }
            }
            catch (DniInvalidoException exDni)
            {
                throw exDni;//
            }
            catch (NacionalidadInvalidaException exNacionalidad)
            {
                throw exNacionalidad;
            }
            catch (OverflowException exOverflow)
            {
                Console.WriteLine(exOverflow.Message);
            }

            return numeroValidado;
        }

        /// <summary>
        /// Método que valida el nombre y apellido de la persona solo tenga letras
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns>Retorna un string vacio si el dato contiene un caracter que no es letra, caso contrario retorna el string</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (Char.IsLetter(letra) == false)
                {
                    dato = "";

                    break;
                }
            }

            return dato;
        }
        #endregion





    }
}
