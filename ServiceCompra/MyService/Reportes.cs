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

        public DtoLib.ResultadoLista<DtoLibCompra.Reportes.CompraPorDepartamento.Ficha> Reportes_ComprasPorDepartamento(DtoLibCompra.Reportes.CompraPorDepartamento.Filtro filtro)
        {
            return ServiceProv.Reportes_ComprasPorDepartamento(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Reportes.CompraDocumento.Ficha> Reportes_ComprasDocumento(DtoLibCompra.Reportes.CompraDocumento.Filtro filtro)
        {
            return ServiceProv.Reportes_ComprasDocumento(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Reportes.CompraPorProductoDetalle.Ficha> Reportes_CompraPorProductoDetalle(DtoLibCompra.Reportes.CompraPorProductoDetalle.Filtro filtro)
        {
            return ServiceProv.Reportes_CompraPorProductoDetalle(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCompra.Reportes.CompraPorProducto.Ficha> Reportes_CompraPorProducto(DtoLibCompra.Reportes.CompraPorProducto.Filtro filtro)
        {
            return ServiceProv.Reportes_CompraPorProducto(filtro);
        }

    }

}