using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Producto.EmpaqueCompra
{
    
    public class Ficha
    {

        public string  autoEmp { get; set; }
        public int contEmp { get; set; }
        public string nombreEmp { get; set; }
        public string decimalesEmp  { get; set; }
        public bool isEmpPredeterminado { get; set; }


        public Ficha()
        {
            autoEmp = "";
            contEmp = 0;
            nombreEmp = "";
            decimalesEmp = "";
            isEmpPredeterminado = false;
        }

    }

}