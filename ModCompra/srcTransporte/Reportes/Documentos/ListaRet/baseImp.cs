using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaRet
{
    abstract public class baseImp: IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Filtro _filtro;


        public baseImp()
        {
        }
        public void setFiltros(Idata data)
        {
            _filtro = new OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Filtro()
            {
                tipoRet = (OOB.LibCompra.Transporte.Reportes.Compras.enumerados.tipoRetencion)data.tipoRetencion,
            };
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


        abstract protected void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha> list);
    }
}