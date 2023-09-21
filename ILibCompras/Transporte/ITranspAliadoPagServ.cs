using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspAliadoPagServ
    {
        DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha>
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado);
    }
}