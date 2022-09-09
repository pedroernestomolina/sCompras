using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ModCompra.Helpers
{
    
    public class Utilitis
    {

        static public OOB.Resultado CargarXml()
        {
            var result = new OOB.Resultado();

            try
            {
                var doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Conf.XML");

                if (doc.HasChildNodes)
                {
                    foreach (XmlNode nd in doc)
                    {
                        if (nd.LocalName.ToUpper().Trim() == "CONFIGURACION")
                        {
                            foreach (XmlNode nv in nd.ChildNodes)
                            {
                                if (nv.LocalName.ToUpper().Trim() == "SERVIDOR")
                                {
                                    foreach (XmlNode sv in nv.ChildNodes)
                                    {
                                        if (sv.LocalName.Trim().ToUpper() == "INSTANCIA")
                                        {
                                            Sistema._Instancia = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "CATALOGO")
                                        {
                                            Sistema._BaseDatos = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "USUARIO")
                                        {
                                            Sistema._Usuario= sv.InnerText.Trim();
                                        }
                                    }
                                }

                                if (nv.LocalName.ToUpper().Trim() == "DOCUMENTOS")
                                {
                                    foreach (XmlNode cn in nv.ChildNodes)
                                    {
                                        if (cn.LocalName.ToUpper().Trim() == "GENERAR_DOCUMENTO")
                                        {
                                            foreach (XmlNode sv in cn.ChildNodes)
                                            {
                                                if (sv.LocalName.Trim().ToUpper() == "HABILITAR_ABRIR_DOCUMENTOS_OTROS_USUARIOS")
                                                {
                                                    Sistema.CnfGenerarDoc.HabilitarAbrirDocumentosOtrosUsuario = sv.InnerText.Trim().ToUpper() == "SI";
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                result.Result = OOB.Enumerados.EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }

    }

}