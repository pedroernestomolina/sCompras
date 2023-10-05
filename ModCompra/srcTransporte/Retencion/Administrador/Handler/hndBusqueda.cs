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
            var filt= (Filtro.Vistas.IdataFiltrar)filtros;
            var _estatus = "";
            var _tipoRet = "";
            if (filt.EstatusDoc != Filtro.Vistas.Enumerados.EstatusDoc.SinDefinir)
            {
                _estatus = "A";
                if (filt.EstatusDoc == Filtro.Vistas.Enumerados.EstatusDoc.Anulado)
                {
                    _estatus = "I";
                }
            }
            if (filt.TipoRetencion!= Filtro.Vistas.Enumerados.TipoRetencion.SinDefinir)
            {
                _tipoRet= "07";
                if (filt.TipoRetencion == Filtro.Vistas.Enumerados.TipoRetencion.ISLR)
                {
                    _tipoRet = "08";
                }
            }
            _filtro = new OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Filtro()
            {
                Desde = filt.Desde,
                Hasta= filt.Hasta,
                Estatus = _estatus,
                IdProveedor= filt.IdProveedor,
                TipoRetencion=_tipoRet,
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