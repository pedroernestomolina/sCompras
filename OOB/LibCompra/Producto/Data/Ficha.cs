using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Producto.Data
{
    
    public class Ficha
    {


        public string auto { get; set; }
        public string autoDepartamento { get; set; }
        public string autoMarca { get; set; }
        public string autoGrupo { get; set; }
        public string autoTasa { get; set; }
        public string autoSubGrupo { get; set; }

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public string referencia { get; set; }
        public int contenidoCompra { get; set; }
        public string empaqueCompra { get; set; }
        public string decimales { get; set; }
        public string origen { get; set; }
        public string categoria { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }
        public Enumerados.EnumAdministradorPorDivisa AdmPorDivisa { get; set; }
        public string departamento { get; set; }
        public string codigoDepartamento { get; set; }
        public string grupo { get; set; }
        public string codigoGrupo { get; set; }
        public string marca { get; set; }
        public decimal tasaIva { get; set; }
        public string nombreTasaIva { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal costo { get; set; }
        public DateTime? fechaUltCambio { get; set; }


        public decimal costoDivisaUnd 
        {
            get 
            {
                var rt = 0.0m;
                rt = costoDivisa / contenidoCompra;
                return rt;
            }
        }

        public decimal costoUnd
        {
            get
            {
                var rt = 0.0m;
                rt = costo / contenidoCompra;
                return rt;
            }
        }

        public bool EsExento 
        {
            get 
            {
                var rt = false;
                if (tasaIva == 0)
                    rt = true;
                return rt;
            }
        }

        public string tasaTipoIva
        {
            get
            {
                var rt = "";
                if (autoTasa == "0000000001")
                    rt = "1";
                if (autoTasa == "0000000002")
                    rt = "2";
                if (autoTasa == "0000000003")
                    rt = "3";
                return rt;
            }
        }


        public Ficha()
        {
            auto = "";
            autoDepartamento = "";
            autoGrupo = "";
            autoMarca = "";
            autoTasa = "";
            autoSubGrupo = "";
            codigo = "";
            nombre = "";
            descripcion = "";
            modelo = "";
            referencia = "";
            contenidoCompra = 1;
            empaqueCompra = "";
            decimales = "0";
            origen = "";
            categoria = "";
            estatus = Enumerados.EnumEstatus.SnDefinir;
            AdmPorDivisa = Enumerados.EnumAdministradorPorDivisa.SnDefinir;
            departamento = "";
            codigoDepartamento = "";
            grupo = "";
            codigoGrupo = "";
            marca = "";
            tasaIva = 0.0m;
            nombreTasaIva = "";
            costo = 0.0m;
            costoDivisa = 0.0m;
        }

        public Ficha(Documento.GetData.FichaDetalle it): this()
        {
            auto = it.prdAuto;
            autoDepartamento = it.prdAutoDepartamento;
            autoGrupo = it.prdAutoGrupo;
            autoTasa = it.prdAutoTasaIva;
            codigo = it.prdCodigo;
            nombre = it.prdNombre;
            descripcion = it.prdNombre;
            contenidoCompra = it.contenido ;
            tasaIva = it.tasaIva;
            empaqueCompra = it.empaqueCompra;
            decimales = it.decimales;
            categoria = it.categoria;
        }

        public Ficha(Documento.ListaItemImportar.Ficha it): this()
        {
            auto = it.prdAuto;
            autoDepartamento = it.prdAutoDepartamento;
            autoGrupo = it.prdAutoGrupo;
            autoTasa = it.prdAutoTasaIva;
            codigo = it.prdCodigo;
            nombre = it.prdNombre;
            descripcion = it.prdNombre;
            contenidoCompra = it.contenidoEmp ;
            tasaIva = it.tasaIva;
            empaqueCompra = it.empaqueCompra;
            decimales = it.decimales;
            categoria = it.categoria;
        }

        public Ficha(Documento.Pendiente.Abrir.FichaDetalle it):
            this()
        {
            auto = it.prdAuto;
            autoDepartamento = it.prdAutoDepartamento;
            autoGrupo = it.prdAutoGrupo;
            autoTasa = it.prdAutoTasaIva;
            codigo = it.prdCodigo;
            nombre = it.prdNombre;
            descripcion = it.prdNombre;
            contenidoCompra = it.contenidoEmp;
            tasaIva = it.tasaIva;
            empaqueCompra = it.empaqueCompra;
            decimales = it.decimales;
            categoria = it.categoria;
        }

    }

}