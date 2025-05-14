using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.PanelMetPagoAgregar.handlers
{
    public class hndPanelAgregar: 
        basePanelAgregarEditar,
        interfaces.IPanelAgregar
    {
        public override string GetTituloFicha { get { return "Agregar Metodo De Pago"; } }
        //
        public object GetItemAgregar { get { return nuevoItemAgregar(); } }
        //
        public hndPanelAgregar()
            : base()
        {
        }
        public void Inicializa()
        {
            base.Inicializa();
        }
        vistas.Frm frm;
        public override void Inicia()
        {
            if (CargarDta()) 
            {
                if (frm == null) 
                {
                    frm = new vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        private object nuevoItemAgregar()
        {
            return null;
            //return new item()
            //{
            //    AplicaFactor = GetAplicaFactor,
            //    Banco = GetBanco,
            //    CheqRefTranf = GetCheqRefTrans,
            //    DetalleOp = GetDetalleOp,
            //    FactorCambio = GetFactor,
            //    FechaOp = GetFechaOp,
            //    ImporteMonAct = GetImporteMonact,
            //    ImporteMonDiv = GetImporteMonDiv,
            //    Lote = GetLote,
            //    MedioPago = (LibUtilitis.Opcion.IData) GetMedioPago,
            //    Monto = GetMonto,
            //    NroCta = GetNroCta,
            //    Referencia = GetReferencia,
            //    DescMetCobro = ((LibUtilitis.Opcion.IData)GetMedioPago).desc,
            //};
        }
    }
}