using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Caja.Maestro
{
    public class Imp: Utils.Maestro.IMaestro
    {
        private Utils.Maestro.ILista _lista;


        public Utils.Maestro.ILista Lista { get { return _lista; } }
        public string TituloMaestro_Get { get { return "Maestro: CAJAS"; } }
        public BindingSource DataSource_Get { get { return _lista.DataSource_Get; } }
        public int CntItems_Get { get { return _lista.CntItems_Get; } }


        public Imp()
        {
            _lista = new ImpLista();
        }


        public void Inicializa()
        {
            _lista.Inicializa();
        }
        Utils.Maestro.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new  Utils.Maestro.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        //private AgregarEditar.Vistas.IAgregar _agregar;
        public void AgregarItem()
        {
            //if (_agregar == null) 
            //{
            //    _agregar = new AgregarEditar.Handlers.Agregar.Imp();
            //}
            //_agregar.Inicializa();
            //_agregar.Inicia();
            //if (_agregar.ProcesarIsOK) 
            //{
            //    InsertarItemLista(_agregar.IdConceptoAgregado);
            //}
        }
        //private AgregarEditar.Vistas.IEditar _editar;
        public void EditarItem()
        {
            //if (_lista.ItemActual != null)
            //{
            //    if (_editar == null)
            //    {
            //        _editar  = new AgregarEditar.Handlers.Editar.Imp();
            //    }
            //    var _item = ((data)_lista.ItemActual);
            //    _editar.Inicializa();
            //    _editar.setConceptoEditar(_item.Ficha.id);
            //    _editar.Inicia();
            //    if (_editar.ProcesarIsOK) 
            //    {
            //        ActualizarItemLista(_item.Ficha.id);
            //    }
            //}
        }


        private bool cargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Caja_GetLista();
                var _lst = new List<data>();
                foreach (var rg in r01.Lista.OrderBy(o => o.descripcion).ToList())
                {
                    var _data = new data(rg);
                    _lst.Add(_data);
                }
                _lista.setDataCargar(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void InsertarItemLista(int idItem)
        {
            try
            {
                var xr1 = Sistema.MyData.Transporte_Documento_Concepto_GetById(idItem);
                var _data = new data(xr1.Entidad);
                _lista.AgregarItem(_data);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        private void ActualizarItemLista(int idItem)
        {
            try
            {
                var xr1 = Sistema.MyData.Transporte_Documento_Concepto_GetById(idItem);
                var _data = new data(xr1.Entidad);
                _lista.RemoverItemBy(_data);
                _lista.AgregarItem(_data);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}