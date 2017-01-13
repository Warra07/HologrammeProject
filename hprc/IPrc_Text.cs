using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    public interface IPrc_Text
    {
        System.Data.DataSet afficher(string dataTableName);
      System.Data.DataSet RechercherTitre(string dataTableName, string titre);
        void deleteById(int id);
        void insert(string titre, string texte);
        void update(int id, string titre, string texte);
    }
}
