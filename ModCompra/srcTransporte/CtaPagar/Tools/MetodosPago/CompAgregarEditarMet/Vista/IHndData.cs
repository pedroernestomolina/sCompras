using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompAgregarEditarMet.Vista
{
    public interface IHndData
    {
        Utils.FiltrosCB.SinBusqueda.MedioPago.IMedioPago MedioPago { get; }
        decimal Get_Monto { get; }
        decimal Get_Factor { get; }
        string Get_Banco { get; }
        string Get_NroCta { get; }
        string Get_CheqRefTrans { get; }
        DateTime Get_FechaOp { get; }
        string Get_DetalleOp { get; }
        bool Get_AplicaFactor { get; }
        string Get_Referencia { get; }
        string Get_Lote { get; }
        bool GetAplicaMovCaja { get; }


        void setMonto(decimal monto);
        void setFactor(decimal factor);
        void setBanco(string banco);
        void setCtaNro(string cta);
        void setChequeRefTranf(string cheqRefTranf);
        void setFechaOperacion(DateTime fecha);
        void setDetalleOperacion(string detalleOp);
        void setAplicaFactor(bool p);
        void setMontoResta(decimal GetMontoPend);
        void setLote(string lote);
        void setReferencia(string referenc);
        void setAplicaMovCaja(bool modo);
    }
}