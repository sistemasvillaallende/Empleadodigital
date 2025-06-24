using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHRR.CIDI.Documentos
{
    public class Permiso
    {
        public Int32 IdTipoDocumentacion { get; set; }
        public String NombreTipoDocumentacion { get; set; }
        public String Upload { get; set; }
        public String Discard { get; set; }
    }
}