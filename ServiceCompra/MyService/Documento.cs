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

        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Visualizar.Ficha> Compra_DocumentoVisualizar(string auto)
        {
            return ServiceProv.Compra_DocumentoVisualizar(auto);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Documento.Lista.Resumen> Compra_DocumentoGetLista(DtoLibCompra.Documento.Lista.Filtro filtro)
        {
            return ServiceProv.Compra_DocumentoGetLista(filtro);
        }

        public DtoLib.Resultado Compra_DocumentoAnularFactura(DtoLibCompra.Documento.Anular.Factura.Ficha ficha)
        {
            var r01 = ServiceProv.Compra_DocumentoAnular_Verificar(ficha.autoDocumento);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                return r01;
            return ServiceProv.Compra_DocumentoAnularFactura(ficha);
        }

        public DtoLib.ResultadoAuto Compra_DocumentoAgregarFactura(DtoLibCompra.Documento.Agregar.Factura.Ficha docFac)
        {
            var r01 = ServiceProv.Compra_DocumentoAgregar_Verificar(docFac.documento.documentoNro, docFac.documento.controlNro, docFac.documento.autoProveedor);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                var rt = new DtoLib.ResultadoAuto()
                {
                    Auto = "",
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
                return rt;
            }
            return ServiceProv.Compra_DocumentoAgregarFactura(docFac);
        }

        public DtoLib.ResultadoAuto Compra_DocumentoAgregarNC(DtoLibCompra.Documento.Agregar.NotaCredito.Ficha docNC)
        {
            var r01 = ServiceProv.Compra_DocumentoAgregar_Verificar(docNC.documento.documentoNro, docNC.documento.controlNro, docNC.documento.autoProveedor);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                var rt = new DtoLib.ResultadoAuto()
                {
                    Auto = "",
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
                return rt;
            }
            return ServiceProv.Compra_DocumentoAgregarNotaCredito(docNC);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaRemision.Ficha> Compra_DocumentoGetListaRemision(DtoLibCompra.Documento.ListaRemision.Filtro filtro)
        {
            return ServiceProv.Compra_DocumentoGetListaRemision(filtro);
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Cargar.Ficha> Compra_DocumentoGetFicha(string auto)
        {
            return ServiceProv.Compra_DocumentoGetFicha(auto);
        }

        public DtoLib.Resultado Compra_DocumentoCorrectorFactura(DtoLibCompra.Documento.Corrector.Factura.Ficha docFac)
        {
            var r01 = ServiceProv.Compra_DocumentoCorrector_Verificar(docFac.documentoNro, docFac.controlNro, docFac.autoProveedor,docFac.autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                return r01;
            return ServiceProv.Compra_DocumentoCorrectorFactura(docFac);
        }

        public DtoLib.Resultado Compra_DocumentoAnularNotaCredito(DtoLibCompra.Documento.Anular.NotaCredito.Ficha ficha)
        {
            var r01 = ServiceProv.Compra_DocumentoAnular_Verificar(ficha.autoDocumento);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                return r01;
            return ServiceProv.Compra_DocumentoAnularNotaCredito(ficha);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaItemImportar.Ficha> Compra_Documento_ItemImportar_GetLista(string autoDoc)
        {
            return ServiceProv.Compra_Documento_ItemImportar_GetLista(autoDoc);
        }

        public DtoLib.Resultado Compra_Documento_Pendiente_Agregar(DtoLibCompra.Documento.Pendiente.Agregar.Ficha ficha)
        {
            return ServiceProv.Compra_Documento_Pendiente_Agregar(ficha);
        }

        public DtoLib.ResultadoEntidad<int> Compra_Documento_Pendiente_Cnt(DtoLibCompra.Documento.Pendiente.Filtro.Ficha filtro)
        {
            return ServiceProv.Compra_Documento_Pendiente_Cnt(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Documento.Pendiente.Lista.Ficha> Compra_Documento_Pendiente_GetLista(DtoLibCompra.Documento.Pendiente.Filtro.Ficha filtro)
        {
            return ServiceProv.Compra_Documento_Pendiente_GetLista(filtro);
        }

        public DtoLib.Resultado Compra_Documento_Pendiente_Eliminar(int idPend)
        {
            return ServiceProv.Compra_Documento_Pendiente_Eliminar(idPend);
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Pendiente.Abrir.Ficha> Compra_Documento_Pendiente_Abrir(int idPend)
        {
            return ServiceProv.Compra_Documento_Pendiente_Abrir(idPend);
        }

    }

}