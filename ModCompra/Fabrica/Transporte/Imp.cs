using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Fabrica.Transporte
{
    public class Imp : IFabrica
    {
        public void Iniciar_FrmPrincipal(Gestion ctr)
        {
            srcTransporte.PantallaInicio.Frm frm = new srcTransporte.PantallaInicio.Frm();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }

        public OOB.Resultado
            AnularDocCompra_Factura(string idDoc, string motivo)
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
            AnularDocCompra_NotaDebito(string idDoc, string motivo)
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
            AnularDocCompra_NotaCredito(string idDoc, string motivo)
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
            var r01 = Sistema.MyData.Transporte_Documento_ChequearSiEs_CompraGrasto_DePagoAliadoServ(idDoc);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                var rt = new OOB.Resultado()
                {
                    Mensaje = r01.Mensaje,
                    Result = OOB.Enumerados.EnumResult.isError,
                };
                return rt;
            }
            if (r01.Entidad) //RETORNA TRUE EN CASO DE SER DOCUMENTO TIPO PAGO SERVICIO ALIADO
            {
                return AnularCompraDeAliadoPagoServ(idDoc, motivo);
            }
            else
            {
                return AnularCompraGasto(idDoc, motivo);
            }
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
        private OOB.Resultado
            AnularCompraDeAliadoPagoServ(string idDoc, string motivo)
        {
            var rt = new OOB.Resultado();
            try
            {
                var v01 = Sistema.MyData.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_Verificar(idDoc);
                //
                var v02 = Sistema.MyData.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ_GetData(idDoc);
                //
                var auditorias = new List<OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.Anular.Auditoria>();
                var audPorCompra = new OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.Anular.Auditoria()
                {
                    autoDoc = idDoc,
                    autoSistemaDocumento = v02.Entidad.documento.autoSistemaDoc,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    estacion = Sistema.EquipoEstacion,
                    ip = "",
                    motivo = motivo,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                };
                auditorias.Add(audPorCompra);
                var ficha = new OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.Anular.Ficha()
                {
                    idPagoServicio = v02.Entidad.documento.idTranspAliadoPagServ,
                    idRelCompraPago = v02.Entidad.documento.idRelPagServ,
                    autoDocCompra = idDoc,
                    auditoria = auditorias,
                    proveedor = new OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.Anular.Proveedor()
                    {
                        autoProv = v02.Entidad.documento.autoPrv,
                        montoDebito = v02.Entidad.documento.totalDivisa,
                        montoCredito = v02.Entidad.documento.totalDivisa,
                    },
                    docRetCompra = v02.Entidad.retencionDoc.Select(xr =>
                    {
                        var xnr = new OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.Anular.DocRetCompra()
                        {
                            autoDocRetCompra = xr.autoDocCompraRet,
                        };
                        return xnr;
                    }).ToList(),
                };
                //
                var v03 = Sistema.MyData.Transporte_Documento_Anular_CompraGrasto_DePagoAliadoServ(ficha);
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            return rt;
        }

        srcTransporte.CtaPagar.Tools.ToolsDoc.Vista.IToolDoc _toolDoc;
        public void ToolsCtasPorPagar()
        {
            if (_toolDoc == null)
            {
                _toolDoc = new srcTransporte.CtaPagar.Tools.ToolsDoc.Handler.ImpToolDoc();
            }
            _toolDoc.Inicializa();
            _toolDoc.Inicia();
        }
    }
}