using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPagoDocumentos.modelos
{
    public class Modelo: __.Modelos.GestionPagoDocumentos.IModelo
    {
        private string _infoEntidad;
        private List<ItemDesplegar> _items;
        //
        IEnumerable<__.Modelos.GestionPagoDocumentos.IItemDesplegar> __.Modelos.GestionPagoDocumentos.IModelo.GetItems { get { return _items; } }
        public int GetCantDocPend { get { return _items.Count(); } }
        public decimal GetMontoPend{ get { return _items.Sum(s => s.Resta); } }
        public decimal GetMontoAbonado{ get { return _items.Sum(s=>s.MontoAAbonar); } }
        public int GetCantDocAbonado{ get { return _items.Count(c => c.MontoAAbonar>0m); } }
        public string GetEntidadInfo { get { return _infoEntidad; } }
        //
        public Modelo()
        {
            _infoEntidad = "";
            _items = new List<ItemDesplegar>();
        }
        public void Inicializa()
        {
            _infoEntidad = "";
            _items.Clear();
        }
        public void setDataCargar(string p, IEnumerable<__.Modelos.GestionPago.IDoc> doc)
        {
            _infoEntidad = p;
            _items.Clear();
            foreach (var rg in doc)
            {
                var nr = new ItemDesplegar(rg);
                _items.Add(nr);
            }
        }
        public void LimpiarAbonos()
        {
            foreach (var rg in _items)
            {
                rg.MontoAAbonar = 0m;
                rg.NotasDelAbono = "";
            }
        }
    }
}