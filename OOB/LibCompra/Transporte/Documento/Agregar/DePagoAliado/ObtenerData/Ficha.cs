using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Agregar.DePagoAliado.ObtenerData
{
    public class Ficha
    {
        public int idPago { get; set; }
        public int idAliado { get; set; }
        public string nroRecibo { get; set; }
        public decimal totalMonAct { get; set; }
        public decimal totalMonDiv { get; set; }
        public decimal tasaCambio { get; set; }
        public decimal tasaRet { get; set; }
        public decimal retencion { get; set; }
        public decimal sustraendo { get; set; }
        public decimal totalRetMonAct { get; set; }
        public decimal totalRetMonDiv { get; set; }
    }
}