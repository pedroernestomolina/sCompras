using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspReportes
    {
        //DOCUMENTOS
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.GeneralDoc.Ficha>
            Transporte_Reportes_Compras_GeneralDoc_GetLista(DtoLibTransporte.Reportes.Compras.GeneralDoc.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.Retencion.Ficha>
            Transporte_Reportes_Compras_Retenciones_GetLista(DtoLibTransporte.Reportes.Compras.Retencion.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIva(string idDocCompra);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIslr(string idDocCompra);

        //CAJA
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Caja.Movimiento.Ficha>
            Transporte_Reportes_Caja_Movimientos_GetLista(DtoLibTransporte.Reportes.Caja.Movimiento.Filtro filtro);

        //ALIADOS
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.Anticipo.General.Ficha>
            Transporte_Reportes_Aliado_Anticipos_GetLista(DtoLibTransporte.Reportes.Aliado.Anticipo.General.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.PagoServ.General.Ficha>
            Transporte_Reportes_Aliado_PagoServ_GetLista(DtoLibTransporte.Reportes.Aliado.PagoServ.General.Filtro filtro);

        //PLANILLAS
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.Anticipo.Planilla.Ficha>
            Transporte_Reportes_Aliado_Anticipos_Planilla(int idMov);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Ficha>
            Transporte_Reportes_Aliado_PagoServ_Planilla(int idMov);
    }
}