using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Administrador.Handler
{
    public class HndBusqDoc: Vistas.IBusqDoc
    {
        private Utils.Componente.Busqueda.Vistas.IBusqueda _busqueda;


        public HndBusqDoc()
        {
            _busqueda = new hndBusqueda();
        }
        public void Inicializa()
        {
            _busqueda.Inicializa();
        }
        public IEnumerable<Object>Buscar()
        {
            return _busqueda.Buscar();
        }
        public void setFiltros(object filtros)
        {
            _busqueda.setFiltros(filtros);
        }
    }
}