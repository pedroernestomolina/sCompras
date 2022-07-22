using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class GestionProductoBuscar
    {


        private IGestionProductoBuscar _gestion;


        public enum metodoBusqueda { SinDefinir=-1, Codigo=1, Nombre, Referencia, CodBarra };
        public string CadenaPrdBuscar { get { return _gestion.CadenaPrdBuscar; } set { _gestion.CadenaPrdBuscar = value; } }
        public metodoBusqueda MetodoBusquedaProducto { get { return _gestion.MetodoBusquedaProducto; } }
        public bool IsProductoSeleccionadoOk { get { return _gestion.IsProductoSeleccionadoOk; } }
        public string AutoProductoSeleccionado { get { return _gestion.AutoProductoSeleccionado; } } 


        public void setGestion(IGestionProductoBuscar gestion)
        {
            _gestion = gestion;
        }

        public void setMetodoBusqueda(metodoBusqueda metodo)
        {
            _gestion.setMetodoBusqueda(metodo);
        }

        public void BuscarProducto()
        {
            _gestion.BuscarProducto();
        }

    }

}