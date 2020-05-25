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

namespace MateoCompiler
{
    public partial class Form1 : Form
    {
        string cs = @"Server= localhost; Database= mateo; Integrated Security=True;";

        private List<Linea> lineas = new List<Linea>();

        #region Instrucciones y alfabeto
        public BindingList<Instruccion> instrucciones = new BindingList<Instruccion>();
        public static string rutaConfig = @".\instrucciones.txt";
        string[] DatosDeConexion = System.IO.File.ReadAllLines(rutaConfig);
        public List<string> Alfabeto = new List<string>();
        #endregion
        #region Codigo
        public static string rutaConfig2 = @".\codigo.txt";
        string[] CodigoLineas = System.IO.File.ReadAllLines(rutaConfig2);
        #endregion
        #region Producciones
        private List<Definicion> definiciones = new List<Definicion>();
        public static string rutaConfig3 = @".\producciones.txt";
        string[] produccionesLineas = System.IO.File.ReadAllLines(rutaConfig3);
        #endregion
        #region Instrucciones SQL
        public string DDL = "";
        public string DML = "";
        #endregion
        #region Contadores
        public int Contador = 0;
        private Dictionary<string, string> numeros = new Dictionary<string, string>();
        private Dictionary<string, string> decimales = new Dictionary<string, string>();
        private Dictionary<string, string> variables = new Dictionary<string, string>();
        private Dictionary<string, string> cadenas = new Dictionary<string, string>();
        #endregion
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
            this.BusquedaDeProducciones();
            LeerInstrucciones();
            CargarCodigo();

        }

