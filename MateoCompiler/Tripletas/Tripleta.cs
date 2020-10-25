using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Tripletas
{
    interface Tripleta
    {
        string[,] Arreglo { get; set; }
        string GenerarCodigoIntermedio();
    }
}
