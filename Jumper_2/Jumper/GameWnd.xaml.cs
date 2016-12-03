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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Jumper
{
    /// <summary>
    /// Interaction logic for GameWnd.xaml
    /// </summary>
    public partial class GameWnd : Window
    {
        
        
       
        GameArea gamearea;
        Storyboard jmp;
        Storyboard flr;
       
        Storyboard obstacle_bottom_anim_1;
        Storyboard obstacle_top_anim_1;
        Storyboard obstacle_bottom_anim_2;
        Storyboard obstacle_top_anim_2;

        Storyboard cld1;
        Storyboard cld2;
        Storyboard cld3;
        
       
       
        
       
       
        public GameWnd()
        {
            InitializeComponent();
          
           
            
            jmp = (Storyboard)TryFindResource("Jump");
            flr = (Storyboard)TryFindResource("Floor_scroll");
            cld1 = (Storyboard)TryFindResource("Clouds_scroll1");
            cld2 = (Storyboard)TryFindResource("Clouds_scroll2");
            cld3 = (Storyboard)TryFindResource("Clouds_scroll3");
           
            obstacle_bottom_anim_1= (Storyboard)TryFindResource("Obstacle1_animation1");
            obstacle_top_anim_1 = (Storyboard)TryFindResource("Obstacle2_animation1");
            obstacle_bottom_anim_2 = (Storyboard)TryFindResource("Obstacle1_animation2");
            obstacle_top_anim_2 = (Storyboard)TryFindResource("Obstacle2_animation2");
            
            
           
            
            gamearea = new GameArea(gwnd,player,Obstacle_image,Obstacle_top_image,Obstacle_2_image, Obstacle_top_2_image,jmp,flr,obstacle_bottom_anim_1,obstacle_top_anim_1,obstacle_bottom_anim_2,obstacle_top_anim_2,cld1,cld2,cld3);
            gamearea.collisionTimer.Tick += Collisiontimer_Tick;
            gamearea.timer.Tick += Timer_Tick;
            textBlock.DataContext = gamearea;
            gamearea.Jump_anim.Completed += Jump_anim_Completed;
            
            
            gamearea.collisionTimer.Start();
            

            

        }

        private void Jump_anim_Completed(object sender, EventArgs e)
        {
            gamearea.Run = false;
        }

        private void Collisiontimer_Tick(object sender, EventArgs e)
        {
            gamearea.Collision();
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
          //  gamearea.SpawnObstacle();
            gamearea.Sec++;

            gamearea.SpawnObstacle();







        }

        private void gwnd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
               
                gamearea.Jump();
                
                   
                
                
                    
                   
                
            }
            if(e.Key == Key.P)
            {
                
               gamearea.Pause(jmp, flr, cld1, cld2, cld3, obstacle_bottom_anim_1, obstacle_top_anim_1, obstacle_bottom_anim_2,obstacle_top_anim_2);
                    
                    
                
               
                    
                 
                
            }
        }
    }
}
