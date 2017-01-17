using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    public interface IPrc_Error
    {

        /*
         * Methode renvoyant l'ensemble des données de la table Erreur
         */
        System.Data.DataSet afficherError(string dataTableName);


        /*
         * Methode de recherche des lignes de la table Erreur selon le code d'erreur
         */
        System.Data.DataSet RechercherCode(string dataTableName, int code);

        /*
         * Methode renvoyant l'ensemble des données d la table Type d'erreur
         */
        System.Data.DataSet afficherErrorType(string dataTableName);

        /*
         * Methode de recuperation des erreurs notifié en base de donnée
         */
        System.Data.DataSet getErrorLine(string dataTableName);

        /* 
         * Methode d'ajout d'une ligne sur la table Type d'erreur
         */
        void errorTypeInsert(string type);
        /*
         * Methode de supppresion d'une erreur de la table erreur selon l'id
         */
        void deleteErrorById(int id);

        /*
         * Methode d'insertion d'une ligne sur la table Erreur
         */
        void errorInsert(int code, string erreur, string solution, int idtype);

        /*
         * M'ethode d'update d'une ligne de la table erreur selon l'id
         */
        void errorUpdate(int id, int code, string erreur, string solution, int idtype);
        
       
    }
}
