using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Agregar.Handler
{
    public class dataCaja: Vistas.IdataCaja
    {
        private OOB.LibCompra.Transporte.Caja.Lista.Ficha _ficha;


        public string descripcion { get; set; }
        public decimal saldoActual { get; set; }
        public decimal montoAbonar { get; set; }
        public bool esDivisa { get; set; }
        public OOB.LibCompra.Transporte.Caja.Lista.Ficha Get_Ficha { get { return _ficha; } }

        
        public dataCaja(OOB.LibCompra.Transporte.Caja.Lista.Ficha ficha)
        {
            _ficha = ficha;
            esDivisa = ficha.esDivisa == "1";
            descripcion = ficha.descripcion;
            saldoActual = ficha.saldoInicial + (ficha.montoPorIngresos - ficha.montoPorEgresos - ficha.montoPorAnulaciones);
            montoAbonar = 0m;
        }
        public void setMontoAbonar(decimal monto)
        {
            montoAbonar = monto;
        }
    }
}