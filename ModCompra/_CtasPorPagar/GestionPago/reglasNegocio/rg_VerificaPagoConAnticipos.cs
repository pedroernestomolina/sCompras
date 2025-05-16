using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.reglasNegocio
{
    public class rg_VerificaPagoConAnticipos: __.ReglasNegocio.GestionPago.IVerificaPago_ConAnticipos
    {
        private string _mensajeAlerta;
        //
        public string MensajeAlerta { get { return _mensajeAlerta; } }
        //
        public bool Execute(__.Modelos.GestionPago.IModelo modelo)
        {
            if (modelo.Get_Anticipos_MontoAUsar > 0m)
            {
                if (modelo.Get_DocSeleccionadosAPagar_PorDeuda_Cnt <= 0)
                {
                    _mensajeAlerta = "NO HAY DOCUMENTOS POR PAGAR SELECCIONADOS PARA USAR ANTICIPOS";
                    return false;
                }
                if (modelo.Get_Anticipos_MontoAUsar > modelo.Get_DocSeleccionadosAPagar_PorDeuda_Monto)
                {
                    _mensajeAlerta = "EL MONTO POR ANTICIPO SOBRE PASA EL MONTO DOCUMENTOS POR PAGAR";
                    return false;
                }
            }
            return true;
        }
    }
}
