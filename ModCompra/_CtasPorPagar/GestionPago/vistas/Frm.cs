using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.GestionPago.vistas
{
    public partial class Frm : Form
    {
        private interfaces.IPanel _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.GetTituloFrm;
            L_ENTIDAD.Text = _controlador.GetInfoEntidad;
            ActualizarPanelAnticipo();
            ActualizarPanelMet();
            ActualizarPanelDocPend();
            ActualizarPanelNtCred();
            ActualizarPanelResumen();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarFichaIsOk || _controlador.IsPagoExitoso)
            {
                //_controlador.LimpiarData();
                e.Cancel = false;
            }
        }
        public void setControlador(interfaces.IPanel ctr)
        {
            _controlador = ctr;
        }
        //PANEL: METODOS 
        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarMetPago();
        }
        private void BT_LISTAR_Click(object sender, EventArgs e)
        {
            ListarMetPago();
        }
        //PANEL: CTAS 
        private void BT_LISTAR_CTAS_PAGAR_Click(object sender, EventArgs e)
        {
            ListarCtasPagar();
        }
        //PANEL: NOTAS/CREDITO 
        private void BT_LISTAR_NT_CRED_Click(object sender, EventArgs e)
        {
            ListarNtCred();
        }
        //PANEL: ANTICIPO
        private void BT_ANTICIPO_Click(object sender, EventArgs e)
        {
            AgregarAnticipo();
        }
        //
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            BtProcesar();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            BtAbandonar();
        }
        //
        private void AgregarMetPago()
        {
            _controlador.AgregarMetPago();
            ActualizarPanelMet();
        }
        private void ListarMetPago()
        {
            _controlador.ListarMetPago();
            ActualizarPanelMet();
        }
        private void ListarCtasPagar()
        {
            _controlador.ListarDocPend();
            ActualizarPanelDocPend();
        }
        private void ListarNtCred()
        {
            _controlador.ListarNtCred();
            ActualizarPanelNtCred();
        }
        private void AgregarAnticipo()
        {
            _controlador.AgregarAnticipo();
            ActualizarPanelAnticipo();
        }
        private void BtProcesar()
        {
            _controlador.ProcesarPago();
            if (_controlador.IsPagoExitoso)
            {
                salir();
            }
        }
        private void BtAbandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarFichaIsOk)
            {
                salir();
            }
        }
        //
        private void salir()
        {
            Close();
        }
        private void ActualizarPanelAnticipo() 
        {
            L_MONTO_ANTICIPO.Text = _controlador.Get_Anticipos_MontoAUsar.ToString("n2");
            L_ANTICIPO_DISPONIBLE.Text = _controlador.Get_Anticipos_MontoDisponible.ToString("n2");
            ActualizarPanelResumen();
        }
        private void ActualizarPanelMet()
        {
            L_MET_CNT.Text = _controlador.GetCntMetRecibido.ToString("n0");
            L_MONTO_RECIBIDO.Text = _controlador.GetMontoRecibido.ToString("n3");
            ActualizarPanelResumen();
        }
        private void ActualizarPanelDocPend()
        {
            L_CNT_CTAS_PAGAR.Text = _controlador.Get_DocSeleccionadosAPagar_PorDeuda_Cnt.ToString();
            L_MONTO_PAGAR.Text = _controlador.Get_DocSeleccionadosAPagar_PorDeuda_Monto.ToString("n3");
            L_SALDO_PEND_PAGAR.Text = _controlador.Get_DocPorDeuda_MontoTotal.ToString("n2");
            ActualizarPanelResumen();
        }
        private void ActualizarPanelNtCred()
        {
            L_CNT_NT_CRED.Text = _controlador.Get_DocSeleccionadosAPagar_PorNC_Cnt.ToString();
            L_MONTO_NT_CRED.Text = _controlador.Get_DocSeleccionadosAPagar_PorNC_Monto.ToString("n2");
            L_NTCRED_DISPONIBLE.Text = _controlador.Get_DocNC_MontoDisponible.ToString("n2");
            ActualizarPanelResumen();
        }
        private void ActualizarPanelResumen()
        {
            var ab = _controlador.Get_Anticipos_MontoAUsar;
            ab += _controlador.GetMontoRecibido;
            ab += _controlador.Get_DocSeleccionadosAPagar_PorNC_Monto;
            //
            var pg = _controlador.Get_DocSeleccionadosAPagar_PorDeuda_Monto;
            //
            var saldo = ab-pg;
            //
            var desc= "";
            var color = System.Drawing.Color.White;
            if (saldo > 0m)
            {
                desc = "SOBRANTE";
                color = System.Drawing.Color.Blue;
            }
            else if (saldo < 0m)
            {
                desc = "FALTANTE";
                color = System.Drawing.Color.Red;
            }
            else
            {
                desc = "OK";
                color = System.Drawing.Color.White;
            }
            L_RESUMEN_ANTICIPO.Text = _controlador.Get_Anticipos_MontoAUsar.ToString("n2");
            L_RESUMEN_MET_PAGO.Text = _controlador.GetMontoRecibido.ToString("n3");
            L_RESUMEN_NT_CRED.Text = _controlador.Get_DocSeleccionadosAPagar_PorNC_Monto.ToString("n2");
            L_RESUMEN_ABONO.Text = ab.ToString("n3");
            L_RESUMEN_CTAS.Text = _controlador.Get_DocSeleccionadosAPagar_PorDeuda_Monto.ToString("n3");
            L_RESUMEN_SALDO.Text = Math.Abs(saldo).ToString("n3");
            L_RESUMEN_DES_SALDO.Text = desc;
            L_RESUMEN_DES_SALDO.ForeColor = color;
        }
    }
}
