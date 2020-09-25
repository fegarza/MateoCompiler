using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Clases
{
    public class Conexion
    {
        private string CadenaDeConexion;
        public SqlConnection SQLServerConexion;

        private static Conexion Instancia;
    
        private Conexion()
        {
            CadenaDeConexion = @"Server= localhost; Database= mateodb; Integrated Security=True;";
            SQLServerConexion = new SqlConnection(CadenaDeConexion);
        }

        public static Conexion getInstancia()
        {
            if(Instancia == null)
            {
                Instancia = new Conexion();
            }
            return Instancia;
        }

        public void EjecutarQuery(string _query)
        {
            SqlCommand cmd = new SqlCommand();
            Abrir();
            cmd.Connection = SQLServerConexion;
            cmd.CommandText = _query;
            cmd.ExecuteNonQuery();
            Cerrar();
        }
        
        public void EjecutarQuery(List<string> _queries)
        {
            SqlCommand cmd = new SqlCommand();
            SQLServerConexion.Open();
            cmd.Connection = SQLServerConexion;
            foreach (string q in _queries)
            {
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
            }
            SQLServerConexion.Close();
        }

        public void Abrir()
        {
            if(this.SQLServerConexion.State == System.Data.ConnectionState.Open)
            {
                Cerrar();
            }
            this.SQLServerConexion.Open();
        }
        public void Cerrar()
        {
            this.SQLServerConexion.Close();
        }

        public override bool Equals(object obj)
        {
            return obj is Conexion conexion && CadenaDeConexion == conexion.CadenaDeConexion;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
