using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHRR.Empleado
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);

                if (!Page.IsPostBack)
                {
                    AsignarDatos(BLL.EmpleadoB.GetByPkTodos(legajo));
                }
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

            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }
    }
}