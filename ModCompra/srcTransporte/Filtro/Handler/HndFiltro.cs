using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Filtro.Handler
{
    public class HndFiltro: Vistas.IHndFiltro
    {
        private Utils.FiltroFecha.IFecha _desde;
        private Utils.FiltroFecha.IFecha _hasta;
        private Utils.FiltrosCB.ICtrlSinBusqueda _estatusDoc;
        private Utils.FiltrosCB.ICtrlSinBusqueda _tipoMovCaja;
        private Utils.FiltrosCB.ICtrlConBusqueda _caja;
        private Utils.FiltrosCB.ICtrlConBusqueda _aliado;
        private Utils.FiltrosCB.ICtrlSinBusqueda _tipoRet;
        private Utils.FiltrosCB.ICtrlConBusqueda _proveedor;


        public HndFiltro()
        {
            _desde = new Utils.FiltroFecha.Imp();
            _hasta = new Utils.FiltroFecha.Imp();
            _estatusDoc = new Utils.FiltrosCB.SinBusqueda.EstatusDoc.Imp();
            _tipoMovCaja = new Utils.FiltrosCB.SinBusqueda.TipoMovCaja.Imp();
            _tipoRet = new Utils.FiltrosCB.SinBusqueda.TipoRetencion.Imp();
            _caja = new Utils.FiltrosCB.ConBusqueda.Caja.Imp();
            _aliado = new Utils.FiltrosCB.ConBusqueda.Aliado.Imp();
            _proveedor = new Utils.FiltrosCB.ConBusqueda.Proveedor.Imp();
        }
        public void Inicializa()
        {
            _desde.Inicializa();
            _hasta.Inicializa();
            _estatusDoc.Inicializa();
            _tipoMovCaja.Inicializa();
            _tipoRet.Inicializa();
            _caja.Inicializa();
            _aliado.Inicializa();
            _proveedor.Inicializa();
        }
        public void CargarData()
        {
            _estatusDoc.ObtenerData();
            _tipoMovCaja.ObtenerData();
            _tipoRet.ObtenerData();
            _caja.ObtenerData();
            _aliado.ObtenerData();
            _proveedor.ObtenerData();

        }
        public void Limpiar()
        {
            _desde.Limpiar();
            _hasta.Limpiar();
            _estatusDoc.LimpiarOpcion();
            _tipoMovCaja.LimpiarOpcion();
            _caja.LimpiarOpcion();
            _aliado.LimpiarOpcion();
            _tipoRet.LimpiarOpcion();
            _proveedor.LimpiarOpcion();
        }


        //
        public DateTime Get_Desde { get { return _desde.Fecha; } }
        public DateTime Get_Hasta { get { return _hasta.Fecha; } }
        public bool Get_IsActivoDesde { get { return _desde.IsActiva; } }
        public bool Get_IsActivoHasta { get { return _hasta.IsActiva; } }
        public void setDesde(DateTime fecha)
        {
            _desde.setFecha(fecha);
        }
        public void setHasta(DateTime fecha)
        {
            _hasta.setFecha(fecha);
        }
        public void ActivarDesde(bool modo)
        {
            _desde.setActivar(modo);
        }
        public void ActivarHasta(bool modo)
        {
            _hasta.setActivar(modo);
        }

        //
        public BindingSource Get_EstatusSource { get { return _estatusDoc.GetSource; } }
        public string Get_EstatusById { get { return _estatusDoc.GetId; } }
        public void setEstatusById(string id)
        {
            _estatusDoc.setFichaById(id);
        }

        //
        public BindingSource Get_TipoMovCajaSource { get { return _tipoMovCaja.GetSource; } }
        public string Get_TipoMovCajaById { get { return _tipoMovCaja.GetId; } }
        public void setTipoMovCajaById(string id)
        {
            _tipoMovCaja.setFichaById(id);
        }

        //
        public BindingSource Get_TipoRetencionSource { get { return _tipoRet.GetSource; } }
        public string Get_TipoRetencionById { get { return _tipoRet.GetId; } }
        public void setTipoRetencionById(string id)
        {
            _tipoRet.setFichaById(id);
        }

        //
        public BindingSource Get_CajaSource { get { return _caja.GetSource; } }
        public string Get_CajaById { get { return _caja.GetId; } }
        public string GetCaja_TextoBuscar { get { return ""; } }
        public void setCajaById(string id)
        {
            _caja.setFichaById(id);
        }
        public void setCajaBuscar(string desc)
        {
            _caja.setTextoBuscar(desc);
        }

        //
        public BindingSource Get_AliadoSource { get { return _aliado.GetSource; } }
        public string Get_AliadoById { get { return _aliado.GetId; } }
        public string GetAliado_TextoBuscar { get { return ""; } }
        public void setAliadoById(string id)
        {
            _aliado.setFichaById(id);
        }
        public void setAliadoBuscar(string desc)
        {
            _aliado.setTextoBuscar(desc);
        }

        //
        public BindingSource Get_ProveedorSource { get { return _proveedor.GetSource; } }
        public string Get_ProveedorById { get { return _proveedor.GetId; } }
        public string GetProveedor_TextoBuscar { get { return ""; } }
        public void setProveedorById(string id)
        {
            _proveedor.setFichaById(id);
        }
        public void setProveedorBuscar(string desc)
        {
            _proveedor.setTextoBuscar(desc);
        }


        //
        public Vistas.IdataFiltrar Get_Filtros
        {
            get { return retornarFiltros(); }
        }
        public bool VerificarFiltros()
        {
            if (_desde.IsActiva && _hasta.IsActiva)
            {
                if (_desde.Fecha > _hasta.Fecha)
                {
                    Helpers.Msg.Alerta("FECHAS INCORRECTAS");
                    return false;
                }
            }
            return true;
        }
        private Vistas.IdataFiltrar retornarFiltros()
        {
            var _filtroRet = new dataFiltrar(); ;
            if (_desde.IsActiva)
            {
                _filtroRet.Desde = _desde.Fecha;
            }
            if (_hasta.IsActiva)
            {
                _filtroRet.Hasta = _hasta.Fecha;
            }
            if (_tipoMovCaja.GetItem != null)
            {
                _filtroRet.TipoMovCaja = _tipoMovCaja.GetId == "1" ? Vistas.Enumerados.TipoMovCaja.Ingreso : Vistas.Enumerados.TipoMovCaja.Egreso;
            }
            if (_estatusDoc.GetItem != null)
            {
                _filtroRet.EstatusDoc = _estatusDoc.GetId == "1" ? Vistas.Enumerados.EstatusDoc.Activo : Vistas.Enumerados.EstatusDoc.Anulado;
            }
            if (_caja.GetItem != null)
            {
                _filtroRet.IdCaja = int.Parse(_caja.GetId);
            }
            if (_aliado.GetItem != null)
            {
                _filtroRet.IdAliado = int.Parse(_aliado.GetId);
            }
            return _filtroRet;
        }
    }
}