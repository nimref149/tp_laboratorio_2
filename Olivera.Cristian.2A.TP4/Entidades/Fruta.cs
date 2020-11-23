using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Manzana))]
    [XmlInclude(typeof(Banana))]
    [XmlInclude(typeof(Melocoton))]

    public abstract class Fruta
    {
        #region atributos
        protected string _color;
        protected double _peso;
        #endregion

        #region propiedades
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo _color de Fruta
        /// </summary>
        public string Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo _peso
        /// </summary>
        public double Peso
        {
            get
            {
                return this._peso;
            }
            set
            {
                this._peso = value;
            }
        }
        /// <summary>
        /// Propiedad abstracta 
        /// </summary>
        public abstract bool TieneCarozo
        {
            get;
        }

        #endregion

        #region constructores
        /// <summary>
        /// Constructor que inicializa los atributos _color y _peso de la clase Fruta
        /// </summary>
        /// <param name="color"></param>
        /// <param name="peso"></param>
        public Fruta(string color, double peso)
        {
            this.Color = color;
            this.Peso = peso;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra el valor de los atributos de la instancia actual de tipo Fruta
        /// </summary>
        /// <returns></returns>
        protected virtual string FrutaToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("Color: " + this._color);
            datos.AppendLine("Peso: " + this._peso);

            return datos.ToString();
        }
        #endregion
    }
}
 