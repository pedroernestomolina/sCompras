using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.ReglasNegocio.GestionPago
{
    public interface IVerificaPago_ConNotasCredito
    {
        string MensajeAlerta { get; }
        bool Execute(__.Modelos.GestionPago.IModelo modelo);
    }
}
