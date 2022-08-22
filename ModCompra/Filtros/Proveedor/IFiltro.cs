using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Filtros.Proveedor
{

    public interface IFiltro
    {

        void setCadenaBusq(string desc);
        void Inicializa();
        string GetProveedorDesc { get; }
        bool ItemSeleccionadoIsOk { get; }
        void BuscarProv();
        string GetProveedorSeleccionadoId { get; }
        string GetProveedorSeleccionadoDesc { get; }
        void LimpiarSeleccion();

    }

}