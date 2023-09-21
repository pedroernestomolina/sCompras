using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaGeneralDoc
{
    public class Imp: IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro _filtro;


        public Imp()
        {
        }
        public void setFiltros(Idata data)
        {
            _filtro = new OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro()
            {
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_GeneralDoc_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha> list)
        {
        }
    }
}