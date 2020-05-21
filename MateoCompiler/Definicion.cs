using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler
{
    class Definicion
    {
        String titulo = "";
        List<Produccion> producciones = new List<Produccion>();

        public Definicion(String _titulo) {
            titulo = _titulo;
        }
        public Definicion(String _titulo, List<Produccion> _producciones)
        {
            titulo = _titulo;
            producciones = _producciones;
        }
        public Definicion GetAsObject() {
            return new Definicion(this.titulo, this.producciones);
        }

        public void AddProduccion(Produccion produccion)
        {
            this.producciones.Add(produccion);
        }

        public override string ToString() {
            string ext = $"--[{this.titulo}] \n";
            foreach (Produccion p in this.producciones) {
                ext += $"|- {p.ToString()}\n";
            }
            return ext;
        }

        public string getQuery()
        {
            string sql = "";
            foreach (Produccion x in producciones) { 
                sql += $"INSERT INTO Producciones Values('{titulo}' , '{x.ToString()}'); \n";
            }
            return sql;
           
        }

    }
}
