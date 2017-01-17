using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hprc;
using System.Diagnostics;

namespace HoloManager
{
    public partial class Form1 : Form
    {   
        //Processus Texte
        private IPrc_Text oPcs;
        //Processus Error
        private IPrc_Error oPce;
        //DataSet qui contient la reponse aux requetes de selection
        private System.Data.DataSet oDs;
        //nom de la table qui sera stocké au niveu du DataSet
        private string dataTableName;
        //Classe de binding de l'onglet Texte
        private BindingSource oBs;
        //Classe de binding de l'onglet Erreur
        private BindingSource oBe;
        //Classe de binding de l'onglet type
        private BindingSource oBt;
        int a = 0;

        public Form1()  {InitializeComponent();}


        /* Initialisation des classe d'accés à la base de données, ainsi que la liaison des composants de type grilles
         * au differentes classes de binding sur lequels les traitement seront effectué
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            this.oPcs = (IPrc_Text)PrcFactory.getProcess("texte");
            this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
            this.oDs = new DataSet();
            this.oBs = new BindingSource();
            this.oBe = new BindingSource();
            this.oBt = new BindingSource();
            this.dtg_gestion.DataSource = oBs;
            this.dtg_error.DataSource = oBe;
            this.dtg_type.DataSource = oBt;
            dtg_error.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_gestion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_type.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        /*
         * Event bouton de chargement du tableau Texte
         */
        private void button5_Click(object sender, EventArgs e)
        {
            this.charger();
        }

        /*
        * Methode de chargement du tableau Texte, récupére les données à partir de la base de donnée
        */
        public void charger()
        {
            this.oDs.Tables.Clear();
            this.dataTableName = "ALL";
            this.oPcs = (IPrc_Text)PrcFactory.getProcess("texte");
            this.oDs = this.oPcs.afficher(this.dataTableName);
            oBs.DataSource = this.oDs.Tables["ALL"];
        }

        /*
         * Bouton de suppression d'une ligne du tableau texte
         */
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.deleteIdBox.Text != "")
            {
                this.oDs.Tables.Clear();
              this.oPcs = (IPrc_Text)PrcFactory.getProcess("texte");
               this.oPcs.deleteById(Convert.ToInt32(this.deleteIdBox.Text));
                this.charger();
            }
        }


        /*
         * bouton d'ajout d'une ligne du tableau Texte
         */
           private void button2_Click(object sender, EventArgs e)
        {
               if(texteBox.Text != "" && titleBox.Text != "")
            {
                this.oPcs.insert(titleBox.Text, texteBox.Text);
                this.charger();
                this.idBox.Clear();
                this.texteBox.Clear();
                this.titleBox.Clear();
            }
        }


        /*
         * bouton d'update d'une ligne du tableau texte
         */
        private void button1_Click(object sender, EventArgs e)
        {
            if (idBox.Text != "" && texteBox.Text != "" && titleBox.Text != "")
            {
                this.oPcs.update(Convert.ToInt32(idBox.Text), titleBox.Text, texteBox.Text);
                this.charger();
                this.idBox.Clear();
                this.texteBox.Clear();
                this.titleBox.Clear();
            }
        }


        /*
         * bouton de recherche d'une ligne du tableau Texte selon le titre
         */
        private void button4_Click(object sender, EventArgs e)
        {
            if (searchTitleBox.Text != "")
            {
                this.oDs.Tables.Clear();

                this.dataTableName = "byTitle";
                this.oPcs = (IPrc_Text)PrcFactory.getProcess("texte");
                this.oDs = this.oPcs.RechercherTitre(this.dataTableName, this.searchTitleBox.Text);
                oBs.DataSource = this.oDs.Tables["byTitle"];

                this.searchTitleBox.Clear();
            }
        }



        /*
         * Methode de chargement du tableau Erreur, récupére les données à partir de la base de donnée
         */
        public void chargerError()
        {
            this.oDs.Tables.Clear();
            this.dataTableName = "ALLError";
            this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
            this.oDs = this.oPce.afficherError(dataTableName);
            oBe.DataSource = this.oDs.Tables["ALLError"];
        }


        /*
         * Methode de chargement du tableau Type, récupére les données à partir de la base de donnée
         */
        public void chargerType()
        {
            this.oDs.Clear();
            this.dataTableName = "ALLType";
            this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
            this.oDs = this.oPce.afficherErrorType(dataTableName);
            oBt.DataSource = this.oDs.Tables["ALLType"];
        }



        /*
         * Methode d'ajout d'un type d'erreur ( bouton d'ajout )
         */
        private void button11_Click(object sender, EventArgs e)
        {
            if ( typeBox.Text != "")
            {
                this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
                this.oPce.errorTypeInsert(typeBox.Text);
                this.chargerType();
                this.typeBox.Clear();
               
            }
        }



        /*
         * bouton de chargement du tableau Type
         */
        private void button12_Click(object sender, EventArgs e)
        {
            this.chargerType();
        }



        /*
         * bouton update du tableau d'erreur
         */
        private void button7_Click(object sender, EventArgs e)
        {
            if (iderrorBox.Text != "" &&  errorBox.Text != "" && solutionBox.Text != "" && codeBox.Text != "" && idtBox.Text != "")
            {
                this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
                this.oPce.errorUpdate(Convert.ToInt32(iderrorBox.Text), Convert.ToInt32(codeBox.Text), errorBox.Text, solutionBox.Text, Convert.ToInt32(idtBox.Text));
                Debug.Write("djdjd");
                this.chargerError();
                this.iderrorBox.Clear();
                this.codeBox.Clear();
                this.errorBox.Clear();
                this.solutionBox.Clear();
                this.idtBox.Clear();
            }
        }


        /*
         * bouton d'insertion du tableau erreur
         */
        private void button6_Click(object sender, EventArgs e)
        {
            if ( errorBox.Text != "" && solutionBox.Text != "" && codeBox.Text != "" && idtBox.Text != "")
            {
                this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
                this.oPce.errorInsert(Convert.ToInt32(codeBox.Text), errorBox.Text, solutionBox.Text, Convert.ToInt32(idtBox.Text));

                this.chargerError();
                this.iderrorBox.Clear();
                this.codeBox.Clear();
                this.errorBox.Clear();
                this.solutionBox.Clear();
                this.idtBox.Clear();
            }
        }


        /*
         * bouton de recherche du tableau d'erreur selon le code d'erreur
         */
        private void button9_Click(object sender, EventArgs e)
        {
            if (searchcodeBox.Text != "")
            {
                this.oDs.Tables.Clear();

                this.dataTableName = "byCode";
                this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
                this.oDs = this.oPce.RechercherCode(this.dataTableName, Convert.ToInt32(this.searchcodeBox.Text));
                oBe.DataSource = this.oDs.Tables["byCode"];

                this.searchcodeBox.Clear();
            }
        }



        /*
         * bouton de chargement du tableau erreur
         */
        private void button8_Click(object sender, EventArgs e)
        {
            this.chargerError();
        }


        /*
         * bouton de suppression d'une ligne du tableau d'erreur
         */


        private void button10_Click(object sender, EventArgs e)
        {
            if (this.delerrorBox.Text != "")
            {
                this.oDs.Tables.Clear();
                this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
                this.oPce.deleteErrorById(Convert.ToInt32(delerrorBox.Text));
                this.chargerError();
            }
        }


        private void searchTitleBox_TextChanged(object sender, EventArgs e) {}
        private void label6_Click(object sender, EventArgs e){}
        private void label11_Click(object sender, EventArgs e){}
        private void delerrorBox_TextChanged(object sender, EventArgs e) {}

    }
}
