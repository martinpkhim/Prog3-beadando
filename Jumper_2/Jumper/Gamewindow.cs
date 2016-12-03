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
using System.Windows.Media.Animation;

namespace Jumper
{
    //A GameWindow osztály a felhasznált grafikai elemek mejelenítésére szolgál
    class Gamewindow
    {
        private int Width;
        private int Height;
        private string[] Buttons = { "New Game", "Help", "Exit" };
        
       
       

        public Gamewindow(Window _window, String _windowTitle, Canvas _canvas, int _height, int _width)
        {
            

           

            this.Width = _width;
            this.Height = _height;

            _window.Title = _windowTitle;
            _window.Width = _width;
            _window.Height = Height;

              _canvas.Height = Height;
              _canvas.Width = Width;
            _canvas.ClipToBounds = true;
            

        }

        //Az AddControls osztály a MainWindow.xaml.cs állományban dinamikusan megadott vezérlők előre meghatározott helyre való elhelyezését teszi lehetővé

        public void AddControls(Canvas _canvas,params Button[] _buttons)
        {
         //   double x = _canvas.Height / 3;
         //   double y = _canvas.Width / 4;

            double x = 50;
            double y = 100;


            Canvas.SetTop(_buttons[0], y);
            Canvas.SetLeft(_buttons[0],x );
            _canvas.Children.Add(_buttons[0]);
            _buttons[0].Content = Buttons[0];
            for(int i = 1;i < _buttons.Length;i++)
            {
                y += 50;
                _buttons[i].Content = Buttons[i];
                Canvas.SetTop(_buttons[i], y);
                Canvas.SetLeft(_buttons[i], x);
                _canvas.Children.Add(_buttons[i]);
            }
        }


       

       


       
        


        //A menüháttér beállítására szolgál
        public void SetMenuBackground(Canvas _canvas)
        {
            ImageBrush backg = new ImageBrush();
            backg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/wojak_bg.jpg", UriKind.Absolute));
            _canvas.Background = backg;
           

            
        }


       
    }
}
