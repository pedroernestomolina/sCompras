using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Corrector.Handler
{
    public class ImpDoc: Vista.IVistaDoc
    {
        private string _idDoc;
        private string _prvCiRif;
        private string _prvNombre;
        private string _prvDirFiscal;
        private DateTime _fechaEmision;
        private string _facturaNro;
        private string _controlNro;
        private string _codXml;
        private string _conceptoDesc;
        private decimal _montoExento;
        private decimal _base_1;
        private decimal _base_2;
        private decimal _base_3;
        private decimal _imp_1;
        private decimal _imp_2;
        private decimal _imp_3;
        private decimal _tasaRet;
        private decimal _sustraendo;
        private decimal _montoRet;
        private decimal _subtBase;
        private decimal _subtImp;
        private decimal _total;
        private OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha _ficha;
        private string _tasa_1;
        private string _tasa_2;
        private string _tasa_3;
        //
        public string Get_PrvCiRif { get { return _prvCiRif; } }
        public string Get_PrvNombre { get { return _prvNombre; } }
        public string Get_PrvDirFiscal { get { return _prvDirFiscal; } }
        public DateTime Get_FechaEmision { get { return _fechaEmision; } }
        public string Get_FacturaNro { get { return _facturaNro; } }
        public string Get_ControlNro { get { return _controlNro; } }
        public string Get_CodXml { get { return _codXml; } }
        public string Get_ConceptoDesc { get { return _conceptoDesc; } }
        public decimal Get_MontoExento { get { return _montoExento; } }
        public decimal Get_Base_1 { get { return _base_1; } }
        public decimal Get_Base_2 { get { return _base_2; } }
        public decimal Get_Base_3 { get { return _base_3; } }
        public decimal Get_Imp_1 { get { return _imp_1; } }
        public decimal Get_Imp_2 { get { return _imp_2; } }
        public decimal Get_Imp_3 { get { return _imp_3; } }
        public decimal Get_TasaRet { get { return _tasaRet; } }
        public decimal Get_Sustraendo { get { return _sustraendo; } }
        public decimal Get_MontoRet { get { return _montoRet; } }
        public decimal Get_SubtBase { get { return _subtBase; } }
        public decimal Get_SubtImp { get { return _subtImp; } }
        public decimal Get_Total { get { return _total; } }
        public object Get_Ficha { get { return _ficha; } }
        public string Get_Tasa_1 { get { return _tasa_1; } }
        public string Get_Tasa_2 { get { return _tasa_2; } }
        public string Get_Tasa_3 { get { return _tasa_3; } }
        //
        public ImpDoc()
        {
            _idDoc = "";
            limpiar();
        }
        public void Inicializa()
        {
            limpiar();
        }
        public void setIdDocumento(string idDoc)
        {
            _idDoc = idDoc;
        }
        public void setCiRif(string dato)
        {
            _prvCiRif = dato;
            _ficha.prvCiRif = dato;
        }
        public void setNombre(string dato)
        {
            _prvNombre = dato;
            _ficha.prvNombre = dato;
        }
        public void setDirFiscal(string dato)
        {
            _prvDirFiscal = dato;
            _ficha.prvDirFiscal = dato;
        }
        public void setFacturaNro(string dato)
        {
            _facturaNro = dato;
            _ficha.numDoc = dato;
        }
        public void setControlNro(string dato)
        {
            _controlNro = dato;
            _ficha.numControlDoc = dato;
        }
        public void setCodigoXML(string dato)
        {
            _codXml = dato;
            _ficha.codXmlIslr = dato;
        }
        public void setDescXML(string dato)
        {
            _conceptoDesc = dato;
            _ficha.descXmlIslr = dato;
        }
        public void setFechaEmisionDoc(DateTime fecha)
        {
            _fechaEmision = fecha;
            _ficha.fechaEmiDoc = fecha;
        }
        public void setExento(decimal monto)
        {
            _montoExento = monto;
            _ficha.exento= monto;
        }
        public void setBase1(decimal monto)
        {
            _base_1 = monto;
            _ficha.base1 = monto;
        }
        public void setBase2(decimal monto)
        {
            _base_2 = monto;
            _ficha.base2 = monto;
        }
        public void setBase3(decimal monto)
        {
            _base_3 = monto;
            _ficha.base3 = monto;
        }
        public void setImp1(decimal monto)
        {
            _imp_1 = monto;
            _ficha.impuesto1 = monto;
        }
        public void setImp2(decimal monto)
        {
            _imp_2 = monto;
            _ficha.impuesto2 = monto;
        }
        public void setImp3(decimal monto)
        {
            _imp_3 = monto;
            _ficha.impuesto3 = monto;
        }
        public void setSubtBase(decimal monto)
        {
            _subtBase = monto;
            _ficha.subtBase = monto;
        }
        public void setSubtImp(decimal monto)
        {
            _subtImp = monto;
            _ficha.subtImp = monto;
        }
        public void setTotal(decimal monto)
        {
            _total = monto;
            _ficha.total = monto;
        }
        public void setTasaRet(decimal monto)
        {
            _tasaRet = monto;
            _ficha.tasaRet = monto;
        }
        public void setSustraendo(decimal monto)
        {
            _sustraendo = monto;
            _ficha.sustraendoRet = monto;
        }
        public void setRetencion(decimal monto)
        {
            _montoRet = monto;
            _ficha.totalRet = monto;
        }
        public void CargarDoc()
        {
            if (_idDoc == "")
            {
                throw new Exception("PROBLEMA CON EL ID DEL DOCUMENTO");
            }
            var r01 = Sistema.MyData.Transporte_DocumentoRet_Crud_Corrector_ObtenerData(_idDoc);
            _ficha= r01.Entidad;
            _prvCiRif = _ficha.prvCiRif;
            _prvDirFiscal = _ficha.prvDirFiscal;
            _prvNombre = _ficha.prvNombre;
            _fechaEmision = _ficha.fechaEmiDoc;
            _facturaNro = _ficha.numDoc;
            _controlNro = _ficha.numControlDoc;
            _codXml = _ficha.codXmlIslr;
            _conceptoDesc = _ficha.descXmlIslr;
            _montoExento = _ficha.exento;
            _base_1 = _ficha.base1;
            _base_2 = _ficha.base2;
            _base_3 = _ficha.base3;
            _imp_1 = _ficha.impuesto1;
            _imp_2 = _ficha.impuesto2;
            _imp_3 = _ficha.impuesto3;
            _tasaRet = _ficha.tasaRet;
            _sustraendo = _ficha.sustraendoRet;
            _montoRet = _ficha.totalRet;
            _subtBase = _base_1 + _base_2 + _base_3;
            _subtImp = _imp_1 + _imp_2 + _imp_3;
            _total = _ficha.total;
            _tasa_1 = _ficha.tasa1.ToString("n2") + "%";
            _tasa_2 = _ficha.tasa2.ToString("n2") + "%";
            _tasa_3 = _ficha.tasa3.ToString("n2") + "%";
        }
        //
        void limpiar() 
        {
            _ficha = null;
            _prvCiRif = "";
            _prvNombre = "";
            _prvDirFiscal = "";
            _fechaEmision = DateTime.Now.Date;
            _facturaNro = "";
            _controlNro = "";
            _codXml = "";
            _conceptoDesc = "";
            _montoExento = 0m;
            _base_1 = 0m;
            _base_2 = 0m;
            _base_3 = 0m;
            _imp_1 = 0m;
            _imp_2 = 0m;
            _imp_3 = 0m;
            _tasaRet = 0m;
            _sustraendo = 0m;
            _montoRet = 0m;
            _subtBase = 0m;
            _subtImp = 0m;
            _total = 0m;
            _tasa_1 = "";
            _tasa_2 = "";
            _tasa_3 = "";
        }
    }
}