using MateoCompiler.Clases.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Clases
{
    class Codigo
    {
        #region INCREMENTABLES
        public Dictionary<string, string> numeros = new Dictionary<string, string>();
        public Dictionary<string, string> decimales = new Dictionary<string, string>();
        public Dictionary<string, Identificador> identificadores = new Dictionary<string, Identificador>();
        public Dictionary<string, string> cadenas = new Dictionary<string, string>();
        public Dictionary<string, string> booleanos = new Dictionary<string, string>();

        public List<Linea> lineas = new List<Linea>();
        public List<Linea> lineasReducidas = new List<Linea>();
        public List<Linea> lineasDeTipo = new List<Linea>();
        public List<Linea> lineasDeTipoReducidas = new List<Linea>();

        public List<Linea> lineasDeSemantica = new List<Linea>();
        public List<Linea> lineasDeSemanticaReducidas = new List<Linea>();

        private GeneralFacade generalFacade = GeneralFacade.getInstancia();
        #endregion

        private string _strContenido;
        private string _strContenidoSemantica;

        public string ContenidoSemantica
        {
            get { return _strContenidoSemantica; }
            set { _strContenidoSemantica = value;
                EstablecerLineasSemantica();
            }
        }




        public int Contador = 0;
        public string Contenido
        {
            get { return _strContenido; }
            set
            {
                _strContenido = value;
                EstablecerLineas();
            }
        }

        public Codigo()
        {

        }


        public string BuscarIncrementable(string _token, string _valor)
        {
            int digito = 0;
            string newToken = _token;
            try
            {

                switch (_token.Substring(0, 2))
                {
                    case "NU":

                        if (numeros.Count == 0)
                        {
                            digito++;
                            newToken = "NU" + "0" + digito.ToString();
                            numeros.Add(_valor, newToken);
                        }
                        else
                        {
                            digito = int.Parse(numeros.Last().Value.Substring(2, 2));
                            if (digito < 9)
                            {
                                digito++;
                                newToken = "NU" + "0" + digito.ToString();
                            }
                            else
                            {
                                digito++;
                                newToken = "NU" + digito.ToString();
                            }
                            if (!numeros.ContainsKey(_valor))
                            {
                                numeros.Add(_valor, newToken);
                            }
                            else
                            {
                                newToken = numeros[_valor];
                            }
                        }






                        break;
                    case "DE":
                        if (decimales.Count == 0)
                        {
                            digito++;
                            newToken = "DE" + "0" + digito.ToString();
                            decimales.Add(_valor, newToken);
                        }
                        else
                        {
                            digito = int.Parse(decimales.Last().Value.Substring(2, 2));
                            if (digito < 9)
                            {
                                digito++;
                                newToken = "DE" + "0" + digito.ToString();
                            }
                            else
                            {
                                digito++;
                                newToken = "DE" + digito.ToString();
                            }
                            if (!decimales.ContainsKey(_valor))
                            {
                                decimales.Add(_valor, newToken);
                            }
                            else
                            {
                                newToken = decimales[_valor];
                            }
                        }
                        break;
                    case "CA":
                        if (cadenas.Count == 0)
                        {
                            digito++;
                            newToken = "CA" + "0" + digito.ToString();
                            cadenas.Add(_valor, newToken);
                        }
                        else
                        {
                            digito = int.Parse(cadenas.Last().Value.Substring(2, 2));
                            if (digito < 9)
                            {
                                digito++;
                                newToken = "CA" + "0" + digito.ToString();
                            }
                            else
                            {
                                digito++;
                                newToken = "CA" + digito.ToString();
                            }
                            if (!cadenas.ContainsKey(_valor))
                            {
                                cadenas.Add(_valor, newToken);
                            }
                            else
                            {
                                newToken = cadenas[_valor];
                            }
                        }
                        break;
                    case "BO":
                        if (booleanos.Count == 0)
                        {
                            digito++;
                            newToken = "BO" + "0" + digito.ToString();
                            booleanos.Add(_valor, newToken);
                        }
                        else
                        {
                            digito = int.Parse(booleanos.Last().Value.Substring(2, 2));
                            if (digito < 9)
                            {
                                digito++;
                                newToken = "BO" + "0" + digito.ToString();
                            }
                            else
                            {
                                digito++;
                                newToken = "BO" + digito.ToString();
                            }
                            if (!booleanos.ContainsKey(_valor))
                            {
                                booleanos.Add(_valor, newToken);
                            }
                            else
                            {
                                newToken = booleanos[_valor];
                            }
                        }
                        break;
                    case "ID":
                        if (identificadores.Count == 0)
                        {
                            digito++;
                            newToken = "ID" + "0" + digito.ToString();
                            identificadores.Add(_valor, new Identificador(newToken));
                        }
                        else
                        {
                            digito = int.Parse(identificadores.Last().Value.Id.Substring(2, 2));
                            if (digito < 9)
                            {
                                digito++;
                                newToken = "ID" + "0" + digito.ToString();
                            }
                            else
                            {
                                digito++;
                                newToken = "ID" + digito.ToString();
                            }

                            if (!identificadores.ContainsKey(_valor))
                            {
                                identificadores.Add(_valor, new Identificador(newToken));
                            }
                            else
                            {
                                newToken = identificadores[_valor].Id;
                            }
                        }
                        break;
                    
                    default:
                        //   MessageBox.Show($"El token: {_valor} no tiene incrementable");
                        break;
                }
                return newToken;
            }
            catch
            {
                return newToken;
            }

        }

        public void EstablecerTipo(string _id, string _tipo)
        {
            if(_tipo == "ID00")
            {
                foreach (KeyValuePair<string, Identificador> n in identificadores)
                {
                    if(_id == n.Value.Id)
                    {
                        if (this.identificadores.ContainsKey(_id))
                        {
                            this.identificadores[_id].Tipo = n.Value.Tipo;
                        }
                    }
                }
            }
            else
            {
                if (this.identificadores.ContainsKey(_id))
                {
                    if(_tipo == "NUME" || _tipo == "CADE" || _tipo == "DECI")
                    {
                        this.identificadores[_id].Tipo = _tipo;
                    }
                   
                }
            }
           
        }


        public string BuscarTipoDeDato(string _id)
        {
            foreach (KeyValuePair<string, Identificador> n in identificadores)
            {
                if(n.Value.Id == _id)
                {
                    return n.Value.Tipo;
                }
            }
             

            return _id;
        }


        public void EstablecerLineas()
        {
            #region ESTABLECER LINEAS EN BASE A LA ENTRADA
            string linea = "";

            //Recorremos cada linea del codigo de entrada
            for (int x = 0; x < _strContenido.Length; x++)
            {
                //Obtenemos el numero del codigo ASCII
                byte[] asciiBytes = Encoding.ASCII.GetBytes(_strContenido[x].ToString());

                //Si se trata de un ENTER
                if (asciiBytes[0] == 10)
                {
                    if (!String.IsNullOrEmpty(linea.Trim()))
                    {
                        lineas.Add(new Linea(linea));
                        lineasReducidas.Add(BuscarMinimaExpresion(new Linea(linea), "producciones"));
                        lineasDeTipo.Add(BuscarMinimaExpresion(new Linea(linea), "definicionesTipoDeDato"));
                        //lineasDeTipoReducidas.Add(BuscarMinimaExpresion(new Linea(linea), "produccionesTipoDeDato"));
                    }
                    linea = "";
                }
                //Si nos encontramos al final de la linea
                else if (x == _strContenido.Length - 1)
                {
                    //linea += _strContenido.ToString();
                    if (!String.IsNullOrEmpty(linea.Trim()))
                    {
                        lineas.Add(new Linea(linea));
                        lineasReducidas.Add(BuscarMinimaExpresion(new Linea(linea), "producciones"));
                        lineasDeTipo.Add(BuscarMinimaExpresion(new Linea(linea), "definicionesTipoDeDato"));
                        //lineasDeTipoReducidas.Add(BuscarMinimaExpresion(new Linea(linea), "produccionesTipoDeDato"));
                    }

                    linea = "";
                }
                //Seguimos concatenando
                else
                {
                    if (!String.IsNullOrEmpty(_strContenido[x].ToString()))
                    {
                        linea += _strContenido[x].ToString();
                    }
                }
            }
            #endregion
           

        }


        public void EstablecerLineasSemantica()
        {
            #region ESTABLECER LINEAS EN BASE A LA ENTRADA
            string linea = "";

            //Recorremos cada linea del codigo de entrada
            for (int x = 0; x < _strContenidoSemantica.Length; x++)
            {
                //Obtenemos el numero del codigo ASCII
                byte[] asciiBytes = Encoding.ASCII.GetBytes(_strContenidoSemantica[x].ToString());

                //Si se trata de un ENTER
                if (asciiBytes[0] == 10)
                {
                    if (!String.IsNullOrEmpty(linea.Trim()))
                    {
                        lineasDeSemantica.Add(new Linea(linea, true));
                        lineasDeSemanticaReducidas.Add(BuscarMinimaExpresion(new Linea(linea, true), "produccionesTipoDeDato"));
                        //lineasDeTipo.Add(BuscarMinimaExpresion(new Linea(linea), "definicionesTipoDeDato"));
                        //lineasDeTipoReducidas.Add(BuscarMinimaExpresion(new Linea(linea), "produccionesTipoDeDato"));
                    }
                    linea = "";
                }
                //Si nos encontramos al final de la linea
                else if (x == _strContenidoSemantica.Length - 1)
                {
                    linea += _strContenidoSemantica.ToString();
                    if (!String.IsNullOrEmpty(linea.Trim()))
                    {
                        lineasDeSemantica.Add(new Linea(linea, true));
                        //lineasReducidas.Add(BuscarMinimaExpresion(new Linea(linea), "producciones"));
                        //lineasDeTipo.Add(BuscarMinimaExpresion(new Linea(linea), "definicionesTipoDeDato"));
                        lineasDeSemanticaReducidas.Add(BuscarMinimaExpresion(new Linea(linea, true), "produccionesTipoDeDato"));
                    }

                    linea = "";
                }
                //Seguimos concatenando
                else
                {
                    if (!String.IsNullOrEmpty(_strContenidoSemantica[x].ToString()))
                    {
                        linea += _strContenidoSemantica[x].ToString();
                    }
                }
            }
            #endregion


        }

        public Linea  BuscarMinimaExpresion(Linea _linea, string _contexto)
        {
            _linea.logs = "";
            Linea linea = _linea.Clone();
            linea.logs = "";

            if (!String.IsNullOrEmpty(linea.ToString()))
            {
                _linea.logs += $"┌──────> ANALIZA: [{linea.ToString()}] \n";
            }
            bool iterar = true;
            Linea actual = _linea.Clone();
            while (iterar)
            {
                linea =    generalFacade.Reducir(linea, _contexto);
                _linea.logs += linea.logs;
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
                _linea.logs += $"└>No hay más coinsidencias, termina el analisis. \n\n";
            }

            linea.instrucciones.Clear();
            linea.logs = _linea.logs;
            foreach (Instruccion i in actual.instrucciones)
            {
                linea.instrucciones.Add((Instruccion)i.Clone());
            }

            return linea;
        }
 




    }
}
