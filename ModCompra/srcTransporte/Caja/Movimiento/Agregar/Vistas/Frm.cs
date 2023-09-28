using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Caja.Movimiento.Agregar.Vistas
{
    public partial class Frm : Form
    {
        private Vistas.IMov _controlador;


        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(Vistas.IMov ctr)
        {
            _controlador = ctr;
        }
    }
}