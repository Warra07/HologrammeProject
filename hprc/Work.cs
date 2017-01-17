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

        /*  COUCHE Acces aux données
         * Classe de connexion et d'envoie de quéte à la base de donnée
         * Cette Classe utilise un design Pattern singleton afin d'eviter de créer des objets inutile
         * l'instantiation se fait grace à la methode getInstance()
         * se référer à l'interface implementant les methodes de la couche metier afin d'etudier leurs fonctionnement
         */
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
                this.cnx = @"Data Source =(LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\wacim\documents\visual studio 2015\Projects\hprc\hprc\holoProject.mdf; Integrated Security = True";

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

            /* Methode retournant un singleton de la classe Work */
            public static IWork getInstance()
            {
                return work;
            }
        }
    }
}
