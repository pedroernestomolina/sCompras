using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Administrador.Documentos
{
    
    public class data
    {
        
        private OOB.LibCompra.Documento.Lista.Ficha rg;


        public OOB.LibCompra.Documento.Lista.Ficha Ficha { get { return rg; } }
        public string AutoDoc { get { return rg.auto; } }
        public DateTime Fecha { get { return rg.fechaEmision; } }
        public string NombreDoc { get { return rg.tipoDocNombre; } }
        public string CodigoDoc { get { return rg.codigoTipo; } }
        public string Documento { get { return rg.documentoNro; } }
        public string Control { get { return rg.ControlNro; } }
        public DateTime FechaReg { get { return rg.fechaRegistro; } }
        public string Sucursal { get { return rg.codigoSuc+"/"+rg.nomSucursal; } }
        public string ProvNombre { get { return rg.provNombre; } }
        public string ProvCiRif { get { return rg.provCiRif; } }
        public decimal Importe { get { return rg.monto; } }
        public decimal ImporteDivisa { get { return rg.montoDivisa; } }
        public string Situacion { get { return rg.situacion; } }
        public bool IsAnulado { get { return rg.esAnulado; } }
        public string Signo { get { return rg.Signo == 1 ? "+" : "-"; } }
        public string Aplica { get { return rg.Aplica; } }
        public string Estatus 
        { 
            get 
            {
                var rt = "";
                rt = IsAnulado ? "ANULADO" : "";
                return rt;
            }
        }


        public data(OOB.LibCompra.Documento.Lista.Ficha rg)
        {
            this.rg = rg;
        }

    }

}