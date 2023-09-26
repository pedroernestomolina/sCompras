using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Handlers
{
    public class hndEnt: Vistas.IEnt
    {
        private decimal _factorCambio;
        private DateTime _fechaServidor;
        private Vistas.IServ _hndServ;
        private Vistas.IGestPag _hndGestPag;


        public Vistas.IGestPag GestPago { get { return _hndGestPag; } }
        public decimal Get_MontoPendiente { get { return _hndServ.Get_MontoPendiente; } }
        public Vistas.IServ Servicios { get { return _hndServ; } }
        public decimal Get_AliadoAnticipos { get { return _hndGestPag.Get_AliadoAnticipos; } }
        public string Get_AliadoInfo { get { return _hndGestPag.Get_AliadoInfo; } }


        public hndEnt()
        {
            _fechaServidor = DateTime.Now.Date;
            _factorCambio = 0m;
            _hndServ= new hndServ();
            _hndGestPag = new hndGestPag();
        }
        public void Inicializa()
        {
            _hndServ.Inicializa();
            _hndGestPag.Inicializa();
        }
        public void CargarData()
        {
            _hndGestPag.CargarData();
            _hndServ.CargarData();
        }
        public void setAliado(OOB.LibCompra.Transporte.Aliado.Entidad.Ficha ficha)
        {
            _hndGestPag.setAliado(ficha);
        }
        public void setTasaCambio(decimal factor)
        {
            _factorCambio = factor;
            _hndGestPag.setTasaFactorCambio(factor);
        }
        public void setFechaServidor(DateTime fecha)
        {
            _fechaServidor = fecha;
            _hndGestPag.setFechaServidor(fecha);
        }
        public void setServicios(List<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha> list)
        {
            var _lst = new List<Vistas.IdataServ>();
            foreach (var rg in list) 
            {
                _lst.Add(new dataServ(rg));
            }
            _hndServ.setDataCargar(_lst);
        }
    }
}