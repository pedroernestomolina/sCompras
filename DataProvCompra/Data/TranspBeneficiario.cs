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
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha> 
            Transporte_Beneficiario_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha>();
            var r01 = MyData.Transporte_Beneficiario_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha()
                        {
                            id = s.id,
                            cirif = s.cirif,
                            nombreRazonSocial = s.nombreRazonSocial,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Beneficiario.Crud.Entidad.Ficha>
            Transporte_Beneficiario_GetById(int idCja)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Beneficiario.Crud.Entidad.Ficha>();
            var r01 = MyData.Transporte_Beneficiario_GetById(idCja);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Transporte.Beneficiario.Crud.Entidad.Ficha()
            {
                estatusAnulado = s.estatusAnulado,
                fechaRegistro = s.fechaRegistro,
                id = s.id,
                ciRif = s.ciRif,
                direccion = s.direccion,
                nombreRazonSocial = s.nombreRazonSocial,
                telefono = s.telefono,
            };
            result.Entidad = nr;
            return result;
        }
        public OOB.ResultadoId 
            Transporte_Beneficiario_Agregar(OOB.LibCompra.Transporte.Beneficiario.Crud.Agregar.Ficha ficha)
        {
            var result = new OOB.ResultadoId();
            var fichaDTO = new DtoLibTransporte.Beneficiario.Crud.Agregar.Ficha()
            {
                ciRif = ficha.ciRif,
                direccion = ficha.direccion,
                nombreRazonSocial = ficha.nombreRazonSocial,
                telefono = ficha.telefono,
            };
            var r01 = MyData.Transporte_Beneficiario_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Id = r01.Id;
            return result;
        }
        public OOB.Resultado 
            Transporte_Beneficiario_Editar(OOB.LibCompra.Transporte.Beneficiario.Crud.Editar.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Beneficiario.Crud.Editar.Ficha()
            {
                id = ficha.id,
                ciRif = ficha.ciRif,
                direccion = ficha.direccion,
                nombreRazonSocial = ficha.nombreRazonSocial,
                telefono = ficha.telefono,
            };
            var r01 = MyData.Transporte_Beneficiario_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
    }
}