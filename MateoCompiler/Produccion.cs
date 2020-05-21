using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler
{
    class Produccion
    {
        String contenido = "";
        public Produccion(String _contenido)
        {
            contenido = _contenido;
        }

        public Produccion getAsNewObject()
        {
            return new Produccion(contenido);
        }

        public override string ToString()
        {
            return this.contenido;
        }
    }
}
