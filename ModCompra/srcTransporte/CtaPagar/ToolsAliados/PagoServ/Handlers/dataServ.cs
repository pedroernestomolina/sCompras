using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Handlers
{
    public class dataServ: Vistas.IdataServ
    {
        private OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha _ficha;


        public DateTime fechaDoc { get; set; }
        public string numeroDoc { get; set; }
        public string nombreDoc { get; set; }
        public string cliente { get; set; }
        public string servicio { get; set; }
        public decimal pendiente { get; set; }
        public bool isSelected { get; set; }


        public dataServ(OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha ficha)
        {
            fechaDoc = ficha.fechaDoc;
            numeroDoc = ficha.numDoc;
            nombreDoc = ficha.nombreDoc;
            cliente = ficha.clienteNombre;
            servicio = ficha.servDetalle;
            pendiente = ficha.importeServDiv - ficha.servMontoAcumuladoDiv;
            isSelected = false;
            _ficha = ficha;
        }
    }
}