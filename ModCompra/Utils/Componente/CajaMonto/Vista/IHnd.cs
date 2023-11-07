using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Componente.CajaMonto.Vista
{
    public interface IHnd
    {
        decimal Get_FactorCambio { get; }
        decimal Get_MontoPendMonAct { get; }
        decimal Get_MontoPendMonDiv { get; }
        decimal MontoCajaPago { get; }
        BindingSource Get_CajaSource { get; }
        IEnumerable<Idata> Get_Lista { get; }
        IEnumerable<Idata> Get_CajasUsadas { get; }

        void Inicializa();
        void CargarData();
        void EditarMontoAbonar();
        void ActualizarSaldosPend();
        bool IsOk();

        void setDataCargar(IEnumerable<Idata> _lst);
        void setFactorCambio(decimal factor);
        void setMontoPendDiv(decimal montoDiv);
    }
}