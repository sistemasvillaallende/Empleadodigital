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
    public partial class CertNoAsignaciones : System.Web.UI.Page
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
                int anio = 0;
                if (DateTime.Now.Month == 1)
                    anio = DateTime.Now.Year - 1;
                else
                    anio = DateTime.Now.Year;

                DAL.LIQ_X_EMPLEADO haber = DAL.LIQ_X_EMPLEADO.getUltimoHaber(obj.legajo, anio);
                List<DAL.DET_LIQ_X_EMPLEADO> lst =
                    DAL.DET_LIQ_X_EMPLEADO.read(haber.legajo, haber.anio, haber.nro_liquidacion);

                bool control = false;
                control = lst.Exists(c => c.cod_concepto_liq == 470 || c.cod_concepto_liq == 410);
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

                if (!control)
                {
                    html.Append("el cual NO percibe en sus haberes mensuales salario familiar alguno.");
                }
                else
                {
                    html.Append("el cual percibe en sus haberes mensuales salario familiar por ");
                    int i = 0;
                    foreach (var item in lst)
                    {
                        if (item.cod_concepto_liq == 410 || item.cod_concepto_liq == 470)
                        {
                            if (i != 0)
                            {
                                html.Append(", ");
                                html.Append(string.Format("{0} Unidades: {1} Monto: ${2}",
        item.des_concepto_liq, item.unidades, item.importe));
                            }
                            else
                            {
                                html.Append(string.Format("{0} Unidades: {1} Monto: ${2}",
        item.des_concepto_liq, item.unidades, item.importe));
                                i = 1;
                            }
                        }
                    }
                    divCert.InnerHtml = html.ToString();
                }

                html.Append("</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Se extiende el presente a pedido del interesado para ser presentado ante");

                html.Append(string.Format("quien corresponda, a los {0} días del mes de {1} de {2}.-</p>",
                    DateTime.Now.Day, MonthName(DateTime.Now.Month), DateTime.Now.Year));

                divCert.InnerHtml = html.ToString();

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