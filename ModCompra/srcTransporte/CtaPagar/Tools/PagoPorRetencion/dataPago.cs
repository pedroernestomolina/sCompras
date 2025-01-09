using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoPorRetencion
{
    public class dataPago
    {
        private bool _habilitarRetIva;
        private bool _habilitarRetIslr;
        private bool _aplicaRetIva;
        private bool _aplicaRetIslr;
        private decimal _tasaRetIva;
        private decimal _tasaRetIslr;
        private decimal _sustraendo;
        //
        public bool GetHabailitarRetIva { get { return _habilitarRetIva; } }
        public bool GetHabailitarRetIslr { get { return _habilitarRetIslr; } }
        public decimal GetTasaRetIva { get { return _tasaRetIva; } }
        public decimal GetTasaRetIslr { get { return _tasaRetIslr; } }
        public decimal GetSustraendo { get { return _sustraendo; } }
        public bool GetAplicarRetIva { get { return _aplicaRetIva; } }
        public bool GetAplicarRetIslr { get { return _aplicaRetIslr; } }
        //
        public dataPago() 
        {
            limpiar();
        }
        public void Inicializa()
        {
            limpiar();
        }
        public void setHabilitarRetIva(bool modo)
        {
            _habilitarRetIva = modo;
        }
        public void setHabilitarRetIslr(bool modo)
        {
            _habilitarRetIslr = modo;
        }
        public void setRetIva()
        {
            _aplicaRetIva = !_aplicaRetIva;
        }
        public void setRetIslr()
        {
            _aplicaRetIslr = !_aplicaRetIslr;
        }
        public void setTasaRetIva(decimal tasa)
        {
            _tasaRetIva = tasa;
        }
        public void setTasaRetIslr(decimal tasa)
        {
            _tasaRetIslr = tasa;
        }
        public void setSustraendo(decimal monto)
        {
            _sustraendo = monto;
        }
        //
        private void limpiar() 
        {
            _habilitarRetIslr = false;
            _habilitarRetIva = false;
            _aplicaRetIslr = false;
            _aplicaRetIva = false;
            _tasaRetIslr = 0m;
            _tasaRetIva = 0m;
            _sustraendo = 0m;
        }
    }
}