using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.GestionPago
{
    public interface IDoc
    {
         string idCxP { get; set; }
         string idDocOrigen { get; set; }
         DateTime fechaEmision { get; set; }
         int diasCredito { get; set; }
         string tipoDoc { get; set; }
         string docNro { get; set; }
         int signoDoc { get; set; }
         DateTime fechaVence { get; set; }
         decimal importeDiv { get; set; }
         decimal acumuladoDiv { get; set; }
         decimal restaDiv { get; set; }
         decimal tasafactor { get; set; }
         int diasvencida { get; set; }
         string notasDoc { get; set; }
    }
}