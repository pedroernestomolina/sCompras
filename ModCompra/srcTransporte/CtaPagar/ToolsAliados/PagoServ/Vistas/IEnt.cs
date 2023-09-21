using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Vistas
{
    public interface IEnt
    {
        IServ Servicios { get; }
        IGestPag GestPago {get;}
        string Get_AliadoInfo { get; }
        decimal Get_AliadoAnticipos { get; }
        decimal Get_MontoPendiente { get; }

        void Inicializa();
        void CargarData();
        void setAliado(OOB.LibCompra.Transporte.Aliado.Entidad.Ficha ficha);
        void setTasaCambio(decimal factor);
        void setFechaServidor(DateTime fecha);
        void setServicios(List<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha> list);
    }
}