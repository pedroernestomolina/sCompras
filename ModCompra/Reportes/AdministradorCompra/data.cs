using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.AdministradorCompra
{
    
    public class data
    {

        public DateTime FechaEmision { get; set; }
        public string NombreDoc { get; set; }
        public string CodigoDoc { get; set; }
        public string NumDocumento { get; set; }
        public string NumControl { get; set; }
        public DateTime FechaReg { get; set; }
        public string Sucursal { get; set; }
        public string ProvNombre { get; set; }
        public string ProvCiRif { get; set; }
        public decimal Importe { get; set; }
        public decimal ImporteDivisa { get; set; }
        public string Situacion { get; set; }
        public bool IsAnulado { get; set; }
        public string SignoDesc { get; set; }
        public string Aplica { get; set; }
        public int Signo { get { return SignoDesc.Trim().ToUpper() == "-" ? -1 : 1; } }


        public data()
        {
            Aplica = "";
            SignoDesc = "";
            IsAnulado = false;
            Situacion = "";
            Importe = 0m;
            ImporteDivisa = 0m;
            ProvCiRif = "";
            ProvNombre = "";
            Sucursal = "";
            FechaReg = DateTime.Now.Date;
            FechaEmision = DateTime.Now.Date;
            NombreDoc = "";
            CodigoDoc = "";
            NumControl = "";
            NumDocumento = "";
        }

    }

}