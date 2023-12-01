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
        public OOB.ResultadoLista<OOB.LibCompra.Proveedor.Data.Ficha> 
            Proveedor_GetLista(OOB.LibCompra.Proveedor.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Proveedor.Data.Ficha>();
            //
            var filtroDto = new DtoLibCompra.Proveedor.Lista.Filtro()
            {
                autoEstado = filtro.autoEstado,
                autoGrupo = filtro.autoGrupo,
                cadena = filtro.cadena,
                MetodoBusqueda = (DtoLibCompra.Proveedor.Enumerados.EnumMetodoBusqueda)filtro.MetodoBusqueda,
                estatus = (DtoLibCompra.Proveedor.Enumerados.EnumEstatus)filtro.estatus,
            };
            var r01 = MyData.Proveedor_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            var list = new List<OOB.LibCompra.Proveedor.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Proveedor.Data.Ficha();
                        var id = new OOB.LibCompra.Proveedor.Data.Identificacion()
                        {
                            auto = s.auto,
                            ciRif = s.ciRif,
                            codigo = s.codigo,
                            dirFiscal = s.dirFiscal,
                            estatus = (OOB.LibCompra.Proveedor.Enumerados.EnumEstatus)s.estatusPrv,
                            nombreContacto = s.nombreContacto,
                            nombreEstado = s.nombreEstado,
                            nombreGrupo = s.nombreGrupo,
                            nombreRazonSocial = s.nombreRazonSocial,
                            telefono = s.telefono,
                            fechaAlta = s.fechaAlta,
                            fechaUltCompra = s.fechaUltCompra,
                            fechaBaja = s.fechaBaja,
                        };
                        nr.identidad = id;
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;
            //
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Proveedor.Data.Ficha> 
            Proveedor_GetFicha(string autoPrv)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Proveedor.Data.Ficha>();
            //
            var r01 = MyData.Proveedor_GetFicha(autoPrv);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Proveedor.Data.Ficha();
            var id = new OOB.LibCompra.Proveedor.Data.Identificacion()
            {
                auto = s.autoId,
                autoEstado = s.autoEstado,
                autoGrupo = s.autoGrupo,
                ciRif = s.ciRif,
                codigo = s.codigo,
                dirFiscal = s.direccionFiscal,
                estatus = s.isActivo ? OOB.LibCompra.Proveedor.Enumerados.EnumEstatus.Activo : OOB.LibCompra.Proveedor.Enumerados.EnumEstatus.Inactivo,
                nombreContacto = s.nombreContacto,
                nombreEstado = s.nombreEstado,
                nombreGrupo = s.nombreGrupo,
                nombreRazonSocial = s.nombreRazonSocial,
                telefono = s.telefono,
                pais = s.pais,
                codigoPostal = s.codigoPostal,
                denominacionFiscal = s.denominacionFiscal,
                email = s.email,
                retIva = s.retIva,
                website = s.website,
                fechaAlta = s.fechaAlta,
                fechaUltCompra = s.fechaUltCompra,
                fechaBaja = s.fechaBaja,
                codXmlIslr = s.codXmlIslr,
                descXmlIslr = s.descXmlIslr,
            };
            nr.identidad = id;
            rt.Entidad = nr;
            //
            return rt;
        }
        public OOB.ResultadoAuto
            Proveedor_AgregarFicha(OOB.LibCompra.Proveedor.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();
            //
            var fichaDTO = new DtoLibCompra.Proveedor.Agregar.Ficha()
            {
                advertencia = ficha.advertencia,
                anticipos = ficha.anticipos,
                benficiarioCtaBanco = ficha.benficiarioCtaBanco,
                ciRif = ficha.ciRif,
                codigo = ficha.codigo,
                codPostal = ficha.codPostal,
                contacto = ficha.contacto,
                creditos = ficha.creditos,
                ctaBanco = ficha.ctaBanco,
                debitos = ficha.debitos,
                denFiscal = ficha.denFiscal,
                dirFiscal = ficha.dirFiscal,
                disponible = ficha.disponible,
                email = ficha.email,
                estatus = ficha.estatus,
                idCtaAnticipos = ficha.idCtaAnticipos,
                idCtaCobrar = ficha.idCtaCobrar,
                idCtaIngreso = ficha.idCtaIngreso,
                idEstado = ficha.idEstado,
                idGrupo = ficha.idGrupo,
                memo = ficha.memo,
                nj = ficha.nj,
                nombre = ficha.nombre,
                pais = ficha.pais,
                razonSocial = ficha.razonSocial,
                retISLR = ficha.retISLR,
                retIva = ficha.retIva,
                rif = ficha.rif,
                saldo = ficha.saldo,
                telefono = ficha.telefono,
                webSite = ficha.webSite,
                codXmlIslr = ficha.codXmlIslr,
                descXmlIslr = ficha.descXmlIslr,
            };
            var r01 = MyData.Proveedor_AgregarFicha(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            rt.Auto = r01.Auto;
            return rt;
        }
        public OOB.Resultado 
            Proveedor_EditarFicha(OOB.LibCompra.Proveedor.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibCompra.Proveedor.Editar.Ficha()
            {
                autoPrv=ficha.autoPrv,
                ciRif = ficha.ciRif,
                codigo = ficha.codigo,
                codPostal = ficha.codPostal,
                contacto = ficha.contacto,
                denFiscal = ficha.denFiscal,
                dirFiscal = ficha.dirFiscal,
                email = ficha.email,
                idEstado = ficha.idEstado,
                idGrupo = ficha.idGrupo,
                pais = ficha.pais,
                razonSocial = ficha.razonSocial,
                retIva = ficha.retIva,
                telefono = ficha.telefono,
                webSite = ficha.webSite,
                codXmlIslr=ficha.codXmlIslr,
                descXmlIslr = ficha.descXmlIslr
            };
            var r01 = MyData.Proveedor_EditarFicha(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            return rt;
        }
        public OOB.ResultadoLista<OOB.LibCompra.Proveedor.Documentos.Ficha> 
            Proveedor_Documentos_GetLista(OOB.LibCompra.Proveedor.Documentos.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Proveedor.Documentos.Ficha>();
            //
            var filtroDto = new DtoLibCompra.Proveedor.Documento.Filtro()
            {
                autoProv = filtro.autoProv,
                desde = filtro.desde,
                hasta = filtro.hasta,
                tipoDoc = (DtoLibCompra.Proveedor.Documento.Enumerados.enumTipoDoc)filtro.tipoDoc,
            };
            var r01 = MyData.Proveedor_Documento_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            var list = new List<OOB.LibCompra.Proveedor.Documentos.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var rg = new OOB.LibCompra.Proveedor.Documentos.Ficha()
                        {
                            codTipoDoc = s.codTipoDoc,
                            documento = s.documento,
                            estatus = s.estatus,
                            fecha = s.fecha,
                            monto = s.monto,
                            montoDivisa = s.montoDivisa,
                            serie = s.serie,
                            tasaDivisa = s.tasaDivisa,
                            nombreTipoDoc = s.nombreTipoDoc,
                            controlNro = s.controlNro,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.Lista = list;
            //
            return rt;
        }
        public OOB.ResultadoLista<OOB.LibCompra.Proveedor.Articulos.Ficha> 
            Proveedor_ArticulosComprados_GetLista(OOB.LibCompra.Proveedor.Articulos.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Proveedor.Articulos.Ficha>();
            //
            var filtroDto = new DtoLibCompra.Proveedor.Articulos.Filtro()
            {
                autoProv = filtro.autoProv,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Proveedor_CompraArticulos_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            var list = new List<OOB.LibCompra.Proveedor.Articulos.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var rg = new OOB.LibCompra.Proveedor.Articulos.Ficha()
                        {
                            cantidad = s.cantidad,
                            cantUnd = s.cantUnd,
                            codigoPrd = s.codigoPrd,
                            codTipoDoc = s.codTipoDoc,
                            nombreTipoDoc=s.nombreTipoDoc,
                            contenidoEmp = s.contenidoEmp,
                            costo= s.costo,
                            costoUnd = s.costoUnd,
                            documento = s.documento,
                            empaque = s.empaque,
                            estatus = s.estatus,
                            fecha = s.fecha,
                            nombrePrd = s.nombrePrd,
                            serie = s.serie,
                            signo = s.signo,
                            tasaCambio = s.tasaCambio,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.Lista = list;
            //
            return rt;
        }
        public OOB.Resultado 
            Proveedor_ActivarFicha(OOB.LibCompra.Proveedor.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibCompra.Proveedor.ActivarInactivar.Ficha()
            {
                id = ficha.id,
            };
            var r01 = MyData.Proveedor_Activar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            return rt;
        }
        public OOB.Resultado 
            Proveedor_InactivarFicha(OOB.LibCompra.Proveedor.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibCompra.Proveedor.ActivarInactivar.Ficha()
            {
                id = ficha.id,
            };
            var r01 = MyData.Proveedor_Inactivar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            return rt;
        }
    }
}