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
using System.Windows.Shapes;

namespace Jumper
{
    /// <summary>
    /// Interaction logic for PlayerNameWindow.xaml
    /// </summary>
    public partial class PlayerNameWindow : Window
    {
        HighScoreWindow hswnd;
        int score;
        public PlayerNameWindow(int scr)
        {
            InitializeComponent();
            score = scr;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            hswnd = new HighScoreWindow(this.textBox.Text, score);
            this.Close();
            hswnd.ShowDialog();
        }
    }
}
