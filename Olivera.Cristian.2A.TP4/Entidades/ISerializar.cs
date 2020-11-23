using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ISerializar
    {
        /// <summary>
        /// Metodo que se implementa en la clase estante y manzana
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Xml(string datos);
    }
}
