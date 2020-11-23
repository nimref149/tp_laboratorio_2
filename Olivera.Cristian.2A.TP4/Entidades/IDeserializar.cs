using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IDeserializar
    {/// <summary>
    /// metodo que se implementa en la clase manzana
    /// </summary>
    /// <param name="datos"></param>
    /// <param name="fruta"></param>
    /// <returns></returns>
        bool Xml(string datos, out Fruta fruta);
    }
}

