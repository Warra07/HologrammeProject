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
        private IPrc_Text oPcs;
        private IPrc_Error oPce;
        private System.Data.DataSet oDs;
        private string dataTableName;
        private BindingSource oBs;
        private BindingSource oBe;
        private BindingSource oBt;
        int a = 0;

        public Form1()
        {
            
            InitializeComponent();
        }


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


        private void button5_Click(object sender, EventArgs e)
        {

            this.charger();
        }

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


        public void charger()
        {
            this.oDs.Tables.Clear();
            this.dataTableName = "ALL";
            this.oPcs = (IPrc_Text)PrcFactory.getProcess("texte");
            this.oDs = this.oPcs.afficher(this.dataTableName);
            oBs.DataSource = this.oDs.Tables["ALL"];
        }
        public void chargerError()
        {
            this.oDs.Tables.Clear();
            this.dataTableName = "ALLError";
            this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
            this.oDs = this.oPce.afficherError(dataTableName);
            oBe.DataSource = this.oDs.Tables["ALLError"];
        }
        public void chargerType()
        {
            this.oDs.Clear();
            this.dataTableName = "ALLType";
            this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
            this.oDs = this.oPce.afficherErrorType(dataTableName);
            oBt.DataSource = this.oDs.Tables["ALLType"];
        }

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

        private void button12_Click(object sender, EventArgs e)
        {
            this.chargerType();
        }

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

        private void button8_Click(object sender, EventArgs e)
        {
            this.chargerError();
        }

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
