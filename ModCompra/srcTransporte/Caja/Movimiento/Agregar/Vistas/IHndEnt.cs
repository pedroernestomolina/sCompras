using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Caja.Movimiento.Agregar.Vistas
{
    public interface IHndEnt
    {
        Utils.FiltrosCB.ICtrlConBusqueda Concepto {get;}
        BindingSource Get_Caja_Source { get; }
        BindingSource Get_TipoMov_Source { get; }
        string Get_CajaID { get; }
        string Get_TipoMovId { get; }
        decimal Get_FactorCambio { get; }
        decimal Get_MontoMov { get; }
        DateTime Get_FechaServidor { get; }
        string Get_Notas { get; }
        string Get_CajaInfo { get; }
        object Get_Caja { get; }
        DateTime Get_FechaEmision { get; }


        void Inicializa();
        void CargarData();
        void setCajaById(string id);
        void setTipoMovById(string id);
        void setFactorCambio(decimal monto);
        void setMontoMov(decimal monto);
        void setFechaServidor(DateTime fecha);
        void setNotas(string desc);
        void setFechaEmisionMov(DateTime fecha);
        bool DataIsOk();
    }
}