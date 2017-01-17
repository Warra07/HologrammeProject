using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    /* COUCHE PROCESSUS
    * Classe du processus Erreur, Processus contenant des methodes de gestion des
    * tableaux Erreur et Type, se référer à l'interface pour la description des methodes
    */
    class Prc_Error : IPrc_Error
    {
        private System.Data.DataSet oDs;
        private Map_Error oMap;
        private hprc.Metier.IWork oCad;
        private string rq_sql;

        public Prc_Error()
        {
            this.oDs = new System.Data.DataSet();
            this.oMap = Map_Error.getInstance();
            this.oCad = hprc.Metier.Work.getInstance();
            this.rq_sql = "NC";
        }

        public DataSet afficherError(string dataTableName)
        {
            this.oDs.Clear();

            this.rq_sql = this.oMap.selectAllError();
            this.oDs = this.oCad.getRows(this.rq_sql, dataTableName);

            return this.oDs;
        }

        public DataSet afficherErrorType(string dataTableName)
        {
            this.oDs.Clear();

            this.rq_sql = this.oMap.selectAllErrorType();
            this.oDs = this.oCad.getRows(this.rq_sql, dataTableName);

            return this.oDs;
        }

        public void deleteErrorById(int id)
        {
            this.oMap.setID(id);
            this.rq_sql = this.oMap.deleteById();
            this.oCad.actionRows(this.rq_sql);
        }

        public void errorInsert(int code, string erreur, string solution, int idtype)
        {
            this.oDs.Clear();
            this.oMap.setCode(code);
            this.oMap.setError(erreur);
            this.oMap.setSolution(solution);
            this.oMap.setIdtype(idtype);

            this.rq_sql = this.oMap.errorInsert();


            this.oCad.actionRows(this.rq_sql);
        }

        public void errorTypeInsert(string type)
        {
            this.oMap.setType(type);
            this.rq_sql = this.oMap.errorTypeInsert();
            this.oCad.actionRows(this.rq_sql);

        }

        public void errorUpdate(int id, int code, string erreur, string solution, int idtype)
        {
            this.oDs.Clear();
            this.oMap.setID(id);
            this.oMap.setCode(code);
            this.oMap.setError(erreur);
            this.oMap.setSolution(solution);
            this.oMap.setIdtype(idtype);



            this.rq_sql = this.oMap.errorUpdate();

            Debug.Write(this.rq_sql);

            this.oCad.actionRows(this.rq_sql);
        }

        public DataSet RechercherCode(string dataTableName, int code)
        {
            this.oDs.Clear();

            this.oMap.setCode(code);
            this.rq_sql = this.oMap.selectByCode();
            this.oDs = this.oCad.getRows(this.rq_sql, dataTableName);
            return this.oDs;
        }

        public DataSet getErrorLine(string dataTableName)
        {
            this.oDs.Clear();

            this.rq_sql = this.oMap.getErrorLine();
            this.oDs = this.oCad.getRows(rq_sql, dataTableName);

            return this.oDs;
        }


    }
}
