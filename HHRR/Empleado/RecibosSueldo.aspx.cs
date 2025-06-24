using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HHRR.Empleado
{
    public partial class RecibosSueldo : System.Web.UI.Page
    {
        //ACTUALIZADO
        override protected void OnInit(EventArgs e)
        {
            try
            {
                for (int i = DateTime.Now.Year - 2; i <= DateTime.Now.Year; i++)
                {
                    HtmlGenericControl li = new HtmlGenericControl();
                    li.TagName = "li";
                    HtmlAnchor a = new HtmlAnchor();
                    a.ServerClick += new EventHandler(btnCambiar_Click);
                    a.InnerText = string.Format("Año {0}", i);
                    a.ID = i.ToString();

                    li.Controls.Add(a);
                    ddlAnteriores.Controls.Add(li);
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divError.Visible = false;
                txtError.InnerText = string.Empty;
                int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);

                if (!Page.IsPostBack)
                {
                    AsignarDatos(BLL.EmpleadoB.GetByPkTodos(legajo));
                    AsignarSueldos(legajo, DateTime.Now.Year);
                    AsignarAginaldo(legajo, DateTime.Now.Year);
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }

        }

        //ACTUALIZADO
        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);
                HtmlAnchor a = (HtmlAnchor)sender;
                AsignarSueldos(legajo, int.Parse(a.ID));
                AsignarAginaldo(legajo, int.Parse(a.ID));
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }

        }

        private void AsignarDatos(Entities.Empleado objEmpleado)
        {
            try
            {
                //lblNombreEmpleado.InnerHtml = objEmpleado.nombre;
                //lblLegajo.InnerHtml = string.Format("Lejago: {0}", objEmpleado.legajo);
                List<DAL.HORARIOS> lst = DAL.HORARIOS.getByPk(objEmpleado.legajo);

            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        private void AsignarSueldos(int legajo, int anio)
        {
            try
            {
                List<DAL.LIQ_X_EMPLEADO> lst = BLL.LIQ_X_EMPLEADO.getLiquidaciones(anio, legajo, false);
                string contenido = string.Empty;
                foreach (var item in lst)
                {
                    contenido += string.Format(@"
                    <div class=""col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12"">
                        <div class=""box box-primary caja"" >
                            <div class=""box-header cabecera"" >
                                <h4>{0}</h4>
                            </div>
                            <div class=""box-body cuerpo"">
                                <span class=""fa fa-download"" style=""font-size: 50px; color: #fad613;""></span>
                            </div>
                            <div class=""box-footer"">
                                <a target=""_blank"" class=""btn btn-primary btn-block"" href=""../reportes/printRecibo.aspx?anio={1}&cod_tipo_liq={2}&nro_liq={3}&liquidacion={4}"">Descargar</a>
                            </div>
                        </div>
                    </div>", item.des_liquidacion, item.anio, item.cod_tipo_liq, item.nro_liquidacion, item.des_liquidacion);
                }
                divSueldos.InnerHtml = contenido;
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        private void AsignarAginaldo(int legajo, int anio)
        {
            try
            {
                List<DAL.LIQ_X_EMPLEADO> lst = BLL.LIQ_X_EMPLEADO.getLiquidaciones(anio, legajo, true);
                string contenido = string.Empty;
                foreach (var item in lst)
                {
                    contenido += string.Format(@"
                    <div class=""col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12"">
                        <div class=""box box-primary caja"" >
                            <div class=""box-header cabecera"" >
                                <h4>{0}</h4>
                            </div>
                            <div class=""box-body cuerpo"">
                                <span class=""fa fa-download"" style=""font-size: 50px; color: #fad613;""></span>
                            </div>
                            <div class=""box-footer"">
                                <a target=""_blank"" class=""btn btn-primary btn-block"" href=""../reportes/printRecibo.aspx?anio={1}&cod_tipo_liq={2}&nro_liq={3}&liquidacion={4}"">Descargar</a>
                            </div>
                        </div>
                    </div>", item.des_liquidacion, item.anio, item.cod_tipo_liq, item.nro_liquidacion, item.des_liquidacion);
                }
                divAguinaldos.InnerHtml = contenido;

            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }
    }
}