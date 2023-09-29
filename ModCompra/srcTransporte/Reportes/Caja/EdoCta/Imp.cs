using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Caja.EdoCta
{
    public class Imp : IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro _filtro;


        public Imp()
        {
            _filtro = new OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro();
        }
        public void setFiltros(object data)
        {
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Caja_Movimientos_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha> list)
        {
        }
    }
}