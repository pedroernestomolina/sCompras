using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspAliadoAnticipo
    {
        DtoLib.Resultado
            Transporte_Aliado_Anticipo_Agregar(DtoLibTransporte.Aliado.Anticipo.Agregar.Ficha ficha);
    }
}