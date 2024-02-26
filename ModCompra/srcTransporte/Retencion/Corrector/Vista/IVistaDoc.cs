using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Corrector.Vista
{
    public interface IVistaDoc
    {
        string Get_PrvCiRif { get; }
        string Get_PrvNombre { get; }
        string Get_PrvDirFiscal { get; }
        DateTime Get_FechaEmision { get; }
        string Get_FacturaNro { get; }
        string Get_ControlNro { get; }
        string Get_CodXml { get; }
        string Get_ConceptoDesc { get; }
        decimal Get_MontoExento { get; }
        decimal Get_Base_1 { get; }
        decimal Get_Base_2 { get; }
        decimal Get_Base_3 { get; }
        decimal Get_Imp_1 { get; }
        decimal Get_Imp_2 { get; }
        decimal Get_Imp_3 { get; }
        decimal Get_TasaRet { get; }
        decimal Get_Sustraendo { get; }
        decimal Get_MontoRet { get; }
        decimal Get_SubtBase { get; }
        decimal Get_SubtImp { get; }
        decimal Get_Total { get; }
        object Get_Ficha { get; }
        string Get_Tasa_1 { get; }
        string Get_Tasa_2 { get; }
        string Get_Tasa_3 { get; }
        //
        void Inicializa();
        void setIdDocumento(string idDoc);
        void setCiRif(string dato);
        void setNombre(string dato);
        void setDirFiscal(string dato);
        void setFacturaNro(string dato);
        void setControlNro(string dato);
        void setCodigoXML(string dato);
        void setDescXML(string dato);
        void setFechaEmisionDoc(DateTime fecha);
        void setExento(decimal monto);
        void setBase1(decimal monto);
        void setBase2(decimal monto);
        void setBase3(decimal monto);
        void setImp1(decimal monto);
        void setImp2(decimal monto);
        void setImp3(decimal monto);
        void setSubtBase(decimal monto);
        void setSubtImp(decimal monto);
        void setTotal(decimal monto);
        void setTasaRet(decimal monto);
        void setSustraendo(decimal monto);
        void setRetencion(decimal monto);
        void CargarDoc();
    }
}