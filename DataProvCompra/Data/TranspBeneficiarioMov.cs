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
        public OOB.ResultadoId 
            Transporte_Beneficiario_Mov_Agregar(OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar.Ficha ficha)
        {
            var result = new OOB.ResultadoId();
            var fichaDTO = new DtoLibTransporte.Beneficiario.Mov.Agregar.Ficha();
            var mov = new DtoLibTransporte.Beneficiario.Mov.Agregar.Movimiento()
            {
                ciRifBeneficiario = ficha.mov.ciRifBeneficiario,
                codConcepto = ficha.mov.codConcepto,
                descConcepto = ficha.mov.descConcepto,
                factorTasa = ficha.mov.factorTasa,
                fechaMov = ficha.mov.fechaMov,
                idBeneficiario = ficha.mov.idBeneficiario,
                idConcepto = ficha.mov.idConcepto,
                montoMonDiv = ficha.mov.montoMonDiv,
                nombreBeneficiario = ficha.mov.nombreBeneficiario,
                notasMov = ficha.mov.notasMov,
            };
            fichaDTO.mov = mov;
            fichaDTO.movCaja = ficha.movCaja.Select(s =>
            {
                var rg = new DtoLibTransporte.Beneficiario.Mov.Agregar.MovCaja()
                {
                    codCaja = s.codCaja,
                    descCaja = s.descCaja,
                    esDivisa = s.esDivisa,
                    idCaja = s.idCaja,
                    monto = s.monto,
                    movimientoCaja = new DtoLibTransporte.Beneficiario.Mov.Agregar.CajaMovimiento()
                    {
                        descMov = s.movimientoCaja.descMov,
                        factorCambio = s.movimientoCaja.factorCambio,
                        montoMovMonAct = s.movimientoCaja.montoMovMonAct,
                        montoMovMonDiv = s.movimientoCaja.montoMovMonDiv,
                        movFueDivisa = s.movimientoCaja.movFueDivisa,
                    },
                };
                return rg;
            }).ToList();
            var r01 = MyData.Transporte_Beneficiario_Mov_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Id = r01.Id;
            return result;
        }
        //
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Ficha> 
            Transporte_Beneficiario_Mov_GetLista(OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Ficha>();
            var filtroDTO = new DtoLibTransporte.Beneficiario.Mov.Lista.Filtro ()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                Estatus = filtro.Estatus,
                IdBeneficiario = filtro.IdBeneficiario,
            };
            var r01 = MyData.Transporte_Beneficiario_Mov_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Ficha()
                        {
                            cirifBene = s.cirifBene,
                            codConcepto = s.codConcepto,
                            descConcepto = s.descConcepto,
                            estatusAnulado = s.estatusAnulado,
                            fechaReg = s.fechaReg,
                            idMov = s.idMov,
                            montoDiv = s.montoDiv,
                            nombreBene = s.nombreBene,
                            reciboNro = s.reciboNro,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        //
        public OOB.Resultado 
            Transporte_Beneficiario_Mov_Anular(int idMov)
        {
            var result = new OOB.Resultado();
            var r01 = MyData.Transporte_Beneficiario_Mov_Anular_ObtenerData(idMov);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var r02 = MyData.Transporte_Beneficiario_Mov_Anular(r01.Entidad);
            if (r02.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r02.Mensaje);
            }
            return result;
        }
    }
}