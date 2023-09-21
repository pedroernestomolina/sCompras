using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaRet
{
    public class iva: baseImp
    {
        public iva()
            :base()
        {
        }
        protected override void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha> list)
        {
            Helpers.Msg.OK("IVA"+list.Count.ToString());
        }
    }
}