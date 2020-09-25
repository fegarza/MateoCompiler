using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Interfaces
{
    interface IInstruccion
    {
        string Token { get; set; }
        string valor { get; set; }

    }
}
