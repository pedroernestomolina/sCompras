using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.PanelMetPagoAgregar.handlers
{
    public class hndPanelEditar:
        basePanelAgregarEditar,
        interfaces.IPanelEditar
    {
        private __.Modelos.PanelMetPagoAgregar.IItemAgregar _itemEditar;
        //
        public override string GetTituloFicha { get { return "Editar Metodo De Pago"; } }
        __.Modelos.PanelMetPagoAgregar.IItemAgregar interfaces.IPanelEditar.GetItemActualizado { get { return nuevoItem(); } }
        //
        public hndPanelEditar(): base()
        {
            _itemEditar = null;
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _itemEditar = null;
        }
        vistas.Frm frm;
        public override void Inicia()
        {
            if (CargarDta()) 
            {
                CargarMediosPago(_mediosPago);
                if (_itemEditar != null) 
                {
                    setMonto(_itemEditar.Monto);
                    setFactor(_itemEditar.FactorCambio);
                    setBanco(_itemEditar.Banco);
                    setCtaNro(_itemEditar.NroCta);
                    setChequeRefTranf(_itemEditar.CheqRefTranf);
                    setFechaOperacion(_itemEditar.FechaOp);
                    setDetalleOperacion(_itemEditar.DetalleOp);
                    setAplicaFactor(_itemEditar.AplicaFactor);
                    setLote(_itemEditar.Lote);
                    setMedPago(_itemEditar.IdMedioPago);
                    setReferencia(_itemEditar.Referencia);
                }
                if (frm == null) 
                {
                    frm = new vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setItemEditar(__.Modelos.PanelMetPagoAgregar.IItemAgregar item)
        {
            _itemEditar = item;
        }
        //
        private modelos.ItemAgregar nuevoItem()
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
                MontoAplica = Math.Round(GetMontoAplica, 3, MidpointRounding.AwayFromZero),
            };
        }
    }
}