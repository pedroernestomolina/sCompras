using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestionProductoBuscar
    {

        string CadenaPrdBuscar { get; set; }
        GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get; }
        bool IsProductoSeleccionadoOk { get; }
        string AutoProductoSeleccionado { get; }


        void setMetodoBusqueda(GestionProductoBuscar.metodoBusqueda metodo);
        void BuscarProducto();

    }

}