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
using System.ComponentModel;
using System.Media;


namespace Jumper
{
    class GameArea : INotifyPropertyChanged
    {
        private bool paused;
        private bool jump_in_progress;
        private bool obstacle_bottom_1_in_progress;
        private int difficulty;
        private int sec;
        public DispatcherTimer timer;
        public Image player_img;
        public Image obstacle_bottom_img_1;
        public Image obstacle_top_img_1;
        public Image obstacle_bottom_img_2;
        public Image obstacle_top_img_2;
        private int score = 0;
        public DispatcherTimer collisionTimer;
       
        public event PropertyChangedEventHandler PropertyChanged;
        
        Storyboard jump_anim;
        Storyboard floor_anim;
        
        Storyboard obstacle1_anim;
        Storyboard obstacle1_top_anim;
        Storyboard obstacle2_anim;
        Storyboard obstacle2_top_anim;
        Storyboard cloud1_anim;
        Storyboard cloud2_anim;
        Storyboard cloud3_anim;

        PlayerNameWindow playernamewnd;
        Window mainwnd;


        public int Sec
        {
            get
            {
                return sec;
            }

            set
            {
                sec = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
                var pc = PropertyChanged;
                if(pc != null)
                {
                    pc(this,new PropertyChangedEventArgs("Score"));
                }
            }
        }

        public Storyboard Jump_anim
        {
            get
            {
                return jump_anim;
            }

            set
            {
                jump_anim = value;
            }
        }

        public bool Run
        {
            get
            {
                return jump_in_progress;
            }

            set
            {
                jump_in_progress = value;
            }
        }

        public int Difficulty
        {
            get
            {
                return difficulty;
            }

            set
            {
                difficulty = value;
            }
        }

        public GameArea(Window wnd ,Image _player, Image _obs_bottom_1, Image _obs_top_1, Image _obs_bottom_2, Image _obs_top_2,params Storyboard[] resources)
        {
            mainwnd = wnd;
           
            player_img = _player;
            obstacle_bottom_img_1 = _obs_bottom_1;
            obstacle_top_img_1 = _obs_top_1;
            obstacle_bottom_img_2 = _obs_bottom_2;
            obstacle_top_img_2 = _obs_top_2;
            
            jump_anim = resources[0];
            floor_anim = resources[1];
            obstacle1_anim = resources[2];
            obstacle1_top_anim = resources[3];
            obstacle2_anim = resources[4];
            obstacle2_top_anim = resources[5];
            cloud1_anim = resources[6];
            cloud2_anim = resources[7];
            cloud3_anim = resources[8];
            
            paused = false;
            
            timer = new DispatcherTimer();
            collisionTimer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(1000);
            this.collisionTimer.Interval = TimeSpan.FromMilliseconds(1);
            floor_anim.Begin();
            cloud1_anim.Begin();
            cloud2_anim.Begin();
            cloud3_anim.Begin();
            this.timer.Start();
            difficulty = 5;
            jump_anim.AccelerationRatio = 0.5;
            jump_anim.DecelerationRatio = 0.5;
            
        }

        
      

        public void Pause(params Storyboard[] resources)
        {
            if (paused == false)
            {
                for (int i = 0; i < resources.Length; i++)
                {
                    resources[i].Pause();
                }
                this.timer.Stop();
                paused = true;
            }
            else
            {
                for (int i = 0; i < resources.Length; i++)
                {
                    resources[i].Resume();
                }
                this.timer.Start();
                paused = false;
            }
        }

       

        public void SpawnObstacle()
        {
            if (this.sec % 2 == 0)
            {
                obstacle1_anim.Begin();
               
                


            }
            if (this.sec % 3 == 0 && this.sec % 2 !=0)
            {
                obstacle1_top_anim.Begin();
          


            }
            if (this.sec % 5 == 0 && this.sec % 3 !=0 && this.sec % 2 != 0)
            {

                obstacle1_top_anim.Begin();

            }
           
            if (sec%5 == 0 && difficulty > 3)
            {
                difficulty--;
            }
            
            
        }

        public void Jump()
        {

               
            if (jump_in_progress == false)
            {
                jump_anim.Begin();
                jump_in_progress = true;
            }

                
           

        }


        
        private Point player_pos = new Point();
      
        private Point obstacle_bottom_1_pos = new Point();
        private Point obstacle_top_1_pos = new Point();
        private Point obstacle_bottom_2_pos = new Point();
        private Point obstacle_top_2_pos = new Point();

        /// <summary>
        ///  Ütközést érzékelő függvény
        /// </summary>

