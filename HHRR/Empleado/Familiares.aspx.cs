using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HHRR.Empleado
{
    public partial class Familiares : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);

                if (!Page.IsPostBack)
                {
                    AsignarDatos(BLL.EmpleadoB.GetByPkTodos(legajo));
                    fillFamiliares(legajo);
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }

        }

        public void fillFamiliares(int legajo)
        {
            try
            {
                List<DAL.FAMILIARES> lst = DAL.FAMILIARES.read(legajo);
                gvFamiliares.DataSource = lst;
                gvFamiliares.DataBind();

                if (lst.Count() > 0)
                    gvFamiliares.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void gvFamiliares_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.FAMILIARES obj = (DAL.FAMILIARES)e.Row.DataItem;
                    //HtmlGenericControl lblEdad = (HtmlGenericControl)e.Row.FindControl("lblEdad");
                    HtmlGenericControl lblSexo = (HtmlGenericControl)e.Row.FindControl("lblSexo");
                    if (obj.sexo == 1)
                        lblSexo.InnerHtml = "<span style=\"color:#ff64b5; font-size:24px;\" class=\"fa fa-female\"></span>";
                    else
                        lblSexo.InnerHtml = "<span style=\"color:#29aae3; font-size:24px;\" class=\"fa fa-male\"></span>";

                    //lblEdad.InnerText = string.Format("{0} Años", Edad(obj.fecha_nacimiento).ToString());
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        public int Edad(DateTime fechaNacimiento)
        {
            try
            {
                //Obtengo la diferencia en años.
                int edad = DateTime.Now.Year - fechaNacimiento.Year;

                //Obtengo la fecha de cumpleaños de este año.
                DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);

                //Le resto un año si la fecha actual es anterior 
                //al día de nacimiento.
                if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
                {
                    edad--;
                }

                return edad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}