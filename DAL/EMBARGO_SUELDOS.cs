using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class EMBARGO_SUELDOS : DALBase
    {
        public int legajo { get; set; }
        public int cod_concepto_liq { get; set; }
        public int nro_historia { get; set; }
        public DateTime fecha_alta_registro { get; set; }
        public string nom_caratula { get; set; }
        public string contra { get; set; }
        public string juez_de { get; set; }
        public string instruccion { get; set; }
        public string nominacion { get; set; }
        public string secretaria { get; set; }
        public int cod_banco { get; set; }
        public int suc_banco { get; set; }
        public string tipo_cuenta { get; set; }
        public string nro_cuenta { get; set; }
        public string cbu { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public bool activo { get; set; }
        public string des_concepto_liq { get; set; }

        public EMBARGO_SUELDOS()
        {
            legajo = 0;
            cod_concepto_liq = 0;
            nro_historia = 0;
            fecha_alta_registro = DateTime.Now;
            nom_caratula = string.Empty;
            contra = string.Empty;
            juez_de = string.Empty;
            instruccion = string.Empty;
            nominacion = string.Empty;
            secretaria = string.Empty;
            cod_banco = 0;
            suc_banco = 0;
            tipo_cuenta = string.Empty;
            nro_cuenta = string.Empty;
            cbu = string.Empty;
            fecha_vencimiento = DateTime.Now;
            activo = false;
            des_concepto_liq = string.Empty;
        }

        private static List<EMBARGO_SUELDOS> mapeo(SqlDataReader dr)
        {
            List<EMBARGO_SUELDOS> lst = new List<EMBARGO_SUELDOS>();
            EMBARGO_SUELDOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new EMBARGO_SUELDOS();
                    if (!dr.IsDBNull(0)) { obj.legajo = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.cod_concepto_liq = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.nro_historia = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.fecha_alta_registro = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.nom_caratula = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.contra = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.juez_de = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.instruccion = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.nominacion = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.secretaria = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.cod_banco = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.suc_banco = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.tipo_cuenta = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.nro_cuenta = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.cbu = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.fecha_vencimiento = dr.GetDateTime(15); }
                    if (!dr.IsDBNull(16)) { obj.activo = dr.GetBoolean(16); }
                    if (!dr.IsDBNull(17)) { obj.des_concepto_liq = dr.GetString(17); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<EMBARGO_SUELDOS> read()
        {
            try
            {
                List<EMBARGO_SUELDOS> lst = new List<EMBARGO_SUELDOS>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM EMBARGO_SUELDOS";
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

        public static List<EMBARGO_SUELDOS> getByLegajo(int legajo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.des_concepto_liq FROM EMBARGO_SUELDOS A");
                sql.AppendLine("INNER JOIN CONCEPTOS_LIQUIDACION B ON A.cod_concepto_liq = B.cod_concepto_liq");
                sql.AppendLine("WHERE legajo = @legajo AND activo = 1");

                EMBARGO_SUELDOS obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<EMBARGO_SUELDOS> lst = mapeo(dr);
                    return lst;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

