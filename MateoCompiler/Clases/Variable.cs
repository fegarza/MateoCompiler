using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler
{
    class Variable
    {
        public string Nombre;
        public string Tipo;
        public Variable(string _nombre, string _tipo) 
        {
            Nombre = _nombre;
            Tipo = _tipo;
        }
 
    }
}
