using CryptoManager.Clases;
using HHRR.CIDI.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHRR.MP
{
    public partial class MP : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            if (Request.Cookies["UserVecino"] == null)
            {
                Response.Redirect("https://vecino.villaallende.gov.ar");
            }
            //if (Request.Url.IsLoopback ||
            //   Request.Url.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            //{
            //    this.Response.Cookies.Add(new HttpCookie("UserVecino")
            //    {
            //        ["administrador"] = "1",
            //        ["apellido"] = "ANDRES",
            //        ["cod_oficina"] = "19",
            //        ["cod_usuario"] = "181",
            //        ["cuit"] = "20225378232",
            //        ["cuit_formateado"] = "23-27.173.499.9",
            //        ["legajo"] = "377",
            //        ["nombre"] = "MANUEL A",
            //        ["nombre_completo"] = "ANDRES, MANUEL A",
            //        ["nombre_oficina"] = "SISTEMAS",
            //        ["nombre_usuario"] = "mvelez",
            //        ["SesionHash"] = "544A4A58676B6D594331524A746C6B71586642653872726B5770413D",
            //        ["lstPermisos"] = "SOY ADMIN",
            //        Expires = DateTime.Now.AddDays(1000.0)
            //    });
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserVecino"] != null)
                {
                    int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);
                    Entities.Empleado obj = DAL.EmpleadoD.GetByPk(legajo);
                    mnuPcApellido.InnerHtml = string.Format("<strong>{0}</strong>",
                        Request.Cookies["UserVecino"]["apellido"]);
                    liApellido.InnerHtml = Request.Cookies["UserVecino"]["apellido"];
                    liNombre.InnerHtml = Request.Cookies["UserVecino"]["nombre"];
                    mnuPcNombre.InnerText = string.Format("{0}", Request.Cookies["UserVecino"]["nombre"]);

                    //spanUsuario3.InnerText =
                    //    Usu.NOMBRE;
                    TraerFotoPerfil();


                    mnuPcNivelCidi.InnerHtml = "2";
                    mnuPcCuit.InnerHtml = Request.Cookies["UserVecino"]["cuit"];
                }
                else
                {
                    Response.Redirect("https://vecino.villaallende.gov.ar");
                }

            }
            //lblEmpleado.InnerHtml = obj.nombre;
        }
        protected void TraerFotoPerfil()
        {
            //txtDocumentos.Text = String.Empty;

            CIDI.Documentos.Entrada entrada = new CIDI.Documentos.Entrada();
            entrada.IdAplicacion = CIDI.Documentos.Config.CiDiIdAplicacion;
            entrada.Contrasenia = CIDI.Documentos.Config.CiDiPassAplicacion;
            entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            entrada.TokenValue = CIDI.Documentos.Config.ObtenerToken_SHA512(entrada.TimeStamp);
            entrada.HashCookie = Request.Cookies["UserVecino"]["SesionHash"];
            entrada.Cuil = Request.Cookies["UserVecino"]["cuit"];

            RespuestaDoc respuesta = CIDI.Documentos.Config.LlamarWebAPI<CIDI.Documentos.Entrada, RespuestaDoc>(
                CIDI.Documentos.APIDocumentacion.Documentacion.Obtener_Foto_Perfil, entrada);

            if (respuesta.Resultado == CIDI.Documentos.Config.CiDi_OK)
            {
                //Desencriptado de la Documentación
                CryptoHash objCryptoHash = new CryptoManager.Clases.CryptoHash();
                String mensaje = String.Empty;

                respuesta.Documentacion.Imagen = objCryptoHash.Descifrar_Datos(respuesta.Documentacion.Imagen, out mensaje);

                if (String.IsNullOrEmpty(mensaje))
                {
                    MostrarImagen(respuesta);
                }
            }
        }
        private void MostrarImagen(RespuestaDoc Respuesta)
        {
            String ext = Respuesta.Documentacion.Extension.ToUpper();
            String[] FormatosPermitidos = new String[] { "JPG", "JPEG", "PNG", "BMP", "GIF", "PDF", "DOC", "DOCX", "XLS", "XLSX", "TXT" };

            if (Array.IndexOf(FormatosPermitidos, ext) >= 0)
            {
                //if (Respuesta.Documentacion.VistaPrevia != null)
                if (ext != "PDF")
                {
                    String ImgVistaPrevia = Convert.ToBase64String(Respuesta.Documentacion.Imagen, 0, Respuesta.Documentacion.Imagen.Length);
                    imgUsuario.Src = "data:image/png;base64," + ImgVistaPrevia;
                    imgUsuario.Visible = true;
                    // imgUsuario2.Src = "data:image/png;base64," + ImgVistaPrevia;
                    // imgUsuario2.Visible = true;
                    return;
                }

                if (ext == "PDF")
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + Respuesta.Documentacion.Descripcion + ".pdf");
                    Response.BinaryWrite(Respuesta.Documentacion.Imagen);
                    Response.Flush();

                    Response.End();
                }
                else
                {
                    //Código para bajar el documento
                    Response.ContentType = "image/" + ext;
                    Response.AddHeader("content-disposition", "attachment;filename=" + Respuesta.Documentacion.Descripcion + "." + ext);
                    Response.BinaryWrite(Respuesta.Documentacion.Imagen);
                    Response.Flush();

                    Response.End();

                    String Img = Convert.ToBase64String(Respuesta.Documentacion.Imagen, 0, Respuesta.Documentacion.Imagen.Length);
                    imgUsuario.Src = "data:image/jpg;base64," + Img;
                    imgUsuario.Visible = true;
                }
            }
            else
            {
                Response.Write("<script>alert('Formato de archivo no compatible.');</script>");
            }
        }
        //OK
        protected void btnSalir_ServerClick(object sender, EventArgs e)
        {
            CIDI.Entrada entrada = new CIDI.Entrada();
            entrada.IdAplicacion = CIDI.Config.CiDiIdAplicacion;
            entrada.Contrasenia = CIDI.Config.CiDiPassAplicacion;
            entrada.HashCookie = Request.Cookies["UserVecino"]["SesionHash"];
            entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            entrada.TokenValue = CIDI.Config.ObtenerToken_SHA1(entrada.TimeStamp);

            CIDI.Respuesta respuesta = CIDI.Config.LlamarWebAPI<CIDI.Entrada,
                CIDI.Respuesta>(CIDI.APICuenta.Usuario.Cerrar_Sesion_Usuario_Aplicacion, entrada);

            if (respuesta.Resultado == CIDI.Config.CiDi_OK)
            {
                Response.Cookies["UserVecino"].Expires = DateTime.Now.AddDays(-1d);
                Response.Redirect("../index.aspx");
            }


        }

        protected void btnCerraSession_ServerClick(object sender, EventArgs e)
        {
            // Verificar si la cookie existe en la solicitud
            if (Request.Cookies["UserVecino"] != null)
            {
                // Crear una nueva cookie con el mismo nombre pero vacía
                HttpCookie cookie = new HttpCookie("UserVecino")
                {
                    Expires = DateTime.Now.AddDays(-1), // Fecha de expiración en el pasado
                    Value = string.Empty // Dejar el valor vacío
                };

                // Agregarla a la respuesta para sobrescribir la existente
                Response.Cookies.Add(cookie);

                // También eliminarla del lado del servidor
                Request.Cookies.Remove("UserVecino");
            }
        }
    }
}