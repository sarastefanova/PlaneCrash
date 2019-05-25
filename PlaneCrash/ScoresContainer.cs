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
        public List<Player> Players { get; set; }

        public ScoresContainer()
        {
            Players = new List<Player>();
        }


        public void addPlayer(Player p)
        {
            Players.Add(p);
        }

        public override string ToString()
        {
            return Players.ToString();
        }
    }
}
