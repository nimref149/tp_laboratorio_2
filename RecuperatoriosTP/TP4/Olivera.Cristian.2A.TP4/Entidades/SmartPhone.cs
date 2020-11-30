using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SmartPhone : Producto
    {
        private ESistemaOperativo SO;
        private EMemoria memoria;

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para  serializacion XML
        /// </summary>
        public SmartPhone()
        {
        }

        /// <summary>
        /// Instancia un objeto de tipo Tecnologia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        public SmartPhone(int id, string nombreProducto, float precio, string marca, ESistemaOperativo SO, EMemoria memoria) : base(id, nombreProducto, precio, marca)
        {
            this.SO = SO;
            this.memoria = memoria;
        }
        #endregion

        #region Propiedad
        

        /// <summary>
        /// Propiedad de lectura del enumerado pero lo devuelve en formato String
        /// </summary>
        public string Memoria
        {
            get
            {
                switch (memoria)
                {
                    case EMemoria.GB64:
                        return "64GB";
                    case EMemoria.GB32:
                        return "32GB";
                    default:
                        return "16GB";
                }
            }
        }

        /// <summary>
        /// Propiedad de lectura del enumerado pero lo devuelve en formato String
        /// </summary>
        public string SistemaOperativo
        {
            get
            {
                switch (SO)
                {
                    case ESistemaOperativo.iOS:
                        return "iOS";
                    default:
                        return "Android";
                }
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Funcion que se encarga de obtener los datos del SmartPhone
        /// </summary>
        /// <returns>Devuelve un string con los datos del SmartPhone</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("S.O: {0}\nMemoria: {1}\n", this.SO, this.Memoria);
            return sb.ToString();
        }

        /// <summary>
        /// Funcion que Realiza un mapeo del string para convertirlo en tipo ESistemaOperativo
        /// </summary>
        /// <param name="aux"></param>
        /// <returns></returns>
        public static ESistemaOperativo MapeoSistemaOperativo(string aux)
        {
            switch (aux)
            {
                case "iOS":
                    return ESistemaOperativo.iOS;
                case "Android":
                    return ESistemaOperativo.Android;
                default:
                    return ESistemaOperativo.Windows;
            }
        }

        /// <summary>
        /// Funcion que Realiza un mapeo del string para convertirlo en tipo EMemoria
        /// </summary>
        /// <param name="aux"></param>
        /// <returns></returns>
        public static EMemoria MapeoMemoria(string aux)
        {
            switch (aux)
            {
                case "64GB":
                    return EMemoria.GB64;
                case "32GB":
                    return EMemoria.GB32;
                default:
                    return EMemoria.GB16;
            }
        }

        
        #endregion

        #region Sobrecarga de metodos
        /// <summary>
        /// Funcion que se encarga de obtener los datos del SmartPhone
        /// </summary>
        /// <returns>Devuelve un string con los datos del SmartPhone</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
