using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public Window1()
        {
            InitializeComponent();

        }

        /*
         * Methode de modification des texteblock selon le parametre envoyé
         */
        public void ModifierTexte(string texte)
        {
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
    }
}
