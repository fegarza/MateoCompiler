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
        string cs = @"Server=localhost;Database=mateo;User Id=pipe;Password=7271;";

        private List<Linea> lineas = new List<Linea>();

        #region Instrucciones y alfabeto
        public BindingList<Instruccion> instrucciones = new BindingList<Instruccion>();
        public static string rutaConfig = @".\instrucciones.txt";
        string[] DatosDeConexion = System.IO.File.ReadAllLines(rutaConfig);
        public List<string> Alfabeto = new List<string>();
        #endregion

        public string DDL = "";
        public string DML = "";
        public Form1()
        {
            InitializeComponent();
            LeerInstrucciones();

        }
        public void LeerInstrucciones()
        {
            //Se define el datagridview
            dgInstrucciones.ColumnCount = 2;
            dgInstrucciones.Columns[0].Name = "Token";
            dgInstrucciones.Columns[1].Name = "Instrucciones";
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
                            if (!Alfabeto.Contains(definicionStr))
                            {
                                Alfabeto.Add(definicionStr);
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
                        if (!Alfabeto.Contains(i.contenido[x].ToString()))
                        {
                            Alfabeto.Add(i.contenido[x].ToString());
                        }
                    }

                }
            }

        }
        public void CrearDDL()
        {
            rtbSalida.Text += "-> CREANDO LA TABLA";
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
            rtbSalida.Text += "// -> SE AGREGAN REGISTROS <- ";
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
                        dmlc = "INSERT INTO Matriz ";
                        dmlc += $"(Estado, [Z{x}])";
                        dmlc += "VALUES ";
                        dmlc += $"({(estado - 1).ToString()}, {estado.ToString()})";
                        cmd.CommandText = dmlc;
                        rtbSalida.Text += dmlc;
                        cmd.ExecuteNonQuery();
                    }
                    //Insertamos el token
                    estado++;
                    dmlc = "INSERT INTO Matriz ";
                    dmlc += $"(estado, token)";
                    dmlc += "VALUES ";
                    dmlc += $"({(estado - 1).ToString()}, '{i.token}')";

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
                            query = $"SELECT * FROM Matriz WHERE Estado = {estadoBuscar} AND [Z{x}] IS NOT NULL";
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
                            }
                            estadoBuscar++;
                            rdr.Close();
                        }
                        //Si ya no tiene colision se crean los estado 
                        else
                        {
                            estado++;
                            colision = false;
                            query = "INSERT INTO Matriz ";
                            query += $"(Estado, [Z{x}])";
                            query += "VALUES ";
                            query += $"({(estado - 1).ToString()}, {estado.ToString()})";
                            cmd.CommandText = query;
                            rtbSalida.Text += query;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    estado++;
                    string queryTkn = "";
                    queryTkn = "INSERT INTO Matriz ";
                    queryTkn += $"(estado, token)";
                    queryTkn += "VALUES ";
                    queryTkn += $"({(estado - 1).ToString()}, '{i.token}')";
                    cmd.CommandText = queryTkn;
                    rtbSalida.Text += queryTkn;
                    cmd.ExecuteNonQuery();
                }


                



            }
            con.Close();
        }
        private void Compilar_Click(object sender, EventArgs e)
        {

            //Se separan las lineas del richtextbox
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
    }
}
