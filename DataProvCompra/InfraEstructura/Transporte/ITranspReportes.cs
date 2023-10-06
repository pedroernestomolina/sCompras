using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspReportes
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha>
            Transporte_Reportes_Compras_GeneralDoc_GetLista(OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha>
            Transporte_Reportes_Compras_Retenciones_GetLista(OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Filtro filtro);
        OOB.ResultadoEntidad< OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIva(string idDocCompra);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIslr(string idDocCompra);

        OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Ficha >
            Transporte_Reportes_Aliado_Anticipos_GetLista(OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Ficha>
            Transporte_Reportes_Aliado_PagoServ_GetLista(OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Filtro filtro);

        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.Planilla.Ficha>
            Transporte_Reportes_Aliado_Anticipos_Planilla(int idMov);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla.Ficha>
            Transporte_Reportes_Aliado_PagoServ_Planilla(int idMov);

        //CAJA
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha>
            Transporte_Reportes_Caja_Movimientos_GetLista(OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Caja.Saldo.Ficha>
            Transporte_Reportes_Caja_Saldo_Al(OOB.LibCompra.Transporte.Reportes.Caja.Saldo.Filtro filtro);
    }
}