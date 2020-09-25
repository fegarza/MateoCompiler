using MateoCompiler.Clases.Singleton;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Clases.Facade
{
    public class GeneralFacade
    {
        private Conexion conexion = Conexion.getInstancia();

        private static GeneralFacade generalFacade;
 
        private GeneralFacade() { }

        public static GeneralFacade getInstancia()
        {
            if (generalFacade == null)
            {
                generalFacade = new GeneralFacade();
            }
            return generalFacade;
        }

        public string ObtenerToken(List<string> _caracteres)
        {
            string result = null;
             
            conexion.Abrir();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.SQLServerConexion;

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
                            return tkn.Trim();
                        }
                    }
                    rdr.Close();
                }
                else
                {
                    rdr.Close();
                }   
                return null;
            }

            return null;
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

        public Linea ReducirTokens(Linea lineaEntrada)
        {
            Linea linea = lineaEntrada.Clone();
            bool encontrado = false;
            int total = linea.instrucciones.Count();
            int tomar = total;
            int posibilidades = 1;


            while (!encontrado && posibilidades <= total)
            {
                //Buscar cada una de las posibilidades
                for (int x = 1; x <= posibilidades; x++)
                {
                    if (!encontrado)
                    {
                        string cadenaDeTokens = "";
                        string contenido = "";
                        int inicio = x - 1;
                        int fin = tomar;
                        List<Instruccion> temp = linea.instrucciones.GetRange(inicio, fin).ToList();
                        foreach (Instruccion i in temp)
                        {
                            if (i.token != null)
                                cadenaDeTokens += i.token.Substring(0, 4) + " ";
                            if (!String.IsNullOrEmpty(i.contenido))
                                contenido += i.contenido + " ";
                        }
                        if (cadenaDeTokens.Count() > 0)
                        {
                            string query = $"SELECT TOP 1 titulo FROM producciones WHERE contenido = '{cadenaDeTokens.Substring(0, cadenaDeTokens.Count() - 1)}'";
                           
                            SqlCommand cmd = new SqlCommand(query);

                            conexion.Abrir();
                            cmd.Connection = conexion.SQLServerConexion;
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
                                    int k = linea.instrucciones.Count - ((x - 1) + tomar);
                                    int p = ((x - 1) + tomar);
                                    ultimos = linea.instrucciones.GetRange(p, k);
                                }
                                catch { }

                                Instruccion n = new Instruccion("xd", "error");
                                encontrado = true;
                                while (rdr.Read())
                                {
                                    n = new Instruccion(rdr[0].ToString(), rdr[0].ToString());
                                    linea.logsReducido += "│ \n";
                                    linea.logsReducido += $"├──> Produccion encontrada: [{cadenaDeTokens.Substring(0, cadenaDeTokens.Count() - 1)}] \n";
                                    linea.logsReducido += "│ \n";
                                    linea.logsReducido += $"├─> Valor: [{rdr[0].ToString()}] \n";
                                    linea.logsReducido += "│ \n";
                                }



                                linea.instrucciones.Clear();
                                linea.instrucciones.AddRange(primeros);
                                linea.instrucciones.Add(n);
                                linea.instrucciones.AddRange(ultimos);
                                linea.logsReducido += $"├─> Analisis actual: [{linea.ToString()}] \n";
                                linea.logsReducido += "│ \n";
                            }
                            conexion.Cerrar();
                        }


                    }

                }
                tomar--;
                posibilidades++;
            }


            //En caso de ser una asignacion de variable/
            if (linea.instrucciones.Count > 0)
            {
                if (linea.instrucciones[0].token == "MO04"){
                    Lenguaje mateo = Lenguaje.ObtenerInstancia();

                    string keyVar = "";
                    Linea valorConjunto = new Linea();
                    valorConjunto.instrucciones = new List<Instruccion>();
                    bool asignacion =  false;
                    foreach(Instruccion i in lineaEntrada.instrucciones)
                    {
                        if (asignacion)
                        {
                            if (i.token != "ES08")
                                valorConjunto.instrucciones.Add((Instruccion)i.Clone());
                        }
                        if (i.token == "OP10")
                        {
                            asignacion = true;
                        }else if(i.token == "ID00" && keyVar == "")
                        {
                            keyVar = i.contenido;
                        }
                        
                    }
                    valorConjunto.BuscarMinimaExpresion();

                    if (valorConjunto.instruccionesReducidas.Count == 1)
                    {
                        mateo.CodigoEntrada.EstablecerTipo(keyVar, valorConjunto.instruccionesReducidas[0].token);
                    }
                }
            } 
            return linea;
        }

 












        public Linea Reducir(Linea _lineaEntrada, string _contexto)
        {
            Linea linea = _lineaEntrada.Clone();


            bool encontrado = false;
            int total = linea.instrucciones.Count();
            int tomar = total;
            int posibilidades = 1;


            while (!encontrado && posibilidades <= total)
            {
                //Buscar cada una de las posibilidades
                for (int x = 1; x <= posibilidades; x++)
                {
                    if (!encontrado)
                    {
                        string cadenaDeTokens = "";
                        string contenido = "";
                        int inicio = x - 1;
                        int fin = tomar;
                        List<Instruccion> temp = linea.instrucciones.GetRange(inicio, fin).ToList();
                        foreach (Instruccion i in temp)
                        {
                            if (i.token != null)
                                cadenaDeTokens += i.token.Substring(0, 4) + " ";
                            if (!String.IsNullOrEmpty(i.contenido))
                                contenido += i.contenido + " ";
                        }
                        if (cadenaDeTokens.Count() > 0)
                        {
                            string query = $"SELECT TOP 1 titulo FROM {_contexto} WHERE contenido = '{cadenaDeTokens.Substring(0, cadenaDeTokens.Count() - 1)}'";

                            SqlCommand cmd = new SqlCommand(query);

                            conexion.Abrir();
                            cmd.Connection = conexion.SQLServerConexion;
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
                                    int k = linea.instrucciones.Count - ((x - 1) + tomar);
                                    int p = ((x - 1) + tomar);
                                    ultimos = linea.instrucciones.GetRange(p, k);
                                }
                                catch { }

                                Instruccion n = new Instruccion("xd", "error");
                                encontrado = true;
                                while (rdr.Read())
                                {
                                    n = new Instruccion(rdr[0].ToString(), rdr[0].ToString());
                                    linea.logs += "│ \n";
                                    linea.logs += $"├──> Produccion encontrada: [{cadenaDeTokens.Substring(0, cadenaDeTokens.Count() - 1)}] \n";
                                    linea.logs += "│ \n";
                                    linea.logs += $"├─> Valor: [{rdr[0].ToString()}] \n";
                                    linea.logs += "│ \n";
                                }



                                linea.instrucciones.Clear();
                                linea.instrucciones.AddRange(primeros);
                                linea.instrucciones.Add(n);
                                linea.instrucciones.AddRange(ultimos);
                                linea.logs += $"├─> Analisis actual: [{linea.ToString()}] \n";
                                linea.logs += "│ \n";
                            }
                            conexion.Cerrar();
                        }


                    }

                }
                tomar--;
                posibilidades++;
            }


            if(_contexto == "producciones")
            {
                //Se trata de una asignacion de variables
                if (linea.instrucciones.Count > 0)
                {
                    if (linea.instrucciones[0].token == "MO04")
                    {
                        Lenguaje mateo = Lenguaje.ObtenerInstancia();

                        string keyVar = "";
                        Linea valorConjunto = new Linea();
                        valorConjunto.instrucciones = new List<Instruccion>();
                        bool asignacion = false;
                        foreach (Instruccion i in _lineaEntrada.instrucciones)
                        {
                           
                            if (i.token == "ID00" && keyVar == "")
                            {
                                keyVar = i.contenido;
                            }
                            if (asignacion)
                            {
                                if (i.token != "ES08")
                                {
                                    if (i.token == "ID00")
                                    {
                                        Instruccion nueva = (Instruccion)i.Clone();
                                        nueva.token = mateo.CodigoEntrada.BuscarTipoDeDato(i.tokenIncrementable);
                                        valorConjunto.instrucciones.Add(nueva);
                                    }
                                    else
                                    {
                                        valorConjunto.instrucciones.Add((Instruccion)i.Clone());
                                    }
                                }
                                else
                                {
                                    break;
                                }
                                   
                                    
                            }
                            if (i.token == "OP10")
                            {
                                asignacion = true;
                            }

                        }

                        Linea abs =  mateo.CodigoEntrada.BuscarMinimaExpresion(valorConjunto, "definicionesTipoDeDato");

                        if (abs.instrucciones.Count == 1)
                        {
                            mateo.CodigoEntrada.EstablecerTipo(keyVar, abs.instrucciones[0].token);
                        }
                    }
                }
            }




            return linea;
        }





    }
}
