using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Administrador.Handler
{
    public class hndBusqueda: Utils.Componente.Busqueda.Vistas.IBusqueda
    {
        private OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Filtro _filtro;


        public hndBusqueda()
        {
            _filtro = new OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Filtro();
        }
        public void Inicializa()
        {
        }
        public void setFiltros(object filtros)
        {
            var filt= (dataFiltro)filtros;
            _filtro = new OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Filtro()
            {
            };
        }
        public IEnumerable<object>Buscar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_DocumentoRet_GetLista (_filtro);
                return (IEnumerable<object>)r01.Lista.OrderByDescending(o=>o.documentoNro);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return null;
            }
        }
    }
}