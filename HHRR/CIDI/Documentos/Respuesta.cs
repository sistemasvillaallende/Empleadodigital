using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHRR.CIDI.Documentos
{
    public class Respuesta
    {
        public String Resultado { get; set; }
        public String CodigoError { get; set; }
        public String SesionHash { get; set; }

    }

    public class RespuestaList : Respuesta
    {
        public List<Documentacion> Documentos { get; set; }

        public RespuestaList()
        {
            Documentos = new List<Documentacion>();
        }
    }

    public class RespuestaDoc : Respuesta
    {
        public Documentacion Documentacion { get; set; }

        public RespuestaDoc()
        {
            Documentacion = new Documentacion();
        }
    }

    public class RespuestaDocInsercion : Respuesta
    {
        public Int32 IdDocumento { get; set; }
    }

    public class RespuestaTipoDoc : Respuesta
    {
        public List<TipoDocumentacion> TipoDocList { get; set; }

        public RespuestaTipoDoc()
        {
            TipoDocList = new List<TipoDocumentacion>();
        }
    }

    public class RespuestaVistaPrevia : Respuesta
    {
        public List<VistaPrevia> Lista_Vista_Previa { get; set; }

        public RespuestaVistaPrevia()
        {
            Lista_Vista_Previa = new List<VistaPrevia>();
        }
    }

    public class RespuestaListDoc : Respuesta
    {
        public String ExisteUsuario { get; set; }
        public String Tipo { get; set; }
        public String Denominacion { get; set; }
        public String Fecha { get; set; }
        public List<Documentacion> Documentos { get; set; }

        public RespuestaListDoc()
        {
            Documentos = new List<Documentacion>();
        }
    }
}