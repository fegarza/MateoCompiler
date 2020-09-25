using MateoCompiler.Clases.Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateoCompiler.Clases.Singleton
{
    class Lenguaje
    {
       

        #region MANEJO DE ARCHIVOS    
        public InstruccionArchivo ArchivoInstruccion = new InstruccionArchivo();
        public DefinicionArchivo ArchivoDeDefiniciones = new DefinicionArchivo();
        public DefinicionTipoDatoArchivo DatoArchivoDefinicionTipo = new DefinicionTipoDatoArchivo();
        public CodigoEntradaArchivo ArchivoEntrada = new CodigoEntradaArchivo();
        public ProduccionTipoDatoArchivo ArchivoDeProduccionesTipoDato = new ProduccionTipoDatoArchivo();

        #endregion

        private static Lenguaje Instancia;
        public Codigo CodigoEntrada;
     
        private Lenguaje()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Lenguaje ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new Lenguaje();
            }
            return Instancia;
        }


     

        
    }
}
