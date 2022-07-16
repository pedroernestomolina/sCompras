using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Administrador.Lista
{
    
    public class data
    {

        private DateTime _fechaUltCompra { get; set; }
        private DateTime _fechaBaja { get; set; }


        public string id { get; set; }
        public string ciRif { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string codigo { get; set; } 
        public bool IsActivo { get; set; }
        public DateTime fechaAlta { get; set; }
        public string Estatus { get; set; }
        public string fechaUltMov 
        { 
            get 
            {
                var rt = "";
                if (_fechaUltCompra != new DateTime(2000, 01, 01))
                    rt = _fechaUltCompra.ToShortDateString();
                return rt;
            } 
        }
        public string Encabezado
        {
            get
            {
                var rt = ciRif + Environment.NewLine + nombre;
                return rt;
            }
        }
        public string fechaFueraDeServicio 
        {
            get
            {
                var rt = "";
                if (_fechaBaja != new DateTime(2000, 01, 01))
                    rt = _fechaBaja.ToShortDateString();
                return rt;
            } 
        }


        public data() 
        {
            _fechaUltCompra = new DateTime(2000, 01, 01);
            _fechaBaja = new DateTime(2000, 01, 01);
            id = "";
            ciRif = "";
            nombre = "";
            direccion = "";
            codigo = "";
            IsActivo = true;
            fechaAlta = DateTime.Now.Date;
            Estatus = "";
        }


        public data(OOB.LibCompra.Proveedor.Data.Ficha rg)
            : this()
        {
            id = rg.autoId;
            ciRif = rg.ciRif;
            nombre = rg.nombreRazonSocial;
            direccion = rg.direccionFiscal;
            codigo = rg.codigo;
            IsActivo = rg.IsActivo;
            fechaAlta = rg.fechaAlta;
            Estatus = rg.estatus;
            _fechaUltCompra = rg.fechaUltCompra;
            _fechaBaja = rg.fechaBaja;
        }

    }

}