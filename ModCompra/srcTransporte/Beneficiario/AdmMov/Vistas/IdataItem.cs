using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.AdmMov.Vistas
{
    public interface IdataItem
    {
        DateTime FechaMov { get; set; }
        string BeneficiarioNombre { get; set; }
        string BeneficiarioCiRif { get; set; }
        decimal Monto { get; set; }
        string Motivo { get; set; }
        string Estatus { get; set; }
        string Concepto { get; set; }
    }
}