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


        public void CargarCtasPendientes()
        {
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