using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    class Map_Error
    {
        private static Map_Error maperror = new Map_Error();
        private string rq_sql;
        private int id;
        private int code;
        private string error;
        private string solution;
        private string type;
        private int idtype;
        private int iserror;

        private Map_Error() { }
        public string selectAllError()
        {
            this.rq_sql =
                          "SELECT [id]" +
                          ",[code]" +
                          ",[erreur] " +
                          ",[solution] " +
                          ",[Type] " +
                          ",[iserror] " +
                          "FROM [Erreur], [Type]";
            return this.rq_sql;
        }

        public string selectAllErrorType()
        {
            this.rq_sql =
                        "SELECT [IdType]" +
                        ",[Type]" +
                        "FROM [Type]";
            return this.rq_sql;
        }

        public string selectByCode()
        {
            this.rq_sql = "SELECT id, code, erreur, solution, Type, iserror FROM Erreur, Type WHERE (code = '" + this.code + "')";
            return this.rq_sql;
        }



        public string deleteById()
        {
            this.rq_sql = "DELETE FROM Erreur WHERE (id = " + this.id + ")";
            return this.rq_sql;
        }

        public string errorInsert()
        {
            this.rq_sql = "INSERT INTO Erreur (code, erreur, solution, iserror, IdType) VALUES ('" + this.code + "', '" + this.error + "', '" + this.solution + "', '" + 0 + "', '" + this.idtype + "');";
            return this.rq_sql;
        }
        public string errorTypeInsert()
        {
            this.rq_sql = "INSERT INTO Type ( Type) VALUES ('" + this.type + "');";
            return this.rq_sql;
        }

        public string errorUpdate()
        {
            this.rq_sql = "UPDATE Erreur SET code = '" + this.code + "', erreur = '" + this.error + "' , solution = '" + this.solution + "', IdType = '" + this.idtype + "' WHERE ( id = " + this.id + ");";
            return this.rq_sql;
        }

        public string errorReset()
        {
            this.rq_sql = "UPDATE Erreur SET iserror = '" + 0  + "';";
            return this.rq_sql;
        }
        public string setIserrorByCode(int code)
        {
            this.rq_sql = "UPDATE Erreur SET iserror = '"  + 1 + "' WHERE code = '" + code +"';";
            return this.rq_sql;
        }
        public static Map_Error getInstance()
        {
            return maperror;
        }

        public void setID(int id) { this.id = id; }
        public void setCode(int code) { this.code = code; }
        public void setError(string erreur) { this.error = erreur; }
        public void setSolution(string solution) { this.solution = solution;}
        public void setIsError( int iserror) { this.iserror = iserror; }
        public void setIdtype( int idtype) { this.idtype = idtype; }
        public void setType (string type) { this.type = type; }
    }
}
