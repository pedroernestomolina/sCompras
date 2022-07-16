using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros
{
    
    public class data
    {

        public OOB.LibCompra.Sucursal.Data.Ficha sucursal{ get; set; }
        public Estatus estatus { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string mesRelacion { get; set; }
        public string anoRelacion { get; set; }


        public data()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            sucursal = null;
            estatus = null;
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
            LimpiarMesAnoRelacion();
        }

        public void LimpiarMesAnoRelacion()
        {
            mesRelacion = "";
            anoRelacion = "";
        }

    }

}