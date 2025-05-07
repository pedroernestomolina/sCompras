using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.usesCase.CargarFactorCambio
{
    public class uc: Iuc
    {
        public decimal Execute()
        {
            var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r01.Result == OOB.Enumerados.EnumResult.isError )
            {
                throw new Exception(r01.Mensaje);
            }
            return r01.Entidad;
        }
    }
}
