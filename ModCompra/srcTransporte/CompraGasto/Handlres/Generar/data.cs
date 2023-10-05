using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CompraGasto.Handlres.Generar
{
    public class data : Vistas.Generar.Idata
    {
        private string _numeroDoc;
        private string _numeroControlDoc;
        private int _diasCredito;
        private DateTime _fechaEmisionDoc;
        private LibUtilitis.CtrlCB.ICtrl _tipoDoc;
        private LibUtilitis.CtrlCB.ICtrl _condicionPagoDoc;
        //
        private bool _incluirLibroCompra;
        private string _notas;
        private LibUtilitis.CtrlCB.ICtrl _sucursal;
        private LibUtilitis.CtrlCB.ICtrl _concepto;
        //
        private Utils.Buscar.Proveedor.Vistas.IProveedor _proveedor;
        //
        private LibUtilitis.CtrlCB.ICtrl _aplicaTipoDoc;
        private DateTime _aplicaFechaDoc;
        private string _aplicaNumeroDoc;
        //
        private DateTime _fechaServidor;
        //
        private decimal _factorCambio;
        private Vistas.Generar.IdataFiscal _tasa1;
        private Vistas.Generar.IdataFiscal _tasa2;
        private Vistas.Generar.IdataFiscal _tasa3;
        private Vistas.Generar.IdataFiscal _tasaEx;
        private decimal _monto;
        private decimal _montoMonAct;
        private decimal _montoMonDivisa;
        private decimal _montoIGTF;
        //
        private decimal _tasaRetIva;
        private decimal _montoRetIva;
        private decimal _tasaRetISLR;
        private decimal _montoRetISLR;
        private decimal _montoSustraendoISLR;


        public string Get_NumeroDoc { get { return _numeroDoc; } }
        public string Get_NumeroControlDoc { get { return _numeroControlDoc; } }
        public int Get_DiasCreditoDoc { get { return _diasCredito; } }
        public DateTime Get_FechaEmisionDoc { get { return _fechaEmisionDoc; } }
        public DateTime Get_FechaVenceDoc { get { return _fechaEmisionDoc.AddDays(_diasCredito); } }
        public BindingSource Get_TipoDocumento_Source { get { return _tipoDoc.GetSource; } }
        public BindingSource Get_CondicionPago_Source { get { return _condicionPagoDoc.GetSource; } }
        public string Get_TipoDocumento_ID { get { return _tipoDoc.GetId; } }
        public string Get_CondicionPago_ID { get { return _condicionPagoDoc.GetId; } }
        //
        public BindingSource Get_Sucursal_Source { get { return _sucursal.GetSource; } }
        public BindingSource Get_Concepto_Source { get { return _concepto.GetSource; } }
        public string Get_Sucursal_ID { get { return _sucursal.GetId; } }
        public string Get_Concepto_ID { get { return _concepto.GetId; } }
        public bool Get_IncluirLibroCompras { get { return _incluirLibroCompra; } }
        public string Get_Notas { get { return _notas; } }
        //
        public Utils.Buscar.Proveedor.Vistas.IProveedor Proveedor { get { return _proveedor; } }
        //
        public bool AplicaActivo { get { return verificaTipoDoc(); } }
        public string Get_Aplica_NumeroDoc { get { return _aplicaNumeroDoc; } }
        public DateTime Get_Aplica_FechaDoc { get { return _aplicaFechaDoc; } }
        //
        public decimal Get_FactorCambio { get { return _factorCambio; } }
        public Vistas.Generar.IdataFiscal Tasa1 { get { return _tasa1; } }
        public Vistas.Generar.IdataFiscal Tasa2 { get { return _tasa2; } }
        public Vistas.Generar.IdataFiscal Tasa3 { get { return _tasa3; } }
        public Vistas.Generar.IdataFiscal TasaEx { get { return _tasaEx; } }
        public decimal Get_SubtotalNeto { get { return _tasa1.Get_Base + _tasa2.Get_Base + _tasa3.Get_Base + _tasaEx.Get_Base; } }
        public decimal Get_SubtotalBase { get { return _tasa1.Get_Base + _tasa2.Get_Base + _tasa3.Get_Base; } }
        public decimal Get_SubtotalImp { get { return _tasa1.Get_Imp + _tasa2.Get_Imp + _tasa3.Get_Imp; } }
        public decimal Get_Monto
        {
            get
            {
                _monto = (_tasa1.Get_Base + _tasa2.Get_Base + _tasa3.Get_Base) +
                        (_tasa1.Get_Imp + _tasa2.Get_Imp + _tasa3.Get_Imp) +
                        _tasaEx.Get_Base;
                _montoMonAct = _monto + _montoIGTF;
                _montoMonDivisa = 0m;
                if (_factorCambio > 0m)
                {
                    _montoMonDivisa = _montoMonAct / _factorCambio;
                }
                return _monto;
            }
        }
        public decimal Get_MontoMonAct { get { return _montoMonAct; } }
        public decimal Get_MontoMonDivisa { get { return _montoMonDivisa; } }
        public decimal Get_MontoIGTF { get { return _montoIGTF; } }
        //
        public decimal Get_TasaRetIva { get { return _tasaRetIva; } }
        public decimal Get_MontoRetIva { get { return _montoRetIva; } }
        public decimal Get_TasaRetISLR { get { return _tasaRetISLR; } }
        public decimal Get_MontoRetISLR { get { return _montoRetISLR; } }
        public decimal Get_SustraendoISLR { get { return _montoSustraendoISLR; } }


        public data()
        {
            _numeroDoc = "";
            _numeroControlDoc = "";
            _diasCredito = 0;
            _fechaEmisionDoc = DateTime.Now.Date;
            _tipoDoc = new LibUtilitis.CtrlCB.ImpCB();
            _condicionPagoDoc = new LibUtilitis.CtrlCB.ImpCB();
            //
            _incluirLibroCompra = false;
            _notas = "";
            _concepto = new LibUtilitis.CtrlCB.ImpCB();
            _sucursal = new LibUtilitis.CtrlCB.ImpCB();
            //
            _proveedor = new Utils.Buscar.Proveedor.Handler.Imp();
            //
            _aplicaTipoDoc = new LibUtilitis.CtrlCB.ImpCB();
            _aplicaFechaDoc = DateTime.Now.Date;
            _aplicaNumeroDoc = "";
            //
            _monto = 0m;
            _montoMonAct = 0m;
            _montoMonDivisa = 0m;
            _factorCambio = 0m;
            _montoIGTF = 0m;
            _tasa1 = new dataFiscal();
            _tasa2 = new dataFiscal();
            _tasa3 = new dataFiscal();
            _tasaEx = new dataFiscal();
            //
            _tasaRetIva = 0m;
            _montoRetIva = 0m;
            _tasaRetISLR = 0m;
            _montoRetISLR = 0m;
            _montoSustraendoISLR = 0m;
        }
        public void Inicializa()
        {
            _numeroDoc = "";
            _numeroControlDoc = "";
            _diasCredito = 0;
            _fechaEmisionDoc = DateTime.Now.Date;
            _tipoDoc.Inicializa();
            _condicionPagoDoc.Inicializa();
            //
            _incluirLibroCompra = false;
            _notas = "";
            _concepto.Inicializa();
            _sucursal.Inicializa();
            //
            _proveedor.Inicializa();
            //
            _aplicaTipoDoc.Inicializa();
            _aplicaFechaDoc = DateTime.Now.Date;
            _aplicaNumeroDoc = "";
            //
            _monto = 0m;
            _montoMonAct = 0m;
            _montoMonDivisa = 0m;
            _montoIGTF = 0m;
            _tasa1.Inicializa();
            _tasa2.Inicializa();
            _tasa3.Inicializa();
            _tasaEx.Inicializa();
            //
            _tasaRetIva = 0m;
            _montoRetIva = 0m;
            _tasaRetISLR = 0m;
            _montoRetISLR = 0m;
            _montoSustraendoISLR = 0m;
        }


        public void SetTipoDocumentoById(string id)
        {
            _tipoDoc.setFichaById(id);
            if (id == "01") //FACTURA
            {
                _aplicaFechaDoc = DateTime.Now.Date;
                _aplicaNumeroDoc = "";
            }
        }
        public void SetCondicionPagoById(string id)
        {
            _condicionPagoDoc.setFichaById(id);
        }
        public void TipoDocumentoCargarData(IEnumerable<LibUtilitis.Opcion.IData> lst)
        {
            _tipoDoc.CargarData(lst);
        }
        public void CondicionPagoDocCargarData(IEnumerable<LibUtilitis.Opcion.IData> lst)
        {
            _condicionPagoDoc.CargarData(lst);
        }
        public void SetNumeroDoc(string numero)
        {
            _numeroDoc = numero;
        }
        public void SetNumeroControlDoc(string control)
        {
            _numeroControlDoc = control;
        }
        public void SetFechaEmisionDoc(DateTime fecha)
        {
            _fechaEmisionDoc = fecha;
        }
        public void SetDiasCreditoDoc(int dias)
        {
            _diasCredito = dias;
        }
        //
        public void SetSucursalById(string id)
        {
            _sucursal.setFichaById(id);
        }
        public void SetConceptoById(string id)
        {
            _concepto.setFichaById(id);
        }
        public void SetIncluirLibroCompras()
        {
            _incluirLibroCompra = !_incluirLibroCompra;
            if (!_incluirLibroCompra)
            {
                SetTasaRetISLR(0m);
                SetMontoSustraendoISLR(0m);
                SetTasaRetIva(0m);
            }
        }
        public void SetNotasDoc(string notas)
        {
            _notas = notas;
        }
        public void SucursalCargarData(List<OOB.LibCompra.Sucursal.Data.Ficha> lst)
        {
            IEnumerable<LibUtilitis.Opcion.IData> _lst;
            var lSuc = new List<dataSucursal>();
            foreach (var rg in lst)
            {
                lSuc.Add(new dataSucursal() { codigo = rg.codigo, desc = rg.nombre, id = rg.auto, ficha = rg });
            }
            _lst = lSuc;
            _sucursal.CargarData(_lst);
        }
        private List<dataConcepto> lConcepto;
        public void ConceptoCargarData(List<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha> lst)
        {
            if (lConcepto == null)
            {
                lConcepto = new List<dataConcepto>();
            }
            lConcepto.Clear();
            IEnumerable<LibUtilitis.Opcion.IData> _lst;
            foreach (var rg in lst)
            {
                lConcepto.Add(new dataConcepto() { codigo = rg.codigo, desc = rg.descripcion, id = rg.id.ToString(), ficha = rg });
            }
            _lst = lConcepto;
            _concepto.CargarData(_lst);
        }


        private bool verificaTipoDoc()
        {
            var rt = false;
            if (_tipoDoc != null)
            {
                if (_tipoDoc.GetItem != null && _tipoDoc.GetId != "01")
                {
                    rt = true;
                }
            }
            return rt;
        }


        public BindingSource Get_AplicaTipoDocumento_Source { get { return _aplicaTipoDoc.GetSource; } }
        public string Get_AplicaTipoDocumento_ID { get { return _aplicaTipoDoc.GetId; } }
        public void AplicaTipoDocumentoCargarData(IEnumerable<LibUtilitis.Opcion.IData> lst)
        {
            _aplicaTipoDoc.CargarData(lst);
        }
        public void SetAplicaTipoDocumentoById(string id)
        {
            _aplicaTipoDoc.setFichaById(id);
        }
        public void SetAplicaNumeroDoc(string numero)
        {
            _aplicaNumeroDoc = numero;
        }
        public void SetAplicaFechaDoc(DateTime fecha)
        {
            _aplicaFechaDoc = fecha;
        }


        public bool Get_FechaEmisionDocIsOk
        {
            get { return _fechaEmisionDoc > _fechaServidor; }
        }
        public bool Get_FechaAplicaDocIsOk
        {
            get { return _aplicaFechaDoc > _fechaEmisionDoc; }
        }
        public void FechaServidorCargar(DateTime fecha)
        {
            _fechaServidor = fecha;
        }


        public void SetFactorCambio(decimal factor)
        {
            _factorCambio = factor;
        }
        public void SetMontoIGTF(decimal monto)
        {
            _montoIGTF = monto;
        }
        public void SetTasaRetIva(decimal tasa)
        {
            _tasaRetIva = tasa;
            ActualizarRetencion_Iva_ISLR();
        }
        public void SetTasaRetISLR(decimal tasa)
        {
            _tasaRetISLR = tasa;
            ActualizarRetencion_Iva_ISLR();
        }


        public bool Verificar()
        {
            var rt = true;
            if (_tipoDoc.GetItem == null)
            {
                Helpers.Msg.Alerta("TIPO DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (Get_NumeroDoc.Trim() == "")
            {
                Helpers.Msg.Alerta("NUMERO DE DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (Get_NumeroControlDoc.Trim() == "")
            {
                Helpers.Msg.Alerta("NUMERO DE CONTROL DEL DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (!Get_FechaEmisionDocIsValida)
            {
                Helpers.Msg.Alerta("FECHA DE EMISION DEL DOCUMENTO INCORRECTA");
                return false;
            }
            if (_condicionPagoDoc.GetItem == null)
            {
                Helpers.Msg.Alerta("CONDICION DE PAGO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (AplicaActivo)
            {
                if (_aplicaTipoDoc.GetItem == null)
                {
                    Helpers.Msg.Alerta("TIPO DOCUMENTO APLICA NO PUEDE ESTAR VACIO");
                    return false;
                }
                if (_tipoDoc.GetId == _aplicaTipoDoc.GetId)
                {
                    Helpers.Msg.Alerta("TIPO DOCUMENTO APLICA INCORRECTO");
                    return false;
                }
                if (_aplicaNumeroDoc.Trim() == "")
                {
                    Helpers.Msg.Alerta("NUMERO DOCUMENTO QUE APLICA NO PUEDE ESTAR VACIO");
                    return false;
                }
                if (_aplicaFechaDoc > _fechaEmisionDoc)
                {
                    Helpers.Msg.Alerta("FECHA DOCUMENTO APLICA INCORRECTO");
                    return false;
                }
            }
            if (_proveedor.Get_Ficha == null)
            {
                Helpers.Msg.Alerta("PROVEEDOR NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_sucursal.GetItem == null)
            {
                Helpers.Msg.Alerta("SUCURSAL NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_concepto.GetItem == null)
            {
                Helpers.Msg.Alerta("CONCEPTO DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_notas.Trim() == "")
            {
                Helpers.Msg.Alerta("NOTAS DEL DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_montoMonAct == 0m)
            {
                Helpers.Msg.Alerta("MONTO DEL DOCUMENTO INCORRECTO");
                return false;
            }
            return rt;
        }
        public bool Get_FechaEmisionDocIsValida { get { return _fechaEmisionDoc <= _fechaServidor; } }
        //
        public object Get_Sucursal_Ficha { get { return _sucursal.GetItem; } }
        public object Get_Concepto_Ficha { get { return _concepto.GetItem; } }


        public void BuscarProveedor()
        {
            _proveedor.Buscar();
            if (_proveedor.ProveedorIsOk)
            {
                var _prv = (Utils.Buscar.Proveedor.Handler.data)_proveedor.Get_Ficha;
                try
                {
                    var r01 = Sistema.MyData.Proveedor_GetFicha(_prv.id);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                    {
                        throw new Exception(r01.Mensaje);
                    }
                    SetTasaRetIva(r01.Entidad.identidad.retIva);
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void SetMontoRetISLR(decimal monto)
        {
            _montoRetISLR = monto;
        }
        public void SetMontoSustraendoISLR(decimal monto)
        {
            _montoSustraendoISLR = monto;
        }
        public void ActualizarRetencion_Iva_ISLR()
        {
            var _montoBase = _tasa1.Get_Base + _tasa2.Get_Base + _tasa3.Get_Base;
            var _montoImp = _tasa1.Get_Imp + _tasa2.Get_Imp + _tasa3.Get_Imp;
            _montoRetIva = (_montoImp) * _tasaRetIva / 100;
            _montoRetISLR = (_montoBase + _tasaEx.Get_Base) * _tasaRetISLR / 100;
        }
        //
        public void FiltrarConcepto(string desc)
        {
            var _lst = lConcepto.Where(w => w.desc.Trim().ToUpper().Contains(desc.Trim().ToUpper())).ToList();
            _concepto.CargarData(_lst);
            var _id = "";
            if (_lst.Count > 0)
            {
                _id = _lst.First().id;
            }
            _concepto.setFichaById(_id);
        }
    }
}