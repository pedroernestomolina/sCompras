using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago
{
    public class Movimiento
    {
        public int  idAliado { get; set; }
        public DateTime fechaEmision { get; set; }
        public string nombreAliado { get; set; }
        public string ciRifAliado { get; set; }
        public string codigoAliado { get; set; }
        public int cntServ { get; set; }
        public string motivo { get; set; }
        public decimal montoMonAct { get; set; }
        public decimal montoMonDiv { get; set; }
        public decimal tasaFactorCambio { get; set; }
        public bool aplicaRet { get; set; }
        public decimal tasaRet { get; set; }
        public decimal retencion  { get; set; }
        public decimal sustraendo { get; set; }
        public decimal montoRetMonAct { get; set; }
        public decimal montoRetMonDiv { get; set; }
        public decimal totalPagMonAct { get; set; }
        public decimal totalPagMonDiv { get; set; }
        public List<Detalle> detalles { get; set; }
        public List<Caja> cajas { get; set; }
    }
}