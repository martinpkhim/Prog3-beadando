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
    /// Interaction logic for HighScoreWindow.xaml
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        MainWindow mwnd2;
        HighScore hs;
        public HighScoreWindow(string name,int score)
        {
            InitializeComponent();
            hs = new HighScore(this.listBox, name, score);
            hs.LoadScore();
            mwnd2 = new MainWindow();
          
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            hs.SaveScore();
            hs.Name.Clear();
            hs.Score.Clear();
            mwnd2.ShowDialog();
           
        }
    }
}
