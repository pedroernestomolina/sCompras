using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv : IData
    {
        public OOB.Resultado 
            Transporte_DocumentoRet_Crud_Anular_Procesar(OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.Ficha()
            {
                auditorias = new List<DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.Auditoria>(),
                compraRet = new DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.CompraRetencion()
                {
                    idDocCompra = ficha.compraRet.idDocCompra,
                    idDocCompraRet = ficha.compraRet.idDocCompraRet,
                    isRetIva = ficha.compraRet.isRetIva,
                },
                proveedor = new DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.Proveedor()
                {
                    idProv = ficha.proveedor.idProv,
                    montoRestaurarMonDiv = ficha.proveedor.montoRestaurarMonDiv,
                },
                cxpDocOrigen = new DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.CxP_DocOrigen()
                {
                    idDoc = ficha.cxpDocOrigen.idDoc,
                    montoRestaurarMonAct = ficha.cxpDocOrigen.montoRestaurarMonAct,
                    montoRestaurarMonDiv = ficha.cxpDocOrigen.montoRestaurarMonDiv,
                },
                cxpIR = new DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.CxP_IR()
                {
                    idDocIR = ficha.cxpIR.idDocIR,
                    idRecibo = ficha.cxpIR.idRecibo,
                },
            };
            var r01= MyData.Transporte_DocumentoRet_Crud_Anular_Procesar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                throw new Exception(r01.Mensaje);
            }
            //
            return rt;
        }
    }
}
