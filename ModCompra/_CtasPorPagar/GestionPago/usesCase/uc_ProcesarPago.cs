using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.usesCase
{
    public class uc_ProcesarPago: __.UsesCase.GestionPago.IProcesarPago
    {
        public string Execute(
            __.Modelos.GestionPago.IModelo modelo, 
            IEnumerable<__.Modelos.GestionPagoDocumentos.IItemDesplegar> docDeudaConPago, 
            IEnumerable<__.Modelos.GestionPagoDocumentos.IItemDesplegar> docNCConPago 
            )
        {
            var rt = "";
            //
            try
            {
                var _montoRecibido = modelo.Get_Anticipos_MontoAUsar;
                _montoRecibido+= modelo.GetMontoPorMetPagoRecibido;
                _montoRecibido+= modelo.Get_DocSeleccionadosAPagar_PorNC_Monto;
                var _importe = modelo.Get_DocSeleccionadosAPagar_PorDeuda_Monto;
                var _guardarComoAnticipoProv = _montoRecibido - _importe;
                _guardarComoAnticipoProv = Math.Round(_guardarComoAnticipoProv, 3, MidpointRounding.AwayFromZero);
                var _montoRecibidoMonAct = _montoRecibido * modelo.GetFactorCambio;
                _montoRecibidoMonAct = Math.Round(_montoRecibidoMonAct, 2, MidpointRounding.AwayFromZero);
                var _importeMonAct = _importe * modelo.GetFactorCambio;
                _importeMonAct = Math.Round(_importeMonAct, 2, MidpointRounding.AwayFromZero);

                var _fichaSistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "01",
                    TipoDoc = "CXP",
                };
                var _sistDocPag = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                //
                var fichaOOB = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Ficha()
                {
                    Recibo = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataRecibo()
                    {
                        autoSistemaDoc = _sistDocPag.Entidad.autoId,
                        codSistemaDoc = _sistDocPag.Entidad.siglas,
                        importeDivisa = _importe,
                        importeMonAct = _importeMonAct ,
                        montoRecibidoDivisa = _montoRecibido,
                        montoRecibidoMonAct = _montoRecibidoMonAct ,
                        nota = "PAGO DOCUMENTOS VARIOS",
                        prvAuto = modelo.FichaGestion.Entidad.id,
                        prvCiRif = modelo.FichaGestion.Entidad.ciRif,
                        prvCodigo = modelo.FichaGestion.Entidad.codigo,
                        prvDirFiscal = modelo.FichaGestion.Entidad.dirFiscal,
                        prvNombre = modelo.FichaGestion.Entidad.nombreRazonSocial,
                        prvTlf = modelo.FichaGestion.Entidad.telefonos,
                        tasaCambio = modelo.GetFactorCambio,
                        usuarioAuto = Sistema.UsuarioP.autoUsu,
                        usuarioNombre = Sistema.UsuarioP.nombreUsu,
                        fechaEmision = DateTime.Now.Date,
                        guardarComoAnticipoProv = _guardarComoAnticipoProv,
                        anticipoUsado = modelo.Get_Anticipos_MontoAUsar,
                    },
                };
                //
                var lstDoc = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataReciboDoc>();
                foreach (var rg in docDeudaConPago)
                {
                    var s = (_CtasPorPagar.GestionPagoDocumentos.modelos.ItemDesplegar)rg;
                    var ndoc = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataReciboDoc()
                    {
                        autoCxpDoc = s.Ficha.idCxP,
                        codTipoDc = s.docTipo,
                        importeDivisa = s.MontoAAbonar,
                        numDoc = s.docNumero,
                    };
                    lstDoc.Add(ndoc);
                }
                foreach (var rg in docNCConPago)
                {
                    var s = (_CtasPorPagar.GestionPagoDocumentos.modelos.ItemDesplegar)rg;
                    var ndoc = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataReciboDoc()
                    {
                        autoCxpDoc = s.Ficha.idCxP,
                        codTipoDc = s.docTipo,
                        importeDivisa = s.MontoAAbonar,
                        numDoc = s.docNumero,
                    };
                    lstDoc.Add(ndoc);
                }
                fichaOOB.Recibo.reciboDoc = lstDoc;
                //
                var _lstMP = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataReciboMetodoPago>();
                foreach (var rg in modelo.MetodosPago)
                {
                    var it = (__.Modelos.PanelMetPagoAgregar.IItemAgregar)rg;
                    var nr = new OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataReciboMetodoPago()
                    {
                        autoMedPago = it.IdMedioPago,
                        autoUsuario = Sistema.UsuarioP.autoUsu,
                        codigoMedPago = it.CodigoMedioPago,
                        descMedPago = it.DescMedioPago,
                        OpAplicaConversion = it.AplicaFactor,
                        OpBanco = it.Banco ,
                        OpDetalle = it.DetalleOp ,
                        OpFecha = it.FechaOp ,
                        OpLote = it.Lote,
                        OpMonto = it.Monto,
                        OpNroCta = it.NroCta,
                        OpNroTransf = it.CheqRefTranf,
                        OpRef = it.Referencia,
                        OpTasa = it.FactorCambio,
                        montoAplicaDiv= it.MontoAplica
                    };
                    _lstMP.Add(nr);
                }
                fichaOOB.Recibo.metpago = _lstMP;
                //
                var _lstCaja = new List<OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.DataCaja>();
                //
                var r01 = Sistema.MyData.Transporte_CxpDoc_GestionPago_Agregar(fichaOOB);
                rt = r01.Entidad.autoRecibo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rt;
        }
    }
}