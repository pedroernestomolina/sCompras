using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Componente.FiltroFecha.Vistas
{
    public interface IFecha
    {
        DateTime Fecha { get; }
        bool IsActiva { get; }

        void Inicializa();
        void setFecha(DateTime fecha);
        void setActivar(bool modo);
    }
}