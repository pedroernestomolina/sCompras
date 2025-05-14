using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelDocumentos.modelos
{
    public class MDocumentos: __.Modelos.PanelDocumentos.IMDocumentos
    {
        private string _infoEntidad;
        private __.Modelos.PanelPrincipal.IItemDesplegar _itemEntidad;
        private List<__.Modelos.PanelDocumentos.IItemDesplegar> _itemsDoc;
        //
        public IEnumerable<__.Modelos.PanelDocumentos.IItemDesplegar> GetItems { get { return _itemsDoc; } }
        public int GetCantDoc { get { return _itemsDoc.Count(); } }
        public decimal GetMontoResta { get { return _itemsDoc.Sum(s => s.MontoPendiente); } }
        public decimal GetMontoAcumulado { get { return _itemsDoc.Sum(s=>s.MontoAcumulado); } }
        public decimal GetMontoImporte { get { return _itemsDoc.Sum(s => s.MontoDeuda); } }
        public string GetEntidadInfo { get { return infoEntidad(); } }
        //
        public MDocumentos()
        {
            _infoEntidad = "";
            _itemsDoc = new List<__.Modelos.PanelDocumentos.IItemDesplegar>();
        }
        public void Inicializa()
        {
            _infoEntidad = "";
            _itemsDoc.Clear();
        }
        public void setItemCargar(__.Modelos.PanelPrincipal.IItemDesplegar item)
        {
            _itemEntidad = item;
            var _it = (PanelPrincipal._Inicio.modelos.ItemDesplegar)_itemEntidad;
            var _lst = new List<__.Modelos.PanelDocumentos.IItemDesplegar>();
            foreach (var doc in _it.Documentos.Where(w => w.signoDoc == 1).OrderBy(o => o.fechaEmision).ToList())
            {
                var nr = new modelos.ItemDesplegar()
                {
                    docId = doc.idDocOrigen,
                    docNumero = doc.docNro,
                    docTipo = doc.tipoDoc,
                    docFechaEmision = doc.fechaEmision,
                    docFechaVence = doc.fechaVence,
                    diasVencida = doc.diasVencida > 0 ? doc.diasVencida.ToString("n0") + " Dias" : "Por Vencer",
                    docDiasVencimiento = doc.diasCredito,
                    MontoDeuda = doc.importeDiv,
                    MontoAcumulado = doc.acumuladoDiv,
                    MontoPendiente = doc.restaDiv,
                    docNotas = doc.notasDoc,
                };
                _lst.Add(nr);
            }
            _itemsDoc = _lst;
        }
        //
        private string infoEntidad()
        {
            _infoEntidad = "";
            if (_itemEntidad != null) 
            {
                _infoEntidad += _itemEntidad.CiRifEntidad + Environment.NewLine;
                _infoEntidad += _itemEntidad.NombreEntidad + Environment.NewLine;
            }
            return _infoEntidad;
        }
    }
}