using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Banana : Fruta
    {
        #region atributos
        protected string _paisOrigen;

        #endregion

        #region propiedades
        /// <summary>
        /// /Propiedad de lectura 
        /// </summary>
        public string Nombre
        {
            get
            {
                return "Banana";
            }
        }
        /// <summary>
        /// Propiedad de escritura y lectura del atributo _paisOrigen de Banana
        /// </summary>
        public string Pais
        {
            get
            {
                return this._paisOrigen;
            }
            set
            {
                this._paisOrigen = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura 
        /// </summary>
        public override bool TieneCarozo
        {
            get
            {
                return false;
            }
        }
        #endregion
        #region constructores
        /// <summary>
        ///Constructor por defecto
        /// </summary>
        public Banana() : this(string.Empty, 0, string.Empty)
        {

        }
        /// <summary>
        /// Inicializa los atributos de una intancia de Banana
        /// </summary>
        /// <param name="color"></param>
        /// <param name="peso"></param>
        /// <param name="paisOrigen"></param>
        public Banana(string color, double peso, string paisOrigen) : base(color, peso)
        {
            this.Pais = paisOrigen;
        }
        #endregion
        #region metodos
        /// <summary>
        /// Muestra el valor de los atributos de una instancia actual Banana
        /// </summary>
        /// <returns>retorna un strinmg con el valor de los atributos</returns>
        protected override string FrutaToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(this.Nombre);
            retorno.Append(base.FrutaToString());
            retorno.AppendLine("Pais de origen: " + this._paisOrigen);
            retorno.AppendLine("Tiene carozo: " + this.TieneCarozo);

            return retorno.ToString();
        }
        /// <summary>
        /// Sobrecarga de ToString(). Muestra los valores de los atributos de una instancia de tipo Banana
        /// </summary>
        /// <returns>Retorna un string con los valores de los atributos </returns>
        public override string ToString()
        {
            return this.FrutaToString();
        }
        #endregion
        #region sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador == que evalua si un objeto tipos banana es igual a otro del mismo tipo, en base a su paisOrigen, color y peso
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorna true si son iguales, caso contrario false</returns>
        public static bool operator ==(Banana v1, Banana v2)
        {
            bool rta = false;

            if (v1._paisOrigen == v2._paisOrigen && v1._color == v2._color && v1._peso == v2._peso)
            {
            rta = true;
            }
  
            return rta;
        }
        /// <summary>
        /// Sobrecarga del operador != que evalua si un objeto de tipo banana y otro del mismo tipo son distintos
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Banana v1, Banana v2)
        {
            return !(v1 == v2);
        }
        #endregion



    }
}
