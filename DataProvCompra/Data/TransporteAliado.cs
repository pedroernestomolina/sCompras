using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Aliado.Entidad.Ficha> 
            Transporte_Aliado_GetFichaById(int id)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Aliado.Entidad.Ficha>();
            var r01 = MyData.Transporte_Aliado_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s= r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.Aliado.Entidad.Ficha()
            {
                ciRif = s.ciRif,
                codigo = s.codigo,
                dirFiscal = s.dirFiscal,
                id = s.id,
                nombreRazonSocial = s.nombreRazonSocial,
                personaContacto = s.personaContacto,
                montoAnticiposDiv = s.montoAnticiposDiv,
                montoAnticiposAnuladoDiv = s.montoAnticiposAnuladoDiv,
                montoAnticipoRetAnuladoDiv = s.montoAnticipoRetAnuladoDiv,
                montoAnticipoRetDiv = s.montoAnticipoRetDiv,
            };
            return result;
        }
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.Entidad.Ficha>
            Transporte_Aliado_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.Entidad.Ficha>();
            var r01 = MyData.Transporte_Aliado_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Aliado.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Aliado.Entidad.Ficha()
                        {
                            ciRif = s.ciRif,
                            codigo = s.codigo,
                            id = s.id,
                            nombreRazonSocial = s.nombreRazonSocial,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }

        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha> 
            Transporte_Aliado_Pediente_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha>();
            var r01 = MyData.Transporte_Aliado_Pediente_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha()
                        {
                            acumuladoDiv = s.acumuladoDiv,
                            aliadoCiRif = s.aliadoCiRif,
                            aliadoCod = s.aliadoCod,
                            aliadoNombre = s.aliadoNombre,
                            aliadoId = s.aliadoId,
                            importeDiv = s.importeDiv,
                            montoAnticipoAnuladoDiv = s.montoAnticipoAnuladoDiv,
                            montoAnticipoDiv = s.montoAnticipoDiv,
                            montoAnticipoRetDiv=s.montoAnticipoRetDiv,
                            montoAnticipoRetAnuladoDiv=s.montoAnticipoRetAnuladoDiv,
                            cntDoc=s.cntDoc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha> 
            Transporte_Aliado_Pediente_GetByIdAliado(int idAliado)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha>();
            var r01 = MyData.Transporte_Aliado_Pediente_GetByIdAliado(idAliado);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var lst = new List<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha>();
            result.Entidad = new OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha()
            {
                acumuladoDiv = s.acumuladoDiv,
                aliadoCiRif = s.aliadoCiRif,
                aliadoCod = s.aliadoCod,
                aliadoNombre = s.aliadoNombre,
                aliadoId = s.aliadoId,
                importeDiv = s.importeDiv,
                montoAnticipoAnuladoDiv = s.montoAnticipoAnuladoDiv,
                montoAnticipoDiv = s.montoAnticipoDiv,
                montoAnticipoRetAnuladoDiv = s.montoAnticipoRetAnuladoDiv,
                montoAnticipoRetDiv = s.montoAnticipoRetDiv,
                cntDoc = s.cntDoc,
            };
            return result;
        }
    }
}