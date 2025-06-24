using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHRR.Reportes
{
    public partial class printFichadas : System.Web.UI.Page
    {
        private ReportDocument customerReport = new ReportDocument();
        CrystalDecisions.Web.CrystalReportViewer crview = new CrystalDecisions.Web.CrystalReportViewer();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["anio"] == null)
                        Response.Redirect("../Empleado/index.aspx");

                    if (Request.QueryString["mes"] == null)
                        Response.Redirect("../Empleado/index.aspx");

                    int anio = Convert.ToInt32(Request.QueryString["anio"]);
                    int mes = Convert.ToInt32(Request.QueryString["mes"]);
                    int legajo = Convert.ToInt32(Request.Cookies["UserVecino"]["legajo"]);

                    List<DAL.REPORTE_FICHA> lstReporte = DAL.REPORTE_FICHA.read(legajo, anio, mes);
                    ConfigureFichadas(lstReporte);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void ConfigureFichadas(List<DAL.REPORTE_FICHA> lst)
        {
            try
            {
                string reportPath = Server.MapPath("lfichdia.rpt");
                customerReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                customerReport.Load(reportPath);

                customerReport.SetDataSource(lst);

                crview.ReportSource = customerReport;

                crview.RefreshReport();
                crview.DataBind();
                //PrintPDF();

                string archivo = "fichada";
                string fichero = Server.MapPath(archivo);
                if (System.IO.File.Exists(fichero))
                    fichero = fichero + "_1";

                archivo = archivo + ".html";
                customerReport.ExportToDisk(ExportFormatType.HTML40, Server.MapPath(archivo));

                fichero = Server.MapPath(archivo);
                System.IO.StreamReader sr = new System.IO.StreamReader(fichero);
                divFichadas.InnerHtml = sr.ReadToEnd();
                sr.Close();

                if (System.IO.File.Exists(fichero))
                    System.IO.File.Delete(fichero);

                //customerReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Fichadas");
            }

            catch (Exception ex)
            {
                System.Console.WriteLine("Error, no se pudo generar el Reporte " + ex.Message);
                Response.Write(ex.Message);
            }
            finally
            {
                ;
            }
        }
    }
}