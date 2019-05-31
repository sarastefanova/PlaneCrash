using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneCrash
{

    [Serializable]
    public class ScoresContainer
    {
        public  List<Player> Players { get; set; }

        public ScoresContainer()
        {
            Players = new List<Player>();
        }


        public void addPlayer(Player p)
        {
            Players.Add(p);
        }

        public void SortScore()
        {
            for(int i = 0; i < Players.Count; i++)
            {
                for(int j = i + 1; j < Players.Count; j++)
                {
                    if (Players[i].Score < Players[j].Score)
                    {
                        Player pom = Players[i];
                        Players[i] = Players[j];
                        Players[j] = pom;
                    }
                }
            }
        }

        public override string ToString()
        {
            return Players.ToString();
        }
    }
}
