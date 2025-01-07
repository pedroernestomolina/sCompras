using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    public interface IDocumento
    {
        OOB.ResultadoAuto Compra_DocumentoAgregarFactura(OOB.LibCompra.Documento.Cargar.Factura.Ficha docFac);
        OOB.ResultadoAuto Compra_DocumentoAgregarNC(OOB.LibCompra.Documento.Agregar.NotaCredito.Ficha docNC);
        OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.Ficha> Compra_DocumentoGetFicha(string auto);
        OOB.ResultadoEntidad<OOB.LibCompra.Documento.Visualizar.Ficha> Compra_DocumentoVisualizar(string auto);
        OOB.ResultadoLista<OOB.LibCompra.Documento.Lista.Ficha> Compra_DocumentoGetLista(OOB.LibCompra.Documento.Lista.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCompra.Documento.ListaRemision.Ficha> Compra_DocumentoGetListaRemision(OOB.LibCompra.Documento.ListaRemision.Filtro filtro);
        OOB.Resultado Compra_DocumentoAnularFactura(OOB.LibCompra.Documento.Anular.Factura.Ficha ficha);
        OOB.Resultado Compra_DocumentoAnularNotaCredito(OOB.LibCompra.Documento.Anular.NotaCredito.Ficha ficha);
        OOB.Resultado Compra_DocumentoCorrector(OOB.LibCompra.Documento.Corrector.Ficha ficha);
        OOB.ResultadoLista<OOB.LibCompra.Documento.ListaItemImportar.Ficha> Compra_Documento_ItemImportar_GetLista(string autoDoc);
        OOB.Resultado Compra_Documento_Pendiente_Agregar(OOB.LibCompra.Documento.Pendiente.Agregar.Ficha ficha);
        OOB.ResultadoEntidad<int> Compra_Documento_Pendiente_Cnt (OOB.LibCompra.Documento.Pendiente.Filtro.Ficha filtro);
        OOB.ResultadoLista<OOB.LibCompra.Documento.Pendiente.Lista.Ficha> Compra_Documento_Pendiente_GetLista(OOB.LibCompra.Documento.Pendiente.Filtro.Ficha filtro);
        OOB.Resultado Compra_Documento_Pendiente_Eliminar(int idDoc);
        OOB.ResultadoEntidad<OOB.LibCompra.Documento.Pendiente.Abrir.Ficha> Compra_Documento_Pendiente_Abrir_GetById(int idDoc);
        //
        OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.AplicarRetencion.Ficha> 
            Compra_GetData_AplicarRetencion(string idDocCompra);
    }
}