using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstanteLlenoException : Exception
    {/// <summary>
     ///Inicializa el atributo message de la clase base Exception
     /// </summary>
        public EstanteLlenoException()
            : base("El estante esta lleno, no se puede agregar mas!")
        {
        }
    }
}
