using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Administrador.Vistas
{
    public interface IdataFiltro
    {
        DateTime? Desde { get; set; }
        DateTime? Hasta { get; set; }

        void Inicializa();
    }
}