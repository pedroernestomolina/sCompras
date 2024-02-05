using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Producto.Precio.zufu.ActualizarPrecio.Vista
{
    public partial class Frm : Form
    {
        private Vista.IVista _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(IVista ctr)
        {
            _controlador = ctr;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.BtAbandonar.OpcionIsOK || _controlador.BtProcesar.OpcionIsOK )
            {
                e.Cancel = false;
            }
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            //
            L_PRD_INFO.Text = _controlador.Data.ProductoDesc;
            L_EMP_COMPRA.Text = "Empaque Compra:" + Environment.NewLine + _controlador.Data.EmpCompraDesc;
            L_MET_CALCULO_UTILIDAD.Text = "Utilidad Tipo: " + Environment.NewLine + _controlador.Data.MetodoCalculoUtilidadDesc;
            L_COSTO_COMPRA.Text = _controlador.Data.CostoEmpCompraDesc;
            L_COSTO_UND.Text = _controlador.Data.CostoUndDesc;
            L_ADM_DIVISA.Text = "Manejador Por Divisa: " + Environment.NewLine + _controlador.Data.EsDivisaDesc;
            L_TASA_CAMBIO.Text = _controlador.Data.TasaCambioDesc;
            L_TASA_IVA.Text = _controlador.Data.TasaIvaDesc;
            L_TIPO_EMPAQUE_1.Text= _controlador.PrecioEmp1.DescTipoEmpaque;
            L_TIPO_EMPAQUE_2.Text = _controlador.PrecioEmp2.DescTipoEmpaque;
            L_TIPO_EMPAQUE_3.Text = _controlador.PrecioEmp3.DescTipoEmpaque;
            for (var x = 0; x < 4; x++) 
            {
                habilitarEmp(1, false, false, false);
                actualizarEmp(1, x + 1);
                habilitarEmp(2, false, false, false);
                actualizarEmp(2, x + 1);
                habilitarEmp(3, false, false, false);
                actualizarEmp(3, x + 1); 
            }
            _modoInicializar = false;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }

        private void L_TIT_UT_EMP_1_Click(object sender, EventArgs e)
        {
            P_EMP_1.Focus();
            TB_UT_EMP_1_1.Focus();
            habilitarEmp(1, true, false, false);
        }
        private void L_TIT_PN_EMP_1_Click(object sender, EventArgs e)
        {
            P_EMP_1.Focus();
            TB_PN_EMP_1_1.Focus();
            habilitarEmp(1, false, true, false);
        }
        private void L_TIT_PF_EMP_1_Click(object sender, EventArgs e)
        {
            P_EMP_1.Focus();
            TB_PF_EMP_1_1.Focus();
            habilitarEmp(1, false, false, true);
        }
        private void TB_EMP_1_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_1_1")
                _controlador.PrecioEmp1.Precio[0].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_1_1")
                _controlador.PrecioEmp1.Precio[0].setNeto(_mnto);
            else
                _controlador.PrecioEmp1.Precio[0].setFull(_mnto);
            actualizarEmp(1, 1);
        }
        private void TB_EMP_1_1_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp1.Precio[0].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_1_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_1_2")
                _controlador.PrecioEmp1.Precio[1].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_1_2")
                _controlador.PrecioEmp1.Precio[1].setNeto(_mnto);
            else
                _controlador.PrecioEmp1.Precio[1].setFull(_mnto);
            actualizarEmp(1, 2);
        }
        private void TB_EMP_1_2_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp1.Precio[1].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_1_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_1_3")
                _controlador.PrecioEmp1.Precio[2].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_1_3")
                _controlador.PrecioEmp1.Precio[2].setNeto(_mnto);
            else
                _controlador.PrecioEmp1.Precio[2].setFull(_mnto);
            actualizarEmp(1, 3);
        }
        private void TB_EMP_1_3_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp1.Precio[2].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_1_4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name =="TB_UT_EMP_1_4")
                _controlador.PrecioEmp1.Precio[3].setUtilidad(_mnto);
            else if (_ct.Name =="TB_PN_EMP_1_4")
                _controlador.PrecioEmp1.Precio[3].setNeto(_mnto);
            else
                _controlador.PrecioEmp1.Precio[3].setFull(_mnto);
            actualizarEmp(1, 4);
        }
        private void TB_EMP_1_4_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp1.Precio[3].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void L_UT_ANT_EMP_1_1_Click_(object sender, EventArgs e)
        {
            var _ctrlEmisor = (Control)sender;
            var _ind = (_ctrlEmisor.Name).IndexOf("_EMP_");
            var _ctrlDest = "TB_UT" + (_ctrlEmisor.Name).Substring(_ind);
            Control[] _ctrl = this.Controls.Find(_ctrlDest, true);
            if (_ctrl.Length == 1)
            {
                _ctrl[0].Focus();
                _ctrl[0].Text = _ctrlEmisor.Text;
            }
        }

        private void L_TIT_UT_EMP_2_Click(object sender, EventArgs e)
        {
            P_EMP_2.Focus();
            TB_UT_EMP_2_1.Focus();
            habilitarEmp(2, true, false, false);
        }
        private void L_TIT_PN_EMP_2_Click(object sender, EventArgs e)
        {
            P_EMP_2.Focus();
            TB_PN_EMP_2_1.Focus();
            habilitarEmp(2, false, true, false);
        }
        private void L_TIT_PF_EMP_2_Click(object sender, EventArgs e)
        {
            P_EMP_2.Focus();
            TB_PF_EMP_2_1.Focus();
            habilitarEmp(2, false, false, true);
        }
        private void TB_EMP_2_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_2_1")
                _controlador.PrecioEmp2.Precio[0].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_2_1")
                _controlador.PrecioEmp2.Precio[0].setNeto(_mnto);
            else
                _controlador.PrecioEmp2.Precio[0].setFull(_mnto);
            actualizarEmp(2, 1);
        }
        private void TB_EMP_2_1_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp2.Precio[0].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_2_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_2_2")
                _controlador.PrecioEmp2.Precio[1].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_2_2")
                _controlador.PrecioEmp2.Precio[1].setNeto(_mnto);
            else
                _controlador.PrecioEmp2.Precio[1].setFull(_mnto);
            actualizarEmp(2, 2);
        }
        private void TB_EMP_2_2_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp2.Precio[1].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_2_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_2_3")
                _controlador.PrecioEmp2.Precio[2].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_2_3")
                _controlador.PrecioEmp2.Precio[2].setNeto(_mnto);
            else
                _controlador.PrecioEmp2.Precio[2].setFull(_mnto);
            actualizarEmp(2, 3);
        }
        private void TB_EMP_2_3_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp2.Precio[2].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_2_4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_2_4")
                _controlador.PrecioEmp2.Precio[3].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_2_4")
                _controlador.PrecioEmp2.Precio[3].setNeto(_mnto);
            else
                _controlador.PrecioEmp2.Precio[3].setFull(_mnto);
            actualizarEmp(2, 4);
        }
        private void TB_EMP_2_4_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp2.Precio[3].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void L_UT_ANT_EMP_2_Click(object sender, EventArgs e)
        {
            var _ctrlEmisor = (Control)sender;
            var _ind = (_ctrlEmisor.Name).IndexOf("_EMP_");
            var _ctrlDest = "TB_UT" + (_ctrlEmisor.Name).Substring(_ind);
            Control[] _ctrl = this.Controls.Find(_ctrlDest, true);
            if (_ctrl.Length == 1)
            {
                _ctrl[0].Focus();
                _ctrl[0].Text = _ctrlEmisor.Text;
            }
        }

        private void L_TIT_UT_EMP_3_Click(object sender, EventArgs e)
        {
            P_EMP_3.Focus();
            TB_UT_EMP_3_1.Focus();
            habilitarEmp(3, true, false, false);
        }
        private void L_TIT_PN_EMP_3_Click(object sender, EventArgs e)
        {
            P_EMP_3.Focus();
            TB_UT_EMP_3_1.Focus();
            habilitarEmp(3, false, true, false);
        }
        private void L_TIT_PF_EMP_3_Click(object sender, EventArgs e)
        {
            P_EMP_3.Focus();
            TB_UT_EMP_3_1.Focus();
            habilitarEmp(3, false, false, true);
        }
        private void TB_EMP_3_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_3_1")
                _controlador.PrecioEmp3.Precio[0].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_3_1")
                _controlador.PrecioEmp3.Precio[0].setNeto(_mnto);
            else
                _controlador.PrecioEmp3.Precio[0].setFull(_mnto);
            actualizarEmp(3, 1);
        }
        private void TB_EMP_3_1_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp3.Precio[0].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_3_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_3_2")
                _controlador.PrecioEmp3.Precio[1].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_3_2")
                _controlador.PrecioEmp3.Precio[1].setNeto(_mnto);
            else
                _controlador.PrecioEmp3.Precio[1].setFull(_mnto);
            actualizarEmp(3, 2);
        }
        private void TB_EMP_3_2_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp3.Precio[1].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_3_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_3_3")
                _controlador.PrecioEmp3.Precio[2].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_3_3")
                _controlador.PrecioEmp3.Precio[2].setNeto(_mnto);
            else
                _controlador.PrecioEmp3.Precio[2].setFull(_mnto);
            actualizarEmp(3, 3);
        }
        private void TB_EMP_3_3_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp3.Precio[2].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void TB_EMP_3_4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            var _ct = (Control)sender;
            var _mnto = decimal.Parse(_ct.Text);
            if (_ct.Name == "TB_UT_EMP_3_4")
                _controlador.PrecioEmp3.Precio[3].setUtilidad(_mnto);
            else if (_ct.Name == "TB_PN_EMP_3_4")
                _controlador.PrecioEmp3.Precio[3].setNeto(_mnto);
            else
                _controlador.PrecioEmp3.Precio[3].setFull(_mnto);
            actualizarEmp(3, 4);
        }
        private void TB_EMP_3_4_Validating(object sender, CancelEventArgs e)
        {
            if (_controlador.PrecioEmp3.Precio[3].Data.UtilidadIsError)
            {
                Helpers.Msg.Alerta("PRECIO INCORRECTO");
                var ct = ((Control)sender);
                ct.Text = (0m).ToString("N2").Replace(".", "");
                e.Cancel = true;
            }
        }
        private void L_UT_ANT_EMP_3_Click(object sender, EventArgs e)
        {
            var _ctrlEmisor = (Control)sender;
            var _ind = (_ctrlEmisor.Name).IndexOf("_EMP_");
            var _ctrlDest = "TB_UT" + (_ctrlEmisor.Name).Substring(_ind);
            Control[] _ctrl = this.Controls.Find(_ctrlDest, true);
            if (_ctrl.Length == 1)
            {
                _ctrl[0].Focus();
                _ctrl[0].Text = _ctrlEmisor.Text;
            }
        }
        private void habilitarEmp(int emp, bool ut, bool pn, bool pf)
        {
            switch (emp)
            {
                case 1:
                    TB_UT_EMP_1_1.Enabled = ut;
                    TB_UT_EMP_1_2.Enabled = ut;
                    TB_UT_EMP_1_3.Enabled = ut;
                    TB_UT_EMP_1_4.Enabled = ut;
                    TB_PN_EMP_1_1.Enabled = pn;
                    TB_PN_EMP_1_2.Enabled = pn;
                    TB_PN_EMP_1_3.Enabled = pn;
                    TB_PN_EMP_1_4.Enabled = pn;
                    TB_PF_EMP_1_1.Enabled = pf;
                    TB_PF_EMP_1_2.Enabled = pf;
                    TB_PF_EMP_1_3.Enabled = pf;
                    TB_PF_EMP_1_4.Enabled = pf;
                    L_UT_ANT_EMP_1_1.Enabled = ut;
                    L_UT_ANT_EMP_1_2.Enabled = ut;
                    L_UT_ANT_EMP_1_3.Enabled = ut;
                    L_UT_ANT_EMP_1_4.Enabled = ut;
                    break;
                case 2:
                    TB_UT_EMP_2_1.Enabled = ut;
                    TB_UT_EMP_2_2.Enabled = ut;
                    TB_UT_EMP_2_3.Enabled = ut;
                    TB_UT_EMP_2_4.Enabled = ut;
                    TB_PN_EMP_2_1.Enabled = pn;
                    TB_PN_EMP_2_2.Enabled = pn;
                    TB_PN_EMP_2_3.Enabled = pn;
                    TB_PN_EMP_2_4.Enabled = pn;
                    TB_PF_EMP_2_1.Enabled = pf;
                    TB_PF_EMP_2_2.Enabled = pf;
                    TB_PF_EMP_2_3.Enabled = pf;
                    TB_PF_EMP_2_4.Enabled = pf;
                    L_UT_ANT_EMP_2_1.Enabled = ut;
                    L_UT_ANT_EMP_2_2.Enabled = ut;
                    L_UT_ANT_EMP_2_3.Enabled = ut;
                    L_UT_ANT_EMP_2_4.Enabled = ut;
                    break;
                case 3:
                    TB_UT_EMP_3_1.Enabled = ut;
                    TB_UT_EMP_3_2.Enabled = ut;
                    TB_UT_EMP_3_3.Enabled = ut;
                    TB_UT_EMP_3_4.Enabled = ut;
                    TB_PN_EMP_3_1.Enabled = pn;
                    TB_PN_EMP_3_2.Enabled = pn;
                    TB_PN_EMP_3_3.Enabled = pn;
                    TB_PN_EMP_3_4.Enabled = pn;
                    TB_PF_EMP_3_1.Enabled = pf;
                    TB_PF_EMP_3_2.Enabled = pf;
                    TB_PF_EMP_3_3.Enabled = pf;
                    TB_PF_EMP_3_4.Enabled = pf;
                    L_UT_ANT_EMP_3_1.Enabled = ut;
                    L_UT_ANT_EMP_3_2.Enabled = ut;
                    L_UT_ANT_EMP_3_3.Enabled = ut;
                    L_UT_ANT_EMP_3_4.Enabled = ut;
                    break;

            }
        }
        private void actualizarEmp(int emp, int tipoPrecio)
        {
            _modoInicializar = true;
            switch (emp) 
            {
                case 1:
                    actualizarEmpaque_1_TipoPrecio(tipoPrecio);
                    break;
                case 2:
                    actualizarEmpaque_2_TipoPrecio(tipoPrecio);
                    break;
                case 3:
                    actualizarEmpaque_3_TipoPrecio(tipoPrecio);
                    break;
            }
            _modoInicializar = false;
        }
        private void actualizarEmpaque_1_TipoPrecio(int tipoPrecio)
        {
            Control[] descPrecio = this.Controls.Find("L_DESC_PRECIO_EMP_1_" + tipoPrecio.ToString().Trim(), true);
            Control[] ut = this.Controls.Find("TB_UT_EMP_1_" + tipoPrecio.ToString().Trim(), true);
            Control[] pn = this.Controls.Find("TB_PN_EMP_1_" + tipoPrecio.ToString().Trim(), true);
            Control[] pf = this.Controls.Find("TB_PF_EMP_1_" + tipoPrecio.ToString().Trim(), true);
            Control[] utAnt = this.Controls.Find("L_UT_ANT_EMP_1_" + tipoPrecio.ToString().Trim(), true);
            descPrecio[0].Text = _controlador.PrecioEmp1.Precio[tipoPrecio - 1].Data.Descripcion;
            ut[0].Text = _controlador.PrecioEmp1.Precio[tipoPrecio-1].Data.Utilidad.ToString("N2").Replace(".", "");
            pn[0].Text = _controlador.PrecioEmp1.Precio[tipoPrecio - 1].Data.PNeto.ToString("N2").Replace(".", "");
            pf[0].Text = _controlador.PrecioEmp1.Precio[tipoPrecio - 1].Data.PFull.ToString("N2").Replace(".", "");
            utAnt[0].Text = _controlador.PrecioEmp1.Precio[tipoPrecio - 1].Data.UtilidadAnterior.ToString("N2").Replace(".", "");
        }
        private void actualizarEmpaque_2_TipoPrecio(int tipoPrecio)
        {
            Control[] descPrecio = this.Controls.Find("L_DESC_PRECIO_EMP_2_" + tipoPrecio.ToString().Trim(), true);
            Control[] ut = this.Controls.Find("TB_UT_EMP_2_" + tipoPrecio.ToString().Trim(), true);
            Control[] pn = this.Controls.Find("TB_PN_EMP_2_" + tipoPrecio.ToString().Trim(), true);
            Control[] pf = this.Controls.Find("TB_PF_EMP_2_" + tipoPrecio.ToString().Trim(), true);
            Control[] utAnt = this.Controls.Find("L_UT_ANT_EMP_2_" + tipoPrecio.ToString().Trim(), true);
            descPrecio[0].Text = _controlador.PrecioEmp2.Precio[tipoPrecio - 1].Data.Descripcion;
            ut[0].Text = _controlador.PrecioEmp2.Precio[tipoPrecio - 1].Data.Utilidad.ToString("N2").Replace(".", "");
            pn[0].Text = _controlador.PrecioEmp2.Precio[tipoPrecio - 1].Data.PNeto.ToString("N2").Replace(".", "");
            pf[0].Text = _controlador.PrecioEmp2.Precio[tipoPrecio - 1].Data.PFull.ToString("N2").Replace(".", "");
            utAnt[0].Text = _controlador.PrecioEmp2.Precio[tipoPrecio - 1].Data.UtilidadAnterior.ToString("N2").Replace(".", "");
        }
        private void actualizarEmpaque_3_TipoPrecio(int tipoPrecio)
        {
            Control[] descPrecio = this.Controls.Find("L_DESC_PRECIO_EMP_3_" + tipoPrecio.ToString().Trim(), true);
            Control[] ut = this.Controls.Find("TB_UT_EMP_3_" + tipoPrecio.ToString().Trim(), true);
            Control[] pn = this.Controls.Find("TB_PN_EMP_3_" + tipoPrecio.ToString().Trim(), true);
            Control[] pf = this.Controls.Find("TB_PF_EMP_3_" + tipoPrecio.ToString().Trim(), true);
            Control[] utAnt = this.Controls.Find("L_UT_ANT_EMP_3_" + tipoPrecio.ToString().Trim(), true);
            descPrecio[0].Text = _controlador.PrecioEmp3.Precio[tipoPrecio - 1].Data.Descripcion;
            ut[0].Text = _controlador.PrecioEmp3.Precio[tipoPrecio - 1].Data.Utilidad.ToString("N2").Replace(".", "");
            pn[0].Text = _controlador.PrecioEmp3.Precio[tipoPrecio - 1].Data.PNeto.ToString("N2").Replace(".", "");
            pf[0].Text = _controlador.PrecioEmp3.Precio[tipoPrecio - 1].Data.PFull.ToString("N2").Replace(".", "");
            utAnt[0].Text = _controlador.PrecioEmp3.Precio[tipoPrecio - 1].Data.UtilidadAnterior.ToString("N2").Replace(".", "");
        }


        private void L_TIT_UT_M_Click(object sender, EventArgs e)
        {
            ActivarTitulo_M(true, false, false);
        }
        private void L_TIT_PN_M_Click(object sender, EventArgs e)
        {
            ActivarTitulo_M(false, true,false);
        }
        private void L_TIT_PF_M_Click(object sender, EventArgs e)
        {
            ActivarTitulo_M(false, false, true);
        }
        private void ActivarTitulo_M(bool ut, bool pn, bool pf)
        {
            TB_UT_EMP_2_1.Enabled = ut;
            TB_UT_EMP_2_2.Enabled = ut;
            TB_UT_EMP_2_3.Enabled = ut;
            TB_UT_EMP_2_4.Enabled = ut;
            L_UT_ANT_EMP_2_1.Enabled = ut;
            L_UT_ANT_EMP_2_2.Enabled = ut;
            L_UT_ANT_EMP_2_3.Enabled = ut;
            L_UT_ANT_EMP_2_4.Enabled = ut;

            TB_PN_EMP_2_1.Enabled = pn;
            TB_PN_EMP_2_2.Enabled = pn;
            TB_PN_EMP_2_3.Enabled = pn;
            TB_PN_EMP_2_4.Enabled = pn;

            TB_PF_EMP_2_1.Enabled = pf;
            TB_PF_EMP_2_2.Enabled = pf;
            TB_PF_EMP_2_3.Enabled = pf;
            TB_PF_EMP_2_4.Enabled = pf;
        }


        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.BtProcesar.OpcionIsOK)
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            _controlador.BtAbandonar.Opcion();
            if (_controlador.BtAbandonar.OpcionIsOK)
            {
                salir();
            }
        }
        private void salir()
        {
            this.Close();
        }
    }
}