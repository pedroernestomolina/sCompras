using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaRet
{
    abstract public class baseImp: srcTransporte.Reportes.IRepFiltro 
    {
        protected OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Filtro _filtro;


        public baseImp()
        {
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_Retenciones_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void setFiltros(object filtros)
        {
            _setFiltros(filtros);
        }


        abstract protected void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha> list);
        abstract protected void _setFiltros(object filtros);
    }
}