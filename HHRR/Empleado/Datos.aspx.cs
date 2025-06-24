using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHRR.Empleado
{
    public partial class Datos : System.Web.UI.Page
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
                lblNombreEmpleado.InnerHtml = objEmpleado.nombre;
                lblLegajoEmpleado.InnerHtml = objEmpleado.legajo.ToString();

                spanTel.InnerHtml = string.Format("&nbsp;{0}", objEmpleado.telefonos);
                spanMail2.InnerHtml = string.Format("&nbsp:{0}", objEmpleado.email);


                lblAntiguedadActual.InnerHtml = string.Format("Antiguedad Actual<br><strong>{0}</strong>",
                    objEmpleado.antiguedad_actual);
                lblAntiguedadAnterior.InnerHtml = string.Format("Antiguedad Anterior<br><strong>{0}</strong>",
    objEmpleado.antiguedad_ant);
                lblBanco.InnerHtml = string.Format("Banco<br><strong>{0}</strong>",
                    objEmpleado.nom_banco);
                lblCargo.InnerHtml = string.Format("Cargo<br><strong>{0}</strong>",
    objEmpleado.des_cargo);
                lblCategoria.InnerHtml = string.Format("Categoria<br><strong>{0}</strong>",
objEmpleado.cod_categoria);
                lblCbu.InnerHtml = string.Format("CBU<br><strong>{0}</strong>",
objEmpleado.nro_cbu);
                lblClasificacion.InnerHtml = string.Format("Clasificacion Personal<br><strong>{0}</strong>",
objEmpleado.des_clasif_per);
                lblCUIT.InnerHtml = string.Format("CUIT/CUIL: <strong>{0}</strong>",
objEmpleado.cuil);
                lblDomicilio.InnerHtml = string.Format("&nbsp;{0} {1} Bº {2}, {3} {4} - CP:{5}",
objEmpleado.calle_domicilio, objEmpleado.nro_domicilio, objEmpleado.barrio_domicilio, objEmpleado.ciudad_domicilio,
objEmpleado.provincia_domicilio, objEmpleado.cod_postal);

                lblDireccion.InnerHtml = string.Format("Direccion<br><strong>{0}</strong>",
objEmpleado.direccion);


                lblEstCivil.InnerHtml = string.Format("EST. CIVIL: <strong>{0}</strong>",
objEmpleado.des_estado_civil);
                lblFechaIngreso.InnerHtml = string.Format("Fecha Ingreso<br><strong>{0}</strong>",
objEmpleado.fecha_ingreso);
                lblFecNac.InnerHtml = string.Format("F. NAC.: <strong>{0}</strong>",
objEmpleado.fecha_nacimiento);
                lblLegajo.InnerHtml = string.Format("Legajo<br><strong>{0}</strong>",
objEmpleado.legajo);
                lblNroAfiliado.InnerHtml = string.Format("Nro. Afiliado APROSS<br><strong>{0}</strong>",
objEmpleado.nro_ipam);
                lblNroDoc.InnerHtml = string.Format("NRO. DOC.: <strong>{0}</strong>",
objEmpleado.nro_documento);
                lblOficina.InnerHtml = string.Format("Oficina<br><strong>{0}</strong>",
objEmpleado.oficina);
                lblSeccion.InnerHtml = string.Format("Seccion<br><strong>{0}</strong>",
objEmpleado.des_seccion);
                lblSecretaria.InnerHtml = string.Format("Secretaria<br><strong>{0}</strong>",
objEmpleado.secretaria);

                lblSexo.InnerHtml = string.Format("SEXO: <strong>{0}</strong>",
objEmpleado.sexo);

                lblTarea.InnerHtml = string.Format("Tarea<br><strong>{0}</strong>",
objEmpleado.tarea);

                lblTipoCuenta.InnerHtml = string.Format("Tipo Cuenta<br><strong>{0}</strong>",
objEmpleado.des_tipo_cuenta);
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                txtError.InnerText = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string pass = string.Empty;
            //List<Entities.Empleado> lst = DAL.EmpleadoD.read();
            //foreach (var item in lst)
            //{
            //    pass = CreateRandomPasswordWithRandomLength();
            //    DAL.EmpleadoD.setPass(item.legajo, pass);
            //}
        }

        private static string CreateRandomPasswordWithRandomLength()
        {
            try
            {
                // Create a string of characters, numbers, special characters that allowed in the password  
                string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random random = new Random();

                // Minimum size 8. Max size is number of all allowed chars.  
                int size = random.Next(8, 8);

                // Select one random character at a time from the string  
                // and create an array of chars  
                char[] chars = new char[size];
                for (int i = 0; i < size; i++)
                {
                    chars[i] = validChars[random.Next(0, validChars.Length)];
                }
                return new string(chars);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}