using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CompraGasto.Handlres.Generar
{
    public class data: Vistas.Generar.Idata
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
        private DateTime _aplicaFechaDoc;
        private string _aplicaNumeroDoc;
        //
        private DateTime _fechaServidor;


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
            _aplicaFechaDoc = DateTime.Now.Date;
            _aplicaNumeroDoc = "";
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
            _aplicaFechaDoc = DateTime.Now.Date;
            _aplicaNumeroDoc = "";
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
        }
        public void SetNotasDoc(string notas)
        {
            _notas = notas;
        }
        public void SucursalCargarData(List<OOB.LibCompra.Sucursal.Data.Ficha> lst)
        {
            IEnumerable<LibUtilitis.Opcion.IData> _lst;
            var lSuc = new List<dataSucursal>();
            foreach(var rg in lst)
            {
                lSuc.Add(new dataSucursal() { codigo = rg.codigo, desc = rg.nombre, id = rg.auto, ficha = rg });
            }
            _lst = lSuc;
            _sucursal.CargarData(_lst);
        }
        public void ConceptoCargarData(List<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha> lst)
        {
            IEnumerable<LibUtilitis.Opcion.IData> _lst;
            var lConcepto= new List<dataConcepto>();
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
                if (_tipoDoc.GetItem != null && _tipoDoc.GetId!="01") 
                {
                    rt=true;
                }
            }
            return rt;
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
    }
}