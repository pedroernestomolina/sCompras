using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Reportes.Filtros
{
    
    public interface  IFiltrar: HlpGestion.IGestion
    {

        BindingSource GetSucursalData { get; }
        BindingSource GetEstatusData { get; }


        void setSucursal(string id);
        void setEstatus(string id);
        void setFechaDesde(DateTime dateTime);
        void setFechaHasta(DateTime dateTime);
        void setProvBuscar(string desc);


        void Filtrar();
        bool FiltrarIsOk { get; }


        bool SalidaIsOk { get;  }
        void Salir();


        bool GetEstatusActivo { get; }
        bool GetSucursalActivo { get; }
        bool GetMesAnoRelacionActivo { get; }
        bool GetFechaDesdeActivo { get; }
        bool GetFechaHastaActivo { get; }
        bool GetProveedorActivo { get; }


        void setEstatusFiltros(IFiltros filtros);


        string GetSurucrsalId { get; }
        string GetEstatusId { get; }
        DateTime GetFechaDesde { get; }
        DateTime GetFechaHasta { get; }
        decimal GetMesRelacion { get; }
        decimal GetAnoRelacion { get; }
        string GetEstatusDesc { get; }
        string GetSucursalDesc { get; }
        string GetProveedorDesc { get; }


        void BuscarProv();
        bool BuscarProvIsOk { get; }
        bool GetProveedorSeleccionadoIsOk { get; }
        string GetProveedorSeleccionadoId { get; }
        string GetProveedorSeleccionadoDesc { get; }


        void LimpiarProveedor();

    }

}