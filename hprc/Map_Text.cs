﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hprc
{
    class Map_Text
    {
        private static Map_Text maptext = new Map_Text();
        private string rq_sql;
        private int id;
        private string titre;
        private string texte;
        private Map_Text() { }
        public string selectAll()
        {
            this.rq_sql =
                          "SELECT [id]" +
                          ",[titre]" +
                          ",[texte] " +
                          "FROM [Texte]";
            return this.rq_sql;
        }

        public string selectByTitle()
        {
            this.rq_sql = "SELECT id, titre, texte FROM Texte WHERE (titre = '" + this.titre + "')";
            return this.rq_sql;
        }

        public string deleteById()
        {
            this.rq_sql = "DELETE FROM Texte WHERE (id = " + this.id + ")";
            return this.rq_sql;
        }

        public string insert()
        {
            this.rq_sql = "INSERT INTO Texte (titre, texte) VALUES ('" + this.titre + "', '" + this.texte + "');";
            return this.rq_sql;
        }

        public string update()
        {
            this.rq_sql = "UPDATE Texte SET titre = '" + this.titre + "', texte = '" + this.texte + "' WHERE id = " + this.id + ";";
            return this.rq_sql;
        }
        public static Map_Text getInstance()
        {
            return maptext;
        }

        public void setID(int id) { this.id = id; }
        public void setTitre(string titre) { this.titre = titre; }
        public void setTexte(string texte) { this.texte = texte; }
    }
}