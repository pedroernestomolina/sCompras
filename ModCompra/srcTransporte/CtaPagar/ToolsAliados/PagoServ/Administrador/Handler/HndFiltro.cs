using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Administrador.Handler
{
    public class HndFiltro: Vistas.IFiltroPagoServ
    {
        private Utils.Componente.FiltroFecha.Vistas.IFecha  _desde;
        private Utils.Componente.FiltroFecha.Vistas.IFecha  _hasta;


        public DateTime Get_Desde { get { return _desde.Fecha; } }
        public DateTime Get_Hasta { get { return _hasta.Fecha; } }
        public bool Get_IsActivoDesde { get { return _desde.IsActiva; } }
        public bool Get_IsActivoHasta { get { return _hasta.IsActiva; } }
        public object Get_Filtros { get { return retornarFiltros(); } }


        public HndFiltro()
        {
            _desde = new Utils.Componente.FiltroFecha.Handlers.Imp();
            _hasta = new Utils.Componente.FiltroFecha.Handlers.Imp();
        }
        public void Inicializa()
        {
            _desde.Inicializa();
            _hasta.Inicializa();
        }
        public void Inicia()
        {
        }


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
        public void Limpiar()
        {
            _desde.Inicializa();
            _hasta.Inicializa();
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


        private Vistas.IdataFiltro retornarFiltros()
        {
            var _filtroRet = new dataFiltro(); ;
            if (_desde.IsActiva)
            {
                _filtroRet.Desde = _desde.Fecha;
            }
            if (_hasta.IsActiva)
            {
                _filtroRet.Hasta = _hasta.Fecha;
            }
            return _filtroRet;
        }
    }
}