using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.ListaAdm.CajaMov
{
    public class Imp : IRepListAdm
    {
        private string _filtros;
        private List<srcTransporte.Caja.Administrador.Vistas.IdataItem> _lst;


        public Imp()
        {
            _filtros = "";
            _lst = new List<srcTransporte.Caja.Administrador.Vistas.IdataItem>(); 
        }
        public void Generar()
        {
            imprimir();
        }
        public void setFiltrosBusq(string filtros)
        {
            _filtros = filtros;
        }
        public void setDataCargar(IEnumerable<object> lst)
        {
            _lst.Clear();
            foreach (var rg in lst)
            {
                _lst.Add((srcTransporte.Caja.Administrador.Vistas.IdataItem)rg);
            }
        }


        private void imprimir()
        {
        }
    }
}