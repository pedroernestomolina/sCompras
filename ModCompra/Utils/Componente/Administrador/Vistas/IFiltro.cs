using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Componente.Administrador.Vistas
{
    public interface IFiltro: HlpGestion.IGestion
    {
        DateTime Get_Desde { get; }
        DateTime Get_Hasta { get; }
        bool Get_IsActivoDesde { get; }
        bool Get_IsActivoHasta { get; }
        object Get_Filtros { get; }

        void setDesde(DateTime fecha);
        void setHasta(DateTime fecha);
        void ActivarDesde(bool modo);
        void ActivarHasta(bool modo);
        void Limpiar();
        bool VerificarFiltros();
    }
}