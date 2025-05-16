using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.reglasNegocio
{
    public class rg_VerificarSaldoPendienteMayorAMontoEstablecido: 
        __.ReglasNegocio.GestionPago.IVerifica_SaldoPendienteMayorAMontoEstablecido
    {
        private  decimal _montoEstablecido=0m;
        //
        public string MensajeAlerta { get { return "HAY UN FALTANTE, Verifique Por Favor"; } }
        public void setMontoEstablecido(decimal monto)
        {
            _montoEstablecido = monto;
        }
        public bool Execute(__.Modelos.GestionPago.IModelo modelo)
        {
            var rt = true;
            if (modelo.SaldoFinal < 0m) 
            {
                return !(Math.Abs(modelo.SaldoFinal) > _montoEstablecido  );
            }
            return rt;
        }
    }
}