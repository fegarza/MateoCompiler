using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MateoCompiler.Clases.Singleton;
using MateoCompiler.Clases;

namespace MateoCompiler
{
    public partial class Form1 : Form
    {

        Lenguaje Mateo = Lenguaje.ObtenerInstancia();


        #region Colores
        private Color CDigitos = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(196)))), ((int)(((byte)(115)))));
        private Color CComentarios = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
        private Color CIdentificadores = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(38)))), ((int)(((byte)(114)))));
        private Color COperadores = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(196)))), ((int)(((byte)(115)))));
        private Color CReservadas = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(219)))), ((int)(((byte)(202)))));
        private Color CFuncion = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(129)))), ((int)(((byte)(252)))));
        #endregion


        public Form1()
        {
            InitializeComponent();

            //Cargamos los parametros de mi lenguaje 
            this.Mateo.ArchivoInstruccion.CargarInstrucciones(this.dgInstrucciones);
            this.Mateo.ArchivoInstruccion.CargarSimbolos(this.dgSimbolos);

            //Cargamos el archivo
            CargarCodigo();
        }

        private void CargarCodigo()
        {
            foreach (string s in this.Mateo.ArchivoEntrada.Lineas)
            {
                rtbEntrada.AppendText(s + "\n");
            }
            lblCantidadLineas.Text = rtbEntrada.Lines.Count().ToString();
        }

        private void GenerarTokens_click(object sender, EventArgs e)
        {
            Mateo.ArchivoInstruccion = new Clases.Archivos.InstruccionArchivo();
            Mateo.DatoArchivoDefinicionTipo = new Clases.Archivos.DefinicionTipoDatoArchivo();
            Mateo.ArchivoDeProduccionesTipoDato = new Clases.Archivos.ProduccionTipoDatoArchivo();
            //Limpiado de registros anteriores
            rtbxLogsProducciones.Clear();
            rtTokens.Clear();
            rtbExpresiones.Clear();
            rtbLogExpresiones.Clear();

            rtPostFijo.Clear();

            Mateo.CodigoEntrada = new Clases.Codigo();
            Mateo.CodigoEntrada.Contenido = rtbEntrada.Text;


            foreach (Linea l in Mateo.CodigoEntrada.lineas)
            {
                rtPostFijo.Text += this.TransformarPostfijo(l);
                foreach (Instruccion i in l.instrucciones)
                {
               
                        rtTokens.Text += i.tokenIncrementable + " ";
                        
                   
                        rtPostFijo.Text += "\n";


                }
                rtTokens.Text += "\n";
            }






            dgContadores.Rows.Clear();

           

            rtbxDefiniciones.Clear();
            foreach (Linea l in Mateo.CodigoEntrada.lineasReducidas)
            {
                //l.BuscarMinimaExpresion();
                //l.BuscarMinimaExpresionTipos();
                rtbxLogsProducciones.Text += l.logs;
                rtbxDefiniciones.Text += l.ToString() + "\n";
                //rtbxDefiniciones.Text += l.ToStringReducidas() + "\n";
                //rtbLogExpresiones.Text += l.logsReducidoTipo;
                //rtbExpresiones.Text += l.ToStringReducidasTipo() + "\n";
            }


            int contadorParentesis = 0;
            int contadorLlave = 0;
 
            int count = 0 ;
 

            foreach (Linea l in Mateo.CodigoEntrada.lineasDeTipo)
            {
                count++;   
                rtbExpresiones.Text += l.ToStringTipoDeDato() + "\n";
                foreach(Instruccion i in l.instrucciones)
                {
                    switch (i.contenido)
                    {
                        case "(":
                            contadorParentesis++;
                            break;
                        case ")":
                            contadorParentesis--;
                            break;
                        case "{":
                            contadorLlave++;
                            break;
                        case "}":
                            contadorLlave--;
                            break;
                    }
                  
                }
            }


            if(contadorParentesis != 0)
            {
                if(contadorParentesis < 0)
                {
                    contadorParentesis = contadorParentesis * -1;
                    MessageBox.Show("ERROR HAN FALTADO POR ABRIR  PARENTESIS :" + contadorParentesis.ToString());
                }
                else
                {
                    MessageBox.Show("ERROR HAN FALTADO POR CERRAR  PARENTESIS :" + contadorParentesis.ToString());
                }
                
            }
            if (contadorLlave != 0)
            {
                if (contadorLlave < 0)
                {
                    contadorLlave = contadorLlave * -1;
                    MessageBox.Show("ERROR HAN FALTADO POR ABRIR LLAVES:" + contadorLlave.ToString());
                }
                else
                {
                    MessageBox.Show("ERROR HAN FALTADO POR CERRAR LLAVES:" + contadorLlave.ToString());
                }
                 
            }


            rtbSalidaProduccionesTipo.Clear();
            Mateo.CodigoEntrada.ContenidoSemantica = rtbExpresiones.Text;

            foreach (Linea l in Mateo.CodigoEntrada.lineasDeSemanticaReducidas)
            {
                rtbLogExpresiones.Text += l.logs;

                if (l.ToString().Trim() != "S...")
                {
                    rtbSalidaProduccionesTipo.Text += "<ERROR>";
                }
                rtbSalidaProduccionesTipo.Text += l.ToString() + "\n";
            }



            foreach (KeyValuePair<string, string> n in Mateo.CodigoEntrada.numeros)
            {
                dgContadores.Rows.Add(n.Value, "ENTE", n.Key);
            }
            foreach (KeyValuePair<string, string> n in Mateo.CodigoEntrada.decimales)
            {
                dgContadores.Rows.Add(n.Value, "DECI", n.Key);
            }
            foreach (KeyValuePair<string, string> n in Mateo.CodigoEntrada.cadenas)
            {
                dgContadores.Rows.Add(n.Value, "CADE", n.Key);
            }
            foreach (KeyValuePair<string, Identificador> n in Mateo.CodigoEntrada.identificadores)
            {

                if (String.IsNullOrEmpty(n.Value.Tipo))
                {
                    dgContadores.Rows.Add(n.Value.Id, "?", n.Key);
                }
                else
                {
                    dgContadores.Rows.Add(n.Value.Id, n.Value.Tipo, n.Key);

                }





            }


        }

        private void GenerarDDL_Click(object sender, EventArgs e)
        {
            //CrearDDL();
            MessageBox.Show("Se ha creado con exito la matriz de transición en la base de datos");
        }
        public string ObtenerDefinicion(string x)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(x);
            if (asciiBytes[0] >= 65 && asciiBytes[0] <= 122)
            {
                return "<LETR>";
            }
            else if (asciiBytes[0] >= 48 && asciiBytes[0] <= 57)
            {
                return "<DIGI>";
            }
            else
            {
                return "<LETR>";
            }
        }

        private void rtbEntrada_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("Si", CReservadas, 0);
            this.CheckKeyword("Entonces", CReservadas, 0);
            this.CheckKeyword("SiNo", CReservadas, 0);
            this.CheckKeyword("var", CIdentificadores, 0);
            this.CheckKeyword("+", COperadores, 0);
            this.CheckKeyword("-", COperadores, 0);
            this.CheckKeyword("==", COperadores, 0);
            this.CheckKeyword("AND", COperadores, 0);
            this.CheckKeyword("OR", COperadores, 0);
            this.CheckKeyword(">=", COperadores, 0);
            this.CheckKeyword("<=", COperadores, 0);
            this.CheckKeyword("!=", COperadores, 0);
            this.CheckKeyword("=", COperadores, 0);
            this.CheckKeyword(">", COperadores, 0);
            this.CheckKeyword("<", COperadores, 0);
            this.CheckKeyword("Wof", CFuncion, 0);
            this.CheckKeyword("LeerPatita", CFuncion, 0);

            lblCantidadLineas.Text = rtbEntrada.Lines.Count().ToString();

        }
        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.rtbEntrada.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.rtbEntrada.SelectionStart;

                while ((index = this.rtbEntrada.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.rtbEntrada.Select((index + startIndex), word.Length);
                    this.rtbEntrada.SelectionColor = color;
                    this.rtbEntrada.Select(selectStart, 0);
                    this.rtbEntrada.SelectionColor = Color.White;
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btnPasos_Click(object sender, EventArgs e)
        { /*
            numeros.Clear();
            decimales.Clear();
            cadenas.Clear();
            variables.Clear();
            rtTokens.Clear();
            //Se separan las lineas del richtextbox y las instrucciones
            lineas.Clear();
            string linea = "";
            for (int x = 0; x < rtbEntrada.Text.Length; x++)
            {

                byte[] asciiBytes = Encoding.ASCII.GetBytes(rtbEntrada.Text[x].ToString());
                if (asciiBytes[0] == 10)
                {
                    lineas.Add(new Linea(linea));
                    linea = "";
                }
                else if (x == rtbEntrada.Text.Length - 1)
                {
                    linea += rtbEntrada.Text[x].ToString();
                    lineas.Add(new Linea(linea));
                    linea = "";
                }
                else
                {
                    linea += rtbEntrada.Text[x].ToString();
                }
            }

            int v = 1;
            //Transformacion a tokens
            foreach (Linea l in lineas)
            {
                MessageBox.Show("Se empieza a leer la línea: #"+v.ToString(), "Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                v++;
                foreach (Instruccion i in l.instrucciones)
                {
               
                    i.token = ObtenerTokenPorPasos(i.caracteres);
                    if (i.token == null)
                    {
                        // MessageBox.Show($"Error en la palabra reservada {i.contenido}, no existe un camino en su matriz de transicion que de como resultado un token.");
                    }
                    else
                    {
                        string xd  = BuscarIncrementable(i.token.Substring(0, 4), i.contenido) + " ";
                        rtTokens.Text += xd;
                        MessageBox.Show($"Se ha encontrado un token para la palabra reservada: {i.contenido}, la cual es: {xd}");
                    }
                }

                if (!String.IsNullOrEmpty(l.contenido))
                    rtTokens.Text += (" \n");
            }
            MessageBox.Show("Se han evaluado todas las lineas"  , "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgSimbolos.Rows.Clear();

            foreach (KeyValuePair<string, string> n in numeros)
            {
                dgSimbolos.Rows.Add(n.Key, n.Value);
            }
            foreach (KeyValuePair<string, string> n in decimales)
            {
                dgSimbolos.Rows.Add(n.Key, n.Value);
            }
            foreach (KeyValuePair<string, string> n in cadenas)
            {
                dgSimbolos.Rows.Add(n.Key, n.Value);
            }
            foreach (KeyValuePair<string, string> n in variables)
            {
                dgSimbolos.Rows.Add(n.Key, n.Value);
            }
              */
        }

        public string ObtenerTokenPorPasos(List<string> _caracteres)
        {
            return "";
            /*
            string result = null;

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            int z = 0;
            int estado = 0;
            string palabraFormada = "";
            foreach (string x in _caracteres)
            {
                palabraFormada = palabraFormada + x;
                z++;
                try
                {


                    cmd.CommandText = $@"SELECT [Z{x}]  FROM Matriz WHERE [Z{x}] IS NOT NULL AND Estado = {estado.ToString()}";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        if (rdr.HasRows)
                        {
                            
                            while (rdr.Read())
                            {
                               
                                Detalle mi = new Detalle(x, estado.ToString(), rdr[0].ToString(), cmd.CommandText, palabraFormada);
                                mi.ShowDialog();
                                estado = int.Parse(rdr[0].ToString());
                                
                            }
                            rdr.Close();
                        }
                        else
                        {
                            rdr.Close();
                            //En el caso de que no exista, pues se busca por una definicion regular
                            string x2 = ObtenerDefinicion(x);
                           
                            cmd.CommandText = $@"SELECT [Z{x2}]  FROM Matriz WHERE [Z{x2}] IS NOT NULL AND Estado = {estado.ToString()}";
                            using (SqlDataReader rdr2 = cmd.ExecuteReader())
                            {

                                if (rdr2.HasRows)
                                {
                                    while (rdr2.Read())
                                    {
                                        Detalle mi = new Detalle(x2, estado.ToString(), rdr2[0].ToString(), cmd.CommandText, palabraFormada);
                                        mi.ShowDialog();
                                        estado = int.Parse(rdr2[0].ToString());
                                    }
                                }
                                else
                                {
                                    return null;
                                }

                                rdr2.Close();
                            }



                        }
                    }


                    // Si es el ultimo elemento hace un paso extra para pasar el delimitador a directamente el estado del token
                    if (z == _caracteres.Count())
                    {
                        cmd.CommandText = $"SELECT [Z ]  FROM Matriz WHERE [Z ] IS NOT NULL AND Estado = {estado.ToString()}";
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Detalle mi = new Detalle("DELIMITADOR", estado.ToString(), rdr[0].ToString(), cmd.CommandText, palabraFormada);
                                    mi.ShowDialog();
                                    estado = int.Parse(rdr[0].ToString());
                                }
                            }
                            else
                            {
                                //En el caso de que no exista, pues se busca por una definicion regular
                                string x2 = ObtenerDefinicion(x);
                                cmd.CommandText = $@"SELECT [Z{x2}]  FROM Matriz WHERE [Z{x2}] IS NOT NULL AND Estado = {estado.ToString()}";

                                using (SqlDataReader rdr2 = cmd.ExecuteReader())
                                {
                                    if (rdr2.HasRows)
                                    {
                                        while (rdr2.Read())
                                        {
                                            Detalle mi = new Detalle(x2, estado.ToString(), rdr2[0].ToString(), cmd.CommandText, palabraFormada);
                                            mi.ShowDialog();
                                            estado = int.Parse(rdr2[0].ToString());
                                        }
                                        rdr2.Close();
                                    }
                                    else
                                    {
                                        rdr2.Close();
                                        return null;
                                    }
                                }



                            }
                            rdr.Close();
                        }



                    }

                }
                catch (Exception ex)
                {
                    string x2 = ObtenerDefinicion(x);
                    cmd.CommandText = $@"SELECT [Z{x2}]  FROM Matriz WHERE [Z{x2}] IS NOT NULL AND Estado = {estado.ToString()}";

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Detalle mi = new Detalle(x2, estado.ToString(), rdr[0].ToString(), cmd.CommandText, palabraFormada);
                                mi.ShowDialog();
                                estado = int.Parse(rdr[0].ToString());
                            }
                            rdr.Close();
                        }
                        else
                        {
                            rdr.Close();
                            return null;
                        }
                    }


                    if (z == _caracteres.Count())
                    {
                        cmd.CommandText = $"SELECT [Z ]  FROM Matriz WHERE [Z ] IS NOT NULL AND Estado = {estado.ToString()}";
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Detalle mi = new Detalle("DELIMITADOR", estado.ToString(), rdr[0].ToString(), cmd.CommandText, palabraFormada);
                                    mi.ShowDialog();
                                    estado = int.Parse(rdr[0].ToString());
                                }
                            }
                            else
                            {
                                rdr.Close();
                                return null;

                            }
                            rdr.Close();
                        }


                    }
                }
            }


            //Al haber analizado todos los caracteres y tener exitosamente un estado final se busca el token en ese estado
            cmd.CommandText = $"SELECT token FROM Matriz WHERE Estado = {estado.ToString()}";
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string tkn = rdr["token"].ToString();
                        if (String.IsNullOrEmpty(tkn))
                        {
                            return null;
                        }
                        else
                        {
                            return tkn;
                        }
                    }
                    rdr.Close();
                }
                else

                    rdr.Close();
                return null;
            }







            return null;
            */
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        #region 
        public int DetectarPosicionUltimaParentesis(Linea linea)
        {
            int result = 0;
            for (int x = 0; x < linea.instrucciones.Count; x++)
            {
                if (linea.instrucciones[x].tokenIncrementable.Trim() == "ES11")
                {
                    result = x;
                }
            }
            return result;
        }


       


         
        public string TransformarPostfijo(Linea linea)
        {
            Stack<string> Operadores = new Stack<string>();
            string postfijo = "";
            Linea parametro = new Linea();
            bool parametroActivo = false;

            for (int x = 0; x < linea.instrucciones.Count; x++)
            {
                if (parametroActivo)
                {
                    if (AnalizarCaracter(linea.instrucciones[x].tokenIncrementable.Trim()) == 4 && (DetectarPosicionUltimaParentesis(linea) == x))
                    {
                        postfijo += TransformarPostfijo(parametro);
                        parametroActivo = false;
                        parametro.instrucciones.Clear();
                        while (Operadores.Count > 0)
                        {
                            postfijo += Operadores.Pop();
                            postfijo += " ";
                        }
                    }
                    else
                    {
                        parametro.instrucciones.Add( linea.instrucciones[x]);
                    }
                }
                else
                {
                    if (AnalizarCaracter(linea.instrucciones[x].tokenIncrementable.Trim()) > 0)
                    {
                        if (AnalizarCaracter(linea.instrucciones[x].tokenIncrementable.Trim()) == 5)
                        {
                            parametroActivo = true;
                        }
                        else
                        {
                            postfijo += " ";
                            if (Operadores.Count == 0)
                            {
                                Operadores.Push(linea.instrucciones[x].tokenIncrementable.Trim());
                            }
                            else
                            {

                                if (AnalizarCaracter(linea.instrucciones[x].tokenIncrementable.Trim()) > AnalizarCaracter(Operadores.Peek()))
                                {
                                    Operadores.Push(linea.instrucciones[x].tokenIncrementable.Trim());
                                }
                                else if (AnalizarCaracter(linea.instrucciones[x].tokenIncrementable.Trim()) < AnalizarCaracter(Operadores.Peek()))
                                {
                                    while (Operadores.Count > 0)
                                    {
                                        postfijo += Operadores.Pop();
                                        postfijo += " ";
                                    }
                                    Operadores.Push(linea.instrucciones[x].tokenIncrementable.Trim());
                                }
                                else if (AnalizarCaracter(linea.instrucciones[x].tokenIncrementable.Trim()) == AnalizarCaracter(Operadores.Peek()))
                                {
                                    postfijo += Operadores.Pop();
                                    postfijo += " ";
                                    Operadores.Push(linea.instrucciones[x].tokenIncrementable.Trim());
                                }
                                else
                                {

                                }

                            }
                        }



                    }
                    else
                    {
                        postfijo += $"{linea.instrucciones[x].tokenIncrementable.Trim()}";
                    }
                    if (x == linea.instrucciones.Count - 1)
                    {
                        while (Operadores.Count > 0)
                        {
                            postfijo += " ";

                            postfijo += Operadores.Pop();

                        }
                    }
                }
            }
            return postfijo;
        }
        



        public bool DetectarParentesis(string x)
        {
            if (x == "ES10" || x == "ES11")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int AnalizarCaracter(string x)
        {
            switch (x)
            {
                case "ES10":
                    return 5;
                case "ES11":
                    return 4;
                case "OP07":
                    return 3;
                case "OP06":
                case "OP09":
                    return 2;
                case "OP04":
                case "OP05":
                    return 1;
                default:
                    return 0;
            }
        }
        #endregion



    }
}

