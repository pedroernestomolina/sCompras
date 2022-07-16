using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibCompra.Reportes.GeneralDocumentos.Ficha> Reportes_ComprasDocumento(OOB.LibCompra.Reportes.GeneralDocumentos.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Reportes.GeneralDocumentos.Ficha>();

            var filtroDto = new DtoLibCompra.Reportes.CompraDocumento.Filtro()
            {
                desde = filtro.desde,
                hasta = filtro.hasta,
                codSucursal = filtro.codSucursal,
                estatus = (DtoLibCompra.Reportes.Enumerados.EnumEstatus)filtro.estatus,
            };
            var r01 = MyData.Reportes_ComprasDocumento (filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Reportes.GeneralDocumentos.Ficha >();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.Reportes.GeneralDocumentos.Ficha()
                        {
                            documento = s.documento,
                            control= s.control,
                            EsAnulado = s.EsAnulado,
                            factorDoc = s.factorDoc,
                            fecha = s.fecha,
                            montoCargo = s.montoCargo,
                            montoDscto = s.montoDscto,
                            nombreDoc = s.nombreDoc,
                            provCiRif = s.provCiRif,
                            provNombre = s.provNombre,
                            renglones = s.renglones,
                            serieDoc = s.serieDoc,
                            signoDoc = s.signoDoc,
                            tipoDoc = s.tipoDoc,
                            total = s.total,
                            totalDivisa = s.totalDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Reportes.CompraporDepartamento.Ficha> Reportes_ComprasPorDepartamento(OOB.LibCompra.Reportes.CompraporDepartamento.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Reportes.CompraporDepartamento.Ficha>();

            var filtroDto = new DtoLibCompra.Reportes.CompraPorDepartamento.Filtro()
            {
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_ComprasPorDepartamento (filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Reportes.CompraporDepartamento.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.Reportes.CompraporDepartamento.Ficha()
                        {
                            autoDepartamento = s.autoDepartamento,
                            nombreDepartamento = s.nombreDepartamento,
                            nombreDoc = s.nombreDoc,
                            serieDoc = s.serieDoc,
                            signoDoc = s.signoDoc,
                            tipoDoc = s.tipoDoc,
                            total = s.total,
                            totalDivisa = s.totalDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Reportes.CompraporProducto.Ficha> Reportes_CompraPorProducto(OOB.LibCompra.Reportes.CompraporProducto.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Reportes.CompraporProducto.Ficha>();

            var filtroDto = new DtoLibCompra.Reportes.CompraPorProducto.Filtro()
            {
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_CompraPorProducto(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Reportes.CompraporProducto.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.Reportes.CompraporProducto.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            cantUnd = s.cantUnd,
                            codigoPrd = s.codigoPrd,
                            nombreDoc = s.nombreDoc,
                            nombrePrd = s.nombrePrd,
                            serieDoc = s.serieDoc,
                            signoDoc = s.signoDoc,
                            tipoDoc = s.tipoDoc,
                            total = s.total,
                            totalDivisa = s.totalDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Reportes.CompraPorProductoDetalle.Ficha> Reportes_CompraPorProductoDetalle(OOB.LibCompra.Reportes.CompraPorProductoDetalle.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Reportes.CompraPorProductoDetalle.Ficha>();

            var filtroDto = new DtoLibCompra.Reportes.CompraPorProductoDetalle.Filtro()
            {
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_CompraPorProductoDetalle (filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Reportes.CompraPorProductoDetalle.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.Reportes.CompraPorProductoDetalle.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            cantUnd = s.cantUnd,
                            codigoPrd = s.codigoPrd,
                            costoUnd = s.costoUnd,
                            documento = s.documento,
                            factor = s.factor,
                            fecha = s.fecha,
                            nombreDoc = s.nombreDoc,
                            nombrePrd = s.nombrePrd,
                            serieDoc = s.serieDoc,
                            signoDoc = s.signoDoc,
                            tipoDoc = s.tipoDoc,
                            total = s.total,
                            totalDivisa = s.totalDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}