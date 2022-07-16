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

        public OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha> Producto_GetLista(OOB.LibCompra.Producto.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha>();

            var filtroDto = new DtoLibCompra.Producto.Lista.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoGrupo = filtro.autoGrupo,
                autoMarca = filtro.autoMarca,
                autoProveedor = filtro.autoProveedor,
                cadena = filtro.cadena,
                MetodoBusqueda = (DtoLibCompra.Producto.Enumerados.EnumMetodoBusqueda)filtro.MetodoBusqueda,
            };
            var r01 = MyData.Producto_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Producto.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Producto.Data.Ficha()
                        {
                            auto = s.autoPrd,
                            codigo = s.codigoPrd,
                            descripcion = s.descripcionPrd,
                            empaqueCompra = s.empaqueCompraPrd,
                            contenidoCompra = s.contenidoEmpaquePrd,
                            departamento = s.nombreDepartamento,
                            grupo = s.nombreGrupo,
                            marca = s.nombreMarca,
                            referencia = s.referenciaPrd,
                            modelo = s.modeloPrd,
                            tasaIva = s.tasaIvaPrd,
                            nombreTasaIva = s.tasaIvaDescripcion,
                            estatus =  (OOB.LibCompra.Producto.Enumerados.EnumEstatus) s.estatusPrd,
                            origen = s.origenPrd,
                            categoria = s.categoriaPrd,
                            AdmPorDivisa = (OOB.LibCompra.Producto.Enumerados.EnumAdministradorPorDivisa) s.admPorDivisa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Producto.Data.Ficha> Producto_GetFicha(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Producto.Data.Ficha>();

            var r01 = MyData.Producto_GetFicha(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            
            var s = r01.Entidad;
            var id = new OOB.LibCompra.Producto.Data.Ficha()
                {
                    AdmPorDivisa = (OOB.LibCompra.Producto.Enumerados.EnumAdministradorPorDivisa)s.AdmPorDivisa,
                    auto = s.auto,
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoMarca = s.autoMarca,
                    autoSubGrupo= s.autoSubGrupo,
                    categoria = s.categoria,
                    codigo = s.codigo,
                    codigoDepartamento = s.codigoDepartamento,
                    codigoGrupo = s.codigoGrupo,
                    contenidoCompra = s.contenidoCompra,
                    decimales = s.decimales,
                    departamento = s.departamento,
                    descripcion = s.descripcion,
                    empaqueCompra = s.empaqueCompra,
                    estatus = (OOB.LibCompra.Producto.Enumerados.EnumEstatus)s.estatus,
                    grupo = s.grupo,
                    marca = s.marca,
                    modelo = s.modelo,
                    nombre = s.nombre,
                    nombreTasaIva = s.nombreTasaIva,
                    origen = s.origen,
                    referencia = s.referencia,
                    tasaIva = s.tasaIva,
                    autoTasa = s.autoTasa,
                    costo = s.costo,
                    costoDivisa = s.costoDivisa,
                    fechaUltCambio = s.fechaUltCambio,
                };
            rt.Entidad = id;

            return rt;
        }

        public OOB.ResultadoEntidad<string> Producto_GetCodigoRefProveedor(OOB.LibCompra.Producto.CodRefProveedor.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var filtroDto = new DtoLibCompra.Producto.CodigoRefProveedor.Filtro()
            {
                autoPrd = filtro.autoPrd,
                autoPrv = filtro.autoPrv,
            };
            var r01 = MyData.Producto_GetCodigoRefProveedor (filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Producto.Utilidad.Ficha> Producto_GetUtilidadPrecio(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Producto.Utilidad.Ficha>();

            var r01 = MyData.Producto_GetUtilidadPrecio(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Producto.Utilidad.Ficha()
            {
                admDivisa = s.admDivisa,
                auto = s.auto,
                contenido_1 = s.contenido_1,
                contenido_2 = s.contenido_2,
                contenido_3 = s.contenido_3,
                contenido_4 = s.contenido_4,
                contenido_5 = s.contenido_5,
                tasaIva = s.tasaIva,
                utilidad_1 = s.utilidad_1,
                utilidad_2 = s.utilidad_2,
                utilidad_3 = s.utilidad_3,
                utilidad_4 = s.utilidad_4,
                utilidad_5 = s.utilidad_5,
                precio_1 = s.precio_1,
                precio_2 = s.precio_2,
                precio_3 = s.precio_3,
                precio_4 = s.precio_4,
                precio_5 = s.precio_5,
                //
                contenido_may_1 = s.contenido_may_1,
                contenido_may_2 = s.contenido_may_2,
                utilidad_may_1 = s.utilidad_may_1,
                utilidad_may_2 = s.utilidad_may_2,
                precio_may_1 = s.precio_may_1,
                precio_may_2 = s.precio_may_2,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Producto_VerificaDepositoAsignado(OOB.LibCompra.Producto.VerificarDepositoAsignado.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibCompra.Producto.VerificarDepositoAsignado.Ficha()
            {
                autoPrd = ficha.autoPrd,
                autoDeposito = ficha.autoDeposito,
            };
            var r01 = MyData.Producto_VerificaDepositoAsignado(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
       }

    }

}