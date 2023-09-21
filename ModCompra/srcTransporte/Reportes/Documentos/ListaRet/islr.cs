using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaRet
{
    public class islr: baseImp
    {
        public islr()
            : base()
        {
        }
        protected override void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha> list)
        {
            Helpers.Msg.OK("ISLR"+list.Count.ToString());
        }
    }
}