using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPagoDocumentos.modelos
{
    public class ItemDesplegar : __.Modelos.GestionPagoDocumentos.IItemDesplegar
    {
        private __.Modelos.GestionPago.IDoc _ficha;
        //
        public string docId { get; set; }
        public string docNumero { get; set; }
        public string docTipo { get; set; }
        public DateTime docFechaEmision { get; set; }
        public DateTime docFechaVence { get; set; }
        public decimal Importe { get; set; }
        public decimal Resta { get; set; }
        public decimal MontoAAbonar { get; set; }
        public string NotasDelAbono { get; set; }
        public string diasVencida { get; set; }
        public __.Modelos.GestionPago.IDoc Ficha { get { return _ficha; } }
        //
        public ItemDesplegar(__.Modelos.GestionPago.IDoc rg)
        {
            _ficha = rg;
            docId = rg.idDocOrigen;
            docNumero = rg.docNro;
            docTipo = rg.tipoDoc;
            docFechaEmision = rg.fechaEmision;
            docFechaVence = rg.fechaVence;
            Importe = rg.importeDiv;
            Resta = rg.restaDiv;
            diasVencida = rg.diasvencida > 0 ? rg.diasvencida.ToString("n0") + " Dias" : "Por Vencer";
            MontoAAbonar = 0m;
            NotasDelAbono = "";
        }
    }
}