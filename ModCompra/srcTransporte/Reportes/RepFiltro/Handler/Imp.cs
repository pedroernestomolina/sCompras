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
        private Utils.FiltrosCB.ICtrlSinBusqueda _estatus;
        private Utils.FiltrosCB.ICtrlConBusqueda _aliado;
        private Vista.IFiltroActivar _filtroActivar;


        public Vista.IFiltroActivar FiltroActivar { get { return _filtroActivar; } }
        public Utils.FiltrosCB.ICtrlSinBusqueda Estatus { get { return _estatus; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Aliado { get { return _aliado; } }
        public Vista.IFiltros Get_Filtros { get { return obtenerFiltros(); } }


        public Imp()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _estatus = new Utils.FiltrosCB.SinBusqueda.EstatusDoc.Imp();
            _aliado = new Utils.FiltrosCB.ConBusqueda.Aliado.Imp();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _estatus.Inicializa();
            _aliado.Inicializa();
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
            _procesarIsOK = true;
        }


        private bool cargarData()
        {
            _estatus.ObtenerData();
            _aliado.ObtenerData();
            return true;
        }
        public void Limpiar()
        {
            _estatus.LimpiarOpcion();
            _aliado.LimpiarOpcion();
        }
        public void setFiltrosCargar(Vista.IFiltroActivar filtroActivar)
        {
            _filtroActivar = filtroActivar;
        }

        private Vista.IFiltros obtenerFiltros()
        {
            var rt = new Filtros();
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
            return rt;
        }
    }
}