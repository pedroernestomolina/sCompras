using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.Aliado.Anticipo
{
    public class Imp : IRepFiltro
    {
        public Imp()
        {
        }
        public void setFiltros(Idata data)
        {
        }
        public void Generar()
        {
            try
            {
                var filtroOOB = new OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Filtro();
                var r01 = Sistema.MyData.Transporte_Reportes_Aliado_Anticipos_GetLista(filtroOOB);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General.Ficha> list)
        {
        }
    }
}