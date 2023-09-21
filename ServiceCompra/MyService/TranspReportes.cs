using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.MyService
{
    public partial class Service: IService
    {
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.GeneralDoc.Ficha>
            Transporte_Reportes_Compras_GeneralDoc_GetLista(DtoLibTransporte.Reportes.Compras.GeneralDoc.Filtro filtro)
        {
            return ServiceProv.Transporte_Reportes_Compras_GeneralDoc_GetLista(filtro);
        }
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.Retencion.Ficha> 
            Transporte_Reportes_Compras_Retenciones_GetLista(DtoLibTransporte.Reportes.Compras.Retencion.Filtro filtro)
        {
            return ServiceProv.Transporte_Reportes_Compras_Retenciones_GetLista(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha> 
            Transporte_Reportes_Compras_Planilla_RetIva(string idDocCompra)
        {
            return ServiceProv.Transporte_Reportes_Compras_Planilla_RetIva(idDocCompra);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIslr(string idDocCompra)
        {
            return ServiceProv.Transporte_Reportes_Compras_Planilla_RetIslr(idDocCompra);
        }
    }
}