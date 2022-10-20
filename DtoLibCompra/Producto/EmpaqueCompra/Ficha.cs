using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.Producto.EmpaqueCompra
{
    
    public class Ficha
    {

        public string autoPrd{ get; set; }
        public string descPrd { get; set; }
        public string autoEmpCompra { get; set; }
        public int contEmpCompra { get; set; }
        public string descEmpCompra { get; set; }
        public string decEmpCompra { get; set; }
        public string autoEmpInv { get; set; }
        public int contEmpInv { get; set; }
        public string descEmpInv { get; set; }
        public string decEmpInv { get; set; }


        public Ficha()
        {
            autoPrd = "";
            descPrd = "";
            autoEmpCompra = "";
            contEmpCompra = 0;
            descEmpCompra = "";
            decEmpCompra= "";
            autoEmpInv = "";
            contEmpInv = 0;
            descEmpInv = "";
            decEmpInv = "";
        }

    }

}