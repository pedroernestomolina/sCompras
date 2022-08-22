using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.Actualizar
{
    
    public class dataGuardar
    {

        private decimal _factorDivisa;


        public decimal GetFactorDivisa { get { return _factorDivisa; } }


        public dataPrecioGuardar precio_1_Emp_1 { get; set; }
        public dataPrecioGuardar precio_1_Emp_2 { get; set; }
        public dataPrecioGuardar precio_1_Emp_3 { get; set; }
        //
        public dataPrecioGuardar precio_2_Emp_1 { get; set; }
        public dataPrecioGuardar precio_2_Emp_2 { get; set; }
        public dataPrecioGuardar precio_2_Emp_3 { get; set; }
        //
        public dataPrecioGuardar precio_3_Emp_1 { get; set; }
        public dataPrecioGuardar precio_3_Emp_2 { get; set; }
        public dataPrecioGuardar precio_3_Emp_3 { get; set; }
        //
        public dataPrecioGuardar precio_4_Emp_1 { get; set; }
        public dataPrecioGuardar precio_4_Emp_2 { get; set; }
        public dataPrecioGuardar precio_4_Emp_3 { get; set; }
        //
        public dataPrecioGuardar precio_5_Emp_1 { get; set; }
        public dataPrecioGuardar precio_5_Emp_2 { get; set; }
        public dataPrecioGuardar precio_5_Emp_3 { get; set; }


        public dataGuardar()
        {
            _factorDivisa = 0m;
            //
            precio_1_Emp_1 = new dataPrecioGuardar();
            precio_1_Emp_2 = new dataPrecioGuardar();
            precio_1_Emp_3 = new dataPrecioGuardar();
            //
            precio_2_Emp_1 = new dataPrecioGuardar();
            precio_2_Emp_2 = new dataPrecioGuardar();
            precio_2_Emp_3 = new dataPrecioGuardar();
            //
            precio_3_Emp_1 = new dataPrecioGuardar();
            precio_3_Emp_2 = new dataPrecioGuardar();
            precio_3_Emp_3 = new dataPrecioGuardar();
            //
            precio_4_Emp_1 = new dataPrecioGuardar();
            precio_4_Emp_2 = new dataPrecioGuardar();
            precio_4_Emp_3 = new dataPrecioGuardar();
            //
            precio_5_Emp_1 = new dataPrecioGuardar();
            precio_5_Emp_2 = new dataPrecioGuardar();
            precio_5_Emp_3 = new dataPrecioGuardar();
        }

        public void setFactorDivisa(decimal p)
        {
            _factorDivisa = p;
        }

    }

}