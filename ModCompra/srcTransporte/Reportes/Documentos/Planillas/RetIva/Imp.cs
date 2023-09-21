using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.Planillas.RetIva
{
    public class Imp: IRepPlanilla
    {
        private string _idDoc;


        public Imp()
        {
        }
        public void setIdDoc(string idDoc)
        {
            _idDoc = idDoc;
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_Planilla_RetIva(_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha ficha)
        {
        }
    }
}