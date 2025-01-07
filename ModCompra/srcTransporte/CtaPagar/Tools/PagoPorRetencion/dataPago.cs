using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoPorRetencion
{
    public class dataPago
    {
        private bool _aplicaRetIva;
        private bool _aplicaRetIslr;
        private decimal _tasaRetIva;
        private decimal _tasaRetIslr;
        private decimal _sustraendo;
        //
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
            _aplicaRetIslr = false;
            _aplicaRetIva = false;
            _tasaRetIslr = 0m;
            _tasaRetIva = 0m;
            _sustraendo = 0m;
        }
    }
}