using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LICENCIA_PARAM_EMPLEADOS : DALBase
    {
        public int id { get; set; }
        public int cod_tipo_licencia { get; set; }
        public decimal anio_desde { get; set; }
        public decimal anios_hasta { get; set; }
        public int cantidad_dias { get; set; }
        public bool habiles { get; set; }
        public bool proporcional { get; set; }
        public int minimo_a_solicitar { get; set; }

        public LICENCIA_PARAM_EMPLEADOS()
        {
            id = 0;
            cod_tipo_licencia = 0;
            anio_desde = 0;
            anios_hasta = 0;
            cantidad_dias = 0;
            habiles = true;
            proporcional = false;
            minimo_a_solicitar = 0;
        }

        private static List<LICENCIA_PARAM_EMPLEADOS> mapeo(SqlDataReader dr)
        {
            List<LICENCIA_PARAM_EMPLEADOS> lst = new List<LICENCIA_PARAM_EMPLEADOS>();
            LICENCIA_PARAM_EMPLEADOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LICENCIA_PARAM_EMPLEADOS();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.cod_tipo_licencia = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.anio_desde = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.anios_hasta = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.cantidad_dias = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.habiles = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.proporcional = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.minimo_a_solicitar = dr.GetInt32(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LICENCIA_PARAM_EMPLEADOS> read(int id)
        {
            try
            {
                List<LICENCIA_PARAM_EMPLEADOS> lst = new List<LICENCIA_PARAM_EMPLEADOS>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LICENCIA_PARAM_EMPLEADOS WHERE cod_tipo_licencia = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
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

        public static LICENCIA_PARAM_EMPLEADOS getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LICENCIA_PARAM_EMPLEADOS WHERE");
                sql.AppendLine("id = @id");
                LICENCIA_PARAM_EMPLEADOS obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LICENCIA_PARAM_EMPLEADOS> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal getMax()
        {
            try
            {
                List<LICENCIA_PARAM_EMPLEADOS> lst = new List<LICENCIA_PARAM_EMPLEADOS>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT ISNULL(MAX(anios_hasta),0) FROM LICENCIA_PARAM_EMPLEADOS";
                    cmd.Connection.Open();
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(LICENCIA_PARAM_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LICENCIA_PARAM_EMPLEADOS(");
                sql.AppendLine("cod_tipo_licencia");
                sql.AppendLine(", anio_desde");
                sql.AppendLine(", anios_hasta");
                sql.AppendLine(", cantidad_dias");
                sql.AppendLine(", habiles");
                sql.AppendLine(", proporcional");
                sql.AppendLine(", minimo_a_solicitar");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_tipo_licencia");
                sql.AppendLine(", @anio_desde");
                sql.AppendLine(", @anios_hasta");
                sql.AppendLine(", @cantidad_dias");
                sql.AppendLine(", @habiles");
                sql.AppendLine(", @proporcional");
                sql.AppendLine(", @minimo_a_solicitar");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_desde", obj.anio_desde);
                    cmd.Parameters.AddWithValue("@anios_hasta", obj.anios_hasta);
                    cmd.Parameters.AddWithValue("@cantidad_dias", obj.cantidad_dias);
                    cmd.Parameters.AddWithValue("@habiles", obj.habiles);
                    cmd.Parameters.AddWithValue("@proporcional", obj.proporcional);
                    cmd.Parameters.AddWithValue("@minimo_a_solicitar", obj.minimo_a_solicitar);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LICENCIA_PARAM_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LICENCIA_PARAM_EMPLEADOS SET");
                sql.AppendLine("cod_tipo_licencia=@cod_tipo_licencia");
                sql.AppendLine(", anio_desde=@anio_desde");
                sql.AppendLine(", anios_hasta=@anios_hasta");
                sql.AppendLine(", cantidad_dias=@cantidad_dias");
                sql.AppendLine(", habiles=@habiles");
                sql.AppendLine(", proporcional=@proporcional");
                sql.AppendLine(", minimo_a_solicitar=@minimo_a_solicitar");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_desde", obj.anio_desde);
                    cmd.Parameters.AddWithValue("@anios_hasta", obj.anios_hasta);
                    cmd.Parameters.AddWithValue("@cantidad_dias", obj.cantidad_dias);
                    cmd.Parameters.AddWithValue("@habiles", obj.habiles);
                    cmd.Parameters.AddWithValue("@proporcional", obj.proporcional);
                    cmd.Parameters.AddWithValue("@minimo_a_solicitar", obj.minimo_a_solicitar);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(LICENCIA_PARAM_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  LICENCIA_PARAM_EMPLEADOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

