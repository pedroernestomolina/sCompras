using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.Actualizar
{
    
    public class dataPrecioGuardar
    {

        public string autoEmpaque { get; set; }
        public int contEmpaque { get; set; }
        public string descEmpaque { get; set; }
        public decimal utilidad { get; set; }
        public decimal pNeto { get; set; }
        public decimal pFull { get; set; }


        public dataPrecioGuardar()
        {
            autoEmpaque = "";
            contEmpaque = 1;
            descEmpaque = "";
            utilidad = 0m;
            pNeto = 0m;
            pFull = 0m;
        }


        public void setData(string idEpaque , int cont, decimal ut, decimal neto, decimal full, string empaque)
        {
            autoEmpaque = idEpaque;
            contEmpaque = cont;
            descEmpaque = empaque;
            utilidad = ut;
            pNeto = neto;
            pFull = full;
        }

    }

}