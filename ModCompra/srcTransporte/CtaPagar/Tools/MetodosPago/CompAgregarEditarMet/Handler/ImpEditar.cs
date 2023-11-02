using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompAgregarEditarMet.Handler
{
    public class ImpEditar : baseAgregarEditar, Vista.IEditar
    {
        private Vista.IHndData _item;
        public override string Get_TituloFicha { get { return "EDITAR METODO/PAGO"; } }


        public ImpEditar()
            :base()
        {
        }
        public void setItemEditar(object item)
        {
            _item = (ImpHndData)item;
        }


        protected override bool cargarData()
        {
            try
            {
                HndData.Cargardata();
                var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                HndData.setFactor(r01.Entidad);
                //
                var r02 = Sistema.MyData.FechaServidor();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                _fechaServidor = r02.Entidad;
                HndData.setFechaOperacion(r02.Entidad);
                if (_item != null)
                {
                    HndData.setMontoResta(Math.Abs(Get_MontoResta+_item.TitImporte));
                    HndData.MedioPago.setFichaById(_item.MedioPago.GetId);
                    HndData.setMonto(_item.Get_Monto);
                    HndData.setAplicaFactor(_item.Get_AplicaFactor);
                    HndData.setFactor(_item.Get_Factor);
                    HndData.setBanco(_item.Get_Banco);
                    HndData.setCtaNro(_item.Get_NroCta);
                    HndData.setChequeRefTranf(_item.Get_CheqRefTrans);
                    HndData.setFechaOperacion(_item.Get_FechaOp);
                    HndData.setDetalleOperacion(_item.Get_DetalleOp);
                    HndData.setReferencia(_item.Get_Referencia);
                    HndData.setLote(_item.Get_Lote);
                    HndData.setAplicaMovCaja(_item.Get_AplicaMovCaja);
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}