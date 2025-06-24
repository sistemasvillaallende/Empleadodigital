using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LEGAJO : DALBase
    {
        public int LEG_LEGAJO { get; set; }
        public int LEG_TARJETA { get; set; }
        public int LEG_COPIA { get; set; }
        public string LEG_APYNOM { get; set; }
        public int LEG_DOCUM { get; set; }
        public string LEG_CUIL { get; set; }
        public DateTime LEG_ULTPROC { get; set; }
        public string LEG_ACTIVO { get; set; }
        public string LEG_ALTER { get; set; }
        public DateTime LEG_FECHING { get; set; }
        public DateTime LEG_FECHEGR { get; set; }
        public string LEG_INHABIL { get; set; }
        public string LEG_HABTODOS { get; set; }
        public string LEG_DIRECCION { get; set; }
        public string LEG_LOCALIDAD { get; set; }
        public string LEG_TELEFONO { get; set; }
        public string LEG_ART { get; set; }
        public string LEG_OBSERV { get; set; }
        public string LEG_SEXO { get; set; }
        public string LEG_FOTO { get; set; }
        public int CAT_CODIGO { get; set; }
        public int TUR_CODIGO { get; set; }
        public int SEC_CODIGO { get; set; }
        public int EMP_CODIGO { get; set; }
        public int GRP_CODIGO { get; set; }
        public int GE1_CODIGO { get; set; }
        public int GE2_CODIGO { get; set; }
        public int GE3_CODIGO { get; set; }
        public int BAN_CODIGO { get; set; }
        public int REM_CODIGO { get; set; }
        public string LEG_GRABAR { get; set; }
        public string LEG_IMPRIMIR { get; set; }
        public string LEG_CTRLNOV { get; set; }

        public LEGAJO()
        {
            LEG_LEGAJO = 0;
            LEG_TARJETA = 0;
            LEG_COPIA = 0;
            LEG_APYNOM = string.Empty;
            LEG_DOCUM = 0;
            LEG_CUIL = string.Empty;
            LEG_ULTPROC = DateTime.Now;
            LEG_ACTIVO = string.Empty;
            LEG_ALTER = string.Empty;
            LEG_FECHING = DateTime.Now;
            LEG_FECHEGR = DateTime.Now;
            LEG_INHABIL = string.Empty;
            LEG_HABTODOS = string.Empty;
            LEG_DIRECCION = string.Empty;
            LEG_LOCALIDAD = string.Empty;
            LEG_TELEFONO = string.Empty;
            LEG_ART = string.Empty;
            LEG_OBSERV = string.Empty;
            LEG_SEXO = string.Empty;
            LEG_FOTO = string.Empty;
            CAT_CODIGO = 0;
            TUR_CODIGO = 0;
            SEC_CODIGO = 0;
            EMP_CODIGO = 0;
            GRP_CODIGO = 0;
            GE1_CODIGO = 0;
            GE2_CODIGO = 0;
            GE3_CODIGO = 0;
            BAN_CODIGO = 0;
            REM_CODIGO = 0;
            LEG_GRABAR = string.Empty;
            LEG_IMPRIMIR = string.Empty;
            LEG_CTRLNOV = string.Empty;
        }

        private static List<LEGAJO> mapeo(SqlDataReader dr)
        {
            List<LEGAJO> lst = new List<LEGAJO>();
            LEGAJO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LEGAJO();
                    if (!dr.IsDBNull(0)) { obj.LEG_LEGAJO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.LEG_TARJETA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.LEG_COPIA = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.LEG_APYNOM = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.LEG_DOCUM = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.LEG_CUIL = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.LEG_ULTPROC = dr.GetDateTime(6); }
                    if (!dr.IsDBNull(7)) { obj.LEG_ACTIVO = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.LEG_ALTER = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.LEG_FECHING = dr.GetDateTime(9); }
                    if (!dr.IsDBNull(10)) { obj.LEG_FECHEGR = dr.GetDateTime(10); }
                    if (!dr.IsDBNull(11)) { obj.LEG_INHABIL = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.LEG_HABTODOS = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.LEG_DIRECCION = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.LEG_LOCALIDAD = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.LEG_TELEFONO = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.LEG_ART = dr.GetString(16); }
                    if (!dr.IsDBNull(17)) { obj.LEG_OBSERV = dr.GetString(17); }
                    if (!dr.IsDBNull(18)) { obj.LEG_SEXO = dr.GetString(18); }
                    if (!dr.IsDBNull(19)) { obj.LEG_FOTO = dr.GetString(19); }
                    if (!dr.IsDBNull(20)) { obj.CAT_CODIGO = dr.GetInt32(20); }
                    if (!dr.IsDBNull(21)) { obj.TUR_CODIGO = dr.GetInt32(21); }
                    if (!dr.IsDBNull(22)) { obj.SEC_CODIGO = dr.GetInt32(22); }
                    if (!dr.IsDBNull(23)) { obj.EMP_CODIGO = dr.GetInt32(23); }
                    if (!dr.IsDBNull(24)) { obj.GRP_CODIGO = dr.GetInt32(24); }
                    if (!dr.IsDBNull(25)) { obj.GE1_CODIGO = dr.GetInt32(25); }
                    if (!dr.IsDBNull(26)) { obj.GE2_CODIGO = dr.GetInt32(26); }
                    if (!dr.IsDBNull(27)) { obj.GE3_CODIGO = dr.GetInt32(27); }
                    if (!dr.IsDBNull(28)) { obj.BAN_CODIGO = dr.GetInt32(28); }
                    if (!dr.IsDBNull(29)) { obj.REM_CODIGO = dr.GetInt32(29); }
                    if (!dr.IsDBNull(30)) { obj.LEG_GRABAR = dr.GetString(30); }
                    if (!dr.IsDBNull(31)) { obj.LEG_IMPRIMIR = dr.GetString(31); }
                    if (!dr.IsDBNull(32)) { obj.LEG_CTRLNOV = dr.GetString(32); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LEGAJO> read()
        {
            try
            {
                List<LEGAJO> lst = new List<LEGAJO>();
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LEGAJO";
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

        public static LEGAJO getByPk(
        int LEG_LEGAJO)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LEGAJO WHERE");
                sql.AppendLine("LEG_LEGAJO = @LEG_LEGAJO");
                LEGAJO obj = null;
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@LEG_LEGAJO", LEG_LEGAJO);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LEGAJO> lst = mapeo(dr);
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



    }
}

