using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Documentos
{
    

    public class data
    {


        private OOB.LibCompra.Proveedor.Documentos.Ficha it;


        public DateTime Fecha { get { return it.fecha; } }
        public string Tipo { get { return it.nombreTipoDoc; } }
        public string Serie { get { return it.serie; } }
        public string Documento { get { return it.documento; } }
        public decimal ImporteDivisa { get { return it.montoDivisa; } }
        public string Estatus { get { return it.IsAnulado ? "ANULADO" : ""; } }
        public string ControlNro { get { return it.controlNro; } }
        public decimal Importe { get { return it.monto ; } }


        public data(OOB.LibCompra.Proveedor.Documentos.Ficha it)
        {
            this.it = it;
        }

    }

}