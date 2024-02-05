using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    public interface IProveedor
    {
        OOB.ResultadoLista<OOB.LibCompra.Proveedor.Data.Ficha> Proveedor_GetLista(OOB.LibCompra.Proveedor.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCompra.Proveedor.Data.Ficha> Proveedor_GetFicha(string autoPrv);
        OOB.ResultadoAuto Proveedor_AgregarFicha(OOB.LibCompra.Proveedor.Agregar.Ficha ficha);
        OOB.Resultado Proveedor_EditarFicha(OOB.LibCompra.Proveedor.Editar.Ficha ficha);
        OOB.ResultadoLista<OOB.LibCompra.Proveedor.Documentos.Ficha> Proveedor_Documentos_GetLista(OOB.LibCompra.Proveedor.Documentos.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCompra.Proveedor.Articulos.Ficha> Proveedor_ArticulosComprados_GetLista(OOB.LibCompra.Proveedor.Articulos.Filtro filtro);
        OOB.Resultado Proveedor_ActivarFicha(OOB.LibCompra.Proveedor.ActivarInactivar.Ficha ficha);
        OOB.Resultado Proveedor_InactivarFicha(OOB.LibCompra.Proveedor.ActivarInactivar.Ficha ficha);
    }
}