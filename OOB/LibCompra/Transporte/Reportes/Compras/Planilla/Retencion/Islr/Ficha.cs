using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr
{
    public class Ficha: baseFicha
    {
        public string dirFiscal { get; set; }
        public string conceptoDoc { get; set; }
        public string conceptoCod { get; set; }
        public decimal subtRet { get; set; }
        public decimal sustraendoRet { get; set; }
        public string codXmlIslr { get; set; }
        public string descXmlIslr { get; set; }
        public decimal subtBase { get; set; }
        public decimal subtImp { get; set; }
        //
        public Ficha()
        {
        }
        public Ficha(DocumentoRet.Crud.Corrector.ObtenerData.Ficha _fichaCorrector)
        {
            anoRelRet=_fichaCorrector.anoRelRet;
            mesRelRet=_fichaCorrector.mesRelRet;
            fechaRet=_fichaCorrector.fechaRet;
            prvNombre=_fichaCorrector.prvNombre;
            prvCiRif=_fichaCorrector.prvCiRif;
            prvDirFiscal=_fichaCorrector.prvDirFiscal;
            comprobanteRet=_fichaCorrector.comprobanteRet;
            numDoc=_fichaCorrector.numDoc;
            fechaEmiDoc=_fichaCorrector.fechaEmiDoc;
            numControlDoc=_fichaCorrector.numControlDoc;
            tipoDoc=_fichaCorrector.tipoDoc;
            aplica=_fichaCorrector.aplica;
            total=_fichaCorrector.total;
            exento=_fichaCorrector.exento;
            base1=_fichaCorrector.base1;
            base2=_fichaCorrector.base2;
            base3=_fichaCorrector.base3;
            impuesto1=_fichaCorrector.impuesto1;
            impuesto2=_fichaCorrector.impuesto2;
            impuesto3=_fichaCorrector.impuesto3;
            tasa1=_fichaCorrector.tasa1;
            tasa2=_fichaCorrector.tasa2;
            tasa3=_fichaCorrector.tasa3;
            retencion1=_fichaCorrector.retencion1;
            retencion2=_fichaCorrector.retencion2;
            retencion3=_fichaCorrector.retencion3;
            tasaRet=_fichaCorrector.tasaRet;
            totalRet=_fichaCorrector.totalRet;
            maquinaFiscal = _fichaCorrector.maquinaFiscal;
            dirFiscal = _fichaCorrector.prvDirFiscal;
            conceptoDoc = _fichaCorrector.conceptoDoc;
            conceptoCod = _fichaCorrector.conceptoCod;
            subtRet = _fichaCorrector.subtRet;
            sustraendoRet = _fichaCorrector.sustraendoRet;
            codXmlIslr = _fichaCorrector.codXmlIslr;
            descXmlIslr = _fichaCorrector.descXmlIslr;
            subtBase = _fichaCorrector.subtBase;
            subtImp = _fichaCorrector.subtImp;
        }
    }
}