using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.reglasNegocio
{
    public class rg_VerificaPago_ConMetodosPago: __.ReglasNegocio.GestionPago.IVerificaPago_ConMetodosPago
    {
        private string _mensajeAlerta;
        //
        public string MensajeAlerta { get { return _mensajeAlerta; } }
        //
        public bool Execute(__.Modelos.GestionPago.IModelo modelo)
        {
            _mensajeAlerta = "";
            return true;
        }
    }
}
