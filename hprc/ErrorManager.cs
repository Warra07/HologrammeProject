using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
  public  class ErrorManager : IPrc_Error
    {
        private System.Data.DataSet oDs;
        private Map_Error oMap;
        private hprc.Metier.IWork oCad;
        private string rq_sql;
        IPrc_Error prc;

        public ErrorManager(IPrc_Error prc)
        {
            this.prc = prc;
            this.oDs = new System.Data.DataSet();
            this.oMap = Map_Error.getInstance();
            this.oCad = hprc.Metier.Work.getInstance();
            this.rq_sql = "NC";
        }
        public DataSet afficherError(string dataTableName)
        {
         return   prc.afficherError(dataTableName);
        }

        public DataSet afficherErrorType(string dataTableName)
        {
            return prc.afficherErrorType(dataTableName);
        }

        public void deleteErrorById(int id)
        {
            prc.deleteErrorById(id);
        }

        public void errorInsert(int code, string erreur, string solution, int idtype)
        {
            prc.errorInsert(code, erreur, solution, idtype);
        }

        public void errorTypeInsert(string type)
        {
            prc.errorTypeInsert(type);
        }

 

        public void errorUpdate(int id, int code, string erreur, string solution, int idtype)
        {
            prc.errorUpdate(id,code,erreur,solution,idtype);
        }

        public DataSet RechercherCode(string dataTableName, int code)
        {
            return prc.RechercherCode(dataTableName, code);
        }

        public void errorReset()
        {

            this.rq_sql = this.oMap.errorReset();
            this.oCad.actionRows(this.rq_sql);
        }

      public  void errorTrue(int code){
            this.rq_sql = this.oMap.setIserrorByCode(code);
            this.oCad.actionRows(this.rq_sql);

        }
            
    }
}
