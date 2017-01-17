using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    

    /* simple classe de la fenetre de diffusion disposant de 4 TextBlock pour afficher le texte t d'une methode d modification */
    public partial class Window1 : Window
    {

        BitmapImage image2;
        Uri uri;

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public Window1()
        {
          image2 = new BitmapImage(new Uri("C:/Users/wacim/Desktop/save/DSC_4497-1.jpg"));
            
          
            InitializeComponent();

        }

        
        /*
         * Methode de modification des texteblock selon le parametre envoyé
         */
        public void ModifierTexte(string texte)
        {
  
            this.mediaElement.Source = new Uri("C:/users/wacim/Desktop/save/source.gif");
            this.image.Visibility = Visibility.Hidden;
            this.image_Copy.Visibility = Visibility.Hidden;
            this.image_Copy1.Visibility = Visibility.Hidden;
            this.image_Copy2.Visibility = Visibility.Hidden;

            this.mediaElement.Visibility = Visibility.Hidden;
            this.mediaElement_Copy.Visibility = Visibility.Hidden;
            this.mediaElement_Copy1.Visibility = Visibility.Hidden;
            this.mediaElement_Copy2.Visibility = Visibility.Hidden;

            textBlock.Visibility = Visibility.Visible;
            textBlock1.Visibility = Visibility.Visible;
            textBlock2.Visibility = Visibility.Visible;
            textBlock3.Visibility = Visibility.Visible;

            textBlock.Text = texte;
            textBlock1.Text = texte;
            textBlock2.Text = texte;
            textBlock3.Text = texte;  }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        var hwnd = new WindowInteropHelper(this).Handle;
         SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        internal void showimages(string fileName)
        {
      

            textBlock.Visibility = Visibility.Hidden;
            textBlock1.Visibility = Visibility.Hidden;
            textBlock2.Visibility = Visibility.Hidden;
            textBlock3.Visibility = Visibility.Hidden;

            if (System.IO.Path.GetExtension(fileName) == ".gif")
            {
                uri = new Uri(fileName);
                this.mediaElement.Visibility = Visibility.Visible;
                this.mediaElement_Copy.Visibility = Visibility.Visible;
                this.mediaElement_Copy1.Visibility = Visibility.Visible;
                this.mediaElement_Copy2.Visibility = Visibility.Visible;

                this.image.Visibility = Visibility.Hidden;
                this.image_Copy.Visibility = Visibility.Hidden;
                this.image_Copy1.Visibility = Visibility.Hidden;
                this.image_Copy2.Visibility = Visibility.Hidden;


                this.mediaElement.Source = uri;
               this.mediaElement_Copy.Source = uri;
                this.mediaElement_Copy1.Source = uri;
                this.mediaElement_Copy2.Source = uri;
            }
            else
            {
                this.mediaElement.Visibility = Visibility.Hidden;
                this.mediaElement_Copy.Visibility = Visibility.Hidden;
                this.mediaElement_Copy1.Visibility = Visibility.Hidden;
                this.mediaElement_Copy2.Visibility = Visibility.Hidden;

                this.image.Visibility = Visibility.Visible;
                this.image_Copy.Visibility = Visibility.Visible;
                this.image_Copy1.Visibility = Visibility.Visible;
                this.image_Copy2.Visibility = Visibility.Visible;

                image2 = new BitmapImage(new Uri(fileName));
                this.image.Source = image2;
                this.image_Copy.Source = image2;
                this.image_Copy1.Source = image2;
                this.image_Copy2.Source = image2;
            }
        }
        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            this.mediaElement.Position = new TimeSpan(0, 0, 1);
            this.mediaElement.Play();

            this.mediaElement_Copy.Position = new TimeSpan(0, 0, 1);
            this.mediaElement_Copy.Play();

            this.mediaElement_Copy1.Position = new TimeSpan(0, 0, 1);
            this.mediaElement_Copy1.Play();

            this.mediaElement_Copy2.Position = new TimeSpan(0, 0, 1);
            this.mediaElement_Copy2.Play();
        }
    }
}
