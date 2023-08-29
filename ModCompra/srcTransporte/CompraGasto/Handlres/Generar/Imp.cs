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
        }

        private bool _procesarIsOK;
        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
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
                _lstCondPago.Add(new dataCondicionPagoDoc() { id = "01", codigo = "", desc = "CREDITO" });
                _lCondPagoDoc = _lstCondPago;

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
                //

                _data.TipoDocumentoCargarData(_lTipoDoc);
                _data.CondicionPagoDocCargarData(_lCondPagoDoc);
                _data.SucursalCargarData(r01.Lista);
                _data.ConceptoCargarData(r02.Lista);
                _data.FechaServidorCargar(r03.Entidad);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}