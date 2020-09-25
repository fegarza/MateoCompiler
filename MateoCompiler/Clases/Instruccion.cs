using MateoCompiler.Clases;
using MateoCompiler.Clases.Facade;
using MateoCompiler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler
{
    public class Instruccion: ICloneable
    {
        public string contenido;
        public string token;
        public string tokenIncrementable;


        public List<string> caracteres = new List<string>();
        private GeneralFacade generalFacade = GeneralFacade.getInstancia();
        public Instruccion(string _contenido)
        {
            contenido = _contenido.Replace("\t", "").Trim();
            ObtenerCaracteres();
        }
        public Instruccion(string _contenido, string _token)
        {
            contenido = _contenido;
            token = _token;
            ObtenerCaracteres();
        }

        public Instruccion()
        {
            ObtenerCaracteres();
        }

        public int ObtenerLongitud()
        {
            int cantidad = 0;
            bool expresion = false;
            for (int x = 0; x < contenido.Length; x++)
            {
                if (contenido[x].ToString() == "<")
                {
                    expresion = true;
                }
                else if (expresion)
                {
                    if (contenido[x].ToString() == ">")
                    {
                        cantidad++;
                        expresion = false;
                    }
                }
                else { cantidad++; }
            }
            return cantidad;
        }
        public void ObtenerCaracteres()
        {
            string expre = "";
            bool expresion = false;
            for (int x = 0; x < contenido.Length; x++)
            {
                if (contenido[x].ToString() == "<")
                {
                    expresion = true;
                    expre = "<";
                }
                else if (expresion)
                {
                    expre += contenido[x];
                    if (contenido[x].ToString() == ">")
                    {
                        expresion = false;
                        caracteres.Add(expre);
                    }
                }
                else
                {
                    caracteres.Add(contenido[x].ToString());
                }

            }

        }

        public void CargarToken()
        {
            this.token = generalFacade.ObtenerToken(this.caracteres);
        }

        public object Clone()
        {
            return new Instruccion(contenido, token);
        }
    }
}
