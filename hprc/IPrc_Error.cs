using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    public interface IPrc_Error
    {
        System.Data.DataSet afficherError(string dataTableName);
        System.Data.DataSet RechercherCode(string dataTableName, int code);
        System.Data.DataSet afficherErrorType(string dataTableName);

        void errorTypeInsert(string type);

        void deleteErrorById(int id);
        void errorInsert(int code, string erreur, string solution, int idtype);
        void errorUpdate(int id, int code, string erreur, string solution, int idtype);
       
    }
}
