using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Filtros.Proveedor
{
    
    public class Filtro: IFiltro
    {


        private string _cadenaBus;
        private ModCompra.Proveedor.Listar.IListar _gListaPrv;
        private bool _itemSeleccionadoIsOk;
        private ModCompra.Proveedor.Listar.data _itemSeleccionado;


        public Filtro()
        {
            _cadenaBus = "";
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
            _gListaPrv = new ModCompra.Proveedor.Listar.Gestion();
        }

        public void Inicializa()
        {
            _cadenaBus = "";
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
            _gListaPrv.Inicializa();
        }

        public string GetProveedorDesc { get { return _cadenaBus; } }
        public void setCadenaBusq(string desc)
        {
            _cadenaBus = desc;
        }
        public void BuscarProv()
        {
            if (_cadenaBus.Trim() != "") 
            {
                var filtro = new OOB.LibCompra.Proveedor.Lista.Filtro()
                {
                    MetodoBusqueda = OOB.LibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.Nombre,
                    cadena = _cadenaBus,
                };
                var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                ListarProvedores(r01.Lista);
            }
        }

        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionadoIsOk; } }
        private void ListarProvedores(List<OOB.LibCompra.Proveedor.Data.Ficha> lst)
        {
            _itemSeleccionado = null;
            _itemSeleccionadoIsOk = false;
            _gListaPrv.ItemSeleccionadoOk += _gListaPrv_ItemSeleccionadoHnd;
            _gListaPrv.Inicializa();
            _gListaPrv.setLista(lst);
            _gListaPrv.Inicia();
            _gListaPrv.ItemSeleccionadoOk -= _gListaPrv_ItemSeleccionadoHnd;
        }
        void _gListaPrv_ItemSeleccionadoHnd(object sender, EventArgs e)
        {
            _itemSeleccionado = (ModCompra.Proveedor.Listar.data)_gListaPrv.ItemActual;
            _cadenaBus = _itemSeleccionado.nombre;
            _itemSeleccionadoIsOk = true;
            _gListaPrv.Cerrar();
        }

        public string GetProveedorSeleccionadoId { get { return _itemSeleccionado != null ? _itemSeleccionado.auto : ""; } }
        public string GetProveedorSeleccionadoDesc { get { return _itemSeleccionado != null ? _itemSeleccionado.nombre : ""; } }


        public void LimpiarSeleccion()
        {
            _cadenaBus = "";
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
            _gListaPrv.LimpiarSeleccion();
        }

    }

}