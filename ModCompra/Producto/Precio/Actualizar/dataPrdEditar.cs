using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.Actualizar
{
    
    public class dataPrdEditar
    {

        public decimal TasaIva { get; set; }
        public bool AdmDivisa { get; set; }
        public int ContEmpCompra { get; set; }
        public string  CodigoPrd { get; set; }
        public string  DescripcionPrd { get; set; }
        public string  AutoPrd { get; set; }
        public decimal CostoMonedaLocal {get;set;}
        public decimal CostoMonedaDivisa {get;set;}
        public string EmpCompraDescripcion { get; set; }


        public dataPrdEditar() 
        {
            TasaIva = 0m;
            AdmDivisa = false;
            ContEmpCompra = 0;
            CodigoPrd = "";
            DescripcionPrd = "";
            AutoPrd = "";
            CostoMonedaDivisa = 0m;
            CostoMonedaLocal = 0m;
            EmpCompraDescripcion = "";
        }

    }

}
