using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Beneficiario.Crud.Entidad
{
    public class Ficha: baseAgregarEditar
    {
        public int id { get; set; }
        public string estatusAnulado { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}