using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Entities;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class EmpleadoD : DALBase
    {

        #region Constructor
        /// <summary>
        /// Contructor de la clase sin parametro.
        /// </summary>

        private static List<Entities.Empleado> mapeo(SqlDataReader dr)
        {
            List<Entities.Empleado> lst = new List<Entities.Empleado>();
            Entities.Empleado obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Entities.Empleado();
                    if (!dr.IsDBNull(0)) { obj.legajo = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.fecha_alta_registro = dr.GetDateTime(1).ToShortDateString(); }
                    if (!dr.IsDBNull(2)) { obj.nombre = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.cod_tipo_documento = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.nro_documento = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.fecha_nacimiento = dr.GetDateTime(5).ToShortDateString(); }
                    if (!dr.IsDBNull(6)) { obj.sexo = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.pais_domicilio = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.provincia_domicilio = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.ciudad_domicilio = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.barrio_domicilio = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.calle_domicilio = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.nro_domicilio = dr.GetInt32(12).ToString(); }
                    if (!dr.IsDBNull(13)) { obj.piso_domicilio = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.dpto_domicilio = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.monoblock_domicilio = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.telefonos = dr.GetString(16); }
                    if (!dr.IsDBNull(17)) { obj.cod_postal = dr.GetString(17); }
                    if (!dr.IsDBNull(18)) { obj.cod_estado_civil = dr.GetInt32(18); }
                    if (!dr.IsDBNull(19)) { obj.fecha_ingreso = dr.GetDateTime(19).ToShortDateString(); }
                    if (!dr.IsDBNull(20)) { obj.tarea = dr.GetString(20); }
                    if (!dr.IsDBNull(21)) { obj.cod_seccion = dr.GetInt32(21); }
                    if (!dr.IsDBNull(22)) { obj.cod_categoria = dr.GetInt32(22); }
                    if (!dr.IsDBNull(23)) { obj.cod_cargo = dr.GetInt32(23); }
                    if (!dr.IsDBNull(24)) { obj.cod_banco = dr.GetInt32(24); }
                    if (!dr.IsDBNull(25)) { obj.nro_sucursal = dr.GetString(25); }
                    if (!dr.IsDBNull(26)) { obj.tipo_cuenta = dr.GetString(26); }
                    if (!dr.IsDBNull(27)) { obj.nro_caja_ahorro = dr.GetString(27); }
                    if (!dr.IsDBNull(28)) { obj.nro_cbu = dr.GetString(28); }
                    if (!dr.IsDBNull(29)) { obj.nro_ipam = dr.GetString(29); }
                    if (!dr.IsDBNull(30)) { obj.cuil = dr.GetString(30); }
                    if (!dr.IsDBNull(31)) { obj.nro_jubilacion = dr.GetString(31); }
                    if (!dr.IsDBNull(32)) { obj.antiguedad_ant = dr.GetInt32(32); }
                    if (!dr.IsDBNull(33)) { obj.antiguedad_actual = dr.GetInt32(33); }
                    if (!dr.IsDBNull(34)) { obj.cod_clasif_per = dr.GetInt32(34); }
                    if (!dr.IsDBNull(35)) { obj.cod_tipo_liq = dr.GetInt32(35); }
                    if (!dr.IsDBNull(36)) { obj.nro_ult_liq = dr.GetInt32(36); }
                    if (!dr.IsDBNull(37)) { obj.anio_ult_liq = dr.GetInt32(37); }
                    if (!dr.IsDBNull(38)) { obj.nro_cta_sb = dr.GetString(38); }
                    if (!dr.IsDBNull(39)) { obj.nro_cta_gastos = dr.GetString(39); }
                    if (!dr.IsDBNull(40)) { obj.fecha_baja = dr.GetDateTime(40).ToShortDateString(); }
                    if (!dr.IsDBNull(41)) { obj.nro_contrato = dr.GetInt32(41); }
                    if (!dr.IsDBNull(42)) { obj.fecha_inicio_contrato = dr.GetDateTime(42).ToShortDateString(); }
                    if (!dr.IsDBNull(43)) { obj.fecha_fin_contrato = dr.GetDateTime(43).ToShortDateString(); }
                    if (!dr.IsDBNull(44)) { obj.listar = dr.GetBoolean(44); }
                    if (!dr.IsDBNull(45)) { obj.id_regimen = dr.GetInt16(45); }
                    if (!dr.IsDBNull(46)) { obj.id_secretaria = dr.GetInt32(46); }
                    if (!dr.IsDBNull(47)) { obj.id_direccion = dr.GetInt32(47); }
                    if (!dr.IsDBNull(48)) { obj.nro_nombramiento = dr.GetString(48); }
                    if (!dr.IsDBNull(49)) { obj.fecha_nombramiento = dr.GetDateTime(49).ToShortDateString(); }
                    if (!dr.IsDBNull(50)) { obj.usuario = dr.GetString(50); }
                    if (!dr.IsDBNull(51)) { obj.cod_escala_aumento = dr.GetInt32(51); }
                    if (!dr.IsDBNull(52)) { obj.cod_regimen_empleado = dr.GetInt32(52); }
                    if (!dr.IsDBNull(53)) { obj.id_oficina = dr.GetInt32(53); }
                    if (!dr.IsDBNull(54)) { obj.celular = dr.GetString(54); }
                    if (!dr.IsDBNull(55)) { obj.email = dr.GetString(55); }
                    if (!dr.IsDBNull(56)) { obj.password = dr.GetString(56); }
                    if (!dr.IsDBNull(57)) { obj.passTemp = dr.GetString(57); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Entities.Empleado> read()
        {
            try
            {
                List<Entities.Empleado> lst = new List<Entities.Empleado>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM EMPLEADOS";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setPass(int legajo, string pass)
        {
            try
            {
                List<Entities.Empleado> lst = new List<Entities.Empleado>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    string md5Passwd = MD5Encryption.EncryptMD5(pass);

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE EMPLEADOS SET password=@password, passTemp=@passTemp WHERE LEGAJO=@LEGAJO";
                    cmd.Parameters.AddWithValue("@password", md5Passwd);
                    cmd.Parameters.AddWithValue("@passTemp", pass);
                    cmd.Parameters.AddWithValue("@LEGAJO", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Entities.Empleado ValidUser(int legajo, string password)
        {
            Entities.Empleado obj = null;
            string md5Passwd = "";
            string md5Passwd_ = "";

            try
            {
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM EMPLEADOS WHERE LEGAJO = @LEGAJO";
                    cmd.Parameters.AddWithValue("@LEGAJO", legajo);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Entities.Empleado> lst = mapeo(dr);
                    if (lst.Count > 0)
                        obj = lst[0];
                    if (obj != null)
                    {
                        md5Passwd = obj.password;
                        md5Passwd_ = MD5Encryption.EncryptMD5(password);
                        if (md5Passwd != md5Passwd_)
                            obj = null;
                    }
                    return obj;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Entities.Empleado getBycuil(string cuil)
        {
            Entities.Empleado obj = null;
            try
            {
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM EMPLEADOS 
                                        WHERE 
                                        REPLACE(REPLACE(cuil, '-', ''), '.', '') = @cuil
                                        AND fecha_baja IS NULL";
                    cmd.Parameters.AddWithValue("@cuil", cuil);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Entities.Empleado> lst = mapeo(dr);
                    if (lst.Count > 0)
                        obj = lst[0];

                    return obj;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Entities.LstEmpleados> GetLstEmpleados(SqlConnection cn, SqlTransaction trx)
        {
            StringBuilder strSQL = new StringBuilder();
            StringBuilder strCondicion = new StringBuilder();
            SqlCommand cmd = null;

            List<Entities.LstEmpleados> lst = new List<Entities.LstEmpleados>();
            Entities.LstEmpleados oEmp;


            strSQL.AppendLine("SELECT");
            strSQL.AppendLine("e.legajo, rtrim(ltrim(e.nombre)) as nombre, ");
            strSQL.AppendLine("convert(varchar(10), e.fecha_ingreso, 103) as fecha_ingreso , convert(varchar(10), e.fecha_nacimiento, 103) as fecha_nacimiento,");
            strSQL.AppendLine("e.cod_categoria, c.des_categoria, e.tarea, tl.des_tipo_liq,");
            strSQL.AppendLine("b.nom_banco, e.nro_caja_ahorro, e.nro_cbu,");
            strSQL.AppendLine("e.nro_documento, e.nro_cta_sb, e.nro_cta_gastos,");
            strSQL.AppendLine("rtrim(ltrim(s.descripcion)) as Secretaria, rtrim(ltrim(d1.descripcion)) as Direccion, ltrim(rtrim(o.nombre_oficina)) as Oficina");
            strSQL.AppendLine(",e.password, e.passTemp");
            strSQL.AppendLine("FROM EMPLEADOS e");
            strSQL.AppendLine("inner join TIPOS_LIQUIDACION tl on");
            strSQL.AppendLine("tl.cod_tipo_liq = e.cod_tipo_liq");
            strSQL.AppendLine("inner join BANCOS b on");
            strSQL.AppendLine("b.cod_banco = e.cod_banco");
            strSQL.AppendLine("inner join CATEGORIAS c on");
            strSQL.AppendLine("e.cod_categoria = c.cod_categoria");
            strSQL.AppendLine("inner join secretaria s on");
            strSQL.AppendLine("s.id_secretaria = e.id_secretaria");
            strSQL.AppendLine("inner join direccion d1 on");
            strSQL.AppendLine("d1.id_direccion = e.id_direccion");
            strSQL.AppendLine("inner join oficinas o on");
            strSQL.AppendLine("o.codigo_oficina = e.id_oficina");
            strSQL.AppendLine("WHERE e.fecha_baja is null");
            strSQL.AppendLine("ORDER BY e.legajo");

            //using (SqlConnection conn = DALBase.GetConnection("Local"))
            //{
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection = cn;
                cmd.Transaction = trx;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int legajo = dr.GetOrdinal("legajo");
                    int nombre = dr.GetOrdinal("nombre");
                    int fecha_ingreso = dr.GetOrdinal("fecha_ingreso");
                    int fecha_nac = dr.GetOrdinal("fecha_nacimiento");
                    int cod_categoria = dr.GetOrdinal("cod_categoria");
                    int des_categoria = dr.GetOrdinal("des_categoria");
                    int tarea = dr.GetOrdinal("tarea");
                    int des_tipo_liq = dr.GetOrdinal("des_tipo_liq");
                    int nom_banco = dr.GetOrdinal("nom_banco");
                    int nro_caja_ahorro = dr.GetOrdinal("nro_caja_ahorro");
                    int nro_cbu = dr.GetOrdinal("nro_cbu");
                    int nro_documento = dr.GetOrdinal("nro_documento");
                    int nro_cta_sb = dr.GetOrdinal("nro_cta_sb");
                    int cod_seccion = dr.GetOrdinal("cod_seccion");
                    int secretaria = dr.GetOrdinal("secretaria");
                    int direccion = dr.GetOrdinal("direccion");
                    int oficina = dr.GetOrdinal("oficina");
                    int usuario = dr.GetOrdinal("usuario");

                    while (dr.Read())
                    {
                        oEmp = new LstEmpleados();

                        if (!dr.IsDBNull(legajo)) oEmp.legajo = dr.GetInt32(legajo);
                        if (!dr.IsDBNull(nombre)) oEmp.nombre = dr.GetString(nombre);
                        if (!dr.IsDBNull(fecha_ingreso)) oEmp.fecha_ingreso = dr.GetString(fecha_ingreso);
                        if (!dr.IsDBNull(nro_documento)) oEmp.nro_documento = dr.GetString(nro_documento);
                        if (!dr.IsDBNull(fecha_nac)) oEmp.fecha_nacimiento = dr.GetString(fecha_nac);
                        if (!dr.IsDBNull(cod_categoria)) oEmp.cod_categoria = dr.GetInt16(cod_categoria);
                        if (!dr.IsDBNull(des_categoria)) oEmp.des_categoria = dr.GetString(des_categoria);
                        if (!dr.IsDBNull(tarea)) oEmp.tarea = dr.GetString(tarea);
                        if (!dr.IsDBNull(des_tipo_liq)) oEmp.des_tipo_liq = dr.GetString(des_tipo_liq);
                        if (!dr.IsDBNull(nom_banco)) oEmp.nom_banco = dr.GetString(nom_banco);
                        if (!dr.IsDBNull(nro_caja_ahorro)) oEmp.nro_caja_ahorro = dr.GetString(nro_caja_ahorro);
                        if (!dr.IsDBNull(nro_cbu)) oEmp.nro_cbu = dr.GetString(nro_cbu);
                        if (!dr.IsDBNull(nro_documento)) oEmp.nro_documento = dr.GetString(nro_documento);
                        if (!dr.IsDBNull(nro_cta_sb)) oEmp.nro_cta_sb = dr.GetString(nro_cta_sb);
                        if (!dr.IsDBNull(secretaria)) oEmp.secrectaria = dr.GetString(secretaria);
                        if (!dr.IsDBNull(direccion)) oEmp.direccion = dr.GetString(direccion);
                        if (!dr.IsDBNull(oficina)) oEmp.oficina = dr.GetString(oficina);
                        lst.Add(oEmp);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            return lst;
        }


        public static List<Entities.LstEmpleados> GetLiqEmpleado(int anio, int cod_tipo_liq, int nro_liquidacion, SqlConnection cn, SqlTransaction trx)
        {

            List<Entities.LstEmpleados> lst = new List<Entities.LstEmpleados>();
            Entities.LstEmpleados oEmp;
            StringBuilder strSQL = new StringBuilder();
            SqlCommand cmd = null;
            strSQL.AppendLine();
            strSQL.AppendLine(" SELECT A.legajo, A.antiguedad_ant, B.sueldo_basico, ");
            strSQL.AppendLine(" convert(varchar(10), A.fecha_ingreso, 103) as fecha_ingreso, A.cod_categoria ");
            //A.cod_escala_aumento");
            strSQL.AppendLine(" FROM EMPLEADOS A WITH (NOLOCK)");
            strSQL.AppendLine(" JOIN  CATEGORIAS B ON ");
            strSQL.AppendLine(" A.cod_categoria=B.cod_categoria ");
            //strSQL.AppendLine(" JOIN  ESCALA_AUMENTOS_ITEMS eai ON ");
            //strSQL.AppendLine(" eai.Activo=1 AND a.Cod_escala_aumento = eai.Cod_escala_aumento ");
            strSQL.AppendLine(" WHERE A.fecha_baja IS NULL ");
            //strSQL.AppendLine(" AND A.legajo IN (867)");
            //strSQL.AppendLine(" AND A.legajo IN (895)");
            strSQL.AppendLine(" AND A.cod_tipo_liq=@cod_tipo_liq");
            strSQL.AppendLine(" AND (A.anio_ult_liq <=@anio OR A.anio_ult_liq IS NULL) AND (A.nro_ult_liq <=@nro_liquidacion");
            strSQL.AppendLine(" OR A.nro_ult_liq IS NULL) ORDER BY A.legajo");

            try
            {

                cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@cod_tipo_liq", cod_tipo_liq);
                cmd.Parameters.AddWithValue("@nro_liquidacion", nro_liquidacion);
                cmd.CommandText = strSQL.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = trx;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    int legajo = dr.GetOrdinal("legajo");
                    int antiguedad_ant = dr.GetOrdinal("antiguedad_ant");
                    int sueldo_basico = dr.GetOrdinal("sueldo_basico");
                    int fecha_ingreso = dr.GetOrdinal("fecha_ingreso");
                    int cod_categoria = dr.GetOrdinal("cod_categoria");


                    while (dr.Read())
                    {
                        oEmp = new LstEmpleados();

                        if (!dr.IsDBNull(legajo)) oEmp.legajo = dr.GetInt32(legajo);
                        if (!dr.IsDBNull(antiguedad_ant))
                            oEmp.antiguedad_ant = dr.GetInt32(antiguedad_ant);
                        if (!dr.IsDBNull(fecha_ingreso)) oEmp.fecha_ingreso = Convert.ToString(dr.GetString(fecha_ingreso));
                        if (!dr.IsDBNull(sueldo_basico)) oEmp.sueldo_basico = dr.GetDecimal(sueldo_basico);
                        if (!dr.IsDBNull(cod_categoria)) oEmp.cod_categoria = dr.GetInt32(cod_categoria);
                        lst.Add(oEmp);
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally
            { cmd = null; }
            return lst;
        }

        public static Entities.Empleado GetByPk(int legajo)
        {
            Entities.Empleado objEmp = new Empleado();
            SqlCommand cmd;
            SqlDataReader dr;
            StringBuilder strSQL = new StringBuilder();

            SqlConnection cn = DALBase.GetConnection("SIIMVA");

            strSQL.AppendLine("SELECT * ");
            strSQL.AppendLine("FROM EMPLEADOS (nolock) ");
            strSQL.AppendLine("WHERE legajo = @legajo");
            strSQL.AppendLine(" AND fecha_baja is null");

            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@legajo", legajo));

            try
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();


                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    objEmp = new Empleado();

                    if (!dr.IsDBNull(dr.GetOrdinal("legajo")))
                        objEmp.legajo = dr.GetInt32((dr.GetOrdinal("legajo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                        objEmp.nombre = dr.GetString((dr.GetOrdinal("nombre")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_alta_registro")))
                        objEmp.fecha_alta_registro = Convert.ToDateTime(dr["fecha_alta_registro"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                        objEmp.cod_tipo_documento = dr.GetInt32((dr.GetOrdinal("cod_tipo_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_documento")))
                        objEmp.nro_documento = dr.GetString((dr.GetOrdinal("nro_documento")));
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                        objEmp.cod_tipo_documento = dr.GetInt32((dr.GetOrdinal("cod_tipo_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_nacimiento")))
                        objEmp.fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]).ToString("dd/MM/yyyy");


                    if (!dr.IsDBNull(dr.GetOrdinal("pais_domicilio")))
                        objEmp.pais_domicilio = dr.GetString((dr.GetOrdinal("pais_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("provincia_domicilio")))
                        objEmp.provincia_domicilio = dr.GetString((dr.GetOrdinal("provincia_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("ciudad_domicilio")))
                        objEmp.ciudad_domicilio = dr.GetString((dr.GetOrdinal("ciudad_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("barrio_domicilio")))
                        objEmp.barrio_domicilio = dr.GetString((dr.GetOrdinal("barrio_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("calle_domicilio")))
                        objEmp.calle_domicilio = dr.GetString((dr.GetOrdinal("calle_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_domicilio")))
                        objEmp.nro_domicilio = Convert.ToString(dr.GetInt32((dr.GetOrdinal("nro_domicilio"))));

                    if (!dr.IsDBNull(dr.GetOrdinal("piso_domicilio")))
                        objEmp.piso_domicilio = dr.GetString((dr.GetOrdinal("piso_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("dpto_domicilio")))
                        objEmp.dpto_domicilio = dr.GetString((dr.GetOrdinal("dpto_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("monoblock_domicilio")))
                        objEmp.monoblock_domicilio = dr.GetString((dr.GetOrdinal("monoblock_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("telefonos")))
                        objEmp.telefonos = dr.GetString((dr.GetOrdinal("telefonos")));

                    if (!dr.IsDBNull(dr.GetOrdinal("celular")))
                        objEmp.celular = dr.GetString((dr.GetOrdinal("celular")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_postal")))
                        objEmp.cod_postal = dr.GetString((dr.GetOrdinal("cod_postal")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_estado_civil")))
                        objEmp.cod_estado_civil = dr.GetInt32((dr.GetOrdinal("cod_estado_civil")));

                    if (!dr.IsDBNull(dr.GetOrdinal("sexo")))
                        objEmp.sexo = dr.GetString((dr.GetOrdinal("sexo")));


                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_ingreso")))
                        objEmp.fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("tarea")))
                        objEmp.tarea = dr.GetString((dr.GetOrdinal("tarea")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_seccion")))
                        objEmp.cod_seccion = dr.GetInt32((dr.GetOrdinal("cod_seccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_categoria")))
                        objEmp.cod_categoria = dr.GetInt32((dr.GetOrdinal("cod_categoria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_cargo")))
                        objEmp.cod_cargo = dr.GetInt32((dr.GetOrdinal("cod_cargo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_banco")))
                        objEmp.cod_banco = dr.GetInt32((dr.GetOrdinal("cod_banco")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_sucursal")))
                        objEmp.nro_sucursal = dr.GetString((dr.GetOrdinal("nro_sucursal")));

                    if (!dr.IsDBNull(dr.GetOrdinal("tipo_cuenta")))
                        objEmp.tipo_cuenta = dr.GetString((dr.GetOrdinal("tipo_cuenta")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_caja_ahorro")))
                        objEmp.nro_caja_ahorro = dr.GetString((dr.GetOrdinal("nro_caja_ahorro")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cbu")))
                        objEmp.nro_cbu = dr.GetString((dr.GetOrdinal("nro_cbu")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_ipam")))
                        objEmp.nro_ipam = dr.GetString((dr.GetOrdinal("nro_ipam")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cuil")))
                        objEmp.cuil = dr.GetString((dr.GetOrdinal("cuil")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_jubilacion")))
                        objEmp.nro_jubilacion = dr.GetString((dr.GetOrdinal("nro_jubilacion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_jubilacion")))
                        objEmp.nro_jubilacion = dr.GetString((dr.GetOrdinal("nro_jubilacion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_ant")))
                        objEmp.antiguedad_ant = dr.GetInt32((dr.GetOrdinal("antiguedad_ant")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_actual")))
                        objEmp.antiguedad_actual = dr.GetInt32((dr.GetOrdinal("antiguedad_actual")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_clasif_per")))
                        objEmp.cod_clasif_per = dr.GetInt32((dr.GetOrdinal("cod_clasif_per")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_liq")))
                        objEmp.cod_tipo_liq = dr.GetInt32((dr.GetOrdinal("cod_tipo_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_ult_liq")))
                        objEmp.nro_ult_liq = dr.GetInt32((dr.GetOrdinal("nro_ult_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("anio_ult_liq")))
                        objEmp.anio_ult_liq = dr.GetInt32((dr.GetOrdinal("anio_ult_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_sb")))
                        objEmp.nro_cta_sb = dr.GetString((dr.GetOrdinal("nro_cta_sb")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_gastos")))
                        objEmp.nro_cta_gastos = dr.GetString((dr.GetOrdinal("nro_cta_gastos")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_baja")))
                        objEmp.fecha_baja = Convert.ToDateTime(dr["fecha_baja"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_contrato")))
                        objEmp.nro_contrato = dr.GetInt32((dr.GetOrdinal("nro_contrato")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_inicio_contrato")))
                        objEmp.fecha_inicio_contrato = Convert.ToDateTime((dr["fecha_inicio_contrato"])).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_fin_contrato")))
                        objEmp.fecha_fin_contrato = Convert.ToDateTime((dr["fecha_fin_contrato"])).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("id_regimen")))
                        objEmp.id_regimen = dr.GetInt16((dr.GetOrdinal("id_regimen")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_secretaria")))
                        objEmp.id_secretaria = dr.GetInt32((dr.GetOrdinal("id_secretaria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_direccion")))
                        objEmp.id_direccion = dr.GetInt32((dr.GetOrdinal("id_direccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_nombramiento")))
                        objEmp.nro_nombramiento = dr.GetString((dr.GetOrdinal("nro_nombramiento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_nombramiento")))
                        objEmp.fecha_nombramiento = Convert.ToDateTime(dr["fecha_nombramiento"]).ToString("dd/MM/yyyy"); ;

                    if (!dr.IsDBNull(dr.GetOrdinal("usuario")))
                        objEmp.usuario = dr.GetString((dr.GetOrdinal("usuario")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_escala_aumento")))
                        objEmp.cod_escala_aumento = dr.GetInt32((dr.GetOrdinal("cod_escala_aumento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_regimen_empleado")))
                        objEmp.cod_regimen_empleado = dr.GetInt32((dr.GetOrdinal("cod_regimen_empleado")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_oficina")))
                        objEmp.id_oficina = dr.GetInt32((dr.GetOrdinal("id_oficina")));

                    if (!dr.IsDBNull(dr.GetOrdinal("email")))
                        objEmp.email = dr.GetString((dr.GetOrdinal("email")));

                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            dr.Close();
            return objEmp;
        }

        public static List<LstEmpleados> GetLiqEmpleadoAguinaldo(int anio, int cod_tipo_liq, int nro_liquidacion, SqlConnection cn, SqlTransaction trx)
        {
            List<Entities.LstEmpleados> lst = new List<Entities.LstEmpleados>();
            Entities.LstEmpleados oEmp;
            StringBuilder strSQL = new StringBuilder();
            SqlCommand cmd = null;
            strSQL.AppendLine();
            strSQL.AppendLine("SELECT A.legajo, A.antiguedad_ant, A.fecha_ingreso, B.sueldo_basico, A.cod_categoria FROM ");
            strSQL.AppendLine(" EMPLEADOS A WITH (NOLOCK), CATEGORIAS B WHERE ");
            strSQL.AppendLine(" A.fecha_baja IS NULL AND A.cod_tipo_liq=@cod_tipo_liq");
            strSQL.AppendLine(" AND A.cod_categoria=B.cod_categoria AND ");
            strSQL.AppendLine(" (A.anio_ult_liq <= @anio");
            strSQL.AppendLine(" OR A.anio_ult_liq IS NULL) AND (A.nro_ult_liq <=@nro_liquidacion ");
            strSQL.AppendLine(" OR A.nro_ult_liq IS NULL) ORDER BY A.legajo");
            try
            {

                cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@cod_tipo_liq", cod_tipo_liq);
                cmd.Parameters.AddWithValue("@nro_liquidacion", nro_liquidacion);
                cmd.CommandText = strSQL.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = trx;
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    int legajo = dr.GetOrdinal("legajo");
                    int antiguedad_ant = dr.GetOrdinal("antiguedad_ant");
                    int sueldo_basico = dr.GetOrdinal("sueldo_basico");
                    int fecha_ingreso = dr.GetOrdinal("fecha_ingreso");
                    int cod_categoria = dr.GetOrdinal("cod_categoria");


                    while (dr.Read())
                    {
                        oEmp = new LstEmpleados();

                        if (!dr.IsDBNull(legajo)) oEmp.legajo = dr.GetInt32(legajo);
                        if (!dr.IsDBNull(antiguedad_ant)) oEmp.antiguedad_ant = dr.GetInt32(antiguedad_ant);
                        if (!dr.IsDBNull(fecha_ingreso)) oEmp.fecha_ingreso = Convert.ToString(dr.GetDateTime(fecha_ingreso));
                        if (!dr.IsDBNull(sueldo_basico)) oEmp.sueldo_basico = dr.GetDecimal(sueldo_basico);
                        if (!dr.IsDBNull(cod_categoria)) oEmp.cod_categoria = dr.GetInt32(cod_categoria);
                        lst.Add(oEmp);
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally
            { cmd = null; }
            return lst;
        }

        public static Entities.Empleado GetByPkTodos(int legajo)
        {
            Entities.Empleado objEmp = new Empleado();
            SqlCommand cmd;
            SqlDataReader dr;
            string strSQL = "";

            SqlConnection cn = DALBase.GetConnection("SIIMVA");

            strSQL = @"
                    SELECT 
                        a.*, b.nom_banco, 
                        c.desc_cargo, e.des_clasif_per, 
                        f.Descripcion as direccion,
                        g.Descripcion as secretaria, h.nombre_oficina, 
                        i.des_estado_civil, j.des_seccion, k.des_tipo_cuenta
                    FROM EMPLEADOS a (nolock) 
                    INNER JOIN VECINO_DIGITAL Z ON REPLACE(REPLACE(a.cuil, '-', ''), '.', '') = Z.CUIT
                    INNER JOIN BANCOS b ON
                        b.cod_banco = a.cod_banco
                    INNER JOIN CARGOS c ON
                    c.cod_cargo = a.cod_cargo
                    INNER JOIN CLASIFICACIONES_PERSONAL e ON
                        e.cod_clasif_per = a.cod_clasif_per
                    INNER JOIN DIRECCION f ON
                        f.Id_direccion = a.Id_direccion
                    INNER JOIN SECRETARIA g ON
                        g.Id_secretaria = a.Id_secretaria
                    INNER JOIN OFICINAS h ON
                        h.codigo_oficina = a.id_oficina
                    INNER JOIN ESTADOS_CIVILES i ON
                        i.cod_estado_civil = a.cod_estado_civil
                    INNER JOIN SECCIONES j ON
                        j.cod_seccion = a.cod_seccion
                    INNER JOIN TIPOS_CUENTAS k ON
                        k.cod_tipo_cuenta = a.tipo_cuenta
                    WHERE legajo = @legajo";

            cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@legajo", legajo));
            try
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Connection.Open();


                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    objEmp = new Empleado();

                    if (!dr.IsDBNull(dr.GetOrdinal("des_tipo_cuenta")))
                        objEmp.des_tipo_cuenta = dr.GetString((dr.GetOrdinal("des_tipo_cuenta")));

                    if (!dr.IsDBNull(dr.GetOrdinal("des_seccion")))
                        objEmp.des_seccion = dr.GetString((dr.GetOrdinal("des_seccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("des_estado_civil")))
                        objEmp.des_estado_civil = dr.GetString((dr.GetOrdinal("des_estado_civil")));

                    if (!dr.IsDBNull(dr.GetOrdinal("direccion")))
                        objEmp.direccion = dr.GetString((dr.GetOrdinal("direccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("secretaria")))
                        objEmp.secretaria = dr.GetString((dr.GetOrdinal("secretaria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nombre_oficina")))
                        objEmp.oficina = dr.GetString((dr.GetOrdinal("nombre_oficina")));


                    if (!dr.IsDBNull(dr.GetOrdinal("des_clasif_per")))
                        objEmp.des_clasif_per = dr.GetString((dr.GetOrdinal("des_clasif_per")));

                    if (!dr.IsDBNull(dr.GetOrdinal("desc_cargo")))
                        objEmp.des_cargo = dr.GetString((dr.GetOrdinal("desc_cargo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nom_banco")))
                        objEmp.nom_banco = dr.GetString((dr.GetOrdinal("nom_banco")));

                    if (!dr.IsDBNull(dr.GetOrdinal("legajo")))
                        objEmp.legajo = dr.GetInt32((dr.GetOrdinal("legajo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                        objEmp.nombre = dr.GetString((dr.GetOrdinal("nombre")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_alta_registro")))
                        objEmp.fecha_alta_registro = Convert.ToDateTime(dr["fecha_alta_registro"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                        objEmp.cod_tipo_documento = dr.GetInt32((dr.GetOrdinal("cod_tipo_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_documento")))
                        objEmp.nro_documento = dr.GetString((dr.GetOrdinal("nro_documento")));
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                        objEmp.cod_tipo_documento = dr.GetInt32((dr.GetOrdinal("cod_tipo_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_nacimiento")))
                        objEmp.fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]).ToString("dd/MM/yyyy");


                    if (!dr.IsDBNull(dr.GetOrdinal("pais_domicilio")))
                        objEmp.pais_domicilio = dr.GetString((dr.GetOrdinal("pais_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("provincia_domicilio")))
                        objEmp.provincia_domicilio = dr.GetString((dr.GetOrdinal("provincia_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("ciudad_domicilio")))
                        objEmp.ciudad_domicilio = dr.GetString((dr.GetOrdinal("ciudad_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("barrio_domicilio")))
                        objEmp.barrio_domicilio = dr.GetString((dr.GetOrdinal("barrio_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("calle_domicilio")))
                        objEmp.calle_domicilio = dr.GetString((dr.GetOrdinal("calle_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_domicilio")))
                        objEmp.nro_domicilio = Convert.ToString(dr.GetInt32((dr.GetOrdinal("nro_domicilio"))));

                    if (!dr.IsDBNull(dr.GetOrdinal("piso_domicilio")))
                        objEmp.piso_domicilio = dr.GetString((dr.GetOrdinal("piso_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("dpto_domicilio")))
                        objEmp.dpto_domicilio = dr.GetString((dr.GetOrdinal("dpto_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("monoblock_domicilio")))
                        objEmp.monoblock_domicilio = dr.GetString((dr.GetOrdinal("monoblock_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("telefonos")))
                        objEmp.telefonos = dr.GetString((dr.GetOrdinal("telefonos")));

                    if (!dr.IsDBNull(dr.GetOrdinal("celular")))
                        objEmp.celular = dr.GetString((dr.GetOrdinal("celular")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_postal")))
                        objEmp.cod_postal = dr.GetString((dr.GetOrdinal("cod_postal")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_estado_civil")))
                        objEmp.cod_estado_civil = dr.GetInt32((dr.GetOrdinal("cod_estado_civil")));

                    if (!dr.IsDBNull(dr.GetOrdinal("sexo")))
                        objEmp.sexo = dr.GetString((dr.GetOrdinal("sexo")));


                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_ingreso")))
                        objEmp.fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("tarea")))
                        objEmp.tarea = dr.GetString((dr.GetOrdinal("tarea")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_seccion")))
                        objEmp.cod_seccion = dr.GetInt32((dr.GetOrdinal("cod_seccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_categoria")))
                        objEmp.cod_categoria = dr.GetInt32((dr.GetOrdinal("cod_categoria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_cargo")))
                        objEmp.cod_cargo = dr.GetInt32((dr.GetOrdinal("cod_cargo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_banco")))
                        objEmp.cod_banco = dr.GetInt32((dr.GetOrdinal("cod_banco")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_sucursal")))
                        objEmp.nro_sucursal = dr.GetString((dr.GetOrdinal("nro_sucursal")));

                    if (!dr.IsDBNull(dr.GetOrdinal("tipo_cuenta")))
                        objEmp.tipo_cuenta = dr.GetString((dr.GetOrdinal("tipo_cuenta")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_caja_ahorro")))
                        objEmp.nro_caja_ahorro = dr.GetString((dr.GetOrdinal("nro_caja_ahorro")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cbu")))
                        objEmp.nro_cbu = dr.GetString((dr.GetOrdinal("nro_cbu")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_ipam")))
                        objEmp.nro_ipam = dr.GetString((dr.GetOrdinal("nro_ipam")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cuil")))
                        objEmp.cuil = dr.GetString((dr.GetOrdinal("cuil")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_jubilacion")))
                        objEmp.nro_jubilacion = dr.GetString((dr.GetOrdinal("nro_jubilacion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_jubilacion")))
                        objEmp.nro_jubilacion = dr.GetString((dr.GetOrdinal("nro_jubilacion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_ant")))
                        objEmp.antiguedad_ant = dr.GetInt32((dr.GetOrdinal("antiguedad_ant")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_actual")))
                        objEmp.antiguedad_actual = dr.GetInt32((dr.GetOrdinal("antiguedad_actual")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_clasif_per")))
                        objEmp.cod_clasif_per = dr.GetInt32((dr.GetOrdinal("cod_clasif_per")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_liq")))
                        objEmp.cod_tipo_liq = dr.GetInt32((dr.GetOrdinal("cod_tipo_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_ult_liq")))
                        objEmp.nro_ult_liq = dr.GetInt32((dr.GetOrdinal("nro_ult_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("anio_ult_liq")))
                        objEmp.anio_ult_liq = dr.GetInt32((dr.GetOrdinal("anio_ult_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_sb")))
                        objEmp.nro_cta_sb = dr.GetString((dr.GetOrdinal("nro_cta_sb")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_gastos")))
                        objEmp.nro_cta_gastos = dr.GetString((dr.GetOrdinal("nro_cta_gastos")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_baja")))
                        objEmp.fecha_baja = Convert.ToDateTime(dr["fecha_baja"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_contrato")))
                        objEmp.nro_contrato = dr.GetInt32((dr.GetOrdinal("nro_contrato")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_inicio_contrato")))
                        objEmp.fecha_inicio_contrato = Convert.ToDateTime((dr["fecha_inicio_contrato"])).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_fin_contrato")))
                        objEmp.fecha_fin_contrato = Convert.ToDateTime((dr["fecha_fin_contrato"])).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("id_regimen")))
                        objEmp.id_regimen = dr.GetInt16((dr.GetOrdinal("id_regimen")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_secretaria")))
                        objEmp.id_secretaria = dr.GetInt32((dr.GetOrdinal("id_secretaria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_direccion")))
                        objEmp.id_direccion = dr.GetInt32((dr.GetOrdinal("id_direccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_nombramiento")))
                        objEmp.nro_nombramiento = dr.GetString((dr.GetOrdinal("nro_nombramiento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_nombramiento")))
                        objEmp.fecha_nombramiento = Convert.ToDateTime(dr["fecha_nombramiento"]).ToString("dd/MM/yyyy"); ;

                    if (!dr.IsDBNull(dr.GetOrdinal("usuario")))
                        objEmp.usuario = dr.GetString((dr.GetOrdinal("usuario")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_escala_aumento")))
                        objEmp.cod_escala_aumento = dr.GetInt32((dr.GetOrdinal("cod_escala_aumento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_regimen_empleado")))
                        objEmp.cod_regimen_empleado = dr.GetInt32((dr.GetOrdinal("cod_regimen_empleado")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_oficina")))
                        objEmp.id_oficina = dr.GetInt32((dr.GetOrdinal("id_oficina")));

                    if (!dr.IsDBNull(dr.GetOrdinal("email")))
                        objEmp.email = dr.GetString((dr.GetOrdinal("email")));

                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            dr.Close();
            return objEmp;
        }



        public static Entities.Empleado GetByPk(int legajo, SqlConnection cn, SqlTransaction trx)
        {
            Entities.Empleado objEmp = new Empleado();
            SqlCommand cmd;
            SqlDataReader dr;
            StringBuilder strSQL = new StringBuilder();
            //SqlConnection cn = DALBase.GetConnection("SIIMVA");
            strSQL.AppendLine("SELECT * ");
            strSQL.AppendLine("FROM EMPLEADOS (nolock) ");
            strSQL.AppendLine("WHERE legajo = @legajo");
            strSQL.AppendLine(" AND fecha_baja is null");

            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@legajo", legajo));


            try
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                //cmd.Connection.Open();
                cmd.Transaction = trx;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    objEmp = new Empleado();

                    if (!dr.IsDBNull(dr.GetOrdinal("legajo")))
                        objEmp.legajo = dr.GetInt32((dr.GetOrdinal("legajo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                        objEmp.nombre = dr.GetString((dr.GetOrdinal("nombre")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_alta_registro")))
                        objEmp.fecha_alta_registro = Convert.ToDateTime(dr["fecha_alta_registro"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                        objEmp.cod_tipo_documento = dr.GetInt32((dr.GetOrdinal("cod_tipo_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_documento")))
                        objEmp.nro_documento = dr.GetString((dr.GetOrdinal("nro_documento")));
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                        objEmp.cod_tipo_documento = dr.GetInt32((dr.GetOrdinal("cod_tipo_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_nacimiento")))
                        objEmp.fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]).ToString("dd/MM/yyyy");


                    if (!dr.IsDBNull(dr.GetOrdinal("pais_domicilio")))
                        objEmp.pais_domicilio = dr.GetString((dr.GetOrdinal("pais_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("provincia_domicilio")))
                        objEmp.provincia_domicilio = dr.GetString((dr.GetOrdinal("provincia_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("ciudad_domicilio")))
                        objEmp.ciudad_domicilio = dr.GetString((dr.GetOrdinal("ciudad_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("barrio_domicilio")))
                        objEmp.barrio_domicilio = dr.GetString((dr.GetOrdinal("barrio_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("calle_domicilio")))
                        objEmp.calle_domicilio = dr.GetString((dr.GetOrdinal("calle_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_domicilio")))
                        objEmp.nro_domicilio = Convert.ToString(dr.GetInt32((dr.GetOrdinal("nro_domicilio"))));

                    if (!dr.IsDBNull(dr.GetOrdinal("piso_domicilio")))
                        objEmp.piso_domicilio = dr.GetString((dr.GetOrdinal("piso_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("dpto_domicilio")))
                        objEmp.dpto_domicilio = dr.GetString((dr.GetOrdinal("dpto_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("monoblock_domicilio")))
                        objEmp.monoblock_domicilio = dr.GetString((dr.GetOrdinal("monoblock_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("telefonos")))
                        objEmp.telefonos = dr.GetString((dr.GetOrdinal("telefonos")));

                    if (!dr.IsDBNull(dr.GetOrdinal("celular")))
                        objEmp.celular = dr.GetString((dr.GetOrdinal("celular")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_postal")))
                        objEmp.cod_postal = dr.GetString((dr.GetOrdinal("cod_postal")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_estado_civil")))
                        objEmp.cod_estado_civil = dr.GetInt32((dr.GetOrdinal("cod_estado_civil")));

                    if (!dr.IsDBNull(dr.GetOrdinal("sexo")))
                        objEmp.sexo = dr.GetString((dr.GetOrdinal("sexo")));


                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_ingreso")))
                        objEmp.fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("tarea")))
                        objEmp.tarea = dr.GetString((dr.GetOrdinal("tarea")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_seccion")))
                        objEmp.cod_seccion = dr.GetInt32((dr.GetOrdinal("cod_seccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_categoria")))
                        objEmp.cod_categoria = dr.GetInt32((dr.GetOrdinal("cod_categoria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_cargo")))
                        objEmp.cod_cargo = dr.GetInt32((dr.GetOrdinal("cod_cargo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_banco")))
                        objEmp.cod_banco = dr.GetInt32((dr.GetOrdinal("cod_banco")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_sucursal")))
                        objEmp.nro_sucursal = dr.GetString((dr.GetOrdinal("nro_sucursal")));

                    if (!dr.IsDBNull(dr.GetOrdinal("tipo_cuenta")))
                        objEmp.tipo_cuenta = dr.GetString((dr.GetOrdinal("tipo_cuenta")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_caja_ahorro")))
                        objEmp.nro_caja_ahorro = dr.GetString((dr.GetOrdinal("nro_caja_ahorro")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cbu")))
                        objEmp.nro_cbu = dr.GetString((dr.GetOrdinal("nro_cbu")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_ipam")))
                        objEmp.nro_ipam = dr.GetString((dr.GetOrdinal("nro_ipam")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cuil")))
                        objEmp.cuil = dr.GetString((dr.GetOrdinal("cuil")));

                    //if (!dr.IsDBNull(dr.GetOrdinal("nro_jubilacion")))
                    //  objEmp.nro_jubilacion = dr.GetString((dr.GetOrdinal("nro_jubilacion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_jubilacion")))
                        objEmp.nro_jubilacion = dr.GetString((dr.GetOrdinal("nro_jubilacion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_ant")))
                        objEmp.antiguedad_ant = dr.GetInt32((dr.GetOrdinal("antiguedad_ant")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_actual")))
                        objEmp.antiguedad_actual = dr.GetInt32((dr.GetOrdinal("antiguedad_actual")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_clasif_per")))
                        objEmp.cod_clasif_per = dr.GetInt32((dr.GetOrdinal("cod_clasif_per")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_liq")))
                        objEmp.cod_tipo_liq = dr.GetInt32((dr.GetOrdinal("cod_tipo_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_ult_liq")))
                        objEmp.nro_ult_liq = dr.GetInt32((dr.GetOrdinal("nro_ult_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("anio_ult_liq")))
                        objEmp.anio_ult_liq = dr.GetInt32((dr.GetOrdinal("anio_ult_liq")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_sb")))
                        objEmp.nro_cta_sb = dr.GetString((dr.GetOrdinal("nro_cta_sb")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_gastos")))
                        objEmp.nro_cta_gastos = dr.GetString((dr.GetOrdinal("nro_cta_gastos")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_baja")))
                        objEmp.fecha_baja = Convert.ToDateTime(dr["fecha_baja"]).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_contrato")))
                        objEmp.nro_contrato = dr.GetInt32((dr.GetOrdinal("nro_contrato")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_inicio_contrato")))
                        objEmp.fecha_inicio_contrato = Convert.ToDateTime((dr["fecha_inicio_contrato"])).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_fin_contrato")))
                        objEmp.fecha_fin_contrato = Convert.ToDateTime((dr["fecha_fin_contrato"])).ToString("dd/MM/yyyy");

                    if (!dr.IsDBNull(dr.GetOrdinal("id_regimen")))
                        objEmp.id_regimen = dr.GetInt16((dr.GetOrdinal("id_regimen")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_secretaria")))
                        objEmp.id_secretaria = dr.GetInt32((dr.GetOrdinal("id_secretaria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_direccion")))
                        objEmp.id_direccion = dr.GetInt32((dr.GetOrdinal("id_direccion")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_nombramiento")))
                        objEmp.nro_nombramiento = dr.GetString((dr.GetOrdinal("nro_nombramiento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_nombramiento")))
                        objEmp.fecha_nombramiento = Convert.ToDateTime(dr["fecha_nombramiento"]).ToString("dd/MM/yyyy"); ;

                    if (!dr.IsDBNull(dr.GetOrdinal("usuario")))
                        objEmp.usuario = dr.GetString((dr.GetOrdinal("usuario")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_escala_aumento")))
                        objEmp.cod_escala_aumento = dr.GetInt32((dr.GetOrdinal("cod_escala_aumento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cod_regimen_empleado")))
                        objEmp.cod_regimen_empleado = dr.GetInt32((dr.GetOrdinal("cod_regimen_empleado")));

                    if (!dr.IsDBNull(dr.GetOrdinal("id_oficina")))
                        objEmp.id_oficina = dr.GetInt32((dr.GetOrdinal("id_oficina")));

                    if (!dr.IsDBNull(dr.GetOrdinal("email")))
                        objEmp.email = dr.GetString((dr.GetOrdinal("email")));

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally
            { cmd = null; strSQL = null; }

            dr.Close();
            return objEmp;

        }


        public static Int32 InsertDatosEmpleado(Entities.Empleado oEmp, SqlConnection cn, SqlTransaction trx)
        {

            SqlCommand objCommand = null;
            SqlCommand cmdInsert = null;
            //SqlConnection objConn = DALBase.GetConnection("SIIMVA");

            try
            {
                StringBuilder strSQL = new StringBuilder();

                //objConn.Open();

                if (oEmp.legajo == 0)
                {
                    string SQL = "SELECT isnull(max(legajo),0) FROM EMPLEADOS";
                    objCommand = new SqlCommand();
                    objCommand.Connection = cn;
                    objCommand.CommandType = CommandType.Text;
                    objCommand.Transaction = trx;
                    objCommand.CommandText = SQL;
                    oEmp.legajo = Convert.ToInt32(objCommand.ExecuteScalar()) + 1;
                }

                strSQL.AppendLine("INSERT INTO EMPLEADOS ");
                strSQL.AppendLine("(legajo,");
                strSQL.AppendLine("nombre,");
                strSQL.AppendLine("fecha_alta_registro,");
                strSQL.AppendLine("fecha_ingreso,");
                strSQL.AppendLine("cod_tipo_documento,");
                strSQL.AppendLine("nro_documento,");
                strSQL.AppendLine("cuil,");
                strSQL.AppendLine("tarea,");
                strSQL.AppendLine("cod_categoria,");
                strSQL.AppendLine("cod_cargo,");
                strSQL.AppendLine("cod_seccion,");
                strSQL.AppendLine("cod_clasif_per,");
                strSQL.AppendLine("cod_tipo_liq,");
                strSQL.AppendLine("id_secretaria,");
                strSQL.AppendLine("id_direccion,");
                strSQL.AppendLine("id_oficina,");
                strSQL.AppendLine("id_regimen,");
                strSQL.AppendLine("cod_regimen_empleado,");
                strSQL.AppendLine("cod_escala_aumento, listar) ");

                //Asigno Valores 

                strSQL.AppendLine("VALUES ");
                strSQL.AppendLine("(@legajo,");
                strSQL.AppendLine("@nombre,");
                strSQL.AppendLine("@fecha_alta_registro,");
                strSQL.AppendLine("@fecha_ingreso,");
                strSQL.AppendLine("@cod_tipo_documento,");
                strSQL.AppendLine("@nro_documento,");
                strSQL.AppendLine("@cuil,");
                strSQL.AppendLine("@tarea,");
                strSQL.AppendLine("@cod_cargo,");
                strSQL.AppendLine("@cod_categoria,");
                strSQL.AppendLine("@cod_seccion,");
                strSQL.AppendLine("@cod_clasif_per,");
                strSQL.AppendLine("@cod_tipo_liq,");
                strSQL.AppendLine("@id_secretaria,");
                strSQL.AppendLine("@id_direccion,");
                strSQL.AppendLine("@id_oficina,");
                strSQL.AppendLine("@id_regimen,");
                strSQL.AppendLine("@cod_regimen_empleado,");
                strSQL.AppendLine("@cod_escala_aumento, @listar)");

                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = trx;
                cmdInsert.CommandText = strSQL.ToString();

                cmdInsert.Parameters.Add(new SqlParameter("@legajo", oEmp.legajo));
                cmdInsert.Parameters.Add(new SqlParameter("@nombre", oEmp.nombre));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_alta_registro", oEmp.fecha_alta_registro != null ? oEmp.fecha_alta_registro : null));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_ingreso", oEmp.fecha_ingreso));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_tipo_documento", oEmp.cod_tipo_documento > 0 ? oEmp.cod_tipo_documento : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_documento", oEmp.nro_documento != null ? oEmp.nro_documento : null));
                cmdInsert.Parameters.Add(new SqlParameter("@cuil", oEmp.cuil != null ? oEmp.cuil : null));
                cmdInsert.Parameters.Add(new SqlParameter("@tarea", oEmp.tarea != null ? oEmp.tarea : null));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_categoria", oEmp.cod_categoria > 0 ? oEmp.cod_categoria : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_cargo", oEmp.cod_cargo > 0 ? oEmp.cod_cargo : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_seccion", oEmp.cod_seccion > 0 ? oEmp.cod_seccion : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_clasif_per", oEmp.cod_clasif_per > 0 ? oEmp.cod_clasif_per : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_tipo_liq", oEmp.cod_tipo_liq > 0 ? oEmp.cod_tipo_liq : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_secretaria", oEmp.id_secretaria > 0 ? oEmp.id_secretaria : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_direccion", oEmp.id_direccion > 0 ? oEmp.id_direccion : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_oficina", oEmp.id_oficina > 0 ? oEmp.id_oficina : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_regimen", oEmp.id_regimen > 0 ? oEmp.id_regimen : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_regimen_empleado", oEmp.cod_regimen_empleado > 0 ? oEmp.cod_regimen_empleado : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_escala_aumento", oEmp.cod_escala_aumento > 0 ? oEmp.cod_escala_aumento : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@listar", 1));


                cmdInsert.ExecuteNonQuery();
                //insertDetalle(op, objCommand);
                //insertAuditoria(op, objCommand, 0);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmdInsert = null;
                objCommand = null;
            }
            return oEmp.legajo;
        }


        public static Int32 UpdateDatosEmpleado(Entities.Empleado oEmp, string usuario, SqlConnection cn, SqlTransaction trx)
        {

            SqlCommand objCommand = null;
            SqlCommand objCategoria = null;
            int cod_categoria_ant = 0;

            //SqlConnection objConn = DALBase.GetConnection("SIIMVA");

            try
            {
                StringBuilder strSQL = new StringBuilder();
                StringBuilder strSQL1 = new StringBuilder();

                //objConn.Open();

                //Averiguo la Categoria del empleado para
                //guardarla como historial si hubo cambio de categoria
                string sql = "";
                sql = "select max(cod_categoria)  from empleados where legajo=" + oEmp.legajo;
                objCategoria = new SqlCommand();
                objCategoria.Connection = cn;
                objCategoria.CommandType = CommandType.Text;
                objCategoria.CommandText = sql;
                objCategoria.Transaction = trx;
                cod_categoria_ant = Convert.ToInt32(objCategoria.ExecuteScalar());


                strSQL.AppendLine("UPDATE EMPLEADOS SET ");
                strSQL.AppendLine("nombre=@nombre,");
                strSQL.AppendLine("fecha_alta_registro=@fecha_alta_registro,");
                if (oEmp.fecha_ingreso.Length != 0)
                    strSQL.AppendLine("fecha_ingreso=@fecha_ingreso,");
                else
                    strSQL.AppendLine("fecha_ingreso=null,");

                strSQL.AppendLine("cod_tipo_documento=@cod_tipo_documento,");
                strSQL.AppendLine("nro_documento=@nro_documento,");
                strSQL.AppendLine("cuil=@cuil,");
                strSQL.AppendLine("tarea=@tarea,");
                strSQL.AppendLine("cod_categoria=@cod_categoria,");
                strSQL.AppendLine("cod_cargo=@cod_cargo,");
                strSQL.AppendLine("cod_seccion=@cod_seccion,");
                strSQL.AppendLine("cod_clasif_per=@cod_clasif_per,");
                strSQL.AppendLine("cod_tipo_liq=@cod_tipo_liq,");
                strSQL.AppendLine("id_secretaria=@id_secretaria,");
                strSQL.AppendLine("id_direccion=@id_direccion,");
                strSQL.AppendLine("id_oficina=@id_oficina,");
                strSQL.AppendLine("id_regimen=@id_regimen,");
                strSQL.AppendLine("cod_escala_aumento=@cod_escala_aumento ");
                if (oEmp.fecha_baja.Length != 0)
                    strSQL.AppendLine(",fecha_baja=@fecha_baja");
                else
                    strSQL.AppendLine(",fecha_baja=null");
                strSQL.AppendLine(",cod_regimen_empleado=@cod_regimen_empleado");
                strSQL.AppendLine(" WHERE legajo=@legajo");


                //Asigno Valores 

                objCommand = new SqlCommand();
                objCommand.Connection = cn;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = strSQL.ToString();
                objCommand.Transaction = trx;


                objCommand.Parameters.Add(new SqlParameter("@legajo", oEmp.legajo));
                objCommand.Parameters.Add(new SqlParameter("@nombre", oEmp.nombre));
                objCommand.Parameters.Add(new SqlParameter("@fecha_alta_registro", oEmp.fecha_alta_registro.Length != 0 ? oEmp.fecha_alta_registro : ""));
                if (oEmp.fecha_ingreso.Length != 0)
                    objCommand.Parameters.Add(new SqlParameter("@fecha_ingreso", oEmp.fecha_ingreso));

                objCommand.Parameters.Add(new SqlParameter("@cod_tipo_documento", oEmp.cod_tipo_documento > 0 ? oEmp.cod_tipo_documento : 0));
                objCommand.Parameters.Add(new SqlParameter("@nro_documento", oEmp.nro_documento != null ? oEmp.nro_documento : null));
                objCommand.Parameters.Add(new SqlParameter("@cuil", oEmp.cuil != null ? oEmp.cuil : null));
                objCommand.Parameters.Add(new SqlParameter("@tarea", oEmp.tarea != null ? oEmp.tarea : null));
                objCommand.Parameters.Add(new SqlParameter("@cod_categoria", oEmp.cod_categoria > 0 ? oEmp.cod_categoria : 0));
                objCommand.Parameters.Add(new SqlParameter("@cod_cargo", oEmp.cod_cargo > 0 ? oEmp.cod_cargo : 0));
                objCommand.Parameters.Add(new SqlParameter("@cod_seccion", oEmp.cod_seccion > 0 ? oEmp.cod_seccion : 0));
                objCommand.Parameters.Add(new SqlParameter("@cod_clasif_per", oEmp.cod_clasif_per > 0 ? oEmp.cod_clasif_per : 0));
                objCommand.Parameters.Add(new SqlParameter("@cod_tipo_liq", oEmp.cod_tipo_liq > 0 ? oEmp.cod_tipo_liq : 0));
                objCommand.Parameters.Add(new SqlParameter("@id_secretaria", oEmp.id_secretaria > 0 ? oEmp.id_secretaria : 0));
                objCommand.Parameters.Add(new SqlParameter("@id_direccion", oEmp.id_direccion > 0 ? oEmp.id_direccion : 0));
                objCommand.Parameters.Add(new SqlParameter("@id_oficina", oEmp.id_oficina > 0 ? oEmp.id_oficina : 0));
                objCommand.Parameters.Add(new SqlParameter("@id_regimen", oEmp.id_regimen > 0 ? oEmp.id_regimen : 0));
                objCommand.Parameters.Add(new SqlParameter("@cod_escala_aumento", oEmp.cod_escala_aumento > 0 ? oEmp.cod_escala_aumento : 0));
                objCommand.Parameters.Add(new SqlParameter("@cod_regimen_empleado", oEmp.cod_regimen_empleado > 0 ? oEmp.cod_regimen_empleado : 0));
                if (oEmp.fecha_baja.Length != 0)
                    objCommand.Parameters.Add(new SqlParameter("@fecha_baja", oEmp.fecha_baja));

                objCommand.ExecuteNonQuery();
                if (cod_categoria_ant != oEmp.cod_categoria)
                    Cambios_categoria_empleado(oEmp.legajo, cod_categoria_ant, usuario, "modifica", "", cn, trx);
                //insertDetalle(op, objCommand);
                //insertAuditoria(op, objCommand, 0);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                objCommand = null;
                objCategoria = null;
            }
            return oEmp.legajo;
        }


        public static Int32 UpdateTab_Datos_Contrato(Entities.Empleado oEmp, string usuario, SqlConnection cn, SqlTransaction trx)
        {

            SqlCommand cmdInsert = null;
            //SqlConnection objConn = DALBase.GetConnection("SIIMVA");
            string nro_cta = oEmp.nro_cta_sb;
            string sql = "";

            try
            {
                StringBuilder strSQL = new StringBuilder();
                StringBuilder strSQL1 = new StringBuilder();


                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.Transaction = trx;
                //objConn.Open();

                strSQL.AppendLine("UPDATE EMPLEADOS set ");


                strSQL.AppendLine("nro_cta_sb=@nro_cta_sb,");

                strSQL.AppendLine("nro_cta_gastos=@nro_cta_gastos,");
                strSQL.AppendLine("nro_ipam=@nro_ipam,");
                strSQL.AppendLine("nro_jubilacion=@nro_jubilacion,");
                strSQL.AppendLine("antiguedad_ant=@antiguedad_ant,");
                strSQL.AppendLine("antiguedad_actual=@antiguedad_actual,");
                strSQL.AppendLine("nro_contrato=@nro_contrato,");

                if (oEmp.fecha_inicio_contrato.Length > 0)
                    strSQL.AppendLine("fecha_inicio_contrato=@fecha_inicio_contrato,");
                else
                    strSQL.AppendLine("fecha_inicio_contrato=null,");

                if (oEmp.fecha_fin_contrato.Length > 0)
                    strSQL.AppendLine("fecha_fin_contrato=@fecha_fin_contrato,");
                else
                    strSQL.AppendLine("fecha_fin_contrato=null,");

                if (oEmp.nro_nombramiento.Length > 0)
                    strSQL.AppendLine("nro_nombramiento=@nro_nombramiento,");
                else
                    strSQL.AppendLine("nro_nombramiento=null,");


                if (oEmp.fecha_nombramiento.Length > 0)
                    strSQL.AppendLine("fecha_nombramiento=@fecha_nombramiento,");
                else
                    strSQL.AppendLine("fecha_nombramiento=null,");

                char[] MyChar = { ',' };
                sql = strSQL.ToString();
                strSQL1.AppendLine(sql.Remove(sql.Trim().Length - 1, 1));


                cmdInsert.Parameters.Add(new SqlParameter("@nro_cta_sb", oEmp.nro_cta_sb.Length > 0 ? oEmp.nro_cta_sb : "0"));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_cta_gastos", oEmp.nro_cta_gastos.Length > 0 ? oEmp.nro_cta_gastos : "0"));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_ipam", oEmp.nro_ipam.Length > 0 ? oEmp.nro_ipam : "0"));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_jubilacion", oEmp.nro_jubilacion.Length > 0 ? oEmp.nro_jubilacion : "0"));
                cmdInsert.Parameters.Add(new SqlParameter("@antiguedad_ant", oEmp.antiguedad_ant > 0 ? oEmp.antiguedad_ant : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@antiguedad_actual", oEmp.antiguedad_actual > 0 ? oEmp.antiguedad_actual : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_contrato", oEmp.nro_contrato > 0 ? oEmp.nro_contrato : 0));

                if (oEmp.fecha_inicio_contrato.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@fecha_inicio_contrato", oEmp.fecha_inicio_contrato));
                if (oEmp.fecha_fin_contrato.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@fecha_fin_contrato", oEmp.fecha_fin_contrato));
                if (oEmp.nro_nombramiento.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@nro_nombramiento", oEmp.nro_nombramiento));
                if (oEmp.fecha_nombramiento.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@fecha_nombramiento", oEmp.fecha_nombramiento));


                strSQL1.AppendLine("WHERE legajo=@legajo");
                cmdInsert.Parameters.Add(new SqlParameter("@legajo", oEmp.legajo));

                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strSQL1.ToString();
                cmdInsert.Transaction = trx;
                cmdInsert.ExecuteNonQuery();
                //En las moficicaciones Guardo el historial del empleados
                //para tener una auditoria de cambios de datos.
                //Hist_cambios_empleados(oEmp.legajo, usuario, "", "", objConn);

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmdInsert = null;
            }
            return oEmp.legajo;
        }


        public static Int32 UpdateTab_Datos_Banco(Entities.Empleado oEmp, string usuario, SqlConnection cn, SqlTransaction trx)
        {
            SqlCommand cmdInsert = null;
            //SqlConnection objConn = DALBase.GetConnection("SIIMVA");

            try
            {
                StringBuilder strSQL = new StringBuilder();

                //objConn.Open();
                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;

                strSQL.AppendLine("UPDATE EMPLEADOS set ");
                strSQL.AppendLine("cod_banco=@cod_banco,");
                strSQL.AppendLine("tipo_cuenta=@tipo_cuenta,");
                strSQL.AppendLine("nro_sucursal=@nro_sucursal,");
                strSQL.AppendLine("nro_caja_ahorro=@nro_caja_ahorro,");
                strSQL.AppendLine("nro_cbu=@nro_cbu");

                cmdInsert.Parameters.Add(new SqlParameter("@cod_banco", oEmp.cod_banco > 0 ? oEmp.cod_banco : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@tipo_cuenta", oEmp.tipo_cuenta != null ? oEmp.tipo_cuenta : null));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_sucursal", oEmp.nro_sucursal != null ? oEmp.nro_sucursal : null));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_caja_ahorro", oEmp.nro_caja_ahorro != null ? oEmp.nro_caja_ahorro : null));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_cbu", oEmp.nro_cbu != null ? oEmp.nro_cbu : null));
                strSQL.AppendLine(" WHERE legajo=@legajo");
                cmdInsert.Parameters.Add(new SqlParameter("@legajo", oEmp.legajo));

                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strSQL.ToString();
                cmdInsert.Transaction = trx;
                cmdInsert.ExecuteNonQuery();
                //Hist_cambios_empleados(oEmp.legajo, usuario, "", "", objConn);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmdInsert = null;
            }
            return oEmp.legajo;
        }


        public static int UpdateTab_Datos_Particulares(Empleado oEmp, string usuario, SqlConnection cn, SqlTransaction trx)
        {

            SqlCommand objCommand = null;
            //SqlConnection cn = DALBase.GetConnection("SIIMVA");
            //int nro = 0;

            try
            {
                StringBuilder strSQL = new StringBuilder();
                Hist_cambios_empleados(oEmp.legajo, usuario, "", "", cn, trx);
                //cn.Open();
                objCommand = new SqlCommand();
                objCommand.Connection = cn;

                strSQL.AppendLine("UPDATE EMPLEADOS set ");
                strSQL.AppendLine("fecha_nacimiento=@fecha_nacimiento,");
                strSQL.AppendLine("sexo=@sexo,");
                strSQL.AppendLine("cod_estado_civil=@cod_estado_civil,");
                strSQL.AppendLine("pais_domicilio=@pais_domicilio,");
                strSQL.AppendLine("provincia_domicilio=@provincia_domicilio,");
                strSQL.AppendLine("ciudad_domicilio=@ciudad_domicilio,");
                strSQL.AppendLine("barrio_domicilio=@barrio_domicilio,");
                strSQL.AppendLine("calle_domicilio=@calle_domicilio,");
                strSQL.AppendLine("nro_domicilio=@nro_domicilio,");
                strSQL.AppendLine("piso_domicilio=@piso_domicilio,");
                strSQL.AppendLine("dpto_domicilio=@dpto_domicilio,");
                strSQL.AppendLine("monoblock_domicilio=@monoblock_domicilio,");
                strSQL.AppendLine("cod_postal=@cod_postal,");
                strSQL.AppendLine("telefonos=@telefonos,");
                strSQL.AppendLine("celular=@celular, ");
                strSQL.AppendLine("email=@email ");

                objCommand.Parameters.Add(new SqlParameter("@fecha_nacimiento", oEmp.fecha_nacimiento != null ? oEmp.fecha_nacimiento : null));
                objCommand.Parameters.Add(new SqlParameter("@sexo", oEmp.sexo != null ? oEmp.sexo : null));
                objCommand.Parameters.Add(new SqlParameter("@cod_estado_civil", oEmp.cod_estado_civil > 0 ? oEmp.cod_estado_civil : 0));
                objCommand.Parameters.Add(new SqlParameter("@pais_domicilio", oEmp.pais_domicilio != null ? oEmp.pais_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@provincia_domicilio", oEmp.provincia_domicilio != null ? oEmp.provincia_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@ciudad_domicilio", oEmp.ciudad_domicilio != null ? oEmp.ciudad_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@barrio_domicilio", oEmp.barrio_domicilio != null ? oEmp.barrio_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@calle_domicilio", oEmp.calle_domicilio != null ? oEmp.calle_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@nro_domicilio", oEmp.nro_domicilio != null ? oEmp.nro_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@piso_domicilio", oEmp.piso_domicilio != null ? oEmp.piso_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@dpto_domicilio", oEmp.dpto_domicilio != null ? oEmp.dpto_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@monoblock_domicilio", oEmp.monoblock_domicilio != null ? oEmp.monoblock_domicilio : null));
                objCommand.Parameters.Add(new SqlParameter("@cod_postal", oEmp.cod_postal != null ? oEmp.cod_postal : null));
                objCommand.Parameters.Add(new SqlParameter("@telefonos", oEmp.telefonos != null ? oEmp.telefonos : null));
                objCommand.Parameters.Add(new SqlParameter("@celular", oEmp.celular != null ? oEmp.celular : null));
                objCommand.Parameters.Add(new SqlParameter("@email", oEmp.email != null ? oEmp.email : null));

                //Con esto saco la ultima coma
                //string sql = strSQL.ToString();
                //StringBuilder strSQLAUX = new StringBuilder();
                //nro = sql.Length;
                //strSQLAUX.AppendLine(sql.Remove((nro - 3), 1));
                //strSQLAUX.AppendLine(" WHERE legajo=@legajo");

                strSQL.AppendLine(" WHERE legajo=@legajo");
                objCommand.Parameters.Add(new SqlParameter("@legajo", oEmp.legajo));
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = strSQL.ToString();
                objCommand.Transaction = trx;
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                objCommand = null;
            }
            return oEmp.legajo;
        }


        public static int Cambios_categoria_empleado(int legajo, int cod_categoria, string usuario, string operacion,
          string observacion, SqlConnection cnn, SqlTransaction trx)
        {

            SqlCommand objCommand = null;
            SqlCommand cmdInsert = null;
            int item = 0;

            try
            {
                StringBuilder strSQL = new StringBuilder();


                string SQL = "SELECT isnull(max(item),0)  As item";
                SQL = SQL + " FROM Empleados_cambios_categoria (nolock)";
                SQL = SQL + " Where legajo = " + legajo;

                objCommand = new SqlCommand();
                objCommand.Connection = cnn;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = SQL;
                objCommand.Transaction = trx;
                item = Convert.ToInt32(objCommand.ExecuteScalar()) + 1;


                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cnn;
                cmdInsert.Transaction = trx;

                strSQL.AppendLine("insert into Empleados_cambios_categoria ");
                strSQL.AppendLine(" (legajo, item, fecha_movimiento, cod_categoria, observacion, operacion, usuario) ");
                strSQL.AppendLine(" values ");
                strSQL.AppendLine("(@legajo,");
                strSQL.AppendLine("@item,");
                strSQL.AppendLine("@fecha_movimiento,");
                strSQL.AppendLine("@cod_categoria,");
                strSQL.AppendLine("@observacion,");
                strSQL.AppendLine("@operacion,");
                strSQL.AppendLine("@usuario ) ");


                cmdInsert.Parameters.Add(new SqlParameter("@legajo", legajo));
                cmdInsert.Parameters.Add(new SqlParameter("@item", item));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_movimiento", DateTime.Today.ToShortDateString()));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_categoria", cod_categoria));
                cmdInsert.Parameters.Add(new SqlParameter("@observacion", observacion));
                cmdInsert.Parameters.Add(new SqlParameter("@operacion", operacion));
                cmdInsert.Parameters.Add(new SqlParameter("@usuario", usuario));

                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strSQL.ToString();
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                cmdInsert = null;
                objCommand = null;
            }
            return legajo;
        }


        public static int Cambios_tipo_personal(int legajo, int cod_clasif_per, string usuario, string operacion, string observacion, SqlConnection cnn, SqlTransaction trx)
        {

            SqlCommand objCommand = null;
            SqlCommand cmdInsert = null;

            int item = 0;

            try
            {
                StringBuilder strSQL = new StringBuilder();

                string SQL = "SELECT isnull(max(item),0)  As item";
                SQL = SQL + " FROM Empleados_cambios_tipo_personal (nolock)";
                SQL = SQL + " Where legajo = " + legajo;

                objCommand = new SqlCommand();
                objCommand.Connection = cnn;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = SQL;
                objCommand.Transaction = trx;
                item = Convert.ToInt32(objCommand.ExecuteScalar()) + 1;

                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cnn;

                strSQL.AppendLine("insert into Empleados_cambios_categoria ");
                strSQL.AppendLine(" (legajo, item, fecha_movimiento, cod_clasif_per, observacion, operacion, usuario) ");
                strSQL.AppendLine(" values ");
                strSQL.AppendLine("(@legajo,");
                strSQL.AppendLine("@item,");
                strSQL.AppendLine("@fecha_movimiento,");
                strSQL.AppendLine("@cod_clasif_per,");
                strSQL.AppendLine("@observacion,");
                strSQL.AppendLine("@operacion,");
                strSQL.AppendLine("@usuario) ");


                cmdInsert.Parameters.Add(new SqlParameter("@legajo", legajo));
                cmdInsert.Parameters.Add(new SqlParameter("@item", item));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_movimiento", DateTime.Today.ToShortDateString()));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_clasif_per", cod_clasif_per));
                cmdInsert.Parameters.Add(new SqlParameter("@observacion", observacion));
                cmdInsert.Parameters.Add(new SqlParameter("@operacion", operacion));
                cmdInsert.Parameters.Add(new SqlParameter("@usuario", usuario));

                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strSQL.ToString();
                cmdInsert.Transaction = trx;
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                cmdInsert = null;
                objCommand = null;
            }
            return legajo;
        }


        public static int Hist_cambios_empleados(int legajo, string usuario, string operacion, string observacion, SqlConnection cn, SqlTransaction trx)
        {

            Entities.Empleado oEmp = new Empleado();
            SqlCommand cmd = null;
            SqlCommand cmdInsert = null;
            //SqlConnection cn = DALBase.GetConnection("SIIMVA");

            int nro_item = 0;

            try
            {
                StringBuilder strSQL = new StringBuilder();


                if (legajo > 0)
                {
                    string SQL = "SELECT isnull(max(nro_item),0)  As item";
                    SQL = SQL + " FROM HIST_CAMBIO_EMPLEADOS (nolock)";
                    SQL = SQL + " Where legajo = " + legajo;

                    cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Transaction = trx;
                    nro_item = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                }
                else
                    nro_item = 1;
                oEmp = GetByPk(legajo, cn, trx);

                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;

                strSQL.AppendLine("INSERT INTO HIST_CAMBIO_EMPLEADOS ");

                strSQL.AppendLine("(legajo, nro_item, nombre, fecha_movimiento, fecha_ingreso, cod_tipo_documento, nro_documento,");
                strSQL.AppendLine("cuil, tarea, cod_cargo, cod_seccion, cod_clasif_per, cod_tipo_liq, id_secretaria, id_direccion,");
                strSQL.AppendLine("id_oficina, id_regimen, cod_escala_aumento, fecha_nacimiento, sexo, cod_estado_civil, pais_domicilio,");
                strSQL.AppendLine("provincia_domicilio, ciudad_domicilio, barrio_domicilio, calle_domicilio, nro_domicilio, piso_domicilio,");
                strSQL.AppendLine("dpto_domicilio, monoblock_domicilio, cod_postal, telefonos, celular, email, nro_cta_sb, nro_cta_gastos,");
                strSQL.AppendLine("nro_ipam, nro_jubilacion, antiguedad_ant, antiguedad_actual, nro_contrato, fecha_inicio_contrato,");
                strSQL.AppendLine("fecha_fin_contrato, nro_nombramiento, fecha_nombramiento, cod_banco, tipo_cuenta, nro_sucursal, nro_caja_ahorro,");
                strSQL.AppendLine("nro_cbu, cod_regimen_empleado)");
                strSQL.AppendLine(" values ");
                strSQL.AppendLine("(@legajo, @nro_item, @nombre, @fecha_movimiento, @fecha_ingreso, @cod_tipo_documento, @nro_documento, @cuil,");
                strSQL.AppendLine("@tarea, @cod_cargo,@cod_seccion, @cod_clasif_per, @cod_tipo_liq, @id_secretaria, @id_direccion, @id_oficina,");
                strSQL.AppendLine("@id_regimen, @cod_escala_aumento, @fecha_nacimiento, @sexo, @cod_estado_civil, @pais_domicilio, @provincia_domicilio,");
                strSQL.AppendLine("@ciudad_domicilio, @barrio_domicilio, @calle_domicilio, @nro_domicilio, @piso_domicilio, @dpto_domicilio, @monoblock_domicilio,");
                strSQL.AppendLine("@cod_postal, @telefonos, @celular, @email, @nro_cta_sb, @nro_cta_gastos, @nro_ipam, @nro_jubilacion, @antiguedad_ant,");
                strSQL.AppendLine("@antiguedad_actual, @nro_contrato, @fecha_inicio_contrato, @fecha_fin_contrato, @nro_nombramiento, @fecha_nombramiento,");
                strSQL.AppendLine("@cod_banco, @tipo_cuenta, @nro_sucursal, @nro_caja_ahorro, @nro_cbu, @cod_regimen_empleado) ");



                cmdInsert.Parameters.Add(new SqlParameter("@legajo", oEmp.legajo));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_item", nro_item));
                cmdInsert.Parameters.Add(new SqlParameter("@nombre", oEmp.nombre));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_movimiento", DateTime.Today.ToShortDateString()));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_ingreso", oEmp.fecha_ingreso != null ? oEmp.fecha_ingreso : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_tipo_documento", oEmp.cod_tipo_documento > 0 ? oEmp.cod_tipo_documento : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_documento", oEmp.nro_documento != null ? oEmp.nro_documento : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@cuil", oEmp.cuil != null ? oEmp.cuil : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@tarea", oEmp.tarea != null ? oEmp.tarea : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_cargo", oEmp.cod_cargo > 0 ? oEmp.cod_cargo : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_seccion", oEmp.cod_seccion > 0 ? oEmp.cod_seccion : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_clasif_per", oEmp.cod_clasif_per > 0 ? oEmp.cod_clasif_per : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_tipo_liq", oEmp.cod_tipo_liq > 0 ? oEmp.cod_tipo_liq : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_secretaria", oEmp.id_secretaria > 0 ? oEmp.id_secretaria : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_direccion", oEmp.id_direccion > 0 ? oEmp.id_direccion : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_oficina", oEmp.id_oficina > 0 ? oEmp.id_oficina : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@id_regimen", oEmp.id_regimen > 0 ? oEmp.id_regimen : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_escala_aumento", oEmp.cod_escala_aumento > 0 ? oEmp.cod_escala_aumento : 0));


                cmdInsert.Parameters.Add(new SqlParameter("@fecha_nacimiento", oEmp.fecha_nacimiento != null ? oEmp.fecha_nacimiento : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@sexo", oEmp.sexo != null ? oEmp.sexo : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_estado_civil", oEmp.cod_estado_civil > 0 ? oEmp.cod_estado_civil : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@pais_domicilio", oEmp.pais_domicilio != null ? oEmp.pais_domicilio : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@provincia_domicilio", oEmp.provincia_domicilio != null ? oEmp.provincia_domicilio : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@ciudad_domicilio", oEmp.ciudad_domicilio != null ? oEmp.ciudad_domicilio : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@barrio_domicilio", oEmp.barrio_domicilio != null ? oEmp.barrio_domicilio : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@calle_domicilio", oEmp.calle_domicilio != null ? oEmp.calle_domicilio : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_domicilio", oEmp.nro_domicilio != null ? oEmp.nro_domicilio : ""));


                cmdInsert.Parameters.Add(new SqlParameter("@piso_domicilio", oEmp.piso_domicilio != null ? oEmp.piso_domicilio : ""));

                cmdInsert.Parameters.Add(new SqlParameter("@dpto_domicilio", oEmp.dpto_domicilio != null ? oEmp.dpto_domicilio : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@monoblock_domicilio", oEmp.monoblock_domicilio != null ? oEmp.monoblock_domicilio : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_postal", oEmp.cod_postal != null ? oEmp.cod_postal : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@telefonos", oEmp.telefonos != null ? oEmp.telefonos : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@celular", oEmp.celular != null ? oEmp.celular : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@email", oEmp.email != null ? oEmp.email : ""));

                cmdInsert.Parameters.Add(new SqlParameter("@nro_cta_sb", oEmp.nro_cta_sb != null ? oEmp.nro_cta_sb : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_cta_gastos", oEmp.nro_cta_gastos != null ? oEmp.nro_cta_gastos : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_ipam", oEmp.nro_ipam != null ? oEmp.nro_ipam : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_jubilacion", oEmp.nro_jubilacion != null ? oEmp.nro_jubilacion : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@antiguedad_ant", oEmp.antiguedad_ant > 0 ? oEmp.antiguedad_ant : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@antiguedad_actual", oEmp.antiguedad_actual > 0 ? oEmp.antiguedad_actual : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_contrato", oEmp.nro_contrato > 0 ? oEmp.nro_contrato : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_inicio_contrato", oEmp.fecha_inicio_contrato != null ? oEmp.fecha_inicio_contrato : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_fin_contrato", oEmp.fecha_fin_contrato != null ? oEmp.fecha_fin_contrato : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_nombramiento", oEmp.nro_nombramiento != null ? oEmp.nro_nombramiento : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_nombramiento", oEmp.fecha_nombramiento != null ? oEmp.fecha_nombramiento : ""));


                cmdInsert.Parameters.Add(new SqlParameter("@cod_banco", oEmp.cod_banco > 0 ? oEmp.cod_banco : 0));
                cmdInsert.Parameters.Add(new SqlParameter("@tipo_cuenta", oEmp.tipo_cuenta != null ? oEmp.tipo_cuenta : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_sucursal", oEmp.nro_sucursal != null ? oEmp.nro_sucursal : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_caja_ahorro", oEmp.nro_caja_ahorro != null ? oEmp.nro_caja_ahorro : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_cbu", oEmp.nro_cbu != null ? oEmp.nro_cbu : ""));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_regimen_empleado", oEmp.cod_regimen_empleado > 0 ? oEmp.cod_regimen_empleado : 0));

                //objCommand.Parameters.Add(new SqlParameter("@usuario", usuario));
                //objCommand.Parameters.Add(new SqlParameter("@observacion", observacion));
                //objCommand.Parameters.Add(new SqlParameter("@operacion", operacion));

                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strSQL.ToString();
                cmdInsert.Transaction = trx;
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd = null;
                cmdInsert = null;
            }
            return legajo;
        }


        public static string Certficaciones_Empleado(int legajo)
        {
            Entities.Empleado oEmp = new Empleado();
            DBHelper oLib = new DBHelper();
            string strXML = "";

            try
            {

                StringBuilder strSQL = new StringBuilder();

                strSQL.AppendLine(" SELECT e.legajo, e.nombre, l.anio, l.periodo, a.desc_cargo, e.tarea, l1.importe");
                strSQL.AppendLine(" FROM LIQUIDACIONES l WITH (NOLOCK)");
                strSQL.AppendLine(" JOIN DET_LIQ_X_EMPLEADO l1 ON");
                strSQL.AppendLine(" l.anio=l1.anio AND");
                strSQL.AppendLine(" l.cod_tipo_liq=l1.cod_tipo_liq AND");
                strSQL.AppendLine(" l.nro_liquidacion = l1.nro_liquidacion AND");
                strSQL.AppendLine(" l1.cod_concepto_liq = 390");
                strSQL.AppendLine(" JOIN EMPLEADOS e ON");
                strSQL.AppendLine(" e.legajo = l1.legajo");
                //strSQL.AppendLine(" LEFT JOIN TIPOS_DOCUMENTOS t ON");
                //strSQL.AppendLine(" e.cod_tipo_documento = t.cod_tipo_documento");
                strSQL.AppendLine(" LEFT JOIN CATEGORIAS c ON");
                strSQL.AppendLine(" e.cod_categoria = c.cod_categoria");
                strSQL.AppendLine(" LEFT JOIN CARGOS a ON");
                strSQL.AppendLine(" e.cod_cargo = a.cod_cargo");
                strSQL.AppendLine(" LEFT JOIN clasificaciones_personal b ON");
                strSQL.AppendLine(" e.cod_clasif_per = b.cod_clasif_per");
                strSQL.AppendLine(" WHERE e.legajo=" + legajo.ToString());
                strSQL.AppendLine(" ORDER BY l.anio,l.cod_tipo_liq,l.nro_liquidacion,l.periodo");

                strXML = oLib.GetXML("Datos", "Dato", strSQL.ToString());

                return strXML;

            }

            catch (Exception ex)
            { throw ex; }
            finally
            {
                oLib = null;
                oEmp = null;
            }
        }


        public static List<Entities.Certificaciones> GetCertificaciones(int legajo)
        {
            List<Entities.Certificaciones> oLst = new List<Entities.Certificaciones>();
            Entities.Certificaciones oDetalle;

            SqlCommand objCommand = null;
            SqlConnection cnn = DALBase.GetConnection("SIIMVA");
            SqlDataReader dr;

            try
            {

                StringBuilder strSQL = new StringBuilder();

                strSQL.AppendLine(" SELECT e.legajo, e.nombre, l.anio, l.periodo, a.desc_cargo, e.tarea, l1.importe");
                strSQL.AppendLine(" FROM LIQUIDACIONES l WITH (NOLOCK)");
                strSQL.AppendLine(" JOIN DET_LIQ_X_EMPLEADO l1 ON");
                strSQL.AppendLine(" l.anio=l1.anio AND");
                strSQL.AppendLine(" l.cod_tipo_liq=l1.cod_tipo_liq AND");
                strSQL.AppendLine(" l.nro_liquidacion = l1.nro_liquidacion AND");
                strSQL.AppendLine(" l1.cod_concepto_liq = 390");
                strSQL.AppendLine(" JOIN EMPLEADOS e ON");
                strSQL.AppendLine(" e.legajo = l1.legajo");
                //strSQL.AppendLine(" JOIN TIPOS_DOCUMENTOS t ON");
                //strSQL.AppendLine(" e.cod_tipo_documento = t.cod_tipo_documento");
                strSQL.AppendLine(" LEFT JOIN CATEGORIAS c ON");
                strSQL.AppendLine(" e.cod_categoria = c.cod_categoria");
                strSQL.AppendLine(" Left JOIN CARGOS a ON");
                strSQL.AppendLine(" e.cod_cargo = a.cod_cargo");
                strSQL.AppendLine(" Left JOIN clasificaciones_personal b ON");
                strSQL.AppendLine(" e.cod_clasif_per = b.cod_clasif_per");
                strSQL.AppendLine(" WHERE e.legajo=@legajo");
                strSQL.AppendLine(" ORDER BY l.anio,l.cod_tipo_liq,l.nro_liquidacion,l.periodo");

                objCommand = new SqlCommand();
                objCommand.Parameters.Add(new SqlParameter("@legajo", legajo));
                objCommand.Connection = cnn;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = strSQL.ToString();
                objCommand.Connection.Open();
                dr = objCommand.ExecuteReader();


                while (dr.Read())
                {
                    oDetalle = new Certificaciones();

                    if (!dr.IsDBNull(dr.GetOrdinal("legajo")))
                        oDetalle.legajo = dr.GetInt32((dr.GetOrdinal("legajo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                        oDetalle.nombre = dr.GetString((dr.GetOrdinal("nombre")));

                    if (!dr.IsDBNull(dr.GetOrdinal("anio")))
                        oDetalle.anio = Convert.ToString(dr.GetInt32((dr.GetOrdinal("anio"))));

                    if (!dr.IsDBNull(dr.GetOrdinal("periodo")))
                        oDetalle.periodo = dr.GetString((dr.GetOrdinal("periodo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("desc_cargo")))
                        oDetalle.cargo = dr.GetString((dr.GetOrdinal("desc_cargo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("tarea")))
                        oDetalle.tarea = dr.GetString((dr.GetOrdinal("tarea")));

                    if (!dr.IsDBNull(dr.GetOrdinal("importe")))
                        oDetalle.importe = dr.GetDecimal((dr.GetOrdinal("importe")));


                    oLst.Add(oDetalle);
                }

                return oLst;

            }

            catch (Exception ex)
            { throw ex; }
            finally
            {
                oLst = null;
                oDetalle = null;
            }
        }


        public static List<Entities.HistorialEmpleado> GetHistCambiosPersonal(int legajo, SqlConnection cn, SqlTransaction trx)
        {
            List<Entities.HistorialEmpleado> oLst = new List<Entities.HistorialEmpleado>();
            Entities.HistorialEmpleado oDetalle;

            SqlCommand cmd = null;
            SqlDataReader dr;

            try
            {

                StringBuilder strSQL = new StringBuilder();

                strSQL.AppendLine("select h.legajo,h.nro_item,convert(char(10),h.fecha_movimiento,103) as fecha_movimiento,");
                strSQL.AppendLine(" h.nombre,t.des_tipo_documento,h.nro_documento,convert(char(10),h.fecha_nacimiento,103) as fecha_nacimiento,");
                strSQL.AppendLine(" h.sexo,h.ciudad_domicilio,h.barrio_domicilio,h.calle_domicilio,h.nro_domicilio,");
                strSQL.AppendLine(" h.dpto_domicilio,h.piso_domicilio,h.monoblock_domicilio,h.telefonos,h.celular,h.cod_postal,");
                strSQL.AppendLine(" e.des_estado_civil, convert(char(10),h.fecha_ingreso,103) as fecha_ingreso,");
                strSQL.AppendLine(" h.tarea,s.des_seccion,h.cod_categoria, c.sueldo_basico,g.desc_cargo,b.nom_banco,h.nro_sucursal,");
                strSQL.AppendLine(" tc.des_tipo_cuenta,h.nro_caja_ahorro,h.nro_ipam,h.cuil,h.antiguedad_ant,h.antiguedad_actual,");
                strSQL.AppendLine(" cp.des_clasif_per , tl.des_tipo_liq, h.nro_cta_sb, h.nro_cta_gastos, h.fecha_baja, h.nro_contrato, ");
                strSQL.AppendLine(" convert(char(10),h.fecha_inicio_contrato,103) as fecha_inicio_contrato, convert(char(10),h.fecha_fin_contrato,103) as fecha_fin_contrato, ");
                strSQL.AppendLine(" h.id_regimen, s1.descripcion as des_secretaria, d.descripcion as des_direccion, h.cod_escala_aumento, h.email, h.cod_regimen_empleado, er.descripcion as des_regimen_empleado");
                strSQL.AppendLine(" from hist_cambio_empleados h");
                strSQL.AppendLine(" LEFT join tipos_documentos t on");
                strSQL.AppendLine(" h.cod_tipo_documento = t.cod_tipo_documento");
                strSQL.AppendLine(" LEFT join estados_civiles e on");
                strSQL.AppendLine(" h.cod_estado_civil = e.cod_estado_civil");
                strSQL.AppendLine(" LEFT join secciones s on");
                strSQL.AppendLine(" h.cod_seccion = s.cod_seccion");
                strSQL.AppendLine(" left join categorias c on");
                strSQL.AppendLine(" h.cod_categoria = c.cod_categoria");
                strSQL.AppendLine(" left join cargos g on");
                strSQL.AppendLine(" h.cod_cargo = g.cod_cargo");
                strSQL.AppendLine(" left join bancos b on");
                strSQL.AppendLine(" h.cod_banco = b.cod_banco");
                strSQL.AppendLine(" left join tipos_cuentas tc on");
                strSQL.AppendLine(" h.tipo_cuenta = tc.cod_tipo_cuenta");
                strSQL.AppendLine(" left join clasificaciones_personal cp on");
                strSQL.AppendLine(" h.cod_clasif_per = cp.cod_clasif_per");
                strSQL.AppendLine(" left join tipos_liquidacion tl on");
                strSQL.AppendLine(" h.cod_tipo_liq = tl.cod_tipo_liq");
                strSQL.AppendLine(" left join secretaria s1 on");
                strSQL.AppendLine(" h.id_secretaria = s1.id_secretaria");
                strSQL.AppendLine(" left join direccion d on");
                strSQL.AppendLine(" h.id_direccion = d.id_direccion");
                strSQL.AppendLine(" left join EMPLEADOS_REGIMEN er on");
                strSQL.AppendLine(" er.cod_regimen_empleado = h.cod_regimen_empleado");

                strSQL.AppendLine(" where h.legajo=@legajo");



                cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter("@legajo", legajo));
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    oDetalle = new HistorialEmpleado();

                    if (!dr.IsDBNull(dr.GetOrdinal("legajo")))
                        oDetalle.legajo = dr.GetInt32((dr.GetOrdinal("legajo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_item")))
                        oDetalle.nro_item = dr.GetInt32((dr.GetOrdinal("nro_item")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_movimiento")))
                        oDetalle.fecha_movimiento = dr.GetString((dr.GetOrdinal("fecha_movimiento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                        oDetalle.nombre = dr.GetString((dr.GetOrdinal("nombre")));

                    if (!dr.IsDBNull(dr.GetOrdinal("des_tipo_documento")))
                        oDetalle.des_tipo_documento = dr.GetString((dr.GetOrdinal("des_tipo_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_documento")))
                        oDetalle.nro_documento = dr.GetString((dr.GetOrdinal("nro_documento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_nacimiento")))
                        oDetalle.fecha_nacimiento = dr.GetString((dr.GetOrdinal("fecha_nacimiento")));

                    if (!dr.IsDBNull(dr.GetOrdinal("sexo")))
                        oDetalle.sexo = dr.GetString((dr.GetOrdinal("sexo")));

                    if (!dr.IsDBNull(dr.GetOrdinal("ciudad_domicilio")))
                        oDetalle.ciudad_domicilio = dr.GetString((dr.GetOrdinal("ciudad_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("barrio_domicilio")))
                        oDetalle.barrio_domicilio = dr.GetString((dr.GetOrdinal("barrio_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("calle_domicilio")))
                        oDetalle.calle_domicilio = dr.GetString((dr.GetOrdinal("calle_domicilio")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_domicilio")))
                        oDetalle.nro_domicilio = Convert.ToString(dr.GetInt32((dr.GetOrdinal("nro_domicilio"))));
                    if (!dr.IsDBNull(dr.GetOrdinal("dpto_domicilio")))
                        oDetalle.dpto_domicilio = dr.GetString((dr.GetOrdinal("dpto_domicilio")));
                    if (!dr.IsDBNull(dr.GetOrdinal("piso_domicilio")))
                        oDetalle.piso_domicilio = dr.GetString((dr.GetOrdinal("piso_domicilio")));
                    if (!dr.IsDBNull(dr.GetOrdinal("monoblock_domicilio")))
                        oDetalle.monoblock_domicilio = dr.GetString((dr.GetOrdinal("monoblock_domicilio")));
                    if (!dr.IsDBNull(dr.GetOrdinal("telefonos")))
                        oDetalle.telefonos = dr.GetString((dr.GetOrdinal("telefonos")));
                    if (!dr.IsDBNull(dr.GetOrdinal("celular")))
                        oDetalle.celular = dr.GetString((dr.GetOrdinal("celular")));
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_postal")))
                        oDetalle.cod_postal = dr.GetString((dr.GetOrdinal("cod_postal")));
                    if (!dr.IsDBNull(dr.GetOrdinal("des_estado_civil")))
                        oDetalle.des_estado_civil = dr.GetString((dr.GetOrdinal("des_estado_civil")));
                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_ingreso")))
                        oDetalle.fecha_ingreso = dr.GetString((dr.GetOrdinal("fecha_ingreso")));
                    if (!dr.IsDBNull(dr.GetOrdinal("tarea")))
                        oDetalle.tarea = dr.GetString((dr.GetOrdinal("tarea")));
                    if (!dr.IsDBNull(dr.GetOrdinal("des_seccion")))
                        oDetalle.des_seccion = dr.GetString((dr.GetOrdinal("des_seccion")));
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_categoria")))
                        oDetalle.cod_categoria = dr.GetInt32((dr.GetOrdinal("cod_categoria")));

                    if (!dr.IsDBNull(dr.GetOrdinal("sueldo_basico")))
                        oDetalle.sueldo_basico = dr.GetDecimal((dr.GetOrdinal("sueldo_basico")));
                    if (!dr.IsDBNull(dr.GetOrdinal("desc_cargo")))
                        oDetalle.desc_cargo = dr.GetString((dr.GetOrdinal("desc_cargo")));
                    if (!dr.IsDBNull(dr.GetOrdinal("nom_banco")))
                        oDetalle.nom_banco = dr.GetString((dr.GetOrdinal("nom_banco")));
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_sucursal")))
                        oDetalle.nro_sucursal = dr.GetString((dr.GetOrdinal("nro_sucursal")));

                    if (!dr.IsDBNull(dr.GetOrdinal("des_tipo_cuenta")))
                        oDetalle.des_tipo_cuenta = dr.GetString((dr.GetOrdinal("des_tipo_cuenta")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_caja_ahorro")))
                        oDetalle.nro_caja_ahorro = dr.GetString((dr.GetOrdinal("nro_caja_ahorro")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_ipam")))
                        oDetalle.nro_ipam = dr.GetString((dr.GetOrdinal("nro_ipam")));

                    if (!dr.IsDBNull(dr.GetOrdinal("cuil")))
                        oDetalle.cuil = dr.GetString((dr.GetOrdinal("cuil")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_ant")))
                        oDetalle.antiguedad_ant = dr.GetInt32((dr.GetOrdinal("antiguedad_ant")));

                    if (!dr.IsDBNull(dr.GetOrdinal("antiguedad_actual")))
                        oDetalle.antigudad_actual = dr.GetInt32((dr.GetOrdinal("antiguedad_actual")));

                    if (!dr.IsDBNull(dr.GetOrdinal("des_clasif_per")))
                        oDetalle.des_clasif_per = dr.GetString((dr.GetOrdinal("des_clasif_per")));
                    if (!dr.IsDBNull(dr.GetOrdinal("des_tipo_liq")))
                        oDetalle.des_tipo_liq = dr.GetString((dr.GetOrdinal("des_tipo_liq")));
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_sb")))
                        oDetalle.nro_cta_sb = dr.GetString((dr.GetOrdinal("nro_cta_sb")));
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cta_gastos")))
                        oDetalle.nro_cta_gastos = dr.GetString((dr.GetOrdinal("nro_cta_gastos")));
                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_baja")))
                        oDetalle.fecha_baja = Convert.ToString((dr.GetOrdinal("fecha_baja")));

                    if (!dr.IsDBNull(dr.GetOrdinal("nro_contrato")))
                        oDetalle.nro_contrato = dr.GetInt32(dr.GetOrdinal("nro_contrato"));

                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_inicio_contrato")))
                        oDetalle.fecha_inicio_contrato = dr.GetString((dr.GetOrdinal("fecha_inicio_contrato")));
                    if (!dr.IsDBNull(dr.GetOrdinal("fecha_fin_contrato")))
                        oDetalle.fecha_fin_contrato = dr.GetString((dr.GetOrdinal("fecha_fin_contrato")));
                    if (!dr.IsDBNull(dr.GetOrdinal("id_regimen")))
                        oDetalle.id_regimen = dr.GetInt32((dr.GetOrdinal("id_regimen")));
                    if (!dr.IsDBNull(dr.GetOrdinal("des_secretaria")))
                        oDetalle.des_secretaria = dr.GetString((dr.GetOrdinal("des_secretaria")));
                    if (!dr.IsDBNull(dr.GetOrdinal("des_direccion")))
                        oDetalle.des_direccion = dr.GetString((dr.GetOrdinal("des_direccion")));
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_escala_aumento")))
                        oDetalle.cod_escala_aumento = dr.GetInt32((dr.GetOrdinal("cod_escala_aumento")));
                    if (!dr.IsDBNull(dr.GetOrdinal("email")))
                        oDetalle.email = dr.GetString((dr.GetOrdinal("email")));
                    if (!dr.IsDBNull(dr.GetOrdinal("cod_regimen_empleado")))
                        oDetalle.cod_regimen_empleado = dr.GetInt32((dr.GetOrdinal("cod_regimen_empleado")));
                    if (!dr.IsDBNull(dr.GetOrdinal("des_regimen_empleado")))
                        oDetalle.des_regimen_empleado = dr.GetString((dr.GetOrdinal("des_regimen_empleado")));

                    oLst.Add(oDetalle);
                }
                return oLst;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                oLst = null;
                oDetalle = null;
            }
        }


    }

}



#endregion


