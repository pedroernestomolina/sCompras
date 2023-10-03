using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Administrador.Handler
{
    public class hndBusqueda: Utils.Componente.Busqueda.Vistas.IBusqueda
    {
        private OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Filtro _filtro;


        public hndBusqueda()
        {
            _filtro= new OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Filtro();
        }
        public void Inicializa()
        {
        }
        public void setFiltros(object filtros)
        {
            var filt= (Filtro.Vistas.IdataFiltrar)filtros;
            var _estatus = "";
            var _tipMov = "";
            var _idCaja = filt.IdCaja;
            if (filt.EstatusDoc != Filtro.Vistas.Enumerados.EstatusDoc.SinDefinir)
            {
                _estatus = "A";
                if (filt.EstatusDoc == Filtro.Vistas.Enumerados.EstatusDoc.Anulado)
                {
                    _estatus = "I";
                }
            }
            if (filt.TipoMovCaja != Filtro.Vistas.Enumerados.TipoMovCaja.SinDefinir )
            {
                _tipMov = "I";
                if (filt.TipoMovCaja== Filtro.Vistas.Enumerados.TipoMovCaja.Egreso)
                {
                    _tipMov= "E";
                }
            }
            _filtro = new OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Filtro()
            {
                Desde = filt.Desde,
                Hasta = filt.Hasta,
                Estatus =_estatus,
                TipoMovimiento= _tipMov,
                IdCaja=_idCaja,
            };
        }
        public IEnumerable<object>Buscar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Caja_Movimientos_GetLista(_filtro);
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