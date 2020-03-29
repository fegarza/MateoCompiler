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
        #region Instrucciones SQL
        public string DDL = "";
        public string DML = "";
        #endregion
        #region Contadores
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
            numeros.Clear();
            decimales.Clear();
            cadenas.Clear();
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
                foreach (Instruccion i in l.instrucciones)
                {
                    i.token = ObtenerToken(i.caracteres);
                    if (i.token == null)
                    {
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


        private string Descomponer()
        {
            return "";
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
    }
}

