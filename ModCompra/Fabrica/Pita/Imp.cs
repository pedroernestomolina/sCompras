using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Fabrica.Pita
{
    public class Imp: IFabrica
    {
        public void Iniciar_FrmPrincipal(Gestion ctr)
        {
            src.PantallaInicio.Frm frm = new src.PantallaInicio.Frm();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
        public OOB.Resultado 
            AnularDocCompra_Factura(string idDoc, string motivo)
        {
            var result = new OOB.Resultado();
            //
            try
            {
                var r01 = Sistema.MyData.Compra_DocumentoGetFicha(idDoc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad.EstatusDocTipoMercancia)
                {
                    var ficha = new OOB.LibCompra.Documento.Anular.Factura.Ficha()
                    {
                        autoDocumento = idDoc,
                        codigoDocumento = r01.Entidad.documentoTipo,
                        autoSistemaDocumento = "0000000019",
                        autoUsuario = Sistema.UsuarioP.autoUsu,
                        codigoUsuario = Sistema.UsuarioP.codigoUsu,
                        estacion = Environment.MachineName,
                        motivo = motivo,
                        nombreUsuario = Sistema.UsuarioP.nombreUsu,
                    };
                    var r02 = Sistema.MyData.Compra_DocumentoAnularFactura(ficha);
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r02.Mensaje);
                    }
                    //
                    return result;
                }
                else 
                {
                    return AnularDocCompra_Factura_GASTO(idDoc, motivo);
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }
        }
        public OOB.Resultado 
            AnularDocCompra_NotaDebito(string idDoc, string motivo)
        {
            var result = new OOB.Resultado();
            try
            {
                var r01 = Sistema.MyData.Compra_DocumentoGetFicha(idDoc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad.EstatusDocTipoMercancia)
                {
                    return result;
                }
                else
                {
                    return AnularDocCompra_NotaDebito_GASTO(idDoc, motivo);
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }
        }
        public OOB.Resultado 
            AnularDocCompra_NotaCredito(string idDoc, string motivo)
        {
            var result = new OOB.Resultado();
            //
            try
            {
                var r01 = Sistema.MyData.Compra_DocumentoGetFicha(idDoc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad.EstatusDocTipoMercancia)
                {
                    var ficha = new OOB.LibCompra.Documento.Anular.NotaCredito.Ficha()
                    {
                        autoDocumento = idDoc,
                        codigoDocumento = r01.Entidad.documentoTipo,
                        autoSistemaDocumento = "0000000019",
                        autoUsuario = Sistema.UsuarioP.autoUsu,
                        codigoUsuario = Sistema.UsuarioP.codigoUsu,
                        estacion = Environment.MachineName,
                        motivo = motivo,
                        nombreUsuario = Sistema.UsuarioP.nombreUsu,
                    };
                    var r02 = Sistema.MyData.Compra_DocumentoAnularNotaCredito(ficha);
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r02.Mensaje);
                    }
                    //
                    return result;
                }
                else 
                {
                    return AnularDocCompra_NotaCredito_GASTO(idDoc, motivo);
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }
        }

        //

        public OOB.Resultado
            AnularDocCompra_Factura_GASTO(string idDoc, string motivo)
        {
            var rt = new OOB.Resultado();
            try
            {
                var r00 = Sistema.MyData.Transporte_Documento_Entidad_CompraGrasto_GetById(idDoc);
                if (r00.Entidad.documento.docTipoDocCompra == "2") //GASTO
                {
                    rt = anularGasto(idDoc, motivo);
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            return rt;
        }
        public OOB.Resultado
            AnularDocCompra_NotaDebito_GASTO(string idDoc, string motivo)
        {
            var rt = new OOB.Resultado();
            try
            {
                var r00 = Sistema.MyData.Transporte_Documento_Entidad_CompraGrasto_GetById(idDoc);
                if (r00.Entidad.documento.docTipoDocCompra == "2") //GASTO
                {
                    rt = anularGasto(idDoc, motivo);
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            return rt;
        }
        public OOB.Resultado
            AnularDocCompra_NotaCredito_GASTO(string idDoc, string motivo)
        {
            var rt = new OOB.Resultado();
            try
            {
                var r00 = Sistema.MyData.Transporte_Documento_Entidad_CompraGrasto_GetById(idDoc);
                if (r00.Entidad.documento.docTipoDocCompra == "2") //GASTO
                {
                    rt = anularGasto(idDoc, motivo);
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            return rt;
        }


        private OOB.Resultado
            anularGasto(string idDoc, string motivo)
        {
            return AnularCompraGasto(idDoc, motivo);
        }
        private OOB.Resultado
            AnularCompraGasto(string idDoc, string motivo)
        {
            var rt = new OOB.Resultado();
            try
            {
                var r01 = Sistema.MyData.Transporte_Documento_Anular_CompraGrasto_GetData(idDoc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad == null )
                {
                    throw new Exception("DATA NO CARGADA");
                }
                if (r01.Entidad.retencionRecibo != null) 
                {
                    if (r01.Entidad.retencionRecibo.Count > 0)
                    {
                        throw new Exception("DOCUMENTO TIENE ( PAGOS / RETENCIONES ) RELACIONADOS");
                    }
                }
                var auditorias = new List<OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Auditoria>();
                var audPorCompra = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Auditoria()
                {
                    autoDoc = idDoc,
                    autoSistemaDocumento = r01.Entidad.documento.autoSistemaDoc,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    estacion = Sistema.EquipoEstacion,
                    ip = "",
                    motivo = motivo,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                };
                auditorias.Add(audPorCompra);
                var audPorCxp = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Auditoria()
                {
                    autoDoc = r01.Entidad.documento.autoCxp,
                    autoSistemaDocumento = r01.Entidad.documento.autoSistemaDocCxp,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    estacion = Sistema.EquipoEstacion,
                    ip = "",
                    motivo = "ANULADO AL ANULAR DOCUMENTO DE COMPRA DE REF: " + r01.Entidad.documento.documento,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                };
                auditorias.Add(audPorCxp);
                foreach (var rg in r01.Entidad.retencionRecibo)
                {
                    var audPorRet = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Auditoria()
                    {
                        autoDoc = rg.autoCxp,
                        autoSistemaDocumento = rg.autoSistDocCxp,
                        autoUsuario = Sistema.UsuarioP.autoUsu,
                        codigoUsuario = Sistema.UsuarioP.codigoUsu,
                        estacion = Sistema.EquipoEstacion,
                        ip = "",
                        motivo = "ANULADO AL ANULAR DOCUMENTO DE COMPRA DE REF: " + r01.Entidad.documento.documento,
                        nombreUsuario = Sistema.UsuarioP.nombreUsu,
                    };
                    //auditorias.Add(audPorRet);
                    //
                    var audPorRec = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Auditoria()
                    {
                        autoDoc = rg.autoRecibo,
                        autoSistemaDocumento = rg.autoSistDocRec,
                        autoUsuario = Sistema.UsuarioP.autoUsu,
                        codigoUsuario = Sistema.UsuarioP.codigoUsu,
                        estacion = Sistema.EquipoEstacion,
                        ip = "",
                        motivo = "ANULADO AL ANULAR DOCUMENTO DE COMPRA DE REF: " + r01.Entidad.documento.documento,
                        nombreUsuario = Sistema.UsuarioP.nombreUsu,
                    };
                    //auditorias.Add(audPorRec);
                }
                var ficha = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Ficha()
                {
                    autoDocCompra = idDoc,
                    autoDocCxP = r01.Entidad.documento.autoCxp,
                    auditoria = auditorias,
                    proveedor = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Proveedor()
                    {
                        autoProv = r01.Entidad.documento.autoPrv,
                        montoDebito = r01.Entidad.documento.importeDiv,
                        montoCredito = r01.Entidad.documento.acumuladoDiv,
                    },
                    retenciones = r01.Entidad.retencionRecibo.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Retencion()
                        {
                            autoCxP = s.autoCxp,
                            autoRecibo = s.autoRecibo,
                        };
                        return nr;
                    }).ToList(),
                    docRetCompra = r01.Entidad.retencionDoc.Select(xr =>
                    {
                        var xnr = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.DocRetCompra()
                        {
                            autoDocRetCompra = xr.autoDocCompraRet,
                        };
                        return xnr;
                    }).ToList(),
                };
                var r02 = Sistema.MyData.Transporte_Documento_Anular_CompraGrasto(ficha);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            return rt;
        }


        _CtasPorPagar.__.Interfaces.PanelPrincipal.IPanel _toolsCtasPorPagar;
        public void ToolsCtasPorPagar()
        {
            if (_toolsCtasPorPagar == null)
            {
                _toolsCtasPorPagar = new _CtasPorPagar.PanelPrincipal._Inicio.handlers.hndPanelPrincipal();
            }
            _toolsCtasPorPagar.Inicializa();
            _toolsCtasPorPagar.Inicia();
        }
    }
}