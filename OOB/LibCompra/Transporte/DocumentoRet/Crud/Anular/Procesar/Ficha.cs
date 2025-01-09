using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar
{
    public class Ficha
    {
        public List<Auditoria> auditorias { get; set; }
        public Proveedor proveedor { get; set; }
        public CxP_DocOrigen cxpDocOrigen { get; set; }
        public CxP_IR cxpIR { get; set; }
        public CompraRetencion compraRet { get; set; }
    }
}