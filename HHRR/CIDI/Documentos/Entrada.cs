using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHRR.CIDI.Documentos
{
    public class Entrada
    {
        public int IdAplicacion { get; set; }

        public String Contrasenia { get; set; }

        public String TokenValue { get; set; }

        public String TimeStamp { get; set; }

        public String Cuil { get; set; }

        public String HashCookie { get; set; }

    }

    public class EntradaDoc : Entrada
    {
        public String CuilOperador { get; set; }
        public byte[] SharedKey { get; set; }
        public String Identificador { get; set; }
        public Documentacion Documentacion { get; set; }

        public EntradaDoc()
        {
            Documentacion = new Documentacion();
        }
    }

    public class EntradaVistaPrevia : Entrada
    {
        public Dictionary<Int32, Int32> DiccionarioDocumentos { get; set; }

        public EntradaVistaPrevia()
        {
            DiccionarioDocumentos = new Dictionary<Int32, Int32>();
        }
    }

}