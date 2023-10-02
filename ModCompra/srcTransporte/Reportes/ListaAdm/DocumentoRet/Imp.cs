using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.ListaAdm.DocumentoRet
{
    public class Imp : IRepListAdm
    {
        private string _filtros;
        private List<Retencion.Administrador.Vistas.IdataItem> _lst;


        public Imp()
        {
            _filtros = "";
            _lst = new List<Retencion.Administrador.Vistas.IdataItem>();
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
                _lst.Add((Retencion.Administrador.Vistas.IdataItem)rg);
            }
        }


        private void imprimir()
        {
        }
    }
}