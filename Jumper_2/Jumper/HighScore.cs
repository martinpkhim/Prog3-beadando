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

using System.IO;

namespace Jumper
{
    class HighScore
    {
        StreamReader sr;
        StreamWriter sw;
        ListBox hsbox;
        int score_save;
        string name_save;
        private List<string> name;
        private List<int> score;
        int place;

        public List<string> Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public List<int> Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public HighScore(ListBox _hsbox, string _namesave, int _scoresave)
        {
            name = new List<string>();
            score = new List<int>();
           
            name_save = _namesave;
            score_save = _scoresave;
           
            hsbox = _hsbox;
            name.Add("Teszt");
            score.Add(0);
            sw = new StreamWriter("scores.dat");
            sw.Close();
            
            LoadScore();
            
        }
        
        public void LoadScore()
        {
           
            sr = new StreamReader("scores.dat");
            place = 0;
            int tempscore;
            while(!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(' ');
                name.Add(temp[0]);
                score.Add(Convert.ToInt32(temp[1]));
                hsbox.Items.Add(string.Format("{0} {1}",name[place],score[place]));
                place++;
            }
            for(int i = 0;i < score.Count-1;i++)
            {
                for(int j = i+1;j < score.Count;j++)
                {
                    if(score[i] < score[j])
                    {
                        tempscore = score[i];
                        score[i] = score[j];
                        score[j] = tempscore;
                    }
                }
            }
           
            sr.Close();
        }

        public void SaveScore()
        {
            sw = new StreamWriter("scores.dat");
            int tempscore = 0;
            string tempname;
            if (score_save > score[score.Count-1])
            {
                score[score.Count - 1] = score_save;
                for (int i = 0; i < score.Count - 1; i++)
                {
                    for (int j = i + 1; j < score.Count; j++)
                    {
                        if (score[i] < score[j])
                        {
                            tempscore = score[i];
                            score[i] = score[j];
                            score[j] = tempscore;

                            tempname = name[i];
                            name[i] = name[j];
                            name[j] = tempname;

                        }
                    }
                }
                for(int i = 0;i < score.Count;i++)
                {
                    sw.WriteLine(string.Format("{0} {1}", name_save, score_save));
                }
            }
            sw.Close();
        }
    }
}
