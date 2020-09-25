using MateoCompiler.Clases;
using MateoCompiler.Clases.Facade;
using MateoCompiler.Clases.Singleton;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler
{
    public class Linea
    {
        public List<Instruccion> instruccionesReducidas = new List<Instruccion>();
        public List<Instruccion> instruccionesReducidasTipo = new List<Instruccion>();
        public List<Instruccion> instrucciones = new List<Instruccion>();
        GeneralFacade generalFacade = GeneralFacade.getInstancia();
        Lenguaje mateo = Lenguaje.ObtenerInstancia();
        public string contenidoAbsoluto;
        public string logsReducido;
        public string logsReducidoTipo;
        public string contenido;
        public string reducido = "";
        public string logs = "";

        public Linea(string _contenido)
        {
            contenido = _contenido;
            ObtenerInstrucciones();
            ObtenerTokens();
        }


        public Linea(string _contenido, bool semantica)
        {
            contenido = _contenido;
            ObtenerInstrucciones();
            ObtenerTokensSemantica();
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
                    if (!string.IsNullOrEmpty(instruccion))
                    {
                        instrucciones.Add(new Instruccion(instruccion));
                    }
                    instruccion = "";
                }
                else if (x == contenido.Length - 1)
                {
                    instruccion += contenido[x].ToString();
                    if (!string.IsNullOrEmpty(instruccion))
                    {
                        instrucciones.Add(new Instruccion(instruccion));
                    }

                    instruccion = "";
                }
                else
                {
                    if (asciiBytes[0] == 34)
                    {
                        cadena = !cadena;
                    }
                    instruccion += contenido[x].ToString();
                }
            }

        }



        public void ObtenerTokensSemantica()
        {
            int cont = -1;
            foreach (Instruccion i in instrucciones)
            {
                i.token = i.contenido;
            }


        }



        public void ObtenerTokens()
        {
            int cont = -1;
            foreach (Instruccion i in instrucciones)
            {
                cont++;
                i.CargarToken();
                if (i.token == null)
                {
                    if (cont != 0)
                    {
                        if (instrucciones[cont - 1].contenido == "var")
                        {
                            i.token = "ID00";
                            i.tokenIncrementable = mateo.CodigoEntrada.BuscarIncrementable(i.token.Substring(0, 4), i.contenido);
                        }
                        else
                        {
                            if (mateo.CodigoEntrada.identificadores.ContainsKey(i.contenido))
                            {
                                i.token = "ID00";
                                i.tokenIncrementable = mateo.CodigoEntrada.BuscarIncrementable(i.token.Substring(0, 4), i.contenido);

                            }
                            else if (i.caracteres.Count() > 0)
                            {
                                if (i.contenido[0].ToString() == "\"")
                                {
                                    i.token = "CA00";
                                    i.tokenIncrementable = mateo.CodigoEntrada.BuscarIncrementable(i.token.Substring(0, 4), i.contenido);
                                }
                            }


                        }
                    }
                    // MessageBox.Show($"Error en la palabra reservada {i.contenido}, no existe un camino en su matriz de transicion que de como resultado un token.");
                }
                else
                {
                    i.tokenIncrementable = mateo.CodigoEntrada.BuscarIncrementable(i.token.Substring(0, 4), i.contenido);
                }
            }


        }

        public override string ToString()
        {
            string text = "";
            foreach (Instruccion i in instrucciones)
            {
                if (!String.IsNullOrEmpty(i.token) && i.token.Count() >= 4)
                    text += i.token.Substring(0, 4) + " ";
            }
            return text;
        }

        public  string ToStringTipoDeDato()
        {
            string text = "";
   
            foreach (Instruccion i in instrucciones)
            {
                if (!String.IsNullOrEmpty(i.token) && i.token.Count() >= 4)
                    if (mateo.CodigoEntrada.identificadores.ContainsKey(i.contenido))
                    {
                        if (String.IsNullOrEmpty(mateo.CodigoEntrada.identificadores[i.contenido].Tipo))
                        {
                            text += "IDEN" + " ";
                        }
                        else
                        {
                            text += mateo.CodigoEntrada.identificadores[i.contenido].Tipo + " ";
                        }
                        
                    }
                    else
                    {
                        text += i.token.Substring(0, 4) + " ";
                    }
                   
            }
            return text;
        }

        public Linea Clone()
        {
            List<Instruccion> temp = new List<Instruccion>();
            foreach (Instruccion i in instrucciones)
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

        public bool Equals(Linea linea)
        {
            if (linea == null)
            {
                return false;
            }
            else
            {
                if (linea.ToString() == this.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void BuscarMinimaExpresion()
        {
            Linea linea = this.Clone();
            if (!String.IsNullOrEmpty(linea.ToString()))
            {
                logsReducido += $"┌──────> ANALIZA: [{linea.ToString()}] \n";
            }
            bool iterar = true;
            Linea actual = linea.Clone();
            while (iterar)
            {
                linea = ReducirTokens(linea);
                logsReducido += linea.logsReducido;
                if (actual.Equals(linea))
                {
                    iterar = false;
                }
                else
                {
                    actual = linea.Clone();
                }
            }
            if (!String.IsNullOrEmpty(linea.ToString()))
            {
                logsReducido += $"└>No hay más coinsidencias, termina el analisis. \n\n";
            }

            foreach (Instruccion i in actual.instrucciones)
            {
                instruccionesReducidas.Add((Instruccion)i.Clone());
            }

        }


        public Linea ReducirTokens(Linea linea)
        {
            return generalFacade.ReducirTokens(linea);
        }


    }
}
