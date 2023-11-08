using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CompraGastoAliadoPagServ.Handlres.Generar
{
    public class Imp : Vistas.Generar.ICompraGasto
    {
        private decimal _factorCambio;
        private OOB.LibCompra.Empresa.Fiscal.Ficha _tasasFiscal;
        private OOB.LibCompra.Transporte.Documento.Agregar.DePagoAliado.ObtenerData.Ficha _pagoServ;
        private Vistas.Generar.IHndData _hndData;


        public Vistas.Generar.IHndData HndData { get { return _hndData; } }


        public Imp()
        {
            _factorCambio = 0m;
            _tasasFiscal = null;
            _pagoServ = null;
            _hndData = new Handlres.Generar.HndData();
        }


        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _tasasFiscal = null;
            _pagoServ = null;
            _hndData.Inicializa();
        }
        Vistas.Generar.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new Vistas.Generar.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool _abandonarIsOK;
        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }

        private bool _procesarIsOK;
        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
            _procesarIsOK = false;
            if (_hndData.Verificar())
            {
                var rp = Helpers.Msg.Procesar();
                if (rp)
                {
                    GuardarDoc();
                }
            }
        }


        private bool cargarData()
        {
            try
            {
                var r01 = Sistema.MyData.FechaServidor();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                _factorCambio = r02.Entidad;
                var r03 = Sistema.MyData.Empresa_GetTasas();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }
                _tasasFiscal = r03.Entidad;
                _hndData.CargarData();
                _hndData.setFechaServidor(r01.Entidad);

                var r04 = Sistema.MyData.Transporte_Documento_CompraGasto_ObtenerDato_PagoServAliado(11);
                _pagoServ = r04.Entidad;

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void GuardarDoc()
        {
            try
            {
                var _prv = (Utils.Buscar.Proveedor.Handler.data)_hndData.Proveedor.Get_Ficha;
                //
                var _fichaSistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "01",
                    TipoDoc = "COMPRAS",
                };
                var _sistDoc = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                //
                _fichaSistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "08",
                    TipoDoc = "COMPRAS",
                };
                var _sistDocRetIslr = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                //
                var _montoBase = 0m;
                var _montoNeto = _montoBase + _pagoServ.totalMonAct;
                var _montoImpuesto = 0m;
                var _subTotal = _montoNeto + _montoImpuesto;
                var _sucursal = (Utils.FiltrosCB.SinBusqueda.Sucursal.data)_hndData.Sucursal.GetItem;
                var _concepto = (Utils.FiltrosCB.ConBusqueda.Concepto.data)_hndData.Concepto.GetItem;
                var _aplicaTipoDoc = "";
                var _aplicaNumeroDoc = "";
                var _aplicaFechaDoc = new DateTime(2000, 01, 01);
                var _fechaRetencion = new DateTime(2000, 01, 01);
                //
                var ficha = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Ficha();
                ficha.documento = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Documento()
                {
                    aplicaCodTipoDoc = _aplicaTipoDoc,
                    aplicaFechaDoc = _aplicaFechaDoc,
                    aplicaNumeroDoc = _aplicaNumeroDoc,
                    autoProv = _prv.Ficha.autoId,
                    autoSucursal = _sucursal.id,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    ciRifProv = _prv.Ficha.ciRif,
                    codicionPagoDoc = "CONTADO",
                    codigoComprasConcepto = _concepto.codigo,
                    codigoProv = _prv.Ficha.codigo,
                    codigoSucursal = _sucursal.codigo,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    codTipoDoc = _sistDoc.Entidad.codigo,
                    comprobanteRetencionISLR = "",
                    comprobanteRetencionNro = "",
                    descComprasConcepto = _concepto.desc,
                    descSucursal = _sucursal.desc,
                    diasCreditoDoc = 0,
                    dirFiscalProv = _prv.Ficha.direccionFiscal,
                    estacionEquipo = Sistema.EquipoEstacion,
                    estatusFiscal = "1",
                    factorCambio = _pagoServ.tasaCambio,
                    fechaEmisDoc = _hndData.Get_FechaEmisionDoc,
                    fechaRetencion = _fechaRetencion,
                    fechaVencDoc = _hndData.Get_FechaEmisionDoc,
                    idComprasConcepto = int.Parse(_concepto.id),
                    moduloDoc = _sistDoc.Entidad.tipo,
                    montoBase = 0m,
                    montoBase1 = 0m,
                    montoBase2 = 0m,
                    montoBase3 = 0m,
                    montoDivisa = _pagoServ.totalMonDiv,
                    montoExento = _pagoServ.totalMonAct,
                    montoImpuesto = 0m,
                    montoImpuesto1 = 0m,
                    montoImpuesto2 = 0m,
                    montoImpuesto3 = 0m,
                    montoNeto = _montoNeto,
                    sustraendoRetISLR = _pagoServ.sustraendo,
                    montoRetISLR = _pagoServ.retencion,
                    totalRetISLR = _pagoServ.totalRetMonAct,
                    montoRetencionIva = 0m,
                    montoTotal = _pagoServ.totalMonAct,
                    nombreDoc = _sistDoc.Entidad.nombre,
                    nombreProv = _prv.Ficha.nombreRazonSocial,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                    notasDoc = _hndData.Get_Notas,
                    numeroControlDoc = _hndData.Get_NumeroControlDoc,
                    numeroDoc = _hndData.Get_NumeroDoc,
                    saldoPendiente = 0m,
                    siglasDoc = _sistDoc.Entidad.siglas,
                    signoDoc = _sistDoc.Entidad.signo,
                    subTotal = _subTotal,
                    subTotalImpuesto = _montoImpuesto,
                    subTotalNeto = _montoNeto,
                    tasaIva1 = _tasasFiscal.Tasa1,
                    tasaIva2 = _tasasFiscal.Tasa2,
                    tasaIva3 = _tasasFiscal.Tasa3,
                    tasaRetencionISLR = _pagoServ.tasaRet,
                    tasaRetencionIva = 0m,
                    telefonoProv = _prv.Ficha.identidad.telefono,
                    igtfMonto = 0m,
                    tipoDocumentoCompra = OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.enumerados.tipoDocumentoCompra.GASTO,
                    autoSistemaDocumento = _sistDoc.Entidad.autoId,
                    maquinafiscal = "",
                    SistDocRetIslrAuto = _sistDocRetIslr.Entidad.autoId,
                    SistDocRetIslrCodigo = _sistDocRetIslr.Entidad.codigo,
                    SistDocRetIslrNombre = _sistDocRetIslr.Entidad.nombre,
                    idPagoServAliado = _pagoServ.idPago,
                };
                ficha.documento.proveedor = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGastoAliado.Proveedor()
                {
                    autoProv = _prv.Ficha.autoId,
                    fechaEmiDoc = HndData.Get_FechaEmisionDoc,
                    montoDebito = _pagoServ.totalMonDiv,
                    montoCredito = _pagoServ.totalMonDiv,
                };
                var r01 = Sistema.MyData.Transporte_Documento_Agregar_CompraGrasto_DePagoAliadoServ(ficha);
                _procesarIsOK = true;
                Helpers.Msg.AgregarOk();
                if (_pagoServ.totalRetMonAct > 0m)
                {
                    PlanillaRetIslr(r01.Entidad.autoDocCompra);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void PlanillaRetIva(string autoDoc)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.RetIva.Imp();
            _rep.setIdDoc(autoDoc);
            _rep.Generar();
        }
        private void PlanillaRetIslr(string autoDoc)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.RetISLR.Imp();
            _rep.setIdDoc(autoDoc);
            _rep.Generar();
        }
    }
}