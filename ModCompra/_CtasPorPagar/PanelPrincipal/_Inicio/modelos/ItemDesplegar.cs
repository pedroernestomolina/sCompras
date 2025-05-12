using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.modelos
{
    public class ItemDesplegar: IItemDesplegar
    {
        public string IdEntidad { get; set; }
        public string CiRifEntidad { get; set; }
        public string NombreEntidad { get; set; }
        public decimal MontoDeuda { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal MontoAcumulado { get; set; }
        public int CntDocDeuda { get; set; }
        public decimal MontoPendiente { get { return MontoDeuda - MontoAcumulado; } }
        public List<OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha> Documentos{ get; set; }
    }
}