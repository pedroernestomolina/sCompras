using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Corrector.Documento
{
    public class Gestion : IGestion
    {
        private bool _procesarIsOK;
        private string _autoDoc;
        private data _data;
        private Utils.Control.Boton.Abandonar.IAbandonar _abandonar;
        private Utils.Control.Boton.Procesar.IProcesar _procesar;
        //
        public string GetDocumento { get { return _data.getDocumento; } }
        public string GetControl { get { return _data.getControl; } }
        public string GetNotas { get { return _data.getNotas; } }
        public string GetCiRif { get { return _data.getCiRif; } }
        public string GetRazonSocial { get { return _data.getRazonSocial; } }
        public string GetDirFiscal { get { return _data.getDirFiscal; } }
        public DateTime GetFechaEmision { get { return _data.getFechaEmision; } }
        public string GetMontoExento { get { return ctos(_data.getMontoExento); } }
        public string GetMontoBase1 { get { return ctos(_data.getMontoBase1); } }
        public string GetMontoBase2 { get { return ctos(_data.getMontoBase2); } }
        public string GetMontoBase3 { get { return ctos(_data.getMontoBase3); } }
        public string GetMontoIva1 { get { return ctos(_data.getMontoIva1); } }
        public string GetMontoIva2 { get { return ctos(_data.getMontoIva2); } }
        public string GetMontoIva3 { get { return ctos(_data.getMontoIva3); } }
        public string GetTasa1 { get { return ctos(_data.getTasa1); } }
        public string GetTasa2 { get { return ctos(_data.getTasa2); } }
        public string GetTasa3 { get { return ctos(_data.getTasa3); } }
        public string GetMontoBase { get { return ctos(_data.getMontoBase); } }
        public string GetMontoIva { get { return ctos(_data.getMontoIva); } }
        public string GetMontoTotal { get { return ctos(_data.getMontoTotal); } }
        //
        public Gestion()
        {
            _procesarIsOK = false;
            _abandonar = new Utils.Control.Boton.Abandonar.Imp();
            _procesar = new Utils.Control.Boton.Procesar.Imp();
            _data = new data();
            _autoDoc = "";
        }
        public void Inicializa()
        {
            _procesarIsOK = false;
            _abandonar.Inicializa();
            _procesar.Inicializa();
            _data.Inicializa();
            _autoDoc = "";
        }
        CorrectorFrm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new CorrectorFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        private bool cargarData()
        {
            var rt = false;
            //
            try
            {
                var r01 = Sistema.MyData.Compra_DocumentoCorrector_GetData(_autoDoc);
                if (r01.Entidad.isAnulado)
                {
                    throw new Exception("DOCUMENTO SE ENCUENTRA ANULADO");
                }
                _data.setData(r01.Entidad);
                rt = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                rt = false;
            }
            //
            return rt;
        }
        public void setIdDoc_Corregir(string idDoc)
        {
            _autoDoc = idDoc;
        }
        public void setDocumento(string p)
        {
            _data.setDocumento(p);
        }
        public void setFechaEmision(DateTime f)
        {
            _data.setFechaEmision(f);
        }
        public void setControl(string p)
        {
            _data.setControl(p);
        }
        public void setCiRif(string p)
        {
            _data.setCiRif(p);
        }
        public void setRazonSocial(string p)
        {
            _data.setRazonSocial(p);
        }
        public void setDirFiscal(string p)
        {
            _data.setDirFiscal(p);
        }
        public void setNotas(string p)
        {
            _data.setNotas(p);
        }
        public void setMontoExento(decimal monto)
        {
            _data.setMontoExento(monto);
        }
        public void setMontoBase1(decimal monto)
        {
            _data.setMontoBase1(monto);
        }
        public void setMontoBase2(decimal monto)
        {
            _data.setMontoBase2(monto);
        }
        public void setMontoBase3(decimal monto)
        {
            _data.setMontoBase3(monto);
        }
        public void setMontoIva1(decimal monto)
        {
            _data.setMontoIva1(monto);
        }
        public void setMontoIva2(decimal monto)
        {
            _data.setMontoIva2(monto);
        }
        public void setMontoIva3(decimal monto)
        {
            _data.setMontoIva3(monto);
        }
        public void setMontoBase(decimal monto)
        {
            _data.setMontoBase(monto);
        }
        public void setMontoIva(decimal monto)
        {
            _data.setMontoIva(monto);
        }
        public void setMontoTotal(decimal monto)
        {
            _data.setMontoTotal(monto);
        }
        //
        public bool AbandonarFichaIsOk { get { return _abandonar.OpcionIsOK; } }
        public bool ProcesarFichaIsOk { get { return _procesarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonar.Opcion();
        }
        public void ProcesarFicha()
        {
            _procesarIsOK = false;
            if (_data.IsOk())
            {
                _procesar.Opcion();
                if (_procesar.OpcionIsOK)
                {
                    guardarCambios();
                }
            }
        }
        //
        private string ctos(decimal p)
        {
            return p.ToString();
        }
        public void guardarCambios()
        {
            try
            {
                var ficha = new OOB.LibCompra.Documento.Corrector.ActualizarData.Ficha()
                {
                    autoId = _autoDoc,
                    controlNro = _data.getControl,
                    documentoNro = _data.getDocumento,
                    fechaEmision = _data.getFechaEmision,
                    montoBase = _data.getMontoBase,
                    montoBase1 = _data.getMontoBase1,
                    montoBase2 = _data.getMontoBase2,
                    montoBase3 = _data.getMontoBase3,
                    montoExento = _data.getMontoExento,
                    montoImpuesto = _data.getMontoIva,
                    montoIva1 = _data.getMontoIva1,
                    montoIva2 = _data.getMontoIva2,
                    montoIva3 = _data.getMontoIva3,
                    montoTotal = _data.getMontoTotal,
                    notas = _data.getNotas,
                    provCiRif = _data.getCiRif,
                    provCodigo = _data.Ficha.provCodigo,
                    provDirFiscal = _data.getDirFiscal,
                    provId = _data.Ficha.provId,
                    provNombre = _data.getRazonSocial,
                    provTelefono = _data.Ficha.provTelefono,
                    subTotal = _data.Ficha.subTotal,
                };
                var r01 = Sistema.MyData.Compra_DocumentoCorrector_ActualizarData(ficha);
                _procesarIsOK = true;
                Helpers.Msg.EditarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}