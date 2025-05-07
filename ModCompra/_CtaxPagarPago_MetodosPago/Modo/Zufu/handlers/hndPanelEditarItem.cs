using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.handlers
{
    public class hndPanelEditarItem: basePanelAgregarEditarItem, Interfaces.IZufuPanelEditarItem
    {
        private _CtaxPagarPago_MetodosPago.Interfaces.IItem _itemEditar;
        //
        public object GetItemActualizado { get { return nuevoItem(); } }
        public override string GetTituloFicha { get { return "Editar Metodo De Pago"; } }
        //
        public hndPanelEditarItem(): base()
        {
            _itemEditar = null;
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _itemEditar = null;
        }
        vistas.FrmMetPago frm;
        public override void Inicia()
        {
            if (CargarDta()) 
            {
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
                    setMedPago(_itemEditar.MedioPago.id);
                    setReferencia(_itemEditar.Referencia);
                }
                if (frm == null) 
                {
                    frm = new vistas.FrmMetPago();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setItemEditar(object item)
        {
            _itemEditar = (_CtaxPagarPago_MetodosPago.Interfaces.IItem)item;
        }
        //
        private object nuevoItem()
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
                MedioPago = (LibUtilitis.Opcion.IData)GetMedioPago,
                Monto = GetMonto,
                NroCta = GetNroCta,
                Referencia = GetReferencia,
                DescMetCobro = ((LibUtilitis.Opcion.IData)GetMedioPago).desc,
            };
        }
    }
}