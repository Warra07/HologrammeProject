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
        interface IWork
        {
            void actionRows(string rq_sql);
         DataSet getRows(string rq_sql, string dataTableName);

        }
    }
}