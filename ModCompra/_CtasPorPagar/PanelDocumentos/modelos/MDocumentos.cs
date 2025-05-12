using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
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
        private IItemDesplegar _item;
        private __.Modelos.PanelDocumentos.IListaIDesplegar _listaDesplegar;
        private __.UsesCase.PanelDocumentos.IVisualizarDoc _visualizarDoc;
        private __.UsesCase.PanelDocumentos.IReporteDoc _repDoc;
        //
        public int GetCantDoc { get { return ListaDesplegar.GetCntItems; } }
        public decimal GetMontoResta { get { return ListaDesplegar.Items.Sum(s=>s.MontoPendiente); } }
        public decimal GetMontoAcumulado { get { return ListaDesplegar.Items.Sum(s=>s.MontoAcumulado); } }
        public decimal GetMontoImporte { get { return ListaDesplegar.Items.Sum(s=>s.MontoDeuda);} }
        public string GetEntidadInfo { get { return infoEntidad(); } }
        public __.Modelos.PanelDocumentos.IItemDesplegar ItemActual { get { return ListaDesplegar.ItemActual; } }
        public object GetDataSource { get { return ListaDesplegar.GetDataSource; } }
        public __.Modelos.PanelDocumentos.IListaIDesplegar ListaDesplegar { get { return _listaDesplegar; } }
        //
        public MDocumentos()
        {
            _listaDesplegar = new ListaIDesplegar();
            _visualizarDoc = new usesCase.uc_VisualizarDoc();
            _repDoc = new usesCase.uc_ReporteDoc();
        }
        public void Inicializa()
        {
            _listaDesplegar.Inicializa();
        }
        public void setItemCargar(IItemDesplegar item)
        {
            _item=item;
            var _it= (PanelPrincipal._Inicio.modelos.ItemDesplegar)_item;
            var _lst = new List<__.Modelos.PanelDocumentos.IItemDesplegar>();
            foreach (var doc in _it.Documentos.Where(w=>w.signoDoc==1).OrderBy(o=>o.fechaEmision).ToList())
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
            _listaDesplegar.CargarItems(_lst);
        }
        public void VisualizarDocumento(__.Modelos.PanelDocumentos.IItemDesplegar item)
        {
            if (item == null) return;
            _visualizarDoc.setIdDocVisualizar(item.docId);
            _visualizarDoc.Execute();
        }
        public void ReporteDocumentos()
        {
            _repDoc.setInfoEntidad(_infoEntidad);
            _repDoc.setData(_listaDesplegar.Items);
            _repDoc.Execute();
        }
        //
        private string infoEntidad()
        {
            _infoEntidad = "";
            if (_item != null) 
            {
                _infoEntidad += _item.CiRifEntidad + Environment.NewLine;
                _infoEntidad += _item.NombreEntidad + Environment.NewLine;
            }
            return _infoEntidad;
        }
    }
}