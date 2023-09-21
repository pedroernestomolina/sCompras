using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {

        private Gestion _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            InicializarCombos();
        }

        private void InicializarCombos()
        {
            CB_ESTADO.ValueMember = "auto";
            CB_ESTADO.DisplayMember = "nombre";

            CB_GRUPO.ValueMember = "auto";
            CB_GRUPO.DisplayMember = "nombre";

            CB_DENOMINACION_FISCAL.ValueMember = "auto";
            CB_DENOMINACION_FISCAL.DisplayMember = "nombre";
        }

        public void setContolador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private bool isCargando;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.TituloFicha;
            TB_RIF.Text = _controlador.GetRif;
            TB_CODIGO.Text = _controlador.GetCodigo;
            TB_RAZON_SOCIAL.Text = _controlador.GetRazonSocial;
            TB_DIR_FISCAL.Text= _controlador.GetDirFiscal;
            TB_PAIS.Text = _controlador.GetPais;
            TB_COD_POSTAL.Text = _controlador.GetCodigoPostal;
            TB_PERSONA.Text = _controlador.GetPersona;
            TB_TELEFONO.Text = _controlador.GetTelefono;
            TB_EMAIL.Text = _controlador.GetEmail;
            TB_WEBSITE.Text = _controlador.GetWebSite;
            TB_RET_IVA.Text = _controlador.GetTasaRetIva.ToString("n2").Replace(".",",");
            isCargando = true;

            CB_GRUPO.DataSource = _controlador.SourceGrupo;
            CB_ESTADO.DataSource = _controlador.SourceEstado;
            CB_DENOMINACION_FISCAL.DataSource = _controlador.SourceDenFiscal;

            CB_GRUPO.SelectedIndex = -1;
            if (_controlador.GetGrupo !="")
                CB_GRUPO.SelectedValue = _controlador.GetGrupo;

            CB_ESTADO.SelectedIndex = -1;
            if (_controlador.GetEstado != "")
                CB_ESTADO.SelectedValue = _controlador.GetEstado;

            CB_DENOMINACION_FISCAL.SelectedIndex = -1;
            if (_controlador.GetDenFiscal != "")
                CB_DENOMINACION_FISCAL.SelectedValue = _controlador.GetDenFiscal;

            isCargando = false;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_RIF_Leave(object sender, EventArgs e)
        {
            _controlador.setCiRif(TB_RIF.Text);
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigo(TB_CODIGO.Text);
        }

        private void TB_RAZON_SOCIAL_Leave(object sender, EventArgs e)
        {
            _controlador.setRazonSocial(TB_RAZON_SOCIAL.Text);
        }

        private void TB_DIR_FISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.setDirFiscal(TB_DIR_FISCAL.Text);
        }

        private void TB_PAIS_Leave(object sender, EventArgs e)
        {
            _controlador.setPais(TB_PAIS.Text);
        }

        private void TB_COD_POSTAL_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigoPostal(TB_COD_POSTAL.Text);
        }

        private void TB_PERSONA_Leave(object sender, EventArgs e)
        {
            _controlador.setPersona(TB_PERSONA.Text);
        }

        private void TB_TELEFONO_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefono(TB_TELEFONO.Text);
        }

        private void TB_EMAIL_Leave(object sender, EventArgs e)
        {
            _controlador.setEmail(TB_EMAIL.Text);
        }

        private void TB_WEBSITE_Leave(object sender, EventArgs e)
        {
            _controlador.setWebSite(TB_WEBSITE.Text);
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isCargando)
            {
                _controlador.setGrupo("");
                if (CB_GRUPO.SelectedIndex != -1)
                    _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }

        private void CB_ESTADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isCargando)
            {
                _controlador.setEstado("");
                if (CB_ESTADO.SelectedIndex != -1)
                    _controlador.setEstado(CB_ESTADO.SelectedValue.ToString());
            }
        }

        private void CB_DENOMINACION_FISCAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isCargando)
            {
                _controlador.setDenFiscal("");
                if (CB_DENOMINACION_FISCAL.SelectedIndex != -1)
                    _controlador.setDenFiscal(CB_DENOMINACION_FISCAL.SelectedValue.ToString());
            }
        }

        private void TB_RET_IVA_Leave(object sender, EventArgs e)
        {
            _controlador.setTasaRetIva(decimal.Parse(TB_RET_IVA.Text));
        }
        private void TB_RET_IVA_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.GetTasaRetIva > 100;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
        }

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controlador.salirIsOk;
        }

        public void Cerrar()
        {
            this.Close();
        }
    }
}