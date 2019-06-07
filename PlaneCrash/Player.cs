using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneCrash
{
    [Serializable]   
    public class Player
    {
        public string Nickname { get; set; }
        public int Score { get; set; }
        public  string Country { get; set; }

        public Player(string nickname, int score,string c)
        {
            Nickname = nickname;
            Score = score;
            Country = c;
        }

        public void setScore(int score)
        {
            if(score > Score)
            {
                Score = score;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Country: {1}, Score : {2}", Nickname, Country, Score); ;
        }
    }
}
