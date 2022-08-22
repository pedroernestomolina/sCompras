using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{

    public partial class DataProv : IData
    {

        public OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha>
            Producto_GetLista(OOB.LibCompra.Producto.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha>();

            var filtroDto = new DtoLibCompra.Producto.Lista.Filtro()
            {
                autoDeposito= filtro.autoDeposito,
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
                            estatus = (OOB.LibCompra.Producto.Enumerados.EnumEstatus)s.estatusPrd,
                            origen = s.origenPrd,
                            categoria = s.categoriaPrd,
                            AdmPorDivisa = (OOB.LibCompra.Producto.Enumerados.EnumAdministradorPorDivisa)s.admPorDivisa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Producto.Data.Ficha>
            Producto_GetFicha(string autoPrd)
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
                    autoSubGrupo = s.autoSubGrupo,
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
        public OOB.ResultadoEntidad<string>
            Producto_GetCodigoRefProveedor(OOB.LibCompra.Producto.CodRefProveedor.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var filtroDto = new DtoLibCompra.Producto.CodigoRefProveedor.Filtro()
            {
                autoPrd = filtro.autoPrd,
                autoPrv = filtro.autoPrv,
            };
            var r01 = MyData.Producto_GetCodigoRefProveedor(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Producto.Utilidad.Ficha>
            Producto_GetUtilidadPrecio(string auto)
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
        public OOB.Resultado
            Producto_VerificaDepositoAsignado(OOB.LibCompra.Producto.VerificarDepositoAsignado.Ficha ficha)
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
        public OOB.ResultadoLista<OOB.LibCompra.Producto.EmpaqueMedida.Lista.Ficha>
            Producto_EmpaqueMedida_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Producto.EmpaqueMedida.Lista.Ficha>();

            var r01 = MyData.Producto_EmpaqueMedida_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var lst = new List<OOB.LibCompra.Producto.EmpaqueMedida.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Producto.EmpaqueMedida.Lista.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Producto.Precio.Capturar.Ficha>
            Producto_Precio_GetCapturar_ById(string idPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Producto.Precio.Capturar.Ficha>();

            var r01 = MyData.Producto_Precio_GetCapturar_ById(idPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var id = new OOB.LibCompra.Producto.Precio.Capturar.Ficha()
            {
                idEmp1_1 = s.idEmp1_1,
                idEmp1_2 = s.idEmp1_2,
                idEmp1_3 = s.idEmp1_3,
                idEmp1_4 = s.idEmp1_4,
                idEmp1_5 = s.idEmp1_5,
                contEmp1_1 = s.contEmp1_1,
                contEmp1_2 = s.contEmp1_2,
                contEmp1_3 = s.contEmp1_3,
                contEmp1_4 = s.contEmp1_4,
                contEmp1_5 = s.contEmp1_5,
                utEmp1_1 = s.utEmp1_1,
                utEmp1_2 = s.utEmp1_2,
                utEmp1_3 = s.utEmp1_3,
                utEmp1_4 = s.utEmp1_4,
                utEmp1_5 = s.utEmp1_5,
                pnEmp1_1 = s.pnEmp1_1,
                pnEmp1_2 = s.pnEmp1_2,
                pnEmp1_3 = s.pnEmp1_3,
                pnEmp1_4 = s.pnEmp1_4,
                pnEmp1_5 = s.pnEmp1_5,
                pfdEmp1_1 = s.pfdEmp1_1,
                pfdEmp1_2 = s.pfdEmp1_2,
                pfdEmp1_3 = s.pfdEmp1_3,
                pfdEmp1_4 = s.pfdEmp1_4,
                pfdEmp1_5 = s.pfdEmp1_5,
                //
                idEmp2_1 = s.idEmp2_1,
                idEmp2_2 = s.idEmp2_2,
                idEmp2_3 = s.idEmp2_3,
                idEmp2_4 = s.idEmp2_4,
                idEmp2_5 = s.idEmp2_5,
                contEmp2_1 = s.contEmp2_1,
                contEmp2_2 = s.contEmp2_2,
                contEmp2_3 = s.contEmp2_3,
                contEmp2_4 = s.contEmp2_4,
                contEmp2_5 = s.contEmp2_5,
                utEmp2_1 = s.utEmp2_1,
                utEmp2_2 = s.utEmp2_2,
                utEmp2_3 = s.utEmp2_3,
                utEmp2_4 = s.utEmp2_4,
                utEmp2_5 = s.utEmp2_5,
                pnEmp2_1 = s.pnEmp2_1,
                pnEmp2_2 = s.pnEmp2_2,
                pnEmp2_3 = s.pnEmp2_3,
                pnEmp2_4 = s.pnEmp2_4,
                pnEmp2_5 = s.pnEmp2_5,
                pfdEmp2_1 = s.pfdEmp2_1,
                pfdEmp2_2 = s.pfdEmp2_2,
                pfdEmp2_3 = s.pfdEmp2_3,
                pfdEmp2_4 = s.pfdEmp2_4,
                pfdEmp2_5 = s.pfdEmp2_5,
                //
                idEmp3_1 = s.idEmp3_1,
                idEmp3_2 = s.idEmp3_2,
                idEmp3_3 = s.idEmp3_3,
                idEmp3_4 = s.idEmp3_4,
                idEmp3_5 = s.idEmp3_5,
                contEmp3_1 = s.contEmp3_1,
                contEmp3_2 = s.contEmp3_2,
                contEmp3_3 = s.contEmp3_3,
                contEmp3_4 = s.contEmp3_4,
                contEmp3_5 = s.contEmp3_5,
                utEmp3_1 = s.utEmp3_1,
                utEmp3_2 = s.utEmp3_2,
                utEmp3_3 = s.utEmp3_3,
                utEmp3_4 = s.utEmp3_4,
                utEmp3_5 = s.utEmp3_5,
                pnEmp3_1 = s.pnEmp3_1,
                pnEmp3_2 = s.pnEmp3_2,
                pnEmp3_3 = s.pnEmp3_3,
                pnEmp3_4 = s.pnEmp3_4,
                pnEmp3_5 = s.pnEmp3_5,
                pfdEmp3_1 = s.pfdEmp3_1,
                pfdEmp3_2 = s.pfdEmp3_2,
                pfdEmp3_3 = s.pfdEmp3_3,
                pfdEmp3_4 = s.pfdEmp3_4,
                pfdEmp3_5 = s.pfdEmp3_5,
            };
            rt.Entidad = id;

            return rt;
        }

    }

}