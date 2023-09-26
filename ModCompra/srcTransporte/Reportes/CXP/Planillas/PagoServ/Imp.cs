using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.Planillas.PagoServ
{
    public class Imp: IRepPlanilla
    {
        private int _idDoc;


        public Imp()
        {
        }
        public void setIdDoc(string idDoc)
        {
            _idDoc = int.Parse(idDoc);
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Aliado_PagoServ_Planilla (_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla.Ficha ficha)
        {
        }
    }
}