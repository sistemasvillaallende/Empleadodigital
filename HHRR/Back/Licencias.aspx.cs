using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HHRR.Back
{
    public partial class Licencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillLicencias();
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        private void fillLicencias()
        {
            try
            {
                List<DAL.LICENCIAS> lst = DAL.LICENCIAS.read();
                gvLicencias.DataSource = lst;
                gvLicencias.DataBind();
                if (lst.Count > 0)
                {
                    gvLicencias.UseAccessibleHeader = true;
                    gvLicencias.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                List<DAL.LICENCIA_TIPOS> lstTipos = DAL.LICENCIA_TIPOS.read();
                DDLTipo.DataTextField = "DESCRIPCION";
                DDLTipo.DataValueField = "ID";
                DDLTipo.DataSource = lstTipos;
                DDLTipo.DataBind();
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }

        }

        protected void gvLicencias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "borrar")
                {
                    DAL.LICENCIAS.delete(Convert.ToInt32(e.CommandArgument));
                    fillLicencias();
                }
                if (e.CommandName == "activar")
                {
                    DAL.LICENCIAS.activaDesactvia(Convert.ToInt32(e.CommandArgument), true);
                    fillLicencias();
                }
                if (e.CommandName == "desactivar")
                {
                    DAL.LICENCIAS.activaDesactvia(Convert.ToInt32(e.CommandArgument), false);
                    fillLicencias();
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        protected void gvLicencias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.LICENCIAS obj = (DAL.LICENCIAS)e.Row.DataItem;
                    LinkButton btnActivo = (LinkButton)e.Row.FindControl("btnActivo");
                    LinkButton btnDesactivo = (LinkButton)e.Row.FindControl("btnDesactivo");

                    HtmlGenericControl lblTipo = (HtmlGenericControl)e.Row.FindControl("lblTipo");
                    HtmlGenericControl lblSexo = (HtmlGenericControl)e.Row.FindControl("lblSexo");
                    HtmlGenericControl lblMasiva = (HtmlGenericControl)e.Row.FindControl("lblMasiva");
                    HtmlGenericControl lblCantDias = (HtmlGenericControl)e.Row.FindControl("lblCantDias");

                    HtmlGenericControl lblCalculo = (HtmlGenericControl)e.Row.FindControl("lblCalculo");
                    HtmlGenericControl lblFracciona = (HtmlGenericControl)e.Row.FindControl("lblFracciona");
                    HtmlGenericControl lblAcumula = (HtmlGenericControl)e.Row.FindControl("lblAcumula");
                    if (obj.separa)
                        lblFracciona.InnerHtml = "SI";
                    else
                        lblFracciona.InnerHtml = "NO";
                    if (obj.acumula)
                        lblAcumula.InnerHtml = "SI";
                    else
                        lblAcumula.InnerHtml = "NO";
                    if (obj.activa)
                    {
                        btnActivo.Visible = false;
                        btnDesactivo.Visible = true;
                    }
                    else
                    {
                        btnActivo.Visible = true;
                        btnDesactivo.Visible = false;
                    }
                    DAL.LICENCIA_TIPOS objTipo = DAL.LICENCIA_TIPOS.getByPk(obj.tipo);
                    lblTipo.InnerHtml = objTipo.DESCRIPCION;
                    if (obj.fija)
                    {
                        lblCalculo.InnerHtml = "FIJA";
                        lblCantDias.InnerHtml = obj.cantidad_dias.ToString();
                    }
                    else
                    {
                        lblCalculo.InnerHtml = "CALCULADA";
                        lblCantDias.InnerHtml = "-";
                    }
                    switch (obj.sexo)
                    {
                        case 0:
                            lblSexo.InnerHtml = "TODOS";
                            break;
                        case 1:
                            lblSexo.InnerHtml = "MUJERES";
                            break;
                        case 2:
                            lblSexo.InnerHtml = "HOMBRE";
                            break;
                        default:
                            break;
                    }
                    if (obj.masiva)
                        lblMasiva.InnerHtml = "SI";
                    else
                        lblMasiva.InnerHtml = "NO";
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (hId.Value == string.Empty)
                {
                    DAL.LICENCIAS obj = new DAL.LICENCIAS();
                    obj.activa = true;
                    obj.descripcion = txtDescripcion.Text;
                    obj.tipo = Convert.ToInt32(DDLTipo.SelectedItem.Value);
                    if (DDLDias.SelectedItem.Value == "0")
                        obj.habiles = false;
                    else
                        obj.habiles = true;
                    if (select.SelectedItem.Value == "0")
                    {
                        obj.fija = false;
                        obj.cantidad_dias = 0;
                    }
                    else
                    {
                        obj.fija = true;
                        obj.cantidad_dias = int.Parse(txtCantDias.Text);
                    }
                    if (DDLMasiva.SelectedItem.Value == "0")
                        obj.masiva = false;
                    else
                        obj.masiva = true;
                    obj.sexo = Convert.ToInt32(DDLSexo.SelectedItem.Value);
                    if (DDLFracciona.SelectedItem.Value == "0")
                        obj.separa = false;
                    else
                        obj.separa = true;
                    if (DDLAcumula.SelectedItem.Value == "0")
                        obj.acumula = false;
                    else
                        obj.acumula = true;

                    DAL.LICENCIAS.insert(obj);
                }
                else
                {
                    DAL.LICENCIAS obj = DAL.LICENCIAS.getByPk(int.Parse(hId.Value));
                    obj.descripcion = txtDescripcion.Text;
                    obj.tipo = Convert.ToInt32(DDLTipo.SelectedItem.Value);
                    if (DDLDias.SelectedItem.Value == "0")
                        obj.habiles = false;
                    else
                        obj.habiles = true;
                    if (select.SelectedItem.Value == "0")
                    {
                        obj.fija = false;
                        obj.cantidad_dias = 0;
                    }
                    else
                    {
                        obj.fija = true;
                        obj.cantidad_dias = int.Parse(txtCantDias.Text);
                    }
                    if (DDLMasiva.SelectedItem.Value == "0")
                        obj.masiva = false;
                    else
                        obj.masiva = true;
                    obj.sexo = Convert.ToInt32(DDLSexo.SelectedItem.Value);
                    if (DDLFracciona.SelectedItem.Value == "0")
                        obj.separa = false;
                    else
                        obj.separa = true;
                    if (DDLAcumula.SelectedItem.Value == "0")
                        obj.acumula = false;
                    else
                        obj.acumula = true;
                    DAL.LICENCIAS.update(obj);
                }
                fillLicencias();
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }
    }
}