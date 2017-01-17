using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    /* COUCHE PROCSSUS
     * Classe decorator permettant d'ajouter deux fonctionnalité à notre processur de gestion
     * des erreurs qui sont la notification des erreurs en base donnée ainsi que la reinitialisation
     * des erreurs, ces methodes ne sont utile qu'aux services de verification de performance
     */
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

        /* METHODE SIMILAIRE AU PROCESSUS ERREUR */


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
        public DataSet getErrorLine(string dataTableName)
        {
            return prc.getErrorLine(dataTableName);
        }

        /* FIN DES METHODES SIMILAIRE AU PROCESSUS ERREUR */


            
           /* Methode permettant de reinitialisation la notification des erreurs avant d'effectuer
             * une nouvelle verification
             */
        public void errorReset()
        {

            this.rq_sql = this.oMap.errorReset();
            this.oCad.actionRows(this.rq_sql);
        }

        /* 
         * Methode permettant de notifier qu'une erreur à été detecté en initialisant la colonne iserror à 1
         * pour l'erreur possédant le code d'erreur fourni en parametre
         */
      public  void errorTrue(int code){
            this.rq_sql = this.oMap.setIserrorByCode(code);
            this.oCad.actionRows(this.rq_sql);

        }

        
    }
}
