using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces
{
    
    public interface IDocumento
    {

        DtoLib.ResultadoAuto Compra_DocumentoAgregarFactura(DtoLibCompra.Documento.Agregar.Factura.Ficha docFac);
        DtoLib.ResultadoAuto Compra_DocumentoAgregarNC (DtoLibCompra.Documento.Agregar.NotaCredito.Ficha docNC);
        DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Cargar.Ficha> Compra_DocumentoGetFicha(string auto);
        DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Visualizar.Ficha> Compra_DocumentoVisualizar(string auto);
        DtoLib.ResultadoLista<DtoLibCompra.Documento.Lista.Resumen> Compra_DocumentoGetLista(DtoLibCompra.Documento.Lista.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaRemision.Ficha> Compra_DocumentoGetListaRemision(DtoLibCompra.Documento.ListaRemision.Filtro filtro);
        DtoLib.Resultado Compra_DocumentoAnularFactura(DtoLibCompra.Documento.Anular.Factura.Ficha ficha);
        DtoLib.Resultado Compra_DocumentoAnularNotaCredito(DtoLibCompra.Documento.Anular.NotaCredito.Ficha ficha);
        DtoLib.Resultado Compra_DocumentoCorrectorFactura(DtoLibCompra.Documento.Corrector.Factura.Ficha docFac);
        DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaItemImportar.Ficha> Compra_Documento_ItemImportar_GetLista(string autoDoc);
        DtoLib.Resultado Compra_Documento_Pendiente_Agregar(DtoLibCompra.Documento.Pendiente.Agregar.Ficha ficha);
        DtoLib.ResultadoEntidad<int> Compra_Documento_Pendiente_Cnt(DtoLibCompra.Documento.Pendiente.Filtro.Ficha filtro);
        DtoLib.ResultadoLista<DtoLibCompra.Documento.Pendiente.Lista.Ficha> Compra_Documento_Pendiente_GetLista(DtoLibCompra.Documento.Pendiente.Filtro.Ficha filtro);
        DtoLib.Resultado Compra_Documento_Pendiente_Eliminar(int idPend);
        DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Pendiente.Abrir.Ficha> Compra_Documento_Pendiente_Abrir(int idPend);

    }

}