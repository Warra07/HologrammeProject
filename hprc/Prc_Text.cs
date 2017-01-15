using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

namespace hprc
{
   public class Prc_Text : IPrc_Text
    {
        private System.Data.DataSet oDs;
        private Map_Text oMap;
        private hprc.Metier.IWork oCad;
        private string rq_sql;

        public Prc_Text()
        {
            this.oDs = new System.Data.DataSet();
            this.oMap = Map_Text.getInstance();
            this.oCad = hprc.Metier.Work.getInstance(); 
            this.rq_sql = "NC";
        }

        public System.Data.DataSet afficher(string dataTableName)
        {
            this.oDs.Clear();

            this.rq_sql = this.oMap.selectAll();
            this.oDs = this.oCad.getRows(this.rq_sql, dataTableName);

            return this.oDs;
        }

        public System.Data.DataSet RechercherTitre(string dataTableName, string titre)
        {
            this.oDs.Clear();
            this.oMap.setTitre(titre);

            this.rq_sql = this.oMap.selectByTitle(titre);
            this.oDs = this.oCad.getRows(this.rq_sql, dataTableName);
           
         
            return this.oDs;
        }

        public void deleteById(int id)
        {
            this.oMap.setID(id);
            this.rq_sql = this.oMap.deleteById();
            this.oCad.actionRows(this.rq_sql);
        }

        public void insert(string titre, string texte)
        {
            this.oDs.Clear();
            this.oMap.setTitre(titre);
            this.oMap.setTexte(texte);
           
            this.rq_sql = this.oMap.insert();


            this.oCad.actionRows(this.rq_sql);
        }
        public void update(int id, string titre, string texte)
        {
            this.oDs.Clear();
            this.oMap.setID(id);
            this.oMap.setTitre(titre);
            this.oMap.setTexte(texte);
            this.rq_sql = this.oMap.update();
            this.oCad.actionRows(this.rq_sql);
        }
    }
}
