using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Handlers
{
    public class data: Vistas.Idata
    {
        private Vistas.IdataCtasPend _ctasPendientes;


        public Utils.Tools.IdataCtasPendientes CtasPendientes { get { return _ctasPendientes; } }


        public data()
        {
            _ctasPendientes = new dataCtasPend();
        }
        public void Inicializa()
        {
            _ctasPendientes.Inicializa();
        }


        private Anticipos.Agregar.Vistas.IAnticipo _anticipo;
        public void AgregarAnticipo()
        {
            if (_ctasPendientes.ItemActual != null)
            {
                if (_anticipo == null)
                {
                    _anticipo = new Anticipos.Agregar.Handler.Imp();
                }
                var item= (dataAliado)_ctasPendientes.ItemActual;
                _anticipo.Inicializa();
                _anticipo.setAliadoCargar(item.Id);
                _anticipo.Inicia();
                if (_anticipo.ProcesarIsOK) 
                {
                    ActualizarSaldoAliado(item.Id);
                }
            }
        }
        private PagoServ.Vistas.IPagServ _servPrest;
        public void ServPrestado()
        {
            if (_ctasPendientes.ItemActual != null)
            {
                if (_servPrest == null)
                {
                    _servPrest = new PagoServ.Handlers.Imp();
                }
                var item = (dataAliado)_ctasPendientes.ItemActual;
                _servPrest.Inicializa();
                _servPrest.setServiciosAliado(item.Id);
                _servPrest.Inicia();
                if (_servPrest.ProcesarIsOK) 
                {
                    ActualizarSaldoAliado(item.Id);
                }
            }
        }
        public void ImprimirLista()
        {
            if (_ctasPendientes.Get_CntItem > 0)
            {
                var _items = _ctasPendientes.Get_Items;
                srcTransporte.Reportes.IRepListAdm _rep = new srcTransporte.Reportes.ListaAdm.ToolsAliado.Imp();
                _rep.setFiltrosBusq("");
                _rep.setDataCargar(_items);
                _rep.Generar();
            }
        }
        public void EstadoCuenta()
        {
            if (_ctasPendientes.ItemActual != null)
            {
                var item = (dataAliado)_ctasPendientes.ItemActual;
                srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.CXP.Aliado.EdoCta.Imp();
                _rep.setIdDoc(item.Id);
                _rep.Generar();

                //if (_servPrest == null)
                //{
                //    _servPrest = new PagoServ.Handlers.Imp();
                //}
                //var item = (dataAliado)_ctasPendientes.ItemActual;
                //_servPrest.Inicializa();
                //_servPrest.setServiciosAliado(item.Id);
                //_servPrest.Inicia();
                //if (_servPrest.ProcesarIsOK)
                //{
                //    ActualizarSaldoAliado(item.Id);
                //}
            }
        }


        private void ActualizarSaldoAliado(int id)
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Aliado_Pediente_GetByIdAliado(id);
                var aliadoCta = new dataAliado(r01.Entidad);
                _ctasPendientes.ActualizarSaldo(aliadoCta);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}