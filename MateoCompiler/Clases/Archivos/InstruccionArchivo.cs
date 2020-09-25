using MateoCompiler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateoCompiler.Clases.Archivos
{
    class InstruccionArchivo : Archivo
    {
        public List<Instruccion> Instrucciones = new List<Instruccion>();
        public List<string> Alfabeto = new List<string>();

        public InstruccionArchivo(): base(@".\instrucciones.txt")
        {
            //1 Instrucciones y simbolos
            int cont = 1;
            string tempToken = "";
            foreach (string x in this.Lineas)
            {
                //Token
                if (cont % 2 != 0)
                {
                    tempToken = x;
                }
                //Texto
                else
                {
                    Instrucciones.Add(new Instruccion(x, tempToken));
                    AnalizarSimbolos(x);
                }
                cont++;
            }
        }

        private void AnalizarSimbolos(string contenido)
        {
            //dgInstrucciones.Rows.Add(i.token, i.contenido);
            bool definicion = false;
            string definicionStr = "";
            for (int x = 0; x < contenido.Length; x++)
            {
                if (definicion)
                {
                    definicionStr += contenido[x];
                    if (contenido[x] == '>')
                    {
                        definicion = false;
                        if (!Alfabeto.Contains(definicionStr.ToLower()))
                        {
                            Alfabeto.Add(definicionStr.ToLower());
                        }

                        definicionStr = "";
                    }

                }
                else if (contenido[x] == '<')
                {
                    definicion = true;
                    definicionStr += contenido[x];
                }
                else
                {
                    if (!Alfabeto.Contains(contenido[x].ToString().ToLower()))
                    {
                        Alfabeto.Add(contenido[x].ToString().ToLower());
                    }
                }

            }
        }

        public void CargarInstrucciones(DataGridView dgView)
        {
            dgView.Rows.Clear();
            foreach (Instruccion i in Instrucciones)
            {
                dgView.Rows.Add(i.token, i.contenido);
            }

        }

        public void CargarSimbolos(DataGridView dgView)
        {
            foreach (string s in Alfabeto)
            {
                dgView.Rows.Add(s);
            }
        }

    }
}
