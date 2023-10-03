using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.MyService
{
    public partial class Service: IService
    {
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Entidad.Ficha>
            Transporte_Aliado_GetFichaById(int id)
        {
            return ServiceProv.Transporte_Aliado_GetFichaById(id);
        }
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Entidad.Ficha>
            Transporte_Aliado_GetLista()
        {
            return ServiceProv.Transporte_Aliado_GetLista();
        }

        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Pendiente.Ficha> 
            Transporte_Aliado_Pediente_GetLista()
        {
            return ServiceProv.Transporte_Aliado_Pediente_GetLista();
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Pendiente.Ficha> 
            Transporte_Aliado_Pediente_GetByIdAliado(int idAliado)
        {
            return ServiceProv.Transporte_Aliado_Pediente_GetByIdAliado(idAliado);
        }
    }
}
