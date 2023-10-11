using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.Maestro.AgregarEditar.Vistas
{
    public interface Idata
    {
        string Get_Codigo { get; }
        string Get_Descripcion { get;  }
        string Get_Direccion { get; }
        string Get_Telefono { get; }

        void SetCodigo(string desc);
        void SetDescripcion(string desc);
        void SetDireccion(string desc);
        void SetTelefono(string desc);

        void Inicializa();
        bool DatosAgregarIsOk();
        bool DatosEditarIsOk();
    }
}