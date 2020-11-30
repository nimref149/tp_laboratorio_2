using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        bool Guardar(string path, T datos);

        bool Leer(string path, out T datos);
    }
}
