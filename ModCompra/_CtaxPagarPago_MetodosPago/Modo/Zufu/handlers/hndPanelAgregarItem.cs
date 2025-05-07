using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.handlers
{
    public class hndPanelAgregarItem: basePanelAgregarEditarItem, Interfaces.IZufuPanelAgregarItem 
    {
        public override string GetTituloFicha { get { return "Agregar Metodo De Pago"; } }
        //
        public object GetItemAgregar { get { return nuevoItemAgregar(); } }
        //
        public hndPanelAgregarItem()
            : base()
        {
        }
        public void Inicializa()
        {
            base.Inicializa();
        }
        vistas.FrmMetPago frm;
        public override void Inicia()
        {
            if (CargarDta()) 
            {
                if (frm == null) 
                {
                    frm = new vistas.FrmMetPago();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        private object nuevoItemAgregar()
        {
            return new item()
            {
                AplicaFactor = GetAplicaFactor,
                Banco = GetBanco,
                CheqRefTranf = GetCheqRefTrans,
                DetalleOp = GetDetalleOp,
                FactorCambio = GetFactor,
                FechaOp = GetFechaOp,
                ImporteMonAct = GetImporteMonact,
                ImporteMonDiv = GetImporteMonDiv,
                Lote = GetLote,
                MedioPago = (LibUtilitis.Opcion.IData) GetMedioPago,
                Monto = GetMonto,
                NroCta = GetNroCta,
                Referencia = GetReferencia,
                DescMetCobro = ((LibUtilitis.Opcion.IData)GetMedioPago).desc,
            };
        }
    }
}