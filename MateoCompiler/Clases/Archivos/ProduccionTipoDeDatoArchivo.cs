using MateoCompiler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Clases.Archivos
{
    class ProduccionTipoDatoArchivo: Archivo
    {
        public List<Definicion> Definiciones = new List<Definicion>();
        public ProduccionTipoDatoArchivo() : base(@".\produccionesTipoDeDato.txt")
        {
            Definicion definicionActual = null;
            int count = 0;
            foreach (String linea in Lineas)
            {
                count++;
                if (count == Lineas.Length)
                {
                    if (linea.Substring(0, 2) == "->")
                    {
                        if (definicionActual != null)
                        {
                            definicionActual.AddProduccion(new Produccion(linea.Substring(3, (linea.Length - 3))));
                        }
                    }
                    if (definicionActual != null)
                    {
                        Definiciones.Add(definicionActual.GetAsObject());
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
                                Definiciones.Add(definicionActual.GetAsObject());
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

            Conexion con = Conexion.getInstancia();
            con.EjecutarQuery("DELETE FROM produccionesTipoDeDato;");
          
            foreach (Definicion d in Definiciones)
            {
                con.EjecutarQuery(d.getQuery("produccionesTipoDeDato"));
            }

        }


    }
}
