using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Administrador.Vistas
{
    public interface IAdm: Utils.Componente.Administrador.Vistas.IAdmin
    {
        DateTime Get_Desde { get; }
        DateTime Get_Hasta { get; }
        bool Get_IsActivoDesde { get; }
        bool Get_IsActivoHasta { get; }
        void setDesde(DateTime fecha);
        void setHasta(DateTime fecha);
        void ActivarDesde(bool modo);
        void ActivarHasta(bool modo);

        IBusqDoc BusqDoc { get; }
        void FitrosBusqueda();
        void FiltrosLimpiar();
    }
}