using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar
{
    public class CompraRetencion
    {
        public string idDocCompra { get; set; }
        public string idDocCompraRet { get; set; }
        public bool isRetIva { get; set; }
    }
}
