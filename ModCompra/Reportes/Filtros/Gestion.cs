using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Reportes.Filtros
{
    
    public class Gestion
    {

        private Reportes.Filtros.IReporte miGestion;
        private IFiltrar _gFiltrar;
        private data _dataFiltro;
        //public bool ActivarMesAnoRElacion { get { return filtros.ActivarMesAnoRelacion; } }


        public Gestion()
        {
            _dataFiltro = new data();
            _gFiltrar = new HlpFiltrar();
        }


        public void Inicia()
        {
            _dataFiltro.Limpiar();
            _gFiltrar.Inicializa();
            _gFiltrar.Inicia();
            if (_gFiltrar.FiltrarIsOk)
            {
                if (_gFiltrar.GetEstatusActivo && _gFiltrar.GetEstatusId != "") 
                {
                    _dataFiltro.setEstatus(_gFiltrar.GetEstatusId, _gFiltrar.GetEstatusDesc);
                }
                if (_gFiltrar.GetSucursalActivo &&  _gFiltrar.GetSurucrsalId != "")
                {
                    _dataFiltro.setSucursal(_gFiltrar.GetSurucrsalId, _gFiltrar.GetSucursalDesc);
                }
                if (_gFiltrar.GetFechaDesdeActivo)
                {
                    _dataFiltro.setFechaDesde(_gFiltrar.GetFechaDesde);
                }
                if (_gFiltrar.GetFechaHastaActivo)
                {
                    _dataFiltro.setFechaHasta(_gFiltrar.GetFechaHasta);
                }
                if (_gFiltrar.GetProveedorActivo && _gFiltrar.BuscarProvIsOk)
                {
                    _dataFiltro.setProveedor(_gFiltrar.GetProveedorSeleccionadoId, _gFiltrar.GetProveedorSeleccionadoDesc);
                }

                GenerarReporte();
            }
        }

        public void setGestion(Reportes.Filtros.IReporte gestion)
        {
            _gFiltrar.setEstatusFiltros(gestion.Filtros);
            miGestion = gestion;
        }

        public void GenerarReporte()
        {
            miGestion.setDataFiltros(_dataFiltro);
            miGestion.Generar();
        }

        public void setMesAnoRelacion(decimal mes, decimal ano)
        {
            //dataFiltro.mesRelacion = ((int)mes).ToString().Trim().PadLeft(2, '0');
            //dataFiltro.anoRelacion = ((int)ano).ToString().Trim().PadLeft(4, '0');
        }

    }

}