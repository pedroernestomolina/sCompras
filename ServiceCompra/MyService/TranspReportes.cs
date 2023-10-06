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
        //DOCUMENTOS
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

        //ALIADOS
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.Anticipo.General.Ficha> 
            Transporte_Reportes_Aliado_Anticipos_GetLista(DtoLibTransporte.Reportes.Aliado.Anticipo.General.Filtro filtro)
        {
            return ServiceProv.Transporte_Reportes_Aliado_Anticipos_GetLista(filtro);
        }
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.PagoServ.General.Ficha> 
            Transporte_Reportes_Aliado_PagoServ_GetLista(DtoLibTransporte.Reportes.Aliado.PagoServ.General.Filtro filtro)
        {
            return ServiceProv.Transporte_Reportes_Aliado_PagoServ_GetLista(filtro);
        }

        //PLANILLAS
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.Anticipo.Planilla.Ficha> 
            Transporte_Reportes_Aliado_Anticipos_Planilla(int idMov)
        {
            return ServiceProv.Transporte_Reportes_Aliado_Anticipos_Planilla(idMov);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Ficha> 
            Transporte_Reportes_Aliado_PagoServ_Planilla(int idMov)
        {
            return ServiceProv.Transporte_Reportes_Aliado_PagoServ_Planilla(idMov);
        }

        //CAJA
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Caja.Movimiento.Ficha> 
            Transporte_Reportes_Caja_Movimientos_GetLista(DtoLibTransporte.Reportes.Caja.Movimiento.Filtro filtro)
        {
            return ServiceProv.Transporte_Reportes_Caja_Movimientos_GetLista(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Caja.Saldo.Ficha> 
            Transporte_Reportes_Caja_Saldo_Al(DtoLibTransporte.Reportes.Caja.Saldo.Filtro filtro)
        {
            return ServiceProv.Transporte_Reportes_Caja_Saldo_Al(filtro);
        }
    }
}