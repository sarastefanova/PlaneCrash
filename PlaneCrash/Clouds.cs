using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneCrash
{
    public class Clouds
    {
        public Image cloud;

        public int X { get; set; }
        public int Y { get; set; }

        public int speed { get; set; }
       
       

        public Clouds(int x, int y,int imgIndex)
        {
            this.X = x;
            this.Y = y;
            speed = 10;

            if (imgIndex == 1)
            {
                cloud = PlaneCrash.Properties.Resources.cloud1;
                

            }
            else if (imgIndex == 2)
            {
                cloud = PlaneCrash.Properties.Resources.cloud2;
               

            }

        }

        public void Draw(Graphics g)
        {
            g.DrawImage(cloud, X, Y);
        }

        public void Move()
        {
            Y += speed;
        }

        public bool CloudOnEgde(int height)
        {
            if (Y + speed < height)
            {
                return true;
            }
            return false;
        }
    }
}
