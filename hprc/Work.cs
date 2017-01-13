using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    namespace Metier
    {
        class Work : IWork
        {
            private static IWork work = new Work();
            private string cnx;
            private string rq_sql;
            private System.Data.SqlClient.SqlConnection oCnx;
            private System.Data.SqlClient.SqlDataAdapter oDA;
            private System.Data.SqlClient.SqlCommand oCmd;
            private System.Data.DataSet oDs;

            private Work()
            {
                this.cnx = @"Data Source=WARRA07;Initial Catalog=holoProject;Integrated Security=True";

                this.rq_sql = "NC";
                this.oCnx = new System.Data.SqlClient.SqlConnection(this.cnx);
                this.oDA = new System.Data.SqlClient.SqlDataAdapter();
                this.oCmd = new System.Data.SqlClient.SqlCommand();
                this.oDs = new System.Data.DataSet();

                this.oCmd.CommandType = System.Data.CommandType.Text;
                this.oCmd.Connection = this.oCnx;
            }
            public void actionRows(string rq_sql)
            {
                this.oCnx.Open();
                this.rq_sql = rq_sql;
                this.oCmd.CommandText = this.rq_sql;
                this.oCmd.ExecuteNonQuery();
                this.oCnx.Close();
            }
            public System.Data.DataSet getRows(string rq_sql, string dataTableName)
            {
                this.oDs.Clear();

                this.rq_sql = rq_sql;
                this.oCmd.CommandText = this.rq_sql;
                this.oDA.SelectCommand = this.oCmd;
                this.oDA.Fill(this.oDs, dataTableName);

                return this.oDs;
            }
            public static IWork getInstance()
            {
                return work;
            }
        }
    }
}
