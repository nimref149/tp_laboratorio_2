using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
    public static class MetodoExtension
    {
        public static bool Guardar(this Vendedora vendedora, string path, string datos)
        {
            Texto t = new Texto();

            return t.Guardar(path, datos);
        }

        public static bool Leer(this Vendedora vendedora, string path, out string datos)
        {
            Texto t = new Texto();

            return t.Leer(path, out datos);
        }
    }
}
