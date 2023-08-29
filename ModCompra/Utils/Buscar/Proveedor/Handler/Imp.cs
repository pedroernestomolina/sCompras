using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Buscar.Proveedor.Handler
{
    public class Imp: Vistas.IProveedor
    {
        private string _buscar;
        private data _proveedor;
        private ICtrlLista _lista;


        public ICtrlLista Lista { get { return _lista; } }
        public string Get_Inf { get { return inf(); } }
        public string Get_Buscar { get { return _buscar; } }


        public Imp()
        {
            _buscar = "";
            _proveedor = null;
            _lista = new Handler.ImpLista();
        }


        public void Inicializa()
        {
            _buscar = "";
            _proveedor = null;
            _lista.Inicializa();
        }
        public void SetBuscar(string desc)
        {
            _buscar = desc;
        }
        public void Buscar()
        {
            if (_buscar.Trim() == "") return;
            try
            {
                var filtro = new OOB.LibCompra.Proveedor.Lista.Filtro()
                {
                    cadena = _buscar,
                    MetodoBusqueda = OOB.LibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.Nombre,
                };
                var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                cargarDesplegarLista(r01.Lista);
                _buscar = "";
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void cargarDesplegarLista(List<OOB.LibCompra.Proveedor.Data.Ficha> lst)
        {
            _lista.Inicializa();
            _lista.setDataCargar(lst);
            _lista.Inicia();
            if (_lista.ItemSeleccionadoIsOk) 
            {
                _proveedor = (data)_lista.ItemSeleccionado;
            }
        }
        private string inf()
        {
            var _inf = "";
            if (_proveedor != null)
            {
                _inf = _proveedor.ciRif + Environment.NewLine + _proveedor.nombre + Environment.NewLine + _proveedor.dirFiscal;
            }
            return _inf;
        }
    }
}