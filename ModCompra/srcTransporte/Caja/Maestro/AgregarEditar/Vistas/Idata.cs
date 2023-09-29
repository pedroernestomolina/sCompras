using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Maestro.AgregarEditar.Vistas
{
    public interface Idata
    {
        bool Get_IsDivisa { get; }
        decimal Get_Saldo { get; }
        string Get_Codigo { get; }
        string Get_Descripcion { get;  }

        void SetCodigo(string desc);
        void SetDescripcion(string desc);
        void setSaldoInicial(decimal monto);
        void setIsDivisa(bool modo);

        void Inicializa();
        bool DatosAgregarIsOk();
        bool DatosEditarIsOk();
    }
}