using BLL;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHRR
{
    public partial class Login : System.Web.UI.Page
    {
        private CIDI.Usuario usuario;
        protected void ObtenerUsuario()
        {
            CIDI.Entrada entrada = new CIDI.Entrada();
            entrada.IdAplicacion = CIDI.Config.CiDiIdAplicacion;
            entrada.Contrasenia = CIDI.Config.CiDiPassAplicacion;
            entrada.HashCookie = Request.QueryString["cidi"].ToString();
            entrada.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            entrada.TokenValue = CIDI.Config.ObtenerToken_SHA1(entrada.TimeStamp);

            usuario = CIDI.Config.LlamarWebAPI<CIDI.Entrada,
                CIDI.Usuario>(CIDI.APICuenta.Usuario.Obtener_Usuario_Aplicacion, entrada);
        }
        //OK
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cidi"] != null)
            {
                ObtenerUsuario();
                try
                {
                    //DAL.VecinoDigital obj = new DAL.VecinoDigital();
                    Entities.Empleado obj = new Entities.Empleado();

                    obj = DAL.EmpleadoD.getBycuil(usuario.CUIL);
                    if (obj == null)
                    {

                    }
                    else
                    {
                        this.Response.Cookies.Add(new System.Web.HttpCookie("UserEmpleado")
                        {
                            ["Id"] = obj.legajo.ToString(),
                            ["NombreFormateado"] = usuario.NombreFormateado,
                            ["nombre"] = usuario.Nombre,
                            ["apellido"] = usuario.Apellido,
                            ["nivel"] = usuario.Id_Estado.ToString(),
                            ["CuilFormateado"] = usuario.CuilFormateado,
                            ["SesionHash"] = usuario.Respuesta.SesionHash,
                            ["cuit"] = usuario.CUIL,
                            Expires = DateTime.Now.AddDays(1.0)
                        });
                        Response.Redirect("Empleado/index.aspx");
                    }
                }
                catch (Exception ex)
                {
                    divLogIn.Visible = false;

                }

            }
        }
        //OK
        protected void btnIngresar_ServerClick(object sender, EventArgs e)
        {
          
                
        }
        //OK
        protected void btnOkError_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelConfirm_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarConfirm_Click(object sender, EventArgs e)
        {
            //            DAL.VecinoDigital obj = BLL.VecinoDigital.getByPk(hCuit.Value);
            //            string URL = string.Format("{0}?cuit={1}&fecha={2}",
            //System.Configuration.ConfigurationManager.AppSettings["URL_CONFIRMAR"].ToString(),
            //hCuit.Value, DateTime.Now.ToShortDateString());
            //            if (txtMailConfirm.Text == obj.MAIL)
            //            {
            //                mail.envio(txtMailConfirm.Text, URL);
            //                btnCancelConfirm_Click(null, null);
            //            }
            //            else
            //            {
            //                if (BLL.VecinoDigital.getByMail(txtMailConfirm.Text) != null)
            //                {
            //                    divConfirmacion.Visible = false;
            //                    divLogIn.Visible = false;
            //                    divError.Visible = true;
            //                    lblError.InnerText = "El mail ingresado ya esta asociado a otra cuenta";
            //                    lblConfirm.InnerText = string.Empty;
            //                    return;
            //                }
            //                else
            //                {
            //                    BLL.VecinoDigital.updateMail(txtMailConfirm.Text, hCuit.Value);
            //                    mail.envio(txtMailConfirm.Text, URL);
            //                    btnCancelConfirm_Click(null, null);
            //                }
            //            }
        }

        protected void btnIniciarSecion_ServerClick(object sender, EventArgs e)
        {

        }
    }
}