using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class SQLServerHelper
    {
        string DBCon;
        public SQLServerHelper()
        {
            this.DBCon = ConfigurationManager.AppSettings["DBCon"];
        }
        public SQLServerHelper(string strCon)
        {
            this.DBCon = strCon;
        }
        public int ExecuteNonQuery(string SQL,params SqlParameter[] arrParam)
        {
            int iCount = 0;
            using (SqlConnection sqlcon=new SqlConnection(DBCon))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(SQL, sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(arrParam);
                iCount = cmd.ExecuteNonQuery();
            }
            return iCount;
        }
    }
}
