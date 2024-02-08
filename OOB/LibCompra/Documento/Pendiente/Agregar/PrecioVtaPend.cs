using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibCompra.Documento.Pendiente.Agregar
{
    public class PrecioVtaPend
    {
        public int idEmpqVta { get; set; }
        public string descEmpVta { get; set; }
        public int contEmpVta { get; set; }
        public decimal[] precios { get; set; }
        public PrecioVtaPend()
        {
            idEmpqVta = -1;
            descEmpVta = "";
            contEmpVta = 0;
            precios = new decimal[] { 0, 0, 0, 0 };
        }
    }
}