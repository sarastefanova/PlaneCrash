using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneCrash
{
   public class MainHeroPlane
    {
        public enum DIRECTION
        {
            right,left,up,down
        }

        public enum PHOTOS
        {
            upDown,left,right
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int life { get; set; }
        public Image Planeleft{ get; set; }
        public Image Planeright { get; set; }
        public Image PlaneUpDown { get; set; }
        public bool GameOver { get; set; }

        public int widthHero { get; set; }
        public int heightHero { get; set; }

        public PHOTOS photos { get; set; }
        public DIRECTION d { get; set; }

        public int speed;

        public MainHeroPlane(PHOTOS photo)
        {
            photos = photo;
            d = DIRECTION.up;
            Planeleft = PlaneCrash.Properties.Resources.LeftPlane;
            

            Planeright = PlaneCrash.Properties.Resources.RightPlane;
            PlaneUpDown = PlaneCrash.Properties.Resources.Plane;

            life = 3;

            X = 500;
            Y = 500;

            GameOver = false;
            widthHero = PlaneCrash.Properties.Resources.Plane.Size.Width;
            heightHero = PlaneCrash.Properties.Resources.Plane.Size.Height;

            speed = 10;
        }

        public void Draw(Graphics g)
        {
            if (d==DIRECTION.left)
            {
                g.DrawImage(Planeleft, X, Y, Planeleft.Size.Width, Planeleft.Size.Height);
            }

            if (d == DIRECTION.right)
            {
                g.DrawImage(Planeright, X, Y, Planeleft.Size.Width, Planeleft.Size.Height);
            }

            if (d == DIRECTION.up || d==DIRECTION.down)
            {
                g.DrawImage(PlaneUpDown, X, Y, Planeleft.Size.Width, Planeleft.Size.Height);
            }
        }


        public void Move(int width,int height)
        {

            width = width - PlaneUpDown.Width-15;
            height = height - PlaneUpDown.Height;

            if (d == DIRECTION.left)
            {
                if (X - speed > 0)
                {
                    X -= speed;
                }
            }

            if (d == DIRECTION.right)
            {
                if (X + speed < width)
                {
                    X += speed;
                }
            }

            if (d == DIRECTION.up)
            {
                if (Y - speed > 0)
                {
                    Y -= speed;
                }

            }

            if (d == DIRECTION.down)
            {
                if (Y + speed < height-15)
                {
                    Y += speed;
                }
            }
        }

        public void ChangeDirection(DIRECTION direction)
        {
            d = direction;
        }
    }
}
