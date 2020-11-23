using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Melocoton : Fruta
    {
        #region atributos
        protected int _cantPelusa;
        #endregion
        #region propiedades
        /// <summary>
        /// Propiedad de lectura 
        /// </summary>
        public string Nombre
        {
            get
            {
                return "Melocoton";
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo _cantPelusa de Melocoton
        /// </summary>
        public int CantidadPelusa
        {
            get
            {
                return this._cantPelusa;
            }
            set
            {
                this._cantPelusa = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura
        /// </summary>
        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }
        #endregion
        #region constructores
        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        public Melocoton()
            : this("", 0, 0)
        {
        }
        /// <summary>
        /// Constructoru que inicializa el atributo _cantPelusa de Melocoton
        /// </summary>
        /// <param name="color"></param>
        /// <param name="peso"></param>
        /// <param name="cantidadPelusa"></param>
        public Melocoton(string color, double peso, int cantidadPelusa)
            : base(color, peso)
        {
            this.CantidadPelusa = cantidadPelusa;
        }
        #endregion
        #region metodos
        /// <summary>
        ///Sobrecarga de la clase Base Fruta que muestra el valor de los atributos de la la instancia actual tipo  Melocoton
        /// </summary>
        /// <returns></returns>
        protected override string FrutaToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(this.Nombre);
            datos.Append(base.FrutaToString());
            datos.AppendLine("Cantidad de pelusa: " + this._cantPelusa);
            datos.AppendLine("Tiene carozo: " + this.TieneCarozo);

            return datos.ToString();
        }
        /// <summary>
        /// Sobrecarga de ToString(). Muestra los valores de los atributos de una instancia de tipo Melocoton
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.FrutaToString();
        }
        #endregion
    }
}
