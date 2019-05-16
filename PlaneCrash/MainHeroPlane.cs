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

        public PHOTOS photos { get; set; }
        public DIRECTION d { get; set; }
        public int brzina;

        public MainHeroPlane(PHOTOS photo)
        {
            photos = photo;
            d = DIRECTION.up;
            Planeleft = PlaneCrash.Properties.Resources.MainPlaneLeft;
            

            Planeright = PlaneCrash.Properties.Resources.MainPlaneRight;
            PlaneUpDown = PlaneCrash.Properties.Resources.MainPlane;

            life = 4;

            X = 500;
            Y = 500;

            

            brzina = 15;
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
                if (X -brzina > 0)
                {
                    X -= brzina;
                }
            }

            if (d == DIRECTION.right)
            {
                if (X + brzina < width)
                {
                    X += brzina;
                }
            }

            if (d == DIRECTION.up)
            {
                if (Y - brzina > 0)
                {
                    Y -= brzina;
                }

            }

            if (d == DIRECTION.down)
            {
                if (Y + brzina < height-15)
                {
                    Y += brzina;
                }
            }
        }

        public void ChangeDirection(DIRECTION direction)
        {
            d = direction;
        }
    }
}
