using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Handler
{
    public class Imp: Vista.IHnd
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;
        private Utils.FiltrosCB.ICtrlSinBusqueda _tipoMovCaja;
        private Utils.FiltrosCB.ICtrlSinBusqueda _estatus;
        private Utils.FiltrosCB.ICtrlConBusqueda _aliado;
        private Utils.FiltrosCB.ICtrlConBusqueda _proveedor;
        private Utils.FiltrosCB.ICtrlConBusqueda _caja;
        private Utils.FiltrosCB.ICtrlConBusqueda _concepto;
        private Utils.FiltrosCB.ICtrlConBusqueda _beneficiario;
        private Vista.IFechaRep _desde;
        private Vista.IFechaRep _hasta;
        private Vista.IFiltroActivar _filtroActivar;


        public Vista.IFiltroActivar FiltroActivar { get { return _filtroActivar; } }
        public Utils.FiltrosCB.ICtrlSinBusqueda TipoMovCaja { get { return _tipoMovCaja; } }
        public Utils.FiltrosCB.ICtrlSinBusqueda Estatus { get { return _estatus; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Aliado { get { return _aliado; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Proveedor { get { return _proveedor; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Caja { get { return _caja; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Concepto { get { return _concepto; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Beneficiario { get { return _beneficiario; } }
        public Vista.IFechaRep Desde { get { return _desde; } }
        public Vista.IFechaRep Hasta { get { return _hasta; } }
        public Vista.IFiltros Get_Filtros { get { return obtenerFiltros(); } }


        public Imp()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _tipoMovCaja = new Utils.FiltrosCB.SinBusqueda.TipoMovCaja.Imp();
            _estatus = new Utils.FiltrosCB.SinBusqueda.EstatusDoc.Imp();
            _aliado = new Utils.FiltrosCB.ConBusqueda.Aliado.Imp();
            _proveedor= new Utils.FiltrosCB.ConBusqueda.Proveedor.Imp();
            _caja = new Utils.FiltrosCB.ConBusqueda.Caja.Imp();
            _concepto= new Utils.FiltrosCB.ConBusqueda.Concepto.Imp();
            _beneficiario= new Utils.FiltrosCB.ConBusqueda.Beneficiario.Imp();
            _desde = new ImpFechaRep();
            _hasta = new ImpFechaRep();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _tipoMovCaja.Inicializa();
            _estatus.Inicializa();
            _aliado.Inicializa();
            _proveedor.Inicializa();
            _caja.Inicializa();
            _concepto.Inicializa();
            _beneficiario.Inicializa();
            _desde.Inicializa();
            _hasta.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = true;
        }

        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
            _procesarIsOK = false;
            if (_desde.IsActiva && _hasta.IsActiva)
            {
                if (_desde.Fecha > _hasta.Fecha)
                {
                    Helpers.Msg.Alerta("FECHAS INCORRECTAS");
                    return;
               }
            }
            _procesarIsOK = true;
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
                _tipoMovCaja.ObtenerData();
                _estatus.ObtenerData();
                _aliado.ObtenerData();
                _proveedor.ObtenerData();
                _caja.ObtenerData();
                _concepto.ObtenerData();
                _beneficiario.ObtenerData();
                _desde.setFecha(r01.Entidad.Date);
                _hasta.setFecha(r01.Entidad.Date);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void Limpiar()
        {
            _tipoMovCaja.LimpiarOpcion();
            _estatus.LimpiarOpcion();
            _aliado.LimpiarOpcion();
            _proveedor.LimpiarOpcion();
            _caja.LimpiarOpcion();
            _concepto.LimpiarOpcion();
            _beneficiario.LimpiarOpcion();
            _desde.Limpiar();
            _hasta.Limpiar();
        }
        public void setFiltrosCargar(Vista.IFiltroActivar filtroActivar)
        {
            _filtroActivar = filtroActivar;
        }

        private Vista.IFiltros obtenerFiltros()
        {
            var rt = new Filtros();
            if (_tipoMovCaja.GetItem != null)
            {
                rt.TipoMovCaja =  Vista.enumerados.TipoMovCaja.Ingreso ;
                if (_tipoMovCaja.GetId == "2")
                {
                    rt.TipoMovCaja = Vista.enumerados.TipoMovCaja.Egreso ;
                }
            }
            if (_estatus.GetItem != null) 
            {
                rt.EstatusDocumento = Vista.enumerados.EstatusDoc.Activo;
                if (_estatus.GetId == "2")
                {
                    rt.EstatusDocumento = Vista.enumerados.EstatusDoc.Inactivo;
                }
            }
            if (_aliado.GetItem != null)
            {
                rt.IdAliado = int.Parse(_aliado.GetId);
            }
            if (_proveedor.GetItem != null)
            {
                rt.IdProveedor = _proveedor.GetId;
            }
            if (_caja.GetItem != null)
            {
                rt.IdCaja = int.Parse(_caja.GetId);
            }
            if (_concepto.GetItem != null)
            {
                rt.IdConcepto= int.Parse(_concepto.GetId);
            }
            if (_beneficiario.GetItem != null)
            {
                rt.IdBeneficiario = int.Parse(_beneficiario.GetId);
            }
            if (_desde.IsActiva )
            {
                rt.Desde= _desde.Fecha ;
            }
            if (_hasta.IsActiva)
            {
                rt.Hasta= _hasta.Fecha;
            }
            return rt;
        }
    }
}