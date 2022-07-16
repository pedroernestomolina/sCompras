using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{

    public interface IGestionTotalizar
    {

        bool IsOk { get; set; }
        decimal Dscto { get; }
        decimal Cargo { get; }
        decimal Monto { get; }
        string Notas { get; }
        decimal Total { get; }
        bool HabilitarDscto { get; }
        bool HabilitarCargo { get; }


        void Inicializar();
        void Guardar();
        void SetMonto(decimal p);
        void SetNotas(string p);
        void setDscto(decimal p);
        void setCargo(decimal p);
        void Inicia();
        void Limpiar();

    }

}