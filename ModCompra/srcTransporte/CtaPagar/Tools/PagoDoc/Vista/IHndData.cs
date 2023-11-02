using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoDoc.Vista
{
    public interface IHndData
    {
        string Get_ProvInfo { get; }
        DateTime Get_FechaPag { get; }
        decimal Get_MontoPag { get; }
        string Get_Motivo { get; }
        decimal Get_TasaFactorCambio { get; }
        DateTime Get_FechaServidor { get; }
        decimal Get_MontoPagMonAct { get; }
        string Get_InfoDoc_Nro { get; }
        DateTime Get_InfoDoc_FechaEmision { get; }
        string Get_InfoDoc_Control { get; }
        string Get_InfoDoc_Condicion { get; }
        string Get_InfoDoc_Concepto { get; }
        string Get_InfoDoc_Motivo { get; }
        decimal Get_InfoDoc_MontoPend { get; }

        void Inicializa();
        bool ProcesarIsOk();

        void setTasaCambioActual(object tasaActual);
        void setFechaServidor(object fecha);
        void setDocPagar(object ficha);
        void setMotivo(string desc);
        void setFechaPag(DateTime fecha);
        void setMontoPag(decimal monto);
        void setTasaFactorCambio(decimal monto);
    }
}