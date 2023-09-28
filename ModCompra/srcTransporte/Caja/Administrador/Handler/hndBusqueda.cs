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
            var filt= (dataFiltro)filtros;
            _filtro = new OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Filtro()
            {
                Desde = filt.Desde,
                Hasta = filt.Hasta,
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