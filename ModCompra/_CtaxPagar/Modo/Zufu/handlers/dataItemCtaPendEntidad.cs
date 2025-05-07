using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.handlers
{
    public class dataItemCtaPendEntidad: _CtaxPagar.Interfaces.IdataItemCtaPendEntidad
    {
        private OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha _ficha;
        //
        public string docNumero { get; set; }
        public string docTipo { get; set; }
        public DateTime docFechaEmision { get; set; }
        public DateTime docFechaVence { get; set; }
        public int docDiasVencimiento { get; set; }
        public decimal MontoDeuda { get; set; }
        public decimal MontoAcumulado { get; set; }
        public decimal MontoPendiente { get; set; }
        public string diasVencida { get; set; }
        public OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha Ficha { get { return _ficha; } }
        //
        public dataItemCtaPendEntidad(object s)
        {
            _ficha = (OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha)s;
            docNumero = _ficha.docNro;
            docTipo = _ficha.tipoDoc;
            docFechaEmision = _ficha.fechaEmision;
            docFechaVence = _ficha.fechaVence;
            diasVencida = _ficha.diasVencida>0 ? _ficha.diasVencida.ToString("n0")+" Dias": "Por Vencer";
            docDiasVencimiento = _ficha.diasCredito;
            MontoDeuda = _ficha.importeDiv;
            MontoAcumulado = _ficha.acumuladoDiv;
            MontoPendiente = _ficha.restaDiv;
        }
    }
}