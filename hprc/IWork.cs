using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace hprc
{
    namespace Metier
    {
        /* COUCHE Acces aux données
         * Interface de la couche Acces aux données possédant les methodes nécéssaire à toutes classe de la couche metier
         * voulant composer des processus de la couche Processus
         */
        interface IWork
        {

            //Methode recevant les requetes d'action ( DELETE, INSERT, UPDATE) à envoyer à la base de donnée.
            void actionRows(string rq_sql);

            // Methode recevant les requetes de selection ( Select ), renvoie un dataset contenant les données de la base donnée
         DataSet getRows(string rq_sql, string dataTableName);

        }
    }
}