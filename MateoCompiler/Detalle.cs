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
    public partial class Detalle : Form
    {
        public Detalle()
        {
            InitializeComponent();
        }
        public Detalle(string _caracter, string _estado, string _estadoR, string _consulta,string _palabra)
        {
            InitializeComponent();
            lblCaracter.Text = _caracter;
            lblEstado.Text = _estado;
            lblEstadoResult.Text = _estadoR;
            rtbEntrada.Text = _consulta;
            lblPalabra.Text = _palabra;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void Detalle_Load(object sender, EventArgs e)
        {

        }

        private void btnTransofmrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