        public void Collision()
        {
            try {

                obstacle_bottom_1_pos.X = Convert.ToInt32(obstacle_bottom_img_1.PointToScreen(new Point()).X);
                obstacle_bottom_1_pos.Y = Convert.ToInt32(obstacle_bottom_img_1.PointToScreen(new Point()).Y);
                obstacle_top_1_pos.X = Convert.ToInt32(obstacle_top_img_1.PointToScreen(new Point()).X);
                obstacle_top_1_pos.Y = Convert.ToInt32(obstacle_top_img_1.PointToScreen(new Point()).Y);
                obstacle_bottom_2_pos.X = Convert.ToInt32(obstacle_bottom_img_2.PointToScreen(new Point()).X);
                obstacle_bottom_2_pos.Y = Convert.ToInt32(obstacle_bottom_img_2.PointToScreen(new Point()).Y);
                obstacle_top_2_pos.X = Convert.ToInt32(obstacle_top_img_2.PointToScreen(new Point()).X);
                obstacle_top_2_pos.Y = Convert.ToInt32(obstacle_top_img_2.PointToScreen(new Point()).Y);
                player_pos.X = Convert.ToInt32(player_img.PointToScreen(new Point()).X);
                player_pos.Y = Convert.ToInt32(player_img.PointToScreen(new Point()).Y);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
           
            if(((player_pos.X + player_img.ActualWidth  > obstacle_top_1_pos.X && player_pos.X + player_img.ActualWidth < obstacle_top_1_pos.X + obstacle_top_img_1.ActualWidth) || (player_pos.X > obstacle_top_1_pos.X && player_pos.X < obstacle_top_1_pos.X+obstacle_top_img_1.ActualWidth)) && player_pos.Y <= obstacle_top_1_pos.Y+obstacle_top_img_1.ActualHeight)
            {
                this.Pause(jump_anim,floor_anim, cloud1_anim, cloud2_anim, cloud3_anim, obstacle1_anim, obstacle1_top_anim,obstacle2_top_anim,obstacle2_anim);
                MessageBox.Show(">tfw game over");
                playernamewnd = new PlayerNameWindow(this.score);
                mainwnd.Close();
                playernamewnd.ShowDialog();
            }
            else
            {
                if (((player_pos.X + player_img.ActualWidth > obstacle_bottom_1_pos.X && player_pos.X + player_img.ActualWidth < obstacle_bottom_1_pos.X + obstacle_bottom_img_1.ActualWidth) || (player_pos.X > obstacle_bottom_1_pos.X && player_pos.X < obstacle_bottom_1_pos.X + obstacle_bottom_img_1.ActualWidth)) && player_pos.Y+player_img.ActualHeight >= obstacle_bottom_1_pos.Y)
                {
                    this.Pause(jump_anim, floor_anim, cloud1_anim, cloud2_anim, cloud3_anim, obstacle1_anim, obstacle1_top_anim, obstacle2_top_anim, obstacle2_anim); MessageBox.Show(">tfw game over");
                    playernamewnd = new PlayerNameWindow(this.score);

                    mainwnd.Close();
                    playernamewnd.ShowDialog();
                }
                else
                {
                    if (((player_pos.X + player_img.ActualWidth > obstacle_top_2_pos.X && player_pos.X + player_img.ActualWidth < obstacle_top_2_pos.X + obstacle_top_img_2.ActualWidth) || (player_pos.X > obstacle_top_2_pos.X && player_pos.X < obstacle_top_2_pos.X + obstacle_top_img_2.ActualWidth)) && player_pos.Y <= obstacle_top_2_pos.Y + obstacle_top_img_2.ActualHeight)
                    {
                        this.Pause(jump_anim, floor_anim, cloud1_anim, cloud2_anim, cloud3_anim, obstacle1_anim, obstacle1_top_anim, obstacle2_top_anim, obstacle2_anim);
                        
                        playernamewnd = new PlayerNameWindow(this.score);
                        
                        mainwnd.Close();
                        playernamewnd.ShowDialog();
                    }
                    else
                    {
                        if (((player_pos.X + player_img.ActualWidth > obstacle_bottom_2_pos.X && player_pos.X + player_img.ActualWidth < obstacle_bottom_2_pos.X + obstacle_bottom_img_2.ActualWidth) || (player_pos.X > obstacle_bottom_2_pos.X && player_pos.X < obstacle_bottom_2_pos.X + obstacle_bottom_img_2.ActualWidth)) && player_pos.Y + player_img.ActualHeight >= obstacle_bottom_2_pos.Y)
                        {
                            this.Pause(jump_anim, floor_anim, cloud1_anim, cloud2_anim, cloud3_anim, obstacle1_anim, obstacle1_top_anim, obstacle2_top_anim, obstacle2_anim); MessageBox.Show(">tfw game over");
                            playernamewnd = new PlayerNameWindow(this.score);

                            mainwnd.Close();
                            playernamewnd.ShowDialog();
                        }
                        else
                        {
                            Score++;
                        }

                    }

                }
            }
            


        }

        public void playSound()
        {
            
            
        }


        
    }
}
