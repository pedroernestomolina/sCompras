using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Corrector.Documento
{

    public class Gestion
    {


        private string _autoDoc;
        private OOB.LibCompra.Documento.GetData.Ficha _doc;
        private data _data;


        public string getDocumento { get { return _data.documentoNro; } }
        public string getControl { get { return _data.controlNro; } }
        public string getNotas { get { return _data.notaDocumento; } }
        public string getCiRif { get { return _data.ciRifProveedor; } }
        public string getRazonSocial { get { return _data.nombreRazonSocialProveedor; } }
        public string getDirFiscal { get { return _data.direccionFiscalProveedor; } }
        public DateTime getFechaEmision { get { return _data.fechaDocumento; } }
        public bool GuardarIsOK { get; set; }


        public Gestion()
        {
            _data = new data();
            _doc = null;
        }


        public void setFicha(Administrador.Documentos.data Item)
        {
            _autoDoc = Item.AutoDoc;
        }

        CorrectorFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CorrectorFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Compra_DocumentoGetFicha(_autoDoc);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _doc = r01.Entidad;
            _data.documentoNro = _doc.documentoNro;
            _data.controlNro = _doc.controlNro;
            _data.fechaDocumento = _doc.fechaEmision;
            _data.ciRifProveedor = _doc.provCiRif;
            _data.nombreRazonSocialProveedor = _doc.provNombre;
            _data.direccionFiscalProveedor = _doc.provDirFiscal;
            _data.notaDocumento = _doc.notas;

            return rt;
        }

        public void setDocumento(string p)
        {
            _data.documentoNro=p;
        }

        public void setFechaEmision(DateTime fecha)
        {
            _data.fechaDocumento = fecha;
        }

        public void setControl(string p)
        {
            _data.controlNro= p;
        }

        public void setCiRif(string p)
        {
            _data.ciRifProveedor = p;
        }

        public void setRazonSocial(string p)
        {
            _data.nombreRazonSocialProveedor= p;
        }

        public void setDirFiscal(string p)
        {
            _data.direccionFiscalProveedor = p;
        }

        public void setNotas(string p)
        {
            _data.notaDocumento = p;
        }

        public void AceptarGuardar()
        {
            GuardarIsOK=false;

            if (!_data.IsOk())
            {
                return;
            }

            var msg = MessageBox.Show("Estas Seguro De Guardar Los Siguiente Datos ?", "*** AÑLERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var ficha = new OOB.LibCompra.Documento.Corrector.Ficha()
                {
                    autoDoc = _doc.autoId,
                    autoProveedor = _doc.provAuto,
                    ciRifProveedor = _data.ciRifProveedor,
                    controlNro = _data.controlNro,
                    direccionFiscalProveedor = _data.direccionFiscalProveedor,
                    documentoNro = _data.documentoNro,
                    fechaDocumento = _data.fechaDocumento,
                    nombreRazonSocialProveedor = _data.nombreRazonSocialProveedor,
                    notaDocumento = _data.notaDocumento,
                };
                var r01= Sistema.MyData.Compra_DocumentoCorrector(ficha);
                if (r01.Result== OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                GuardarIsOK = true;
            }
        }

    }

}