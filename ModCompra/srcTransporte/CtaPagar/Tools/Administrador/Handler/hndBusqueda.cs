using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.Administrador.Handler
{
    public class hndBusqueda: Utils.Componente.Busqueda.Vistas.IBusqueda
    {
        private OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Filtro _filtro;


        public hndBusqueda()
        {
            _filtro = new OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Filtro();
        }
        public void Inicializa()
        {
        }
        public void setFiltros(object filtros)
        {
            var filt = (Filtro.Vistas.IdataFiltrar)filtros;
            var _estatus = OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.enumerados.EstatusDoc.SinDefinir;
            if (filt.EstatusDoc != Filtro.Vistas.Enumerados.EstatusDoc.SinDefinir)
            {
                _estatus = OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.enumerados.EstatusDoc.Activo ;
                if (filt.EstatusDoc == Filtro.Vistas.Enumerados.EstatusDoc.Anulado)
                {
                    _estatus = OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.enumerados.EstatusDoc.Anulado;
                }
            }
            _filtro = new OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Filtro()
            {
                Desde = filt.Desde,
                Hasta = filt.Hasta,
                EstatusDoc = _estatus,
                IdProveedor = filt.IdProveedor,
            };
        }
        public IEnumerable<object>Buscar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_CxpDoc_GetLista_PagosEmitidos(_filtro);
                return (IEnumerable<object>)r01.Lista.OrderByDescending(o=>o.idMov);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return null;
            }
        }
    }
}