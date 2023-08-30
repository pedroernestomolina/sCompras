using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CompraGasto.Vistas.Generar
{
    public interface IdataFiscal
    {
        decimal Get_Tasa { get; }
        decimal Get_Base { get; }
        decimal Get_Imp { get; }

        void Inicializa();
        void SetTasa(decimal tasa);
        void SetBase(decimal monto);
    }
}