using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Corrector.Documento
{
    public class data
    {
        private OOB.LibCompra.Documento.Corrector.GetData.Ficha _ficha;
        private string _documentoNro;
        private string _controlNro;
        private DateTime _fechaDocumento;
        private string _ciRifProveedor;
        private string _nombreRazonSocialProveedor;
        private string _direccionFiscalProveedor;
        private string _notaDocumento;
        private decimal _exento;
        private decimal _base1;
        private decimal _base2;
        private decimal _base3;
        private decimal _iva1;
        private decimal _iva2;
        private decimal _iva3;
        private decimal _tasa1;
        private decimal _tasa2;
        private decimal _tasa3;
        private decimal _montoBase;
        private decimal _montoIva;
        private decimal _montoTotal;
        //
        public OOB.LibCompra.Documento.Corrector.GetData.Ficha Ficha { get { return _ficha; } }
        public string getDocumento { get { return _documentoNro; } }
        public string getControl { get { return _controlNro; } }
        public string getNotas { get { return _notaDocumento; } }
        public string getCiRif { get { return _ciRifProveedor; } }
        public string getRazonSocial { get { return _nombreRazonSocialProveedor; } }
        public string getDirFiscal { get { return _direccionFiscalProveedor; } }
        public DateTime getFechaEmision { get { return _fechaDocumento; } }
        public decimal getMontoExento { get { return _exento; } }
        public decimal getMontoBase1 { get { return _base1; } }
        public decimal getMontoBase2 { get { return _base2; } }
        public decimal getMontoBase3 { get { return _base3; } }
        public decimal getMontoIva1 { get { return _iva1; } }
        public decimal getMontoIva2 { get { return _iva2; } }
        public decimal getMontoIva3 { get { return _iva3; } }
        public decimal getTasa1 { get { return _tasa1; } }
        public decimal getTasa2 { get { return _tasa2; } }
        public decimal getTasa3 { get { return _tasa3; } }
        public decimal getMontoBase { get { return _montoBase; } }
        public decimal getMontoIva { get { return _montoIva; } }
        public decimal getMontoTotal { get { return _montoTotal; } }
        //
        public data()
        {
            inicializar();
        }
        //
        public void setDocumento(string p)
        {
            _documentoNro = p;
        }
        public void setFechaEmision(DateTime fecha)
        {
            _fechaDocumento = fecha;
        }
        public void setControl(string p)
        {
            _controlNro = p;
        }
        public void setCiRif(string p)
        {
            _ciRifProveedor = p;
        }
        public void setRazonSocial(string p)
        {
            _nombreRazonSocialProveedor = p;
        }
        public void setDirFiscal(string p)
        {
            _direccionFiscalProveedor = p;
        }
        public void setNotas(string p)
        {
            _notaDocumento = p;
        }
        public void setMontoExento(decimal monto)
        {
            _exento = monto;
            recalcula();
        }
        public void setMontoBase1(decimal monto)
        {
            _base1 = monto;
            recalcula();
        }
        public void setMontoBase2(decimal monto)
        {
            _base2 = monto;
            recalcula();
        }
        public void setMontoBase3(decimal monto)
        {
            _base3 = monto;
            recalcula();
        }
        public void setMontoIva1(decimal monto)
        {
            _iva1 = monto;
            recalcula();
        }
        public void setMontoIva2(decimal monto)
        {
            _iva2 = monto;
            recalcula();
        }
        public void setMontoIva3(decimal monto)
        {
            _iva3 = monto;
            recalcula();
        }
        public void setMontoBase(decimal monto)
        {
            _montoBase = monto;
        }
        public void setMontoIva(decimal monto)
        {
            _montoIva = monto;
        }
        public void setMontoTotal(decimal monto)
        {
            _montoTotal = monto;
        }
        //
        public bool IsOk()
        {
            var rt = true;
            if (_documentoNro == "")
            {
                Helpers.Msg.Error("CAMPO [NUMERO DE DOCUMENTO] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_controlNro == "")
            {
                Helpers.Msg.Error("CAMPO [NUMERO DE CONTROL] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_ciRifProveedor == "")
            {
                Helpers.Msg.Error("CAMPO [CI/RIF] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_nombreRazonSocialProveedor == "")
            {
                Helpers.Msg.Error("CAMPO [NOMBRE/RAZON SOCIAL] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_direccionFiscalProveedor == "")
            {
                Helpers.Msg.Error("CAMPO [DIRECCION FISCAL] NO PUEDE ESTAR VACIO");
                return false;
            }
            if ((_exento + _base1 + _base2 + _base3) == 0m)
            {
                Helpers.Msg.Error("MONTOS INCORRECTOS, NO PUEDE SER CERO (0.0)");
                return false;
            }
            if (_montoTotal == 0m)
            {
                Helpers.Msg.Error("MONTO TOTAL DEL DOCUMENTO NO PUEDE SER CERO (0.0)");
                return false;
            }
            return rt;
        }
        public void setData(OOB.LibCompra.Documento.Corrector.GetData.Ficha ficha)
        {
            _documentoNro = ficha.documentoNro;
            _controlNro = ficha.controlNro;
            _fechaDocumento = ficha.fechaEmision;
            _ciRifProveedor = ficha.provCiRif;
            _nombreRazonSocialProveedor = ficha.provNombre;
            _direccionFiscalProveedor = ficha.provDirFiscal;
            _notaDocumento = ficha.notas;
            _exento = ficha.montoExento;
            _base1 = ficha.montoBase1;
            _base2 = ficha.montoBase2;
            _base3 = ficha.montoBase3;
            _iva1 = ficha.montoIva1;
            _iva2 = ficha.montoIva2;
            _iva3 = ficha.montoIva3;
            _tasa1 = ficha.tasaIva1;
            _tasa2 = ficha.tasaIva2;
            _tasa3 = ficha.tasaIva3;
            _montoBase = ficha.montoBase;
            _montoIva = ficha.montoImpuesto;
            _montoTotal = ficha.montoTotal;
            _ficha = ficha;
        }
        public void Inicializa()
        {
            inicializar();
        }
        //
        private void inicializar()
        {
            _documentoNro = "";
            _fechaDocumento = new DateTime();
            _nombreRazonSocialProveedor = "";
            _direccionFiscalProveedor = "";
            _ciRifProveedor = "";
            _notaDocumento = "";
            _controlNro = "";
            _ficha = null;
            _exento = 0m;
            _base1 = 0m;
            _base2 = 0m;
            _base3 = 0m;
            _iva1 = 0m;
            _iva2 = 0m;
            _iva3 = 0m;
            _tasa1 = 0m;
            _tasa2 = 0m;
            _tasa3 = 0m;
            _montoBase = 0m;
            _montoIva = 0m;
            _montoTotal = 0m;
        }
        private void recalcula() 
        {
            _montoBase = _base1+_base2+_base3;
            _montoIva = _iva1 + _iva2 + _iva3;
            _montoTotal = _montoBase + _montoIva + _exento;
        }
    }
}