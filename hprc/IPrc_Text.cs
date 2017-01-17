using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    public interface IPrc_Text
    {

        /*
         * Methode renvoyant l'ensemble des données de la table Texte
         */
        System.Data.DataSet afficher(string dataTableName);

        /*
         * Methode renvoyant les lignes de la table Texte possédant le titre envoyé en parametre
         */
      System.Data.DataSet RechercherTitre(string dataTableName, string titre);

        /*
         * Methode supprimant une ligne de la table Texte selon l'id renvoyer en parametre
         */
        void deleteById(int id);

        /*
         * Methode d'insertion de ligne à la table texte
         */
        void insert(string titre, string texte);


        /*
         * Methode d'update d'une ligne de la table texte selon le parametre id
         */
        void update(int id, string titre, string texte);
    }
}
