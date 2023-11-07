using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto
{
    public class Proveedor
    {
        public string autoProv { get; set; }
        public decimal montoDebito { get; set; }
        public DateTime fechaEmiDoc { get; set; }
        public decimal montoCredito { get; set; }
    }
}