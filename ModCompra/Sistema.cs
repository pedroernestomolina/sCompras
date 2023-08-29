using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra
{
    public class Sistema
    {
        static public Fabrica.IFabrica Fabrica;
        static public DataProvCompra.InfraEstructura.IData MyData;
        static public OOB.LibCompra.Usuario.Data.Ficha UsuarioP;
        static public OOB.LibCompra.Empresa.Data.Ficha Negocio;
        static public string _Instancia { get; set; }
        static public string _BaseDatos { get; set; }
        static public string _Usuario { get; set; }
        static public string EquipoEstacion { get; set; }
        static public Documento.CnfGenerarDocumento CnfGenerarDoc;
    }
}