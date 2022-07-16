using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar
{
    
    public class dataDocumento
    {

        private DateTime fechaServidor;


        public OOB.LibCompra.Proveedor.Data.Ficha proveedor { get; set; }
        public OOB.LibCompra.Sucursal.Data.Ficha Sucursal { get; set; }
        public OOB.LibCompra.Deposito.Data.Ficha Deposito { get; set; }

        public string documentoNro { get; set; }
        public DateTime fechaEmision { get; set; }
        public int diasCredito { get; set; }
        public string controlNro { get; set; }
        public string ordenCompra { get; set; }
        public decimal factorDivisa { get; set; }
        public string notas { get; set; }
        public string IdSucursal
        {
            get
            {
                var rt = "";
                if (Sucursal!= null) { rt = Sucursal.auto; }
                return rt;
            }
        }
        public string IdDeposito 
        { 
            get 
            {
                var rt = "";
                if (Deposito != null) { rt = Deposito.auto; }
                return rt; 
            }
        }
        public string mesRelacion { get { return fechaServidor.Month.ToString().Trim().PadLeft(2,'0'); } }
        public string anoRelacion { get { return fechaServidor.Year.ToString().Trim().PadLeft(4, '0'); } }
        public DateTime fechaVencimiento { get { return fechaEmision.AddDays(diasCredito); } }

        public string idProveedor 
        {
            get 
            {
                var rt = "";
                if (proveedor != null)
                    rt = proveedor.identidad.auto;
                return rt;
            }
        }

        public string ciRif 
        { 
            get 
            {
                var rt = "";
                if (proveedor!=null)
                    rt= proveedor.identidad.ciRif;
                return rt;
            }
        }
        public string nombreRazonSocial 
        { 
            get 
            {
                var rt = "";
                if (proveedor != null)
                    rt = proveedor.identidad.nombreRazonSocial;
                return rt;
            } 
        }
        public string direccionFiscal 
        { 
            get 
            {
                var rt = "";
                if (proveedor != null)
                    rt = proveedor.identidad.dirFiscal;
                return rt;
            } 
        }

        public string DepositoNombre 
        {
            get 
            {
                var rt = "";
                if (Deposito != null)
                    rt = Deposito.nombre;
                return rt;
            }
        }

        public string SucursalNombre 
        {
            get 
            {
                var rt = "";
                if (Sucursal != null)
                    rt = Sucursal.nombre;
                return rt;
            }
        }


        public dataDocumento()
        {
            limpiarData();
        }


        public void setFechaServidor(DateTime fecha)
        {
            fechaServidor = fecha;
        }

        public void setFactorDivisa(decimal p)
        {
            factorDivisa = p;
        }

        public bool ValidarEntradas()
        {
            var rt=true;

            if (proveedor== null)
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Proveedor]");
                return false;
            }
            if (documentoNro == "")
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Documento Nro]");
                return false;
            }
            if (controlNro== "")
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Control Nro]");
                return false;
            }
            if (Sucursal == null)
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Sucursal]");
                return false;
            }
            if (Deposito == null)
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Depósito]");
                return false;
            }

            return rt;
        }

        public void Limpiar()
        {
            limpiarData();
        }

        private void limpiarData()
        {
            proveedor = null;
            Deposito = null;
            Sucursal = null;
            documentoNro = "";
            fechaEmision = DateTime.Now.Date;
            diasCredito = 0;
            controlNro = "";
            ordenCompra = "";
            factorDivisa = 0.0m;
            notas = "";
        }

        public void setDocumentoNro(string p)
        {
            documentoNro = p;
        }

        public  void setControlNro(string p)
        {
            controlNro = p;
        }

        public void setFechaEmision(DateTime p)
        {
            this.fechaEmision = p;
        }

        public void setDiasCredito(int p)
        {
            this.diasCredito = p;
        }

        public void setOrdenCompra(string p)
        {
            this.ordenCompra = p;
        }

        public void setSucursal(OOB.LibCompra.Sucursal.Data.Ficha ficha)
        {
            this.Sucursal = ficha;
        }

        public void setDeposito(OOB.LibCompra.Deposito.Data.Ficha ficha)
        {
            this.Deposito = ficha;
        }

    }

}