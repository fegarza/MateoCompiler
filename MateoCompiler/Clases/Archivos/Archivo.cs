using MateoCompiler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoCompiler.Clases
{
    public class Archivo : IArchivo
    {
        private string _ruta;

        public string Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        private string[] _lineas;

        public string[] Lineas
        {
            get {

                if (_lineas == null)
                {
                    ObtenerLineas();
                }
                return _lineas; 
            
            }
            set { _lineas = value; }
        }


        public Archivo(string _ruta) 
        {
            Ruta = _ruta;
        }

        private void ObtenerLineas()
        {
            this._lineas =  System.IO.File.ReadAllLines(Ruta);
        }
    }
}
