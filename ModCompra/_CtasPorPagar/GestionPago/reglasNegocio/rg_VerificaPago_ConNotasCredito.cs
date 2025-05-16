using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.reglasNegocio
{
    public class rg_VerificaPago_ConNotasCredito: __.ReglasNegocio.GestionPago.IVerificaPago_ConNotasCredito
    {
        private string _mensaje = "";
        public string MensajeAlerta { get { return _mensaje; } }
        public bool Execute(__.Modelos.GestionPago.IModelo modelo)
        {
            if (modelo.Get_DocSeleccionadosAPagar_PorNC_Monto > 0m)
            {
                if (modelo.Get_DocSeleccionadosAPagar_PorDeuda_Cnt<=0)
                {
                    _mensaje = "NO HAY DOCUMENTOS A PAGAR PARA USAR CON LAS NOTAS DE CREDITO SELECCIONADAS";
                    return false;
                }
                if (modelo.Get_DocSeleccionadosAPagar_PorNC_Monto > modelo.Get_DocSeleccionadosAPagar_PorDeuda_Monto ) 
                {
                    _mensaje = "EL MONTO SELECCIONADO POR NOTAS DE CREDITO NO PUEDE SER MAYOR A DOCUMENTOS A PAGAR";
                    return false;
                }
            }
            return true;
        }
    }
}