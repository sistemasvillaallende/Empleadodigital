using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHRR.Back
{
    public partial class LicenciasFormaCalculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null)
                    Response.Redirect("Licencias.aspx");
                if (!IsPostBack)
                {
                    DAL.LICENCIAS obj = DAL.LICENCIAS.getByPk(Convert.ToInt32(Request.QueryString["id"]));
                    lblLicencia.InnerHtml = obj.descripcion;
                    fillFormasCalculo(obj.cod_tipo_licencia);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void fillFormasCalculo(int id)
        {
            try
            {
                gvLicencias.DataSource = DAL.LICENCIA_PARAM_EMPLEADOS.read(id);
                gvLicencias.DataBind();
                decimal maxDesde = DAL.LICENCIA_PARAM_EMPLEADOS.getMax();
                if (maxDesde < 1)
                {
                    txtDesde.Text = decimal.Round(maxDesde * 12, 0).ToString();
                    DDLUnidadDesde.SelectedItem.Value = "0";
                    DDLUnidadDesde.Enabled = false;
                }
                else
                {
                    txtDesde.Text = decimal.Round(maxDesde, 0).ToString();
                    DDLUnidadDesde.SelectedItem.Value = "1";
                    DDLUnidadDesde.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvLicencias_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvLicencias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.LICENCIA_PARAM_EMPLEADOS obj = (DAL.LICENCIA_PARAM_EMPLEADOS)e.Row.DataItem;
                    Label lblDesde = (Label)e.Row.FindControl("lblDesde");
                    Label lblHasta = (Label)e.Row.FindControl("lblHasta");
                    Label lblDias = (Label)e.Row.FindControl("lblDias");

                    if (obj.anio_desde < 1)
                        lblDesde.Text = string.Format("{0} Meses", decimal.Round(obj.anio_desde * 12, 0));
                    else
                        lblDesde.Text = string.Format("{0} Años", decimal.Round(obj.anio_desde, 0));

                    if (obj.anios_hasta < 1)
                        lblHasta.Text = string.Format("{0} Meses", decimal.Round(obj.anios_hasta * 12, 0));
                    else
                        lblHasta.Text = string.Format("{0} Años", decimal.Round(obj.anios_hasta, 0));

                    if (obj.proporcional)
                        lblDias.Text = "Calculo proporcional";
                    else
                        lblDias.Text = obj.cantidad_dias.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.LICENCIA_PARAM_EMPLEADOS obj = new DAL.LICENCIA_PARAM_EMPLEADOS();
                obj.cod_tipo_licencia = Convert.ToInt32(Request.QueryString["id"]);
                if (DDLUnidadDesde.SelectedItem.Value == "0")
                {
                    if (Convert.ToInt32(txtDesde.Text) == 0)
                        obj.anio_desde = 0;
                    else
                        obj.anio_desde = Convert.ToDecimal(txtDesde.Text) / 12;

                }
                else
                    obj.anio_desde = Convert.ToInt32(txtDesde.Text);

                if (DDLUnidadHasta.SelectedItem.Value == "0")
                {
                    if (Convert.ToInt32(txtHasta.Text) == 0)
                        obj.anios_hasta = 0;
                    else
                        obj.anios_hasta = Convert.ToDecimal(txtHasta.Text) / 12;

                }
                else
                    obj.anios_hasta = Convert.ToInt32(txtHasta.Text);
                //txt.Text = "años: " + (da.Year - dn.Year).ToString() + " meses:" + (Math.Abs(da.Month - dn.Month)) + " dias: " + (da.Day - dn.Day) + " horas: " + (da.Hour - dn.Hour);

                if (DDLDias.SelectedIndex == 0)
                    obj.habiles = true;
                else
                    obj.habiles = false;

                if (chkProporcional.Checked)
                {
                    obj.proporcional = true;
                }
                else
                {
                    obj.proporcional = false;
                    obj.cantidad_dias = Convert.ToInt32(txtDias.Text);
                }
                int id = DAL.LICENCIA_PARAM_EMPLEADOS.insert(obj);
                fillFormasCalculo(Convert.ToInt32(Request.QueryString["id"]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}