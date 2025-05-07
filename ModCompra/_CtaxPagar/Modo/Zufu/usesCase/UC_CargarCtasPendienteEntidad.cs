using ModCompra._CtaxPagar.Modo.Zufu.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public class UC_CargarCtasPendienteEntidad: ICargarCtasPendienteEntidad
    {
        private OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro _filtro;
        private Interfaces.IZufuLista _lista;
        private string _idEntidad;
        //
        public void setIdEntidad(string idEntidad)
        {
            _idEntidad = idEntidad;
        }
        public void setListaDestino(Interfaces.IZufuLista listaDestino)
        {
            _lista = listaDestino;
        }
        public void Execute()
        {
            var _filtro = new OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro()
            {
                IdEntidad = _idEntidad,
            };
            var r01 = Sistema.MyData.Transporte_CxpDoc_GetLista_DocPend(_filtro);
            var lst = r01.Lista
                .Select(s => new dataItemCtaPendEntidad(s))
                .ToList();
            _lista.CargarData(lst);
        }
    }
}