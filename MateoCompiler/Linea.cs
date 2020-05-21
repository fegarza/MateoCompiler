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
        public string contenidoAbsoluto;
        public List<Instruccion> instrucciones = new List<Instruccion>();
        public Linea(string _contenido)
        {
            contenido = _contenido;
            ObtenerInstrucciones();
        }
        public Linea(string _contenido, string _contenidoAbsoluto)
        {
            contenidoAbsoluto = _contenidoAbsoluto;
            contenido = _contenido;
            ObtenerInstrucciones();
        }
        public Linea(string _contenido, string _contenidoAbsoluto, List<Instruccion> _instrucciones)
        {
            contenidoAbsoluto = _contenidoAbsoluto;
            contenido = _contenido;
            instrucciones = _instrucciones;
            ObtenerInstrucciones();
        }

        public Linea() { }
        public void ObtenerInstrucciones()
        {
            Boolean cadena = false;
            string instruccion = "";
            for (int x = 0; x < contenido.Length; x++)
            {

                byte[] asciiBytes = Encoding.ASCII.GetBytes(contenido[x].ToString());
                 
                if (asciiBytes[0] == 32 && !cadena)
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
                    if (asciiBytes[0] == 34) {
                        cadena = !cadena;
                    }
                    instruccion += contenido[x].ToString();
                }
            }

        }
        
        public override string ToString()
        {
            string text = "";
            foreach(Instruccion i in instrucciones)
            {
                if(!String.IsNullOrEmpty(i.token) && i.token.Count() >= 4)
                    text += i.token.Substring(0,4) + " ";
            }
            return text;
        }

     
        public Linea Clone()
        {
            List<Instruccion> temp = new List<Instruccion>();
            foreach(Instruccion i in instrucciones)
            {
                temp.Add(i);
            }
            return new Linea
            {
                contenido = this.contenido,
                contenidoAbsoluto = this.contenidoAbsoluto,
                instrucciones = temp
            };
        }

        public  bool Equals(Linea linea)
        {
            if (linea == null) 
            {
                return false;
            }
            else
            {
                if (linea.ToString() == this.ToString()) {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
