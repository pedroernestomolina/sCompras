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
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha> 
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha>();
            var r01 = MyData.Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(idAliado);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha()
                        {
                            aliadoCiRif = s.aliadoCiRif,
                            aliadoCodigo = s.aliadoCodigo,
                            aliadoNombre = s.aliadoNombre,
                            clienteCiRif = s.clienteCiRif,
                            clienteNombre = s.clienteNombre,
                            fechaDoc = s.fechaDoc,
                            idAliado = s.idAliado,
                            idAliadoDoc = s.idAliadoDoc,
                            idAliadoServ = s.idAliadoServ,
                            importeServDiv = s.importeServDiv,
                            nombreDoc = s.nombreDoc,
                            numDoc = s.numDoc,
                            servCodigo = s.servCodigo,
                            servDesc = s.servDesc,
                            servDetalle = s.servDetalle,
                            servId = s.servId,
                            servMontoAcumuladoDiv = s.servMontoAcumuladoDiv,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
    }
}