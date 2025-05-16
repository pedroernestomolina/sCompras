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
        public __.Modelos.PanelMetPagoAgregar.IItemAgregar ItemAgregar { get { return nuevoItemAgregar(); } }
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
        private modelos.ItemAgregar nuevoItemAgregar()
        {
            return new modelos.ItemAgregar()
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
                Monto = GetMonto,
                NroCta = GetNroCta,
                Referencia = GetReferencia,
                CodigoMedioPago = ((LibUtilitis.Opcion.IData)GetMedioPago).codigo,
                DescMedioPago = ((LibUtilitis.Opcion.IData)GetMedioPago).desc,
                IdMedioPago = ((LibUtilitis.Opcion.IData)GetMedioPago).id,
                MontoAplica = Math.Round(GetMontoAplica,3, MidpointRounding.AwayFromZero),
            };
        }
    }
}