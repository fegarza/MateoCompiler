using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Tripletas
{
    class TripletaAccionarPuerta : Tripleta
    {
        public bool Temp1;

        public string marginLeft = "";

        public string[,] Arreglo { get; set; }


        public TripletaAccionarPuerta()
        {
            this.Arreglo = new string[7, 3] {
                 {"Temp1", "[VALOR]", ""},
                 {"Temp1", "", ""},
                 {"V", "", ""},
                 {"F", "", ""},
                 {"MarginLeft", "", ""},
                 {"Dirigirse", "", ""},
                 {"MarginLeft", "", ""}
            };
        }



        public void AnalisisDeTripleta()
        {/*

            bool terminado = false;
            int actual = 0;
            if (!terminado)
            {
                //Significa un cambio de posicion
                if (Arreglo[actual][2] == "") {
                    int nuevo = int.Parse(Arreglo[actual][1]);
                }


                actual++;
            }

           
        
                if (Arreglo[x][2] == "asignar")
                {    

                    this.Temp1 = Arreglo[x][1] == "BOOL";
               
                }  
          */
        }



        public string GenerarCodigoIntermedio()
        {
            return "accionarPuerta(" + (Temp1 ? "true" : "false") + " , " + marginLeft + " );";
        }
    }
}
