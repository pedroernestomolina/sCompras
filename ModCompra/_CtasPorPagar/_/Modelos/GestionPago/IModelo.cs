using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.GestionPago
{
    public interface IModelo
    {
        string GetInfoEntidad { get; }
        IFichaGestion FichaGestion { get; }
        IEnumerable<IDoc> DocDeuda { get; }
        IEnumerable<IDoc> DocNC { get; }
        IEnumerable<Modelos.PanelMetPagoAgregar.IItemAgregar> MetodosPago { get; }

        // PANEL ANTICIPOS 
        decimal Get_Anticipos_MontoAUsar { get; }
        decimal Get_Anticipos_MontoDisponible { get; }
        // PANEL METODOS/PAGO
        int GetCntMetPagoRecibido { get; }
        decimal GetMontoPorMetPagoRecibido { get; }
        // PANEL POR DEUDA
        int Get_DocSeleccionadosAPagar_PorDeuda_Cnt { get; }
        decimal Get_DocSeleccionadosAPagar_PorDeuda_Monto { get; }
        decimal Get_DocPorDeuda_MontoTotal { get; }

        // PANEL POR NC 
        int Get_DocSeleccionadosAPagar_PorNC_Cnt { get; }
        decimal Get_DocSeleccionadosAPagar_PorNC_Monto { get; }
        decimal Get_DocNC_MontoDisponible { get; }

        //
        decimal SaldoFinal { get; }

        //
        void Inicializa();
        void setCargarEntidad(IFichaGestion fichaGestion);
        void setFactorCambio(decimal factor);
        void setMediosPago(IEnumerable<IMedioPago> mediosPag);

        void setMontoUsarPorAnticipo(decimal monto);

        void setCntDocDeudaAbonado(int cnt);
        void setMontoDocDeudaAbonar(decimal monto);

        void setCntDocNCAbonado(int cnt);
        void setMontoDocNCAbonar(decimal monto);

        decimal GetFactorCambio { get; }
        IEnumerable<IMedioPago> GetMediosPago { get; }

        //
        void AgregarMetodoPago(Modelos.PanelMetPagoAgregar.IItemAgregar rt);
        void CargarMetodosPago(IEnumerable<PanelMetPagoAgregar.IItemAgregar> lista);
    }
}