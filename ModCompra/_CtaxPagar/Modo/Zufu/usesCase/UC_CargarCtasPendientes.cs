using ModCompra._CtaxPagar.Modo.Zufu.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public class UC_CargarCtasPendientes: ICargarCtasPendientes
    {
        private OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro _filtro;
        private Interfaces.IZufuLista _lista;
        //
        public void setFiltro(OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro filtro)
        {
            _filtro = filtro;
        }
        public void setListaDestino(Interfaces.IZufuLista listaDestino)
        {
            _lista = listaDestino;
        }
        public void Execute()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_CxpDoc_GetLista_DocPend(_filtro);
                var lst = r01.Lista
                    .GroupBy(g => new { g.idEntidad, g.ciRif, g.nombreRazonSocial })
                    .Select(s => new dataItemDocPend()
                    {
                        IdEntidad = s.Key.idEntidad,
                        CiRifEntidad = s.Key.ciRif,
                        NombreEntidad = s.Key.nombreRazonSocial,
                        MontoDeuda = s.Where(w => w.signoDoc == 1).Sum(ss => ss.importeDiv),
                        MontoCredito = s.Where(w => w.signoDoc == -1).Sum(ss => ss.importeDiv),
                        MontoAcumulado = s.Sum(ss => ss.acumuladoDiv),
                        CntDocDeuda = s.Where(w => w.signoDoc == 1).Count(),
                    })
                    .OrderBy(o => o.NombreEntidad)
                    .ToList();
                _lista.CargarData(lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}