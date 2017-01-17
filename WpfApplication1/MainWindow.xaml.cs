using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using hprc;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Win32;

namespace WpfApplication1
{
   /* classe de la fenetre principal de l'application d diffusion */
    public partial class MainWindow : Window
    {


        OpenFileDialog openfile;
        //Objet dataset contenant le resultat des requetes de selection
        private System.Data.DataSet oDs;
        //nom de la table dans le dataset
        private string dataTableName;
        //Objet de type Datatable afin de d'enumérer le contenue de la table récupérer
        DataTable dt;
        //Processus de type Texte
        private IPrc_Text oPcs;
        //Processus de type Erreur
        private IPrc_Error oPce;
        //Objet de la fenetre de diffusion
        Window1 diffusion;
        
       /* constructeur de la fenetre principal */
        public MainWindow()
        {  /*
            *initialisation des composants d'accés à la base de données et mise en forme de la fenetre 
            */
            diffusion = new Window1();
            diffusion.Hide();
           dt = new DataTable();
            openfile = new OpenFileDialog();
           
            this.oPcs = (IPrc_Text)PrcFactory.getProcess("texte");
            this.oPce = (IPrc_Error)PrcFactory.getProcess("error");
            this.dataTableName = "ALLTexte";
            Loaded += MyWindow_Loaded;
        
            InitializeComponent();
        }

        /* 
         * Evenement lancé au chargement de la fenetre permettant le chargement des données récupéré de la base dee donnée
         */
        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
           MyWipedText.Visibility = Visibility.Hidden;
            mainimage.Visibility = Visibility.Hidden;
            listBox.Items.Clear();
            this.oDs = this.oPcs.afficher(dataTableName);

            dt = oDs.Tables["ALLTexte"];
            foreach (DataRow dr in dt.Rows)
            {
                listBox.Items.Add(dr["Titre"].ToString());
            }
            
        }

     

        /*
         * Evenement du au changement de la selection au niveau de la liste
         */

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyWipedText.Visibility = Visibility.Visible;
            mainimage.Visibility = Visibility.Hidden;
            this.oDs = this.oPcs.afficher(dataTableName);
            dt = oDs.Tables["ALLTexte"];
            foreach (DataRow dr in dt.Rows)
            {
              if (dr["Titre"].ToString().Equals(listBox.SelectedItem.ToString()))
                {
                   

                    MyWipedText.Text = dr["Texte"].ToString();
                }
               
            }
            diffusion.ModifierTexte(this.MyWipedText.Text);
            MyWipedText.Visibility = Visibility.Visible;
            
        }
        /*
         * Evenement de diffusion, cette evenement effectue un test afin de verifier si aucune erreur n'a été notifié
         * en base de donnée par le service hologramme checker, si une erreur est trouvé, le programme n'est pas lancé, l'erreur ainsi que
         * sa solution est affiché sur un MessageBox, sinon la fenetre de diffusion est lancé avec le texte selectionné.
         */
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.oDs = this.oPce.getErrorLine("isError");
            dt = this.oDs.Tables["isError"];
            int i = 0;
            string errors = "";
            foreach (DataRow dr in dt.Rows)   {    i++;
              errors += dr["erreur"].ToString() + " : " + dr["solution"].ToString() +"\n";  }
           if( i == 0)  {

                diffusion.Show(); } else   {  MessageBox.Show(errors);  }
        }





        /*
         * Evenement lancé à la fermeture de la fenetre principal permettant la fermeture de la fenetre secondaire
         */
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            diffusion.Close();
        }

        /*
         * Erreur...
         */

        private void listBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) { }

        private void listBox_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e) { }

        private void importer_Click(object sender, RoutedEventArgs e)
        {
            MyWipedText.Visibility = Visibility.Hidden;
            openfile.ShowDialog();
           mainimage.Source = new BitmapImage(new Uri(openfile.FileName));
            diffusion.showimages(openfile.FileName);
            mainimage.Visibility = Visibility.Visible;
        }
    }
}
