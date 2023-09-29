using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Caja.Crud.Entidad
{
    public class Ficha
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal saldoInicial { get; set; }
        public decimal montoIngreso { get; set; }
        public decimal montoEgreso { get; set; }
        public decimal montoIngresoAnulado { get; set; }
        public decimal montoEgresoAnulado { get; set; }
        public string estatusAnulado { get; set; }
        public string esDivisa { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}