using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateoCompiler
{
    public partial class Form1 : Form
    {
        private List<Linea> lineas = new List<Linea>();

        #region Instrucciones y alfabeto
        public BindingList<Instruccion> instrucciones = new BindingList<Instruccion>();
        public static string rutaConfig = @".\instrucciones.txt";
        string[] DatosDeConexion = System.IO.File.ReadAllLines(rutaConfig);
        public List<string> Alfabeto = new List<string>();
        #endregion


        public Form1()
        {
            InitializeComponent();
            leerInstrucciones();

        }

        public void leerInstrucciones()
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
                for(int x = 0; x < i.contenido.Length; x++)
                {
                    if (definicion)
                    {
                        definicionStr += i.contenido[x];
                        if (i.contenido[x] == '>')
                        {
                            definicion = false;
                            if (! Alfabeto.Contains(definicionStr))
                            {
                                Alfabeto.Add(definicionStr);
                                MessageBox.Show($"se agrega {definicionStr}");
                            }
                            
                            definicionStr = "";
                        }

                    }
                    else if( i.contenido[x] == '<')
                    {
                        definicion = true;
                        definicionStr += i.contenido[x];
                    }
                    else
                    {
                        if (!Alfabeto.Contains(i.contenido[x].ToString()))
                        {
                            MessageBox.Show($"se agrega {i.contenido[x].ToString()}");
                            Alfabeto.Add(i.contenido[x].ToString());
                        }
                    }
                    
                }
            }
            
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
    }
}
