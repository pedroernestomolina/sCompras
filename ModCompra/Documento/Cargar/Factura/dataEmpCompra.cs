using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class dataEmpCompra
    {

        private string _id;
        private OOB.LibCompra.Producto.EmpaqueCompra.Ficha _f;


        public string id { get { return _id; } }
        public string desc { get { return _f.nombreEmp; } }
        public OOB.LibCompra.Producto.EmpaqueCompra.Ficha EmpCompra { get { return _f; } }


        public dataEmpCompra(OOB.LibCompra.Producto.EmpaqueCompra.Ficha f, string id)
        {
            _id = id;
            _f= f;
        }
        
    }

}