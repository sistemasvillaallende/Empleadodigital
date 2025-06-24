using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHRR.Certificados
{
    public partial class CertLaboral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);

            if (!Page.IsPostBack)
            {
                AsignarDatos(BLL.EmpleadoB.GetByPkTodos(legajo));
            }

        }

        public void AsignarDatos(Entities.Empleado obj)
        {
            try
            {
                DAL.LIQ_X_EMPLEADO haber = DAL.LIQ_X_EMPLEADO.getUltimoHaber(obj.legajo, DateTime.Now.Year);

                StringBuilder html = new StringBuilder();
                html.Append("<p style=\"text-align:justify;\">");
                if (obj.sexo == "M")
                    html.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Conste: Que el Sr. <strong>{0}</strong>", obj.nombre.ToUpper().Trim()));
                else
                    html.Append(string.Format("   Conste: Que la Sra. <strong>{0}</strong>", obj.nombre.ToUpper().Trim()));

                html.Append(string.Format(", D.N.I. {0}, con domicilio en {1} {2}", obj.nro_documento.ToUpper().Trim(),
                    obj.calle_domicilio.ToUpper().Trim(), obj.nro_domicilio.ToUpper().Trim()));
                if (obj.barrio_domicilio != string.Empty)
                    html.Append(string.Format(" Bº {0}", obj.barrio_domicilio.ToUpper().Trim()));
                html.Append(string.Format(" de la Ciudad de {0}, con fecha de ingreso el {1}",
                    obj.ciudad_domicilio.ToUpper().Trim(), obj.fecha_ingreso));
                html.Append(string.Format(", cumple funciones en esta Municipalidad en carácter de {0}, ",
                    obj.des_clasif_per.ToUpper().Trim()));
                //html.Append(string.Format("percibiendo una remuneración en bruto de Pesos: ${0} (PESOS {1})",
                //    haber.sueldo_neto.ToString(), conversiones.enletras(haber.sueldo_neto.ToString())));

                //List<DAL.EMBARGO_SUELDOS> lst = DAL.EMBARGO_SUELDOS.getByLegajo(obj.legajo);
                //if (lst.Count == 0)
                //    html.Append(", no registrando a la fecha Embargos ni Retenciones Judiciales.-");
                //else
                //{
                //    html.Append(" registrando a la fecha, ");
                //    int i = 0;
                //    foreach (var item in lst)
                //    {
                //        if (i != 0)
                //        {
                //            html.Append(", ");
                //            html.Append(string.Format("retención por {0} ({1})", item.des_concepto_liq, item.nom_caratula));
                //        }
                //        else
                //        {
                //            html.Append(string.Format("retención por {0} ({1})", item.des_concepto_liq, item.nom_caratula));
                //            i = 1;
                //        }

                //    }
                //}
                html.Append("<p/><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Se realizan los aportes jubilatorios a la Caja de Jubilaciones y Pensiones ");
                html.Append("y retiros de la Provincia de Córdoba.- <p/><p>");
                html.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Se extiende el presente a pedido del interesado para ser presentado ante");

                html.Append(string.Format("quien corresponda, a los {0} días del mes de {1} de {2}.-</p>",
                    DateTime.Now.Day, MonthName(DateTime.Now.Month), DateTime.Now.Year));

                divCert.InnerHtml = html.ToString();
                /*               
                                     
*/
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
    }
}