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

namespace Jumper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gamewindow gw;
        
       
        bool run = false;
        public MainWindow()
        {
            InitializeComponent();
            
            
            // a Gamewindow osztályt példányosítom, abban megadom az ablakot, annak címét és méretét, valamit a rajta levő háttérvezérlőt
            gw = new Gamewindow(MWindow,"Jumper",CanvasBackground,480,640);
            // A Fő ablak vezérlő gombjai
            Button newGame = new Button();
            Button help = new Button();
            Button exit = new Button();
            // a Fő ablak vezérlői gombjaira vonatkozó egérkattintás eventek
            newGame.Click += button_Click;
            help.Click += button_Click;
            exit.Click += button_Click;

            // a gw.AddControls()-nak megadom a háttérvezérlőt, valamint a rajta elhelyezendő gombok listáját
            gw.AddControls(CanvasBackground, newGame, help, exit);
            // a gw.SetMenuBackground()-nak megadom a háttérvezérlőt
            gw.SetMenuBackground(CanvasBackground);
            
            


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToString(((Button)sender).Content) == "New Game")
            {
                GameWnd gamewnd = new GameWnd();
                
                this.Close();
                gamewnd.ShowDialog();

                /*CanvasBackground.Children.Clear();
                gw.SetGameBackground(CanvasBackground);
                move = new Movement(gw.Ceiling, gw.Floor);
                */
            }
            if (Convert.ToString(((Button)sender).Content) == "Exit")
            {
                this.Close();
            }
            run = true;
        }

        private void MWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        private void MWindow_KeyDown(object sender, KeyEventArgs e)
        {
        }
        
    }
}
