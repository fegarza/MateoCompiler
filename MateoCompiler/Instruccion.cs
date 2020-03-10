using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler
{
    public class Instruccion
    {
        public string contenido;
        public string token;
        public Instruccion(string _contenido)
        {
            contenido = _contenido;
        }
        public Instruccion(string _contenido, string _token)
        {
            contenido = _contenido;
            token = _token;
        }
        public Instruccion()
        { }
    }
}
