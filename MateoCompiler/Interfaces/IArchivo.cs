using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Interfaces
{
    public interface IArchivo
    {
        string Ruta { get;  set; }
        string[] Lineas { get; set; }

    }
}
