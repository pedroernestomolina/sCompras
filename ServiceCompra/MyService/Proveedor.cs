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

        public DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Lista.Resumen> Proveedor_GetLista(DtoLibCompra.Proveedor.Lista.Filtro filtro)
        {
            return ServiceProv.Proveedor_GetLista(filtro);
        }

        DtoLib.ResultadoEntidad<DtoLibCompra.Proveedor.Data.Ficha> IProveedor.Proveedor_GetFicha(string autoPrv)
        {
            return ServiceProv.Proveedor_GetFicha(autoPrv);
        }

        public DtoLib.ResultadoAuto Proveedor_AgregarFicha(DtoLibCompra.Proveedor.Agregar.Ficha ficha)
        {
            var fichaVal = new DtoLibCompra.Proveedor.Agregar.FichaValidar()
            {
                codigo = ficha.codigo,
                razonSocial = ficha.razonSocial,
            };
            var r01 = ServiceProv.Proveedor_AgregarFicha_Validar(fichaVal);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                return new DtoLib.ResultadoAuto()
                {
                    Auto = "",
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
            }
            return ServiceProv.Proveedor_AgregarFicha(ficha);
        }

        public DtoLib.Resultado Proveedor_EditarFicha(DtoLibCompra.Proveedor.Editar.Ficha ficha)
        {
            var fichaVal = new DtoLibCompra.Proveedor.Editar.FichaValidar()
            {
                codigo = ficha.codigo,
                razonSocial = ficha.razonSocial,
                autoId = ficha.autoPrv,
            };
            var r01 = ServiceProv.Proveedor_EditarFicha_Validar(fichaVal);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                return new DtoLib.ResultadoAuto()
                {
                    Auto = "",
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
            }
            return ServiceProv.Proveedor_EditarFicha(ficha);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Documento.Ficha> Proveedor_Documento_GetLista(DtoLibCompra.Proveedor.Documento.Filtro filtro)
        {
            return ServiceProv.Proveedor_Documento_GetLista(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Articulos.Ficha> Proveedor_CompraArticulos_GetLista(DtoLibCompra.Proveedor.Articulos.Filtro filtro)
        {
            return ServiceProv.Proveedor_CompraArticulos_GetLista(filtro);
        }

        public DtoLib.Resultado Proveedor_Activar(DtoLibCompra.Proveedor.ActivarInactivar.Ficha ficha)
        {
            return ServiceProv.Proveedor_Activar(ficha);
        }

        public DtoLib.Resultado Proveedor_Inactivar(DtoLibCompra.Proveedor.ActivarInactivar.Ficha ficha)
        {
            return ServiceProv.Proveedor_Inactivar(ficha);
        }

    }

}