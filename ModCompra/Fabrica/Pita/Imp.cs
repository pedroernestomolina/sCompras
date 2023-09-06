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
            try
            {
                var r01 = Sistema.MyData.Compra_DocumentoGetFicha(idDoc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r01.Mensaje);
                }
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
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public OOB.Resultado 
            AnularDocCompra_NotaDebito(string idDoc, string motivo)
        {
            throw new NotImplementedException();
        }
        public OOB.Resultado 
            AnularDocCompra_NotaCredito(string idDoc, string motivo)
        {
            var result = new OOB.Resultado();
            try
            {
                var r01 = Sistema.MyData.Compra_DocumentoGetFicha(idDoc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
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
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Enumerados.EnumResult.isError;
            }
            return result;
        }
    }
}