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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado> 
            Transporte_Documento_Agregar_CompraGrasto(DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha ficha)
        {
            var r01 = ServiceProv.Transporte_Documento_Agregar_CompraGrasto_Verificar(ficha);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado>();
                result.Result = DtoLib.Enumerados.EnumResult.isError;
                result.Mensaje = r01.Mensaje;
                return result;
            }
            return ServiceProv.Transporte_Documento_Agregar_CompraGrasto(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Anular.CompraGasto.GetData.Ficha> 
            Transporte_Documento_Anular_CompraGrasto_GetData(string autoDoc)
        {
            return ServiceProv.Transporte_Documento_Anular_CompraGrasto_GetData(autoDoc);
        }
        public DtoLib.Resultado 
            Transporte_Documento_Anular_CompraGrasto(DtoLibTransporte.Documento.Anular.CompraGasto.Anular.Ficha ficha)
        {
            var r01 = ServiceProv.Transporte_Documento_Anular_CompraGrasto_Verificar(ficha.autoDocCompra, ficha.autoDocCxP);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                var rt = new DtoLib.Resultado()
                {
                     Mensaje=r01.Mensaje,
                      Result= DtoLib.Enumerados.EnumResult.isError,
                };
                return rt;
            }
            return ServiceProv.Transporte_Documento_Anular_CompraGrasto(ficha);
        }
        public DtoLib.ResultadoLista<DtoLibTransporte.Documento.Concepto.Entidad.Ficha> 
            Transporte_Documento_Concepto_GetLista()
        {
            return ServiceProv.Transporte_Documento_Concepto_GetLista();
        }
        public DtoLib.ResultadoId 
            Transporte_Documento_Concepto_Agregar(DtoLibTransporte.Documento.Concepto.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_Documento_Concepto_Agregar(ficha);
        }
        public DtoLib.Resultado 
            Transporte_Documento_Concepto_Editar(DtoLibTransporte.Documento.Concepto.Editar.Ficha ficha)
        {
            return ServiceProv.Transporte_Documento_Concepto_Editar(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Concepto.Entidad.Ficha> 
            Transporte_Documento_Concepto_GetById(int id)
        {
            return ServiceProv.Transporte_Documento_Concepto_GetById(id);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Entidad.Ficha> 
            Transporte_Documento_Entidad_CompraGrasto_GetById(string autoDoc)
        {
            return ServiceProv.Transporte_Documento_Entidad_CompraGrasto_GetById(autoDoc);
        }


        //
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha> 
            Transporte_Documento_CompraGasto_ObtenerDato_PagoServAliado(int idPagoServ)
        {
            return ServiceProv.Transporte_Documento_CompraGasto_ObtenerDato_PagoServAliado(idPagoServ);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Resultado> 
            Transporte_Documento_Agregar_CompraGrasto_DePagoAliadoServ(DtoLibTransporte.Documento.Agregar.CompraGastoAliado.Ficha ficha)
        {
            return ServiceProv.Transporte_Documento_Agregar_CompraGrasto_DePagoAliadoServ(ficha);
        }
        public DtoLib.Resultado 
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_Verificar(string autoDoc)
        {
            return ServiceProv.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_Verificar(autoDoc);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Anular.CompraGastoAliado.GetData.Ficha> 
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_GetData(string autoDoc)
        {
            return ServiceProv.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_GetData(autoDoc);
        }
        public DtoLib.Resultado 
            Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ(DtoLibTransporte.Documento.Anular.CompraGastoAliado.Anular.Ficha ficha)
        {
            return ServiceProv.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ(ficha);
        }
        public DtoLib.ResultadoEntidad<bool>
            Transporte_Documento_ChequearSiEs_CompraGrasto_DePagoAliadoServ(string autoDoc)
        {
            return ServiceProv.Transporte_Documento_ChequearSiEs_CompraGrasto_DePagoAliadoServ(autoDoc);
        }
    }
}