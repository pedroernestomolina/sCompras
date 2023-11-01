using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Handler
{
    public class dataItemCtasPend: Vista.IdataItemCtaPend
    {
        private OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha _ficha;
        private decimal _pendiente;


        public string Id { get; set; }
        public string dataCiRif { get; set; }
        public string dataNombreRazonSocial { get; set; }
        public string dataDocNro { get; set; }
        public DateTime dataFechaDoc { get; set; }
        public string dataDocTipo { get; set; }
        public decimal dataImporte { get; set; }
        public decimal dataAcumulado { get; set; }
        public decimal dataResta { get; set; }
        public decimal Get_Pendiente { get { return _pendiente; } }


        public dataItemCtasPend(OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha ficha)
        {
            _ficha = ficha;
            Id = ficha.id;
            dataCiRif = ficha.ciRif;
            dataNombreRazonSocial = ficha.nombreRazonSocial;
            dataDocNro = ficha.docNro;
            dataFechaDoc = ficha.fechaEmision;
            dataDocTipo = ficha.tipoDoc;
            dataImporte = ficha.importeDiv;
            dataAcumulado = ficha.acumuladoDiv;
            dataResta = ficha.restaDiv;
            _pendiente = ficha.restaDiv * ficha.signoDoc;
        }
    }
}