using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using ModCompra._CtasPorPagar.__.UsesCase.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.usesCase
{
    public class uc_CargarCtas : ICargarCuentas
    {
        private IFiltroBusqueda _filtro;
        //
        public void setFiltro(IFiltroBusqueda filtro)
        {
            _filtro = filtro;
        }
        //
        IEnumerable<IItemDesplegar>
            ICargarCuentas.Execute()
        {
            var lst = new List<IItemDesplegar>();
            try
            {
                var filtroOOB = new OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro()
                {
                    CadenaBusq = _filtro.TextoBuscar,
                    IdEntidad = "",
                };
                var r01 = Sistema.MyData.Transporte_CxpDoc_GetLista_DocPend(filtroOOB);
                lst = r01.Lista
                    .GroupBy(g => new { g.idEntidad, g.ciRif, g.nombreRazonSocial })
                    .Select(s =>
                    {
                        IItemDesplegar nr = new modelos.ItemDesplegar()
                        {
                            IdEntidad = s.Key.idEntidad,
                            CiRifEntidad = s.Key.ciRif,
                            NombreEntidad = s.Key.nombreRazonSocial,
                            MontoDeuda = s.Where(w => w.signoDoc == 1).Sum(ss => ss.importeDiv),
                            MontoCredito = s.Where(w => w.signoDoc == -1).Sum(ss => ss.importeDiv),
                            MontoAcumulado = s.Sum(ss => ss.acumuladoDiv),
                            CntDocDeuda = s.Where(w => w.signoDoc == 1).Count(),
                            Documentos = s.ToList(),
                        };
                        return nr;
                    })
                    .OrderBy(o => o.NombreEntidad)
                    .ToList();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            return lst;
        }
    }
}