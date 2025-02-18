using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Corrector.Documento
{
    public interface IGestion: HlpGestion.IGestion
    {
        string GetDocumento { get; }
        string GetControl { get; }
        string GetNotas { get; }
        string GetCiRif { get; }
        string GetRazonSocial { get; }
        string GetDirFiscal { get; }
        DateTime GetFechaEmision { get; }
        string GetMontoExento { get; }
        string GetMontoBase1 { get; }
        string GetMontoBase2 { get; }
        string GetMontoBase3 { get; }
        string GetMontoIva1 { get; }
        string GetMontoIva2 { get; }
        string GetMontoIva3 { get; }
        string GetTasa1 { get; }
        string GetTasa2 { get; }
        string GetTasa3 { get; }
        string GetMontoBase { get; }
        string GetMontoIva { get; }
        string GetMontoTotal { get; }
        //
        void setDocumento(string p);
        void setFechaEmision(DateTime dateTime);
        void setControl(string p);
        void setCiRif(string p);
        void setRazonSocial(string p);
        void setDirFiscal(string p);
        void setNotas(string p);
        void setMontoExento(decimal monto);
        void setMontoBase1(decimal monto);
        void setMontoBase2(decimal monto);
        void setMontoBase3(decimal monto);
        void setMontoIva1(decimal monto);
        void setMontoIva2(decimal monto);
        void setMontoIva3(decimal monto);
        void setMontoBase(decimal monto);
        void setMontoIva(decimal monto);
        void setMontoTotal(decimal monto);
        //
        void AbandonarFicha();
        void ProcesarFicha();
        bool AbandonarFichaIsOk { get; }
        bool ProcesarFichaIsOk { get; }
    }
}