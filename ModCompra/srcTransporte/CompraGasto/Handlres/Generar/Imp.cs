using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CompraGasto.Handlres.Generar
{
    public class Imp: Vistas.Generar.ICompraGasto
    {
        private Vistas.Generar.Idata _data;


        public Vistas.Generar.Idata data { get { return _data; } }


        public Imp()
        {
            _data = new Handlres.Generar.data();
        }


        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _data.Inicializa();
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
            if (_data.Verificar()) 
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
                IEnumerable<LibUtilitis.Opcion.IData> _lTipoDoc;
                var _lstTipoDoc = new List<dataTipoDocumento>();
                _lstTipoDoc.Add(new dataTipoDocumento() { id = "01", codigo = "", desc = "FACTURA" });
                _lstTipoDoc.Add(new dataTipoDocumento() { id = "02", codigo = "", desc = "NOTA DEBITO" });
                _lstTipoDoc.Add(new dataTipoDocumento() { id = "03", codigo = "", desc = "NOTA CREDITO" });
                _lTipoDoc = _lstTipoDoc;

                IEnumerable<LibUtilitis.Opcion.IData> _lCondPagoDoc;
                var _lstCondPago = new List<dataCondicionPagoDoc>();
                _lstCondPago.Add(new dataCondicionPagoDoc() { id = "01", codigo = "", desc = "CONTADO" });
                _lstCondPago.Add(new dataCondicionPagoDoc() { id = "02", codigo = "", desc = "CREDITO" });
                _lCondPagoDoc = _lstCondPago;

                IEnumerable<LibUtilitis.Opcion.IData> _lAplicaTipoDoc;
                var _lstAplicaTipoDoc = new List<dataTipoDocumento>();
                _lstAplicaTipoDoc.Add(new dataTipoDocumento() { id = "01", codigo = "", desc = "FACTURA" });
                _lstAplicaTipoDoc.Add(new dataTipoDocumento() { id = "02", codigo = "", desc = "NOTA DEBITO" });
                _lAplicaTipoDoc = _lstAplicaTipoDoc;

                //
                var r01 = Sistema.MyData.Sucursal_GetLista();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                { 
                    throw new Exception(r01.Mensaje);
                }
                var r02 = Sistema.MyData.Transporte_Documento_Concepto_GetLista();
                var r03 = Sistema.MyData.FechaServidor ();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                { 
                    throw new Exception(r03.Mensaje);
                }
                var r04 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r04.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r04.Mensaje);
                }
                var r05 = Sistema.MyData.Empresa_GetTasas();
                if (r05.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r05.Mensaje);
                }
                //
                _data.TipoDocumentoCargarData(_lTipoDoc);
                _data.AplicaTipoDocumentoCargarData(_lAplicaTipoDoc);
                _data.CondicionPagoDocCargarData(_lCondPagoDoc);
                _data.SucursalCargarData(r01.Lista);
                _data.ConceptoCargarData(r02.Lista);
                _data.FechaServidorCargar(r03.Entidad);
                _data.SetFactorCambio(r04.Entidad);
                _data.Tasa1.SetTasa(r05.Entidad.Tasa1);
                _data.Tasa2.SetTasa(r05.Entidad.Tasa2);
                _data.Tasa3.SetTasa(r05.Entidad.Tasa3);
                _data.TasaEx.SetTasa(0m);
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
                var _prv = (Utils.Buscar.Proveedor.Handler.data) _data.Proveedor.Get_Ficha;
                var _fichaSistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = _data.Get_TipoDocumento_ID,
                    TipoDoc = "COMPRAS",
                };
                var _sistDoc = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                //
                _fichaSistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "02",
                    TipoDoc = "CXP",
                };
                var _sistDocCxp = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                //
                _fichaSistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "07",
                    TipoDoc = "COMPRAS",
                };
                var _sistDocRetIva = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                //
                _fichaSistDoc = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = "08",
                    TipoDoc = "COMPRAS",
                };
                var _sistDocRetIslr = Sistema.MyData.SistemaDocumento_Get(_fichaSistDoc);
                var _montoBase= _data.Tasa1.Get_Base+_data.Tasa2.Get_Base+_data.Tasa3.Get_Base;
                var _montoNeto= _montoBase+_data.TasaEx.Get_Base;
                var _montoImpuesto=_data.Tasa1.Get_Imp+_data.Tasa2.Get_Imp+_data.Tasa3.Get_Imp;
                var _subTotal= _montoNeto+_montoImpuesto;
                var _sucursal = (dataSucursal)_data.Get_Sucursal_Ficha;
                var _concepto= (dataConcepto)_data.Get_Concepto_Ficha;
                var _aplicaTipoDoc ="";
                var _aplicaNumeroDoc = "";
                var _aplicaFechaDoc = new DateTime(2000,01,01);
                var _fechaRetencion = new DateTime(2000,01,01);
                if (_data.AplicaActivo) 
                {
                    _aplicaTipoDoc = _data.Get_AplicaTipoDocumento_ID;
                    _aplicaFechaDoc = _data.Get_Aplica_FechaDoc;
                    _aplicaNumeroDoc = _data.Get_Aplica_NumeroDoc;
                }
                var _acumulado = _data.Get_MontoRetIva + _data.Get_MontoRetISLR;
                var _resta = _data.Get_MontoMonAct - _acumulado;
                var _acumuladoDiv= 0m;
                var _restaDiv= 0m;
                if (_data.Get_FactorCambio>0m)
                {
                    _acumuladoDiv = _acumulado / _data.Get_FactorCambio;
                    _restaDiv = _resta / _data.Get_FactorCambio;
                }
                //
                var ficha = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Ficha();
                ficha.documento = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Documento()
                {
                    aplicaCodTipoDoc = _aplicaTipoDoc,
                    aplicaFechaDoc = _aplicaFechaDoc,
                    aplicaNumeroDoc = _aplicaNumeroDoc,
                    autoProv = _prv.Ficha.autoId,
                    autoSucursal = _sucursal.ficha.auto,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    ciRifProv = _prv.Ficha.ciRif,
                    codicionPagoDoc = _data.Get_CondicionPago_ID == "01" ? "CONTADO" : "CREDITO",
                    codigoComprasConcepto = _concepto.ficha.codigo,
                    codigoProv = _prv.Ficha.codigo,
                    codigoSucursal = _sucursal.ficha.codigo,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    codTipoDoc = _sistDoc.Entidad.codigo,
                    comprobanteRetencionISLR = "",
                    comprobanteRetencionNro = "",
                    descComprasConcepto = _concepto.ficha.descripcion,
                    descSucursal = _sucursal.ficha.nombre,
                    diasCreditoDoc = _data.Get_DiasCreditoDoc,
                    dirFiscalProv = _prv.Ficha.direccionFiscal,
                    estacionEquipo = Sistema.EquipoEstacion,
                    estatusFiscal = _data.Get_IncluirLibroCompras ? "1" : "0",
                    factorCambio = _data.Get_FactorCambio,
                    fechaEmisDoc = _data.Get_FechaEmisionDoc,
                    fechaRetencion = _fechaRetencion,
                    fechaVencDoc = _data.Get_FechaVenceDoc,
                    idComprasConcepto = _concepto.ficha.id,
                    moduloDoc = _sistDoc.Entidad.tipo,
                    montoBase = _montoBase,
                    montoBase1 = _data.Tasa1.Get_Base,
                    montoBase2 = _data.Tasa2.Get_Base,
                    montoBase3 = _data.Tasa3.Get_Base,
                    montoDivisa = _data.Get_MontoMonDivisa,
                    montoExento = _data.TasaEx.Get_Base,
                    montoImpuesto = _montoImpuesto,
                    montoImpuesto1 = _data.Tasa1.Get_Imp,
                    montoImpuesto2 = _data.Tasa2.Get_Imp,
                    montoImpuesto3 = _data.Tasa3.Get_Imp,
                    montoNeto = _montoNeto,
                    sustraendoRetISLR = _data.Get_SustraendoISLR,
                    montoRetISLR = _data.Get_MontoRetISLR,
                    totalRetISLR = (_data.Get_SustraendoISLR + _data.Get_MontoRetISLR),
                    montoRetencionIva = _data.Get_MontoRetIva,
                    montoTotal = _data.Get_MontoMonAct,
                    nombreDoc = _sistDoc.Entidad.nombre,
                    nombreProv = _prv.Ficha.nombreRazonSocial,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                    notasDoc = _data.Get_Notas,
                    numeroControlDoc = _data.Get_NumeroControlDoc,
                    numeroDoc = _data.Get_NumeroDoc,
                    saldoPendiente = _data.Get_MontoMonAct,
                    siglasDoc = _sistDoc.Entidad.siglas,
                    signoDoc = _sistDoc.Entidad.signo,
                    subTotal = _subTotal,
                    subTotalImpuesto = _montoImpuesto,
                    subTotalNeto = _montoNeto,
                    tasaIva1 = _data.Tasa1.Get_Tasa,
                    tasaIva2 = _data.Tasa2.Get_Tasa,
                    tasaIva3 = _data.Tasa3.Get_Tasa,
                    tasaRetencionISLR = _data.Get_TasaRetISLR,
                    tasaRetencionIva = _data.Get_TasaRetIva,
                    telefonoProv = _prv.Ficha.identidad.telefono,
                    igtfMonto = _data.Get_MontoIGTF,
                    tipoDocumentoCompra = OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.enumerados.tipoDocumentoCompra.GASTO,
                    autoSistemaDocumento= _sistDoc.Entidad.autoId,
                };
                ficha.cxp = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.CxP()
                {
                    acumulado = _acumulado,
                    acumuladoDivisa = _acumuladoDiv,
                    autoProveedor = _prv.Ficha.autoId,
                    ciRifProveedor = _prv.Ficha.ciRif,
                    codigoProveedor = _prv.Ficha.codigo,
                    diasCredito = _data.Get_DiasCreditoDoc,
                    documentoNro = _data.Get_NumeroDoc,
                    fechaEmision = _data.Get_FechaEmisionDoc,
                    fechaVencimiento = _data.Get_FechaVenceDoc,
                    importe = _data.Get_MontoMonAct,
                    importeDivisa = _data.Get_MontoMonDivisa,
                    nombreRazonSocialProveedor = _prv.Ficha.nombreRazonSocial,
                    resta = _resta,
                    restaDivisa = _restaDiv,
                    siglasTipoDocumento = _sistDocCxp.Entidad.siglas,
                    signoTipoDocumento = _sistDocCxp.Entidad.signo,
                    tasaDivisa = _data.Get_FactorCambio,
                    notas ="",
                    autoSistemaDoc = _sistDocCxp.Entidad.autoId
                };
                if (_data.Get_MontoRetIva > 0m)
                {
                    var _montoRetIvaDivisa = _data.Get_MontoRetIva / _data.Get_FactorCambio;
                    ficha.retIva = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.CxP()
                    {
                        acumulado = 0m,
                        acumuladoDivisa = 0m,
                        autoProveedor = _prv.Ficha.autoId,
                        ciRifProveedor = _prv.Ficha.ciRif,
                        codigoProveedor = _prv.Ficha.codigo,
                        diasCredito = 0,
                        documentoNro = _data.Get_NumeroDoc,
                        fechaEmision = _data.Get_FechaEmisionDoc,
                        fechaVencimiento = _data.Get_FechaVenceDoc,
                        importe = _data.Get_MontoRetIva,
                        importeDivisa = _montoRetIvaDivisa,
                        nombreRazonSocialProveedor = _prv.Ficha.nombreRazonSocial,
                        resta = 0m,
                        restaDivisa = 0m,
                        siglasTipoDocumento = _sistDocRetIva.Entidad.siglas,
                        signoTipoDocumento = _sistDocRetIva.Entidad.signo*(-1),
                        tasaDivisa = _data.Get_FactorCambio,
                        notas = "RETENCION IVA "+_data.Get_TasaRetIva.ToString("n2")+"%, DOC: "+_data.Get_NumeroDoc,
                        autoSistemaDoc = _sistDocRetIva.Entidad.autoId,
                    };
                    ficha.recIva = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Recibo()
                    {
                        documento = _sistDocRetIva.Entidad.siglas,
                        importe = _data.Get_MontoRetIva,
                        importeDivisa = _montoRetIvaDivisa,
                        montoRecibido = _data.Get_MontoRetIva,
                        montoRecibidoDivisa = _montoRetIvaDivisa,
                        nota = "RETENCION IVA " + _data.Get_TasaRetIva.ToString("n2") + "%, DOC: " + _data.Get_NumeroDoc,
                        prvAuto = _prv.Ficha.autoId,
                        prvCiRif = _prv.Ficha.ciRif,
                        prvCodigo = _prv.Ficha.codigo,
                        prvDirFiscal = _prv.Ficha.direccionFiscal,
                        prvNombre = _prv.Ficha.nombreRazonSocial,
                        prvTlf = _prv.Ficha.identidad.telefono,
                        tasaCambio = _data.Get_FactorCambio,
                        usuarioAuto = Sistema.UsuarioP.autoUsu,
                        usuarioNombre = Sistema.UsuarioP.nombreUsu,
                        autoSistemaDoc = _sistDocRetIva.Entidad.autoId,
                        docRecibo = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.DocumentoRecibo()
                        {
                            importe = _data.Get_MontoRetIva,
                            numDocumentoAfecta = _data.Get_NumeroDoc,
                            siglasDocumentoAfecta = _sistDoc.Entidad.siglas,
                            tipoOperacionRealizar = "Abono",
                        }
                    };
                }
                if (_data.Get_MontoRetISLR > 0m)
                {
                    var _montoRetISLRDivisa = _data.Get_MontoRetISLR / _data.Get_FactorCambio;
                    ficha.retISLR = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.CxP()
                    {
                        acumulado = 0m,
                        acumuladoDivisa = 0m,
                        autoProveedor = _prv.Ficha.autoId,
                        ciRifProveedor = _prv.Ficha.ciRif,
                        codigoProveedor = _prv.Ficha.codigo,
                        diasCredito = 0,
                        documentoNro = _data.Get_NumeroDoc,
                        fechaEmision = _data.Get_FechaEmisionDoc,
                        fechaVencimiento = _data.Get_FechaVenceDoc,
                        importe = _data.Get_MontoRetISLR,
                        importeDivisa = _montoRetISLRDivisa,
                        nombreRazonSocialProveedor = _prv.Ficha.nombreRazonSocial,
                        resta = 0m,
                        restaDivisa = 0m,
                        siglasTipoDocumento = _sistDocRetIslr.Entidad.siglas,
                        signoTipoDocumento = _sistDocRetIslr.Entidad.signo * (-1),
                        tasaDivisa = _data.Get_FactorCambio,
                        notas = "RETENCION ISLR " + _data.Get_TasaRetISLR.ToString("n2") + "%, DOC: " + _data.Get_NumeroDoc,
                        autoSistemaDoc = _sistDocRetIslr.Entidad.autoId,
                    };
                    ficha.recISLR = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Recibo()
                    {
                        documento = _sistDocRetIslr.Entidad.siglas,
                        importe = _data.Get_MontoRetISLR,
                        importeDivisa = _montoRetISLRDivisa,
                        montoRecibido = _data.Get_MontoRetISLR,
                        montoRecibidoDivisa = _montoRetISLRDivisa,
                        nota = "RETENCION ISLR " + _data.Get_TasaRetISLR.ToString("n2") + "%, DOC: " + _data.Get_NumeroDoc,
                        prvAuto = _prv.Ficha.autoId,
                        prvCiRif = _prv.Ficha.ciRif,
                        prvCodigo = _prv.Ficha.codigo,
                        prvDirFiscal = _prv.Ficha.direccionFiscal,
                        prvNombre = _prv.Ficha.nombreRazonSocial,
                        prvTlf = _prv.Ficha.identidad.telefono,
                        tasaCambio = _data.Get_FactorCambio,
                        usuarioAuto = Sistema.UsuarioP.autoUsu,
                        usuarioNombre = Sistema.UsuarioP.nombreUsu,
                        autoSistemaDoc = _sistDocRetIslr.Entidad.autoId,
                        docRecibo = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.DocumentoRecibo()
                        {
                            importe = _data.Get_MontoRetISLR,
                            numDocumentoAfecta = _data.Get_NumeroDoc,
                            siglasDocumentoAfecta = _sistDoc.Entidad.siglas,
                            tipoOperacionRealizar = "Abono",
                        }
                    };
                }
                ficha.proveedor = new OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Proveedor()
                {
                    autoProv = _prv.Ficha.autoId,
                    fechaEmiDoc = _data.Get_FechaEmisionDoc,
                    montoDebito = _data.Get_MontoMonDivisa,
                };
                var r01 = Sistema.MyData.Transporte_Documento_Agregar_CompraGrasto(ficha);
                _procesarIsOK = true;
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}