using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Beneficiario.Movimiento.Vistas
{
    public interface IHndMov
    {
        Utils.FiltrosCB.ICtrlConBusqueda Beneficiario { get; }
        Utils.FiltrosCB.ICtrlConBusqueda Concepto { get; }
        decimal Get_FactorCambio { get; }
        decimal Get_MontoMov { get; }
        DateTime Get_FechaServidor { get; }
        string Get_Notas { get; }
        decimal Get_MontoMonAct { get; }
        object Get_BeneficiarioFicha { get; }
        object Get_ConceptoFicha { get; }
        DateTime Get_FechaMovimiento { get; }


        void Inicializa();
        void CargarData();
        void setFactorCambio(decimal monto);
        void setMontoMov(decimal monto);
        void setFechaServidor(DateTime fecha);
        void setNotas(string desc);
        void setFechaMov(DateTime fecha);
        bool DataIsOk();
    }
}