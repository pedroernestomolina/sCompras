using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Vistas
{
    public interface IGestPag
    {
        Anticipos.Agregar.Vistas.Idata hndData { get; }
        Anticipos.Agregar.Vistas.Icaja hndCaja { get; }
        decimal Get_TasaFactorCambio { get; }
        DateTime Get_FechaPag { get; }
        string Get_AliadoInfo { get;}
        decimal Get_AliadoAnticipos { get; }
        string Get_Motivo { get; }
        decimal Get_MontoPag { get; }
        DateTime Get_FechaServidor { get; }
        decimal Get_MontoPagMonAct { get; }
        decimal Get_MontoRetencion { get; }
        decimal Get_MontoAbonoMonDiv { get; }
        decimal Get_MontoAbonoMonAct { get; }
        bool Get_AplicaRet { get; }
        decimal Get_TasaRetencion { get; }
        decimal Get_MontoSustraendo { get; }
        BindingSource Get_CajaSource { get; }
        decimal CajaGet_MontoPendMonDiv { get; }
        decimal CajaGet_MontoPendMonAct { get; }
        OOB.LibCompra.Transporte.Aliado.Entidad.Ficha Get_Aliado { get; }
        decimal Get_TotalRetMonAct { get; }
        decimal Get_TotalRetMonDiv { get; }
        IEnumerable<object> Get_CajasUsadas { get; }

        void Inicializa();
        void CargarData();
        void setFechaServidor(DateTime fecha);
        void setFechaPag(DateTime fecha);
        void setTasaFactorCambio(decimal monto);
        void setAliado(OOB.LibCompra.Transporte.Aliado.Entidad.Ficha ficha);
        void setMotivo(string desc);
        void setMontoPagDiv(decimal monto);
        void setAplicaRet(bool aplica);
        void setTasaRet(decimal monto);
        void setMontoSustraendo(decimal monto);
        void ActualizarSaldoCaja();
        void CajaEditarMontoAbonar();
        bool IsOk();
    }
}