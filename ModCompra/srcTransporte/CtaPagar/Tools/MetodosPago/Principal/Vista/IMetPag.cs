using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.Principal.Vista
{
    public interface IMetPag
    {
        BindingSource Get_Source { get; }
        decimal Get_MontoPagar { get; }
        decimal Get_MontoPend { get; }
        decimal Get_MontoRecibido { get; }
        decimal Get_ImporteMovCaja { get; }
        IEnumerable<object> Get_Lista_MetPago_Registrado { get; }

        void Inicializa();
        void AgregarMet();
        void EditarMet();
        void EliminarMet();
        bool ProcesarIsOk();

        void setMontoPagarDiv(decimal monto);

        //
        void ActualizarItem();
        string Get_ItemInfo_Metodo { get; }
        decimal Get_ItemInfo_Monto { get; }
        string Get_ItemInfo_AplicaFactorCambio { get; }
        string Get_ItemInfo_Banco { get; }
        string Get_ItemInfo_NroCta { get; }
        string Get_ItemInfo_NroRef { get; }
        DateTime Get_ItemInfo_FechaOperacion { get; }
        string Get_ItemInfo_DetalleOperacion { get; }
    }
}