using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Visualizar
{

    public partial class VisualizarFrm : Form
    {

        private Gestion _controlador;


        public VisualizarFrm()
        {
            InitializeComponent();
        }

        internal void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void VisualizarFrm_Load(object sender, EventArgs e)
        {
            L_CIRIF.Text = _controlador.CiRif;
            L_CODIGO.Text = _controlador.Codigo;
            L_NOMBRE_RAZON_SOCIAL.Text = _controlador.NombreRazonSocial;
            L_DIR_FISCAL.Text = _controlador.DirFiscal;

            L_UB_COD_POSTAL.Text = _controlador.CodPostal;
            L_UB_ESTADO.Text = _controlador.Estado;
            L_UB_PAIS .Text = _controlador.Pais;
            L_UB_GRUPO.Text = _controlador.Grupo;

            L_CONT_EMAIL.Text = _controlador.Email;
            L_CONT_PERSONA.Text = _controlador.Persona;
            L_CONT_TELEFONO.Text = _controlador.Telefono;
            L_CONT_WEBSITE.Text = _controlador.WebSite;

            L_DEN_FISCAL.Text = _controlador.DenominacionFiscal;
            L_RET_IVA.Text = _controlador.RetencionIva;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}