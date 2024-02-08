using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.CtrlPrecio
{
    public class ImpPrecio: IPrecio
    {
        private decimal _costoxUnd;
        private int _contEmpVta;
        private decimal _tasaIva;
        private decimal _costoActual;
        private decimal _utActual;
        private decimal _pNetoActual;
        private decimal _pFullActual;
        private Idata _data;
        private enumerados.enumMetCalculoUtilidad _metodoCalculo;
        //
        public Idata Data { get { return _data; } }
        //
        public ImpPrecio(decimal costoxUnd, int contEmpVta, decimal tasaIva, enumerados.enumMetCalculoUtilidad met)
        {
            _costoActual = 0m;
            //
            _utActual = 0m;
            _pNetoActual = 0m;
            _pFullActual = 0m;
            _data = new data(costoxUnd, contEmpVta, tasaIva, met);
            //
            _costoxUnd = costoxUnd;
            _contEmpVta = contEmpVta;
            _tasaIva = tasaIva;
            _metodoCalculo = met;
            //
            _costoActual = calculaCostoActual(_costoxUnd, _contEmpVta);
        }
        //cuando se necesite cargar un precio 
        public ImpPrecio(IPrecio precio)
        {
            _costoActual = 0m;
            //
            _utActual = precio.Data.Utilidad;
            _pNetoActual = precio.Data.PNeto;
            _pFullActual = precio.Data.PFull;
            _data = new data(precio.Data);
            //
            _costoxUnd = precio.Data.CostoxUnd;
            _contEmpVta = precio.Data.ContEmpVta;
            _tasaIva = precio.Data.TasaIva;
            _metodoCalculo = precio.Data.MetCalculoUt;
            //
            _costoActual = calculaCostoActual(_costoxUnd, _contEmpVta);
        }
        //cuando se necesite cargar un precio pero con un nuevo costo
        public ImpPrecio(IPrecio precio, decimal costoUnd) 
        {
            _costoActual = 0m;
            //
            _utActual = precio.Data.Utilidad;
            _pNetoActual = precio.Data.PNeto;
            _pFullActual = precio.Data.PFull;
            _data = new data(precio.Data);
            //
            _costoxUnd = costoUnd;
            _contEmpVta = precio.Data.ContEmpVta;
            _tasaIva = precio.Data.TasaIva;
            _metodoCalculo = precio.Data.MetCalculoUt;
            //
            _costoActual = calculaCostoActual(_costoxUnd, _contEmpVta);
        }
        //cuando se necesite restaurar un precio
        public ImpPrecio(decimal costoxUnd, int contEmpVta, decimal tasaIva, enumerados.enumMetCalculoUtilidad met, decimal pneto)
        {
            _costoActual = 0m;
            //
            _utActual = 0m;
            _pNetoActual = 0m;
            _pFullActual = 0m;
            _data = new data(costoxUnd, contEmpVta, tasaIva, met);
            //
            _costoxUnd = costoxUnd;
            _contEmpVta = contEmpVta;
            _tasaIva = tasaIva;
            _metodoCalculo = met;
            //
            _costoActual = calculaCostoActual(_costoxUnd, _contEmpVta);
            //
            setNeto(pneto);
        }
        public void Inicializa()
        {
            _utActual = 0m;
            _pNetoActual = 0m;
            _pFullActual = 0m;
            _data.Inicializa();
        }
        public void setUtilidad(decimal ut)
        {
            _utActual= ut;
            _pNetoActual = calculaPNetoEnBaseUtilidad(_costoActual, ut);
            _pFullActual = calculaPrecioFull(_pNetoActual, _tasaIva);
            refreshData();
        }
        public void setNeto(decimal neto)
        {
            _pNetoActual = neto;
            _utActual= calculaUtilidadEnBaseNeto(neto, _costoActual);
            _pFullActual = calculaPrecioFull(_pNetoActual, _tasaIva);
            refreshData();
        }
        public void setFull(decimal full)
        {
            _pFullActual = full;
            _pNetoActual = obtenerNeto(full, _tasaIva);
            _utActual = calculaUtilidadEnBaseNeto(_pNetoActual, _costoActual);
            refreshData();
        }
        public void setUtilidadVieja(decimal ut)
        {
            _data.UtilidadVieja(ut);
        }
        public void setPrecioViejo(decimal precioViejo, bool isNeto)
        {
            _data.setPrecioViejo(precioViejo, isNeto);
        }
        public void setDescripcion(string desc)
        {
            _data.setDescripcion(desc);
        }
        //
        private decimal calculaUtilidadEnBaseNeto(decimal neto, decimal costo)
        {
            var rt = 0m;
            if (neto > 0m) 
            {
                if (_metodoCalculo == enumerados.enumMetCalculoUtilidad.Financiero)
                {
                    rt = (1m - (costo / neto)) * 100m;
                }
                else 
                {
                    if (costo > 0) 
                    {
                        rt = ((neto / costo) * 100m) - 100m;
                    }
                }
            }
            return rt;
        }
        private decimal calculaPNetoEnBaseUtilidad(decimal costo, decimal ut)
        {
            var neto = 0m;
            if (ut > 0m)
            {
                if (_metodoCalculo == enumerados.enumMetCalculoUtilidad.Financiero)
                {
                    var dif = (100m - _utActual) / 100m;
                    if (dif > 0m)
                    {
                        neto = costo / dif;
                    }
                }
                else
                {
                    var porct = (1m + (ut / 100m));
                    neto = costo * porct;
                }
            }
            return neto;
        }
        private decimal obtenerNeto(decimal precio, decimal tasaIva)
        {
            var neto = precio;
            if (tasaIva > 0m)
            {
                var tasa = (1m + (tasaIva / 100m));
                neto = precio / tasa;
            }
            return neto;
        }
        private decimal calculaPrecioFull(decimal precio, decimal tasaIva)
        {
            var precioFull = precio;
            if (tasaIva > 0m) 
            {
                var iva = (tasaIva / 100) * precio;
                precioFull += iva;
            }
            return precioFull;
        }
        private decimal calculaCostoActual(decimal costoxUnd, int contEmp)
        {
            return (_costoxUnd * contEmp);
        }
        private void refreshData()
        {
            _data.Utilidad = _utActual;
            _data.PNeto = _pNetoActual;
            _data.PFull = _pFullActual;
        }
        public void ActualizarImportacion()
        {
            var neto= _pNetoActual;
            _utActual= calculaUtilidadEnBaseNeto(neto, _costoActual);
            _pFullActual = calculaPrecioFull(_pNetoActual, _tasaIva);
            refreshData();
        }
        //
        public bool VerificarPrecio(decimal costoUnd)
        {
            return (costoUnd * _contEmpVta) > _pNetoActual;
        }
    }
}