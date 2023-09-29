using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspCaja
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Lista.Ficha>
            Transporte_Caja_GetLista();
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Caja.Crud.Entidad.Ficha>
            Transporte_Caja_GetById(int idCja);
        OOB.ResultadoId
            Transporte_Caja_Agregar(OOB.LibCompra.Transporte.Caja.Crud.Agregar.Ficha ficha);
        OOB.Resultado
            Transporte_Caja_Editar(OOB.LibCompra.Transporte.Caja.Crud.Editar.Ficha ficha);
    }
}