using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.usesCase
{
    public class uc_CargarInfoEntidad: __.UsesCase.GestionPago.ICargarInfoEntidad
    {
        public __.Modelos.GestionPago.IFichaGestion Execute(string id)
        {
            var r01 = Sistema.MyData.Transporte_CxpDoc_GetInfo_Entidad(id);
            var _ent = r01.Entidad.Entidad;
            var _doc = r01.Entidad.DocPendentes;
            var _entidad = new modelos.Entidad()
            {
                anticipos = _ent.anticiposEntidad,
                ciRif = _ent.ciRifEntidad,
                codigo = _ent.codigoEntidad,
                dirFiscal = _ent.dirFiscalEntidad,
                id = _ent.idEntidad,
                nombreRazonSocial = _ent.nombreRazonSocialEntidad,
                telefonos = _ent.telfEntidad,
            };
            var _docDeuda = _doc.Where(w => w.signoDoc == 1).OrderBy(o => o.fechaEmision).ToList().Select(s =>
            {
                var nr = new modelos.Doc()
                {
                    acumuladoDiv = s.acumuladoDiv,
                    diasCredito = s.diasCredito,
                    diasvencida = s.diasvencida,
                    docNro = s.docNro,
                    fechaEmision = s.fechaEmision,
                    fechaVence = s.fechaVence,
                    idCxP = s.idCxP,
                    idDocOrigen = s.idDocOrigen,
                    importeDiv = s.importeDiv,
                    notasDoc = s.notasDoc,
                    restaDiv = s.restaDiv,
                    signoDoc = s.signoDoc,
                    tasafactor = s.tasafactor,
                    tipoDoc = s.tipoDoc,
                };
                return nr;
            }).ToList();
            var _nc = _doc.Where(w => w.signoDoc == -1).OrderBy(o => o.fechaEmision).ToList().Select(s =>
            {
                var nr = new modelos.Doc()
                {
                    acumuladoDiv = s.acumuladoDiv,
                    diasCredito = s.diasCredito,
                    diasvencida = s.diasvencida,
                    docNro = s.docNro,
                    fechaEmision = s.fechaEmision,
                    fechaVence = s.fechaVence,
                    idCxP = s.idCxP,
                    idDocOrigen = s.idDocOrigen,
                    importeDiv = s.importeDiv,
                    notasDoc = s.notasDoc,
                    restaDiv = s.restaDiv,
                    signoDoc = s.signoDoc,
                    tasafactor = s.tasafactor,
                    tipoDoc = s.tipoDoc,
                };
                return nr;
            }).ToList();
            var _fichaGestion = new modelos.FichaGestion()
            {
                Entidad = _entidad,
                DocDeudas = _docDeuda,
                NotasCredito = _nc,
            };
            return _fichaGestion;
        }
    }
}