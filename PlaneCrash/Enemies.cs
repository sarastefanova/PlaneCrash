using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneCrash
{
    public class Enemies
    {
        public Image enemy;
        
        public int X { get; set; }
        public int Y { get; set; }

        public int speed { get; set; }
        public bool isHit { get; set; }
        public int  widthEnemy { get; set; }
        public int heightEnemy { get; set; }

        public Enemies(int x,int y,int imgIndex)
        {
            this.X = x;
            this.Y = y;
            speed = 15;
            if(imgIndex == 1)
            {
                enemy = PlaneCrash.Properties.Resources.enemyPlane1;
                widthEnemy = PlaneCrash.Properties.Resources.enemyPlane1.Size.Width;
                heightEnemy = PlaneCrash.Properties.Resources.enemyPlane1.Size.Height;

            }
            else if(imgIndex == 2)
            {
                enemy = PlaneCrash.Properties.Resources.enemyPlane2;
                widthEnemy = PlaneCrash.Properties.Resources.enemyPlane2.Size.Width;
                heightEnemy = PlaneCrash.Properties.Resources.enemyPlane2.Size.Height;

            }
            else if(imgIndex == 3)
            {
                enemy = PlaneCrash.Properties.Resources.Comet;
                widthEnemy = PlaneCrash.Properties.Resources.Comet.Size.Width;
                heightEnemy = PlaneCrash.Properties.Resources.Comet.Size.Height;
            }

            isHit = false;
        }
    
        public void Draw(Graphics g)
        {
            g.DrawImage(enemy, X, Y);
        }

        public void Move()
        {
            Y += speed;
        }

        public bool EnemyOnEgde(int height)
        {
            if(Y+speed < height)
            {
                return true;
            }
            return false;
        }

    }
}
