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
                    auditorias.Add(audPorRet);
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
                    auditorias.Add(audPorRec);
                }
                var ficha = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Ficha()
                {
                    autoDocCompra = idDoc,
                    autoDocCxP = r01.Entidad.documento.autoCxp,
                    auditoria = auditorias,
                    proveedor = new OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular.Proveedor()
                    {
                        autoProv = r01.Entidad.documento.autoPrv,
                        montoDebito = r01.Entidad.documento.total,
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
    }
}