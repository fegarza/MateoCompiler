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
        private List<String> tokens = new List<string>();



        public Form1()
        {
            InitializeComponent();
          
        }

       
        
        private void Compilar_Click(object sender, EventArgs e)
        {
            
            //Se separan las lineas del richtextbox
            lineas.Clear();
            string linea = "";
            for(int x=0; x < rtbEntrada.Text.Length; x++)
            {
               
                byte[] asciiBytes = Encoding.ASCII.GetBytes(rtbEntrada.Text[x].ToString());
                if(asciiBytes[0] == 10)
                {
                    lineas.Add(new Linea(linea));
                    linea = "";
                }else if(x == rtbEntrada.Text.Length - 1)
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
