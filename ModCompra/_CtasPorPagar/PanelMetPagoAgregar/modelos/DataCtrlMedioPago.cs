using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelMetPagoAgregar.modelos
{
    public class DataCtrlMedioPago: LibUtilitis.Opcion.IData 
    {
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }
        public DataCtrlMedioPago(__.Modelos.GestionPago.IMedioPago ficha)
        {
            codigo = ficha.codigo;
            desc = ficha.descripcion;
            id = ficha.id;
        }
    }
}