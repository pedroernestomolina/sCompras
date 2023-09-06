using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Concepto.AgregarEditar.Vistas
{
    public interface Idata
    {
        string Get_Codigo { get; }
        string Get_Descripcion { get;  }

        void SetCodigo(string desc);
        void SetDescripcion(string desc);

        void Inicializa();
        bool DatosAgregarIsOk();
        bool DatosEditarIsOk();
    }
}