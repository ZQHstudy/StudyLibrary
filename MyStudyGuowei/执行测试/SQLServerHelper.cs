using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SQLServerHelper
    {
        private static string ConnetionString = "";
        
        public static void InitConnectionString(string sConnStr)
        {
            ConnetionString = sConnStr;
        }

        private static void InitConnectionString()
        {
            if (string.IsNullOrEmpty(ConnetionString))
            {
                string sConnStr = ConfigurationManager.ConnectionStrings["DBConn"].ToString();
                ConnetionString = sConnStr;
            }
        }
        
        public static int ExecNonQuerySQL(string sSQL, params SqlParameter[] arrParam)
        {
            int iResult = -1;
            try
            {
                InitConnectionString();
                using (SqlConnection conn = new SqlConnection(ConnetionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(arrParam);
                    iResult = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            return iResult;
        }
        
        public static DataTable ExecQuerySQL(string sSQL, params SqlParameter[] arrParam)
        {
            DataTable dtResult = null;
            try
            {
                InitConnectionString();
                using (SqlConnection conn = new SqlConnection(ConnetionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(arrParam);
                    dtResult = new DataTable();
                    SqlDataAdapter dta = new SqlDataAdapter(cmd);
                    dta.Fill(dtResult);
                }
            }
            catch (Exception ex)
            {
            }
            return dtResult;
        }
        
        public static int ExecNonQueryTrn(string sSQL, params SqlParameter[] arrParam)
        {
            int iResult = -1;
            SqlTransaction trn = null;
            try
            {
                InitConnectionString();
                using (SqlConnection conn = new SqlConnection(ConnetionString))
                {
                    conn.Open();
                    trn = conn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand(sSQL, conn, trn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(arrParam);
                    iResult = cmd.ExecuteNonQuery();
                    trn.Commit();
                }
            }
            catch (Exception ex)
            {
                trn.Rollback();
            }
            return iResult;
        }
        
        public static int MultiExec(List<string> listSQL, bool bTrn, params SqlParameter[] arrParam)
        {
            int iResult = -1;
            if (listSQL == null || listSQL.Count < 1)
            {
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("begin ");
                for (int i = 0; i < listSQL.Count; i++)
                {
                    sb.Append(listSQL[i]);
                    sb.Append(";");
                }
                sb.Append(" end");

                if (bTrn)
                {
                    iResult = ExecNonQueryTrn(sb.ToString(), arrParam);
                }
                else
                {
                    iResult = ExecNonQuerySQL(sb.ToString(), arrParam);
                }
            }
            return iResult;
        }
    }
}
