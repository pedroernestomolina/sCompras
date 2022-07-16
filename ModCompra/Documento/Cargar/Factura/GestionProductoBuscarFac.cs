using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionProductoBuscarFac: Controlador.IGestionProductoBuscar
    {

        private Controlador.GestionProductoBuscar.metodoBusqueda metodo;
        private OOB.LibCompra.Producto.Lista.Filtro filtros;
        private Producto.Listar.Gestion gestionLista;
        private bool isProductoSeleccionadoOk;
        private string autoProductoSeleccionado;


        public string CadenaPrdBuscar { get; set; }
        public Controlador.GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get { return metodo; } }
        public bool IsProductoSeleccionadoOk { get { return isProductoSeleccionadoOk; } }
        public string AutoProductoSeleccionado { get { return autoProductoSeleccionado; } }


        public GestionProductoBuscarFac()
        {
            isProductoSeleccionadoOk=false;
            autoProductoSeleccionado = "";
            CadenaPrdBuscar = "";
            filtros=new OOB.LibCompra.Producto.Lista.Filtro();
            gestionLista = new Producto.Listar.Gestion();
            gestionLista.ItemSeleccionadoOk+=gestionLista_ItemSeleccionadoOk;
        }


        private void gestionLista_ItemSeleccionadoOk(object sender, EventArgs e)
        {
            autoProductoSeleccionado  = gestionLista.ItemSeleccionado.auto;
            isProductoSeleccionadoOk=true;
            gestionLista.CerrarFrm();
        }

        public void setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda opc)
        {
            this.metodo = opc;
        }

        public void BuscarProducto()
        {
            isProductoSeleccionadoOk=false;
            autoProductoSeleccionado = "";
            filtros.cadena = CadenaPrdBuscar;
            switch(metodo)
            {
                case Controlador.GestionProductoBuscar.metodoBusqueda.Codigo:
                    filtros.MetodoBusqueda = OOB.LibCompra.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
                    break;
                case Controlador.GestionProductoBuscar.metodoBusqueda.Nombre:
                    filtros.MetodoBusqueda = OOB.LibCompra.Producto.Enumerados.EnumMetodoBusqueda.Nombre;
                    break;
                case Controlador.GestionProductoBuscar.metodoBusqueda.Referencia:
                    filtros.MetodoBusqueda = OOB.LibCompra.Producto.Enumerados.EnumMetodoBusqueda.Referencia;
                    break;
            }
            if (filtros.IsActivarBusquedaOk())
                RealizarBusqueda();
            filtros.Limpiar();
        }

        private void RealizarBusqueda()
        {
            var r01 = Sistema.MyData.Producto_GetLista(filtros);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            gestionLista.setLista(r01.Lista);
            gestionLista.Inicia();
        }

    }

}