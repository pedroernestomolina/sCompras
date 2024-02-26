using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Corrector.Handler
{
    public class ImpVista: Vista.IVista
    {
        private Utils.Control.Boton.Abandonar.IAbandonar _btAbandonar;
        private Utils.Control.Boton.Procesar.IProcesar  _btProcesar;
        private Vista.IVistaDoc _doc;
        private bool _procesarIsOk;
        //
        public Utils.Control.Boton.Abandonar.IAbandonar BtAbandonar { get { return _btAbandonar; } }
        public Utils.Control.Boton.Procesar.IProcesar BtProcesar { get { return _btProcesar; } }
        public Vista.IVistaDoc Doc { get { return _doc; } }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        //
        public ImpVista()
        {
            _procesarIsOk = false;
            _btAbandonar = new Utils.Control.Boton.Abandonar.Imp();
            _btProcesar = new Utils.Control.Boton.Procesar.Imp();
            _doc = new ImpDoc();
        }
        public void Inicializa()
        {
            _procesarIsOk = false;
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
            _doc.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarDataIsOk())
            {
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setIdDocumento(string idDoc)
        {
            _doc.setIdDocumento(idDoc);
        }
        public void Procesar()
        {
            _procesarIsOk = false;
            _btProcesar.Opcion();
            if (_btProcesar.OpcionIsOK)
            {
                srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.RetISLR.Imp();
                _rep.setIdDoc(_doc.Get_Ficha);
                _rep.Generar();
                _procesarIsOk = true;
            }
        }
        //
        private bool cargarDataIsOk()
        {
            try
            {
                _doc.CargarDoc();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
