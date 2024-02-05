using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.CtrlPrecio
{
    public class data: Idata
    {
        private decimal _utilidadVieja;
        private decimal _precioViejo;
        private bool _precioViejoIsNeto;
        private string _descripcion;
        //
        public decimal Utilidad { get; set; }
        public decimal PNeto { get; set; }
        public decimal PFull { get; set; }
        public decimal CostoxUnd { get; set; }
        public int ContEmpVta { get; set; }
        public decimal TasaIva { get; set; }
        public enumerados.enumMetCalculoUtilidad MetCalculoUt { get; set; }
        //
        public decimal PrecioViejoParaComprar { get { return _precioViejo; } }
        public bool PrecioViejoParaComprarIsNeto { get { return _precioViejoIsNeto; } }
        public decimal UtilidadAnterior { get { return _utilidadVieja; } }
        public bool UtilidadIsError { get { return Utilidad < 0m; } }
        public string Descripcion { get { return _descripcion; } }
        public bool CambioPrecioIsOk 
        {
            get 
            {
                var pv = Math.Round(_precioViejo, 2, MidpointRounding.AwayFromZero);
                var pnuevo = 0m;
                if (_precioViejoIsNeto)
                {
                    pnuevo = Math.Round(PNeto, 2, MidpointRounding.AwayFromZero);
                }
                else 
                {
                    pnuevo = Math.Round(PFull, 2, MidpointRounding.AwayFromZero);
                }
                return Math.Abs(pv - pnuevo) > 0m;
            }
        }
        //
        public data()
        {
            _utilidadVieja=0m;
            _precioViejo = 0m;
            _precioViejoIsNeto = false;
            _descripcion = "";
            //
            Utilidad = 0m;
            PNeto = 0m;
            PFull = 0m;
            ContEmpVta = 0;
            CostoxUnd = 0m;
            TasaIva = 0m;
            MetCalculoUt = enumerados.enumMetCalculoUtilidad.SinDefinir;
        }
        public data(decimal costoxUnd, int contEmpVta, decimal tasaIva, enumerados.enumMetCalculoUtilidad met)
        {
            _utilidadVieja = 0m;
            _precioViejo = 0m;
            _precioViejoIsNeto = false;
            _descripcion = "";
            //
            Utilidad = 0m;
            PNeto = 0m;
            PFull = 0m;
            this.CostoxUnd = costoxUnd;
            this.ContEmpVta = contEmpVta;
            this.TasaIva = tasaIva;
            this.MetCalculoUt = met;
        }
        public data(Idata data)
        {
            _utilidadVieja = data.UtilidadAnterior;
            _precioViejo = data.PrecioViejoParaComprar;
            _precioViejoIsNeto = data.PrecioViejoParaComprarIsNeto;
            _descripcion = data.Descripcion;
            //
            Utilidad = data.Utilidad;
            PNeto = data.PNeto;
            PFull = data.PFull;
            CostoxUnd = data.CostoxUnd ;
            ContEmpVta = data.ContEmpVta;
            TasaIva = data.TasaIva;
            MetCalculoUt = data.MetCalculoUt;
        }
        public void Inicializa()
        {
            _utilidadVieja = 0m;
            _precioViejo = 0m;
            _precioViejoIsNeto = false;
            _descripcion = "";
            //
            Utilidad = 0m;
            PNeto = 0m;
            PFull = 0m;
            ContEmpVta = 0;
            CostoxUnd = 0m;
            TasaIva = 0m;
            MetCalculoUt = enumerados.enumMetCalculoUtilidad.SinDefinir;
        }
        public void UtilidadVieja(decimal ut)
        {
            _utilidadVieja= ut;
        }
        public void setPrecioViejo(decimal precio, bool isNeto)
        {
            _precioViejo = precio;
            _precioViejoIsNeto = isNeto;
        }
        public void setDescripcion(string desc)
        {
            _descripcion = desc;
        }
    }
}