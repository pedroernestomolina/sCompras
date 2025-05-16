using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.ReglasNegocio.GestionPago
{
    public interface IVerifica_SaldoPendienteMayorAMontoEstablecido
    {
        string MensajeAlerta { get; }
        void setMontoEstablecido(decimal monto);
        bool Execute(__.Modelos.GestionPago.IModelo modelo);
    }
}
