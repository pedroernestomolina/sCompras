using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspDocumento
    {
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Resultado>
            Transporte_Documento_Agregar_CompraGrasto(OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Ficha ficha);
        
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.GetData.Ficha>
            Transporte_Documento_Anular_CompraGrasto_GetData(string autoDoc);
        OOB.Resultado
            Transporte_Documento_Anular_CompraGrasto(OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Ficha ficha);

        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Entidad.Ficha>
            Transporte_Documento_Entidad_CompraGrasto_GetById(string autoDoc);

        OOB.ResultadoLista<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetLista();
        OOB.ResultadoId
            Transporte_Documento_Concepto_Agregar(OOB.LibCompra.Transporte.Documento.Concepto.Agregar.Ficha ficha);
        OOB.Resultado
            Transporte_Documento_Concepto_Editar(OOB.LibCompra.Transporte.Documento.Concepto.Editar.Ficha ficha);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetById(int id);


        //
        //
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha>
            Transporte_Documento_CompraGasto_ObtenerDato_PagoServAliado(int idPagoServ);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Resultado>
            Transporte_Documento_Agregar_CompraGrasto_DePagoAliadoServ(OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Ficha ficha);
        OOB.Resultado 
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_Verificar(string autoDoc);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.GetData.Ficha>
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_GetData(string autoDoc);
    }
}