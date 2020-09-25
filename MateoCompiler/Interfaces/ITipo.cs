using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Interfaces
{
    public interface ITipo
    {
        Instruccion instruccionNativa { get; set; }
        string ObtenerIncrementable();
    }
}