        private void CargarCodigo()
        {
            foreach (string s in CodigoLineas)
            {
                rtbEntrada.AppendText(s + "\n");
            }
            lblCantidadLineas.Text = rtbEntrada.Lines.Count().ToString();
        }
        public void LeerInstrucciones()
        {
            //Se obtiene cada instruccion y se establece el alfabeto
            int cont = 1;
            string tempToken = "";
            foreach (string x in DatosDeConexion)
            {
                //Entra aqui si se trata de un token
                if (cont % 2 != 0)
                {
                    tempToken = x;
                }
                //Entra aqui si se trata de una instruccion
                else
                {
                    instrucciones.Add(new Instruccion(x, tempToken));
                }
                cont++;
            }

            foreach (Instruccion i in instrucciones)
            {
                dgInstrucciones.Rows.Add(i.token, i.contenido);
                bool definicion = false;
                string definicionStr = "";
                for (int x = 0; x < i.contenido.Length; x++)
                {
                    if (definicion)
                    {
                        definicionStr += i.contenido[x];
                        if (i.contenido[x] == '>')
                        {
                            definicion = false;
                            if (!Alfabeto.Contains(definicionStr.ToLower()))
                            {
                                Alfabeto.Add(definicionStr.ToLower());
                            }

                            definicionStr = "";
                        }

                    }
                    else if (i.contenido[x] == '<')
                    {
                        definicion = true;
                        definicionStr += i.contenido[x];
                    }
                    else
                    {
                        if (!Alfabeto.Contains(i.contenido[x].ToString().ToLower()))
                        {
                            Alfabeto.Add(i.contenido[x].ToString().ToLower());
                        }
                    }

                }
            }

        }
        public void CrearDDL()
        {
            rtbSalida.Text += "// -> CREANDO LA TABLA \n";
            DDL = "CREATE TABLE Matriz( \n";
            DDL += "Estado INT, \n";
            foreach (string i in Alfabeto)
            {
                DDL += $"[Z{i}] INT,\n";
            }
            DDL += " token VARCHAR(10))";
            //MessageBox.Show(DDL);
            rtbSalida.Text += DDL;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DROP TABLE IF EXISTS Matriz";
            cmd.ExecuteNonQuery();
            cmd.CommandText = DDL;
            cmd.ExecuteNonQuery();
            con.Close();
            CrearDML();
        }
        public void CrearDML()
        {
            rtbSalida.Text += "\n\n// -> SE AGREGAN REGISTROS <- \n\n ";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "DELETE FROM Matriz";
            cmd.ExecuteNonQuery();
            var xe = instrucciones.OrderByDescending(w => w.ObtenerLongitud()).ToList();
            int estado = 0;

            foreach (Instruccion i in xe)
            {
                //Primera instruccion
                if (i == xe.First())
                {
                    string dmlc = "";
                    //Insertamos un estado x cada una
                    foreach (string x in i.caracteres)
                    {
                        estado++;
                        dmlc = "INSERT INTO Matriz \n ";
                        dmlc += $"(Estado, [Z{x}]) \n";
                        dmlc += "VALUES ";
                        dmlc += $"({(estado - 1).ToString()}, {estado.ToString()}) \n\n";
                        cmd.CommandText = dmlc;
                        rtbSalida.Text += dmlc;
                        cmd.ExecuteNonQuery();
                    }
                    //Insertamos el token
                    estado++;
                    dmlc = "INSERT INTO Matriz \n";
                    dmlc += $"(estado, token) \n";
                    dmlc += "VALUES \n";
                    dmlc += $"({(estado - 1).ToString()}, '{i.token}') \n\n";

                    cmd.CommandText = dmlc;
                    cmd.ExecuteNonQuery();

                    rtbSalida.Text += dmlc;
                }
                else
                {
                    int estadoBuscar = 0;
                    bool colision = true;
                    foreach (string x in i.caracteres)
                    {
                        string query = "";
                        //Se ignoran todos los elemento que ya tengan alguna colision
                        if (colision)
                        {
                            query = $@"SELECT [Z{x}] FROM Matriz WHERE Estado = {estadoBuscar} AND [Z{x}] IS NOT NULL";
                            cmd.CommandText = query;
                            SqlDataReader rdr = cmd.ExecuteReader();
                            //En caso de ya no encontrar colision se crea un nuevo estado y se enlaza con el estado actual
                            if (!rdr.HasRows)
                            {
                                rdr.Close();
                                estado++;
                                query = "UPDATE Matriz SET ";
                                query += $"[Z{x}] = {estado.ToString()} WHERE estado = {estadoBuscar.ToString()}";
                                cmd.CommandText = query;
                                rtbSalida.Text += query;
                                cmd.ExecuteNonQuery();
                                colision = false;
                                estadoBuscar++;
                            }
                            else
                            {
                                while (rdr.Read())
                                {
                                    estadoBuscar = int.Parse(rdr[0].ToString());
                                }

                            }

                            rdr.Close();
                        }
                        //Si ya no tiene colision se crean los estado s
                        else
                        {
                            estado++;
                            colision = false;
                            query = "INSERT INTO Matriz \n";
                            query += $"(Estado, [Z{x}]) \n";
                            query += "VALUES \n";
                            query += $"({(estado - 1).ToString()}, {estado.ToString()}) \n\n";
                            cmd.CommandText = query;
                            rtbSalida.Text += query;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    estado++;
                    string queryTkn = "";
                    queryTkn = "INSERT INTO Matriz \n ";
                    queryTkn += $"(estado, token) \n";
                    queryTkn += "VALUES ";
                    queryTkn += $"({(estado - 1).ToString()}, '{i.token} \n\n')";
                    cmd.CommandText = queryTkn;
                    rtbSalida.Text += queryTkn;
                    cmd.ExecuteNonQuery();
                }






            }
            con.Close();
        }
        private void GenerarTokens_click(object sender, EventArgs e)
        {
            rtbxLogsProducciones.Clear();
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

            //Transformacion a tokens
            foreach (Linea l in lineas)
            {
                int cont = -1;
                foreach (Instruccion i in l.instrucciones)
                {
                    cont++;
                    i.token = ObtenerToken(i.caracteres);
                    if (i.token == null)
                    {
                        if (cont != 0)
                        {
                            if (l.instrucciones[cont - 1].contenido == "var")
                            {
                                i.token = "ID00";
                                rtTokens.Text += BuscarIncrementable(i.token.Substring(0, 4), i.contenido) + " ";
                            }
                            else {
                                if (variables.ContainsKey(i.contenido))
                                {
                                    i.token = "ID00";
                                    rtTokens.Text += BuscarIncrementable(i.token.Substring(0, 4), i.contenido) + " ";
                                }
                                else if (i.caracteres.Count() > 0) {
                                    if (i.contenido[0].ToString() == "\"")
                                    {
                                        i.token = "CA00";
                                        rtTokens.Text += BuscarIncrementable(i.token.Substring(0, 4), i.contenido) + " ";
                                    }
                                }


                            }
                        }
                        // MessageBox.Show($"Error en la palabra reservada {i.contenido}, no existe un camino en su matriz de transicion que de como resultado un token.");
                    }
                    else
                    {

                        rtTokens.Text += BuscarIncrementable(i.token.Substring(0, 4), i.contenido) + " ";
                    }
                }

                if (!String.IsNullOrEmpty(l.contenido))
                    rtTokens.Text += (" \n");
            }

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

            rtbxDefiniciones.Clear();
            foreach (Linea l in lineas) {
                rtbxDefiniciones.Text += BuscarMinimaExpresion(l) + " \n";
            }



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
                    case "ID":
                        if (variables.Count == 0)
                        {
                            digito++;
                            newToken = "ID" + "0" + digito.ToString();
                            variables.Add(_valor, newToken);
                        }
                        else
                        {
                            digito = int.Parse(variables.Last().Value.Substring(2, 2));
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
                            if (!variables.ContainsKey(_valor))
                            {
                                variables.Add(_valor, newToken);
                            }
                            else
                            {
                                newToken = variables[_valor];
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
        private void BusquedaDeProducciones()
        {
            
            Definicion definicionActual = null;
            int count = 0;
            foreach (String linea  in produccionesLineas) {
                count++;
                if (count == produccionesLineas.Length) {
                    if (linea.Substring(0, 2) == "->")
                    {
                        if (definicionActual != null)
                        {
                            definicionActual.AddProduccion(new Produccion(linea.Substring(3, (linea.Length - 3))));
                        }
                    }
                    if(definicionActual != null)
                    {
                        definiciones.Add(definicionActual.GetAsObject());
                      //  MessageBox.Show(definicionActual.ToString());
                        definicionActual = null;
                    }
                }
                else
                {
                    if (linea.Length > 3)
                    {
                        //Se trata de una definicion de una instruccion
                        if (linea.Substring(0, 3) == "-->")
                        {
                            if (definicionActual == null)
                            {
                                definicionActual = new Definicion(linea.Substring(4, (linea.Length - 4)));
                            }
                            else
                            {
                                definiciones.Add(definicionActual.GetAsObject());
                              //  MessageBox.Show(definicionActual.ToString());
                                definicionActual = null;
                                definicionActual = new Definicion(linea.Substring(4, (linea.Length - 4)));
                            }
                        }
                        //Se trata de una produccion de la definicion
                        else if (linea.Substring(0, 2) == "->")
                        {
                            if (definicionActual != null)
                            {
                                definicionActual.AddProduccion(new Produccion(linea.Substring(3, (linea.Length - 3))));
                            }
                        }
                    }
                }


              
            }




            SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM producciones;";
            cmd.ExecuteNonQuery();
                con.Close();
           
            foreach (Definicion d in definiciones) {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = d.getQuery();
                    cmd.ExecuteNonQuery();
                    con.Close();
                 
            }
           
            
            

        }
        private void GenerarDDL_Click(object sender, EventArgs e)
        {
            CrearDDL();
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
        public string ObtenerToken(List<string> _caracteres)
        {
            string result = null;

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            int z = 0;
            int estado = 0;
            foreach (string x in _caracteres)
            {
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
        {
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

        }
        public string ObtenerTokenPorPasos(List<string> _caracteres)
        {
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
        }
        private void rtbxDefiniciones_TextChanged(object sender, EventArgs e)
        {

        }

        
        private string BuscarMinimaExpresion(Linea linea)
        {
            if (!String.IsNullOrEmpty(linea.ToString()))
            {
                rtbxLogsProducciones.Text += $"┌──────> ANALIZA: [{linea.ToString()}] \n";
            }
            


            bool iterar = true;
            Linea actual = linea.Clone();
            while (iterar)
            {
                linea = ReducirTokens(linea);
                if(actual.Equals(linea))
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
                rtbxLogsProducciones.Text += $"└>No hay más coinsidencias, termina el analisis. \n\n";
            }
              
            
           

            return actual.ToString();
        }
        private Linea ReducirTokens(Linea linea)
        {
            
            bool encontrado = false;
            int total = linea.instrucciones.Count();
            int tomar = total;
            int posibilidades = 1;

            

            while (!encontrado && posibilidades <= total )
            {
                //Buscar cada una de las posibilidades
                for (int x = 1; x <= posibilidades; x++) 
                {
                    if (!encontrado) {
                        string cadenaDeTokens = "";
                        string contenido = "";
                        int inicio = x - 1;
                        int fin = tomar;
                        List<Instruccion> temp = linea.instrucciones.GetRange(inicio, fin).ToList();
                        foreach (Instruccion i in temp )
                        {
                            if(i.token != null)
                                cadenaDeTokens += i.token.Substring(0,4) + " ";
                            if (!String.IsNullOrEmpty(i.contenido))
                                contenido += i.contenido + " ";
                        }
                        if(cadenaDeTokens.Count() > 0)
                        {

                           
                            string query = $"SELECT TOP 1 titulo FROM Producciones WHERE contenido = '{cadenaDeTokens.Substring(0, cadenaDeTokens.Count() - 1)}'";
                            SqlConnection con = new SqlConnection(cs);
                            SqlCommand cmd = new SqlCommand(query);

                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = query;
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                               

                                List<Instruccion> primeros = new List<Instruccion>();
                                List<Instruccion> ultimos = new List<Instruccion>();
                                try
                                {
                                    primeros = linea.instrucciones.GetRange(0, x - 1);
                                }
                                catch { }
                                try
                                {
                                    int k = linea.instrucciones.Count - ((x - 1)+ tomar) ;
                                    int p = ((x - 1) + tomar);
                                    ultimos = linea.instrucciones.GetRange(p, k);
                                }
                                catch { }

                                Instruccion n = new Instruccion("xd","error");
                                encontrado = true;
                                while (rdr.Read()) 
                                {
                                    n = new Instruccion(rdr[0].ToString(), rdr[0].ToString());
                                    rtbxLogsProducciones.Text += "│ \n";
                                    rtbxLogsProducciones.Text += $"├──> Produccion encontrada: [{cadenaDeTokens.Substring(0, cadenaDeTokens.Count() - 1)}] \n";
                                    rtbxLogsProducciones.Text += "│ \n";
                                    rtbxLogsProducciones.Text += $"├─> Valor: [{rdr[0].ToString()}] \n";
                                    rtbxLogsProducciones.Text += "│ \n";
                                }
                                    
                                

                                linea.instrucciones.Clear();
                                linea.instrucciones.AddRange(primeros);
                                linea.instrucciones.Add(n);
                                linea.instrucciones.AddRange(ultimos);
                                rtbxLogsProducciones.Text += $"├─> Analisis actual: [{linea.ToString()}] \n";
                                rtbxLogsProducciones.Text += "│ \n";
                            }
                            con.Close();
                        }
                       
                       
                    }
                   
                }
                tomar--;
                posibilidades++;
            }
            



            return linea;
        }
 
    }
}

