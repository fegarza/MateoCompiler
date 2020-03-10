using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler
{
    class Linea
    {
        public string contenido;
        public List<Instruccion> instrucciones = new List<Instruccion>();
        public Linea(string _contenido)
        {
            contenido = _contenido;
            ObtenerInstrucciones();
        }
        public void ObtenerInstrucciones()
        {
           
            string instruccion = "";
            for (int x = 0; x < contenido.Length; x++)
            {

                byte[] asciiBytes = Encoding.ASCII.GetBytes(contenido[x].ToString());
                 
                if (asciiBytes[0] == 32)
                {
                    instrucciones.Add(new Instruccion(instruccion));
                    instruccion = "";
                }
                else if (x == contenido.Length - 1)
                {
                    instruccion += contenido[x].ToString();
                    instrucciones.Add(new Instruccion(instruccion));
                    instruccion = "";
                }
                else
                {
                    instruccion += contenido[x].ToString();
                }
            }
            foreach(Instruccion x in instrucciones)
            {
                System.Windows.Forms.MessageBox.Show(x.contenido);
            }

        }
    }
}
