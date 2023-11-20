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
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.LibroSeniat.Ficha>
            Transporte_Reportes_Compras_LibroSeniat_GetLista(DtoLibTransporte.Reportes.Compras.LibroSeniat.Filtro filtro);

        //CAJA
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Caja.Movimiento.Ficha>
            Transporte_Reportes_Caja_Movimientos_GetLista(DtoLibTransporte.Reportes.Caja.Movimiento.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Caja.Saldo.Ficha>
            Transporte_Reportes_Caja_Saldo_Al(DtoLibTransporte.Reportes.Caja.Saldo.Filtro filtro);

        //ALIADOS
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.Anticipo.General.Ficha>
            Transporte_Reportes_Aliado_Anticipos_GetLista(DtoLibTransporte.Reportes.Aliado.Anticipo.General.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.PagoServ.General.Ficha>
            Transporte_Reportes_Aliado_PagoServ_GetLista(DtoLibTransporte.Reportes.Aliado.PagoServ.General.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Aliado.MovCaja.Ficha>
            Transporte_Reportes_Aliado_MovCaja_GetLista(DtoLibTransporte.Reportes.Aliado.MovCaja.Filtro filtro);

        //ALIDOS-PLANILLAS
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.Anticipo.Planilla.Ficha>
            Transporte_Reportes_Aliado_Anticipos_Planilla(int idMov);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla.Ficha>
            Transporte_Reportes_Aliado_PagoServ_Planilla(int idMov);

        //BENEFICIARIOS
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Beneficiario.Movimiento.Ficha>
            Transporte_Reportes_Beneficiario_Movimiento_GetLista(DtoLibTransporte.Reportes.Beneficiario.Movimiento.Fitro filtro);
        //BENEFICIARIO-PLANILLA
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Beneficiario.Planilla.Ficha>
            Transporte_Reportes_Beneficiario_Planilla(int idMov);

        //CXP
        DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Ficha>
            Transporte_Reportes_Cxp_Documentos_PagosEmitidos(DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Filtro filtro);
        //CXP-PLANILLA
        DtoLib.ResultadoEntidad<DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla.Ficha>
            Transporte_Reportes_Cxp_PagoEmitido_Planilla(string idMov);
    }
}