using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneCrash
{
    public partial class NewGame : Form
    {
        
        SoundPlayer simpleSound = new SoundPlayer(PlaneCrash.Properties.Resources.game);
        bool isPlaying;
    
        Timer timer;

       
        public MainHeroPlane HeroPlane { get; set; }

        public List<Enemies> enemies { get; set; } 

        public List<Clouds> clouds { get; set; }
        public NewGame()
        {

         
            InitializeComponent();
            this.DoubleBuffered = true;


            StartGame();

        }

        public void StartGame()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            simpleSound.PlayLooping();


            HeroPlane = new MainHeroPlane(MainHeroPlane.PHOTOS.upDown);
            enemies = new List<Enemies>();
            clouds = new List<Clouds>();

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(Timer1_Tick);
            timer.Start();


            fillEnemiesList();

           
            fillCloudList();
        }

      
        public void fillEnemiesList()
        {
            Random r = new Random();
            for(int i=enemies.Count;i<10;i++)
            {
               
                enemies.Add(new Enemies(r.Next(this.ClientSize.Width), -r.Next(1000), r.Next(1, 4)));
            }
        }

        public void fillCloudList()
        {
            Random random = new Random();
            for (int i = clouds.Count; i < 5; i++)
            {

                clouds.Add(new Clouds(random.Next(900), -random.Next(1000), random.Next(1,3)));
            }
        }

        public void MoveClouds()
        {
            for (int i = 0; i < clouds.Count; i++)
            {
                clouds[i].Move();
                if (!clouds[i].CloudOnEgde(this.ClientSize.Height))
                {
                    clouds.Remove(clouds[i]);
                }

            }

            if (clouds.Count < 5)
            {
                fillCloudList();
            }
        }

        public void MoveEnemies()
        {
            for(int i=0;i<enemies.Count;i++)
            {
                enemies[i].Move();
                if(!enemies[i].EnemyOnEgde(this.ClientSize.Height))
                {
                    enemies.Remove(enemies[i]);
                }

                if (Crash(enemies[i]))
                {
                    enemies[i].isHit = true;

                    if (HeroPlane.life == 0)
                    {
                        HeroPlane.GameOver = true;
                        
                    }
                    else 
                    {
                        HeroPlane.life--;
                    }

                }
                
            }

            for(var i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].isHit)
                {
                    enemies.Remove(enemies[i]);
                }

            }
           
            if(enemies.Count < 10 )
            {
                fillEnemiesList();
            }
        }


        public bool Crash(Enemies en)
        {
           
            Rectangle R1 = new Rectangle(HeroPlane.X, HeroPlane.Y, HeroPlane.widthHero, HeroPlane.heightHero);
             Rectangle R2 = new Rectangle(en.X, en.Y, en.widthEnemy, en.widthEnemy);

            return (R2.X <R1.X + R1.Width) &&
                        (R1.X < (R2.X + R2.Width)) &&
                        (R2.Y < R1.Y + R1.Height) &&
                        (R1.Y < R2.Y + R2.Height);
        }

       

        private void NewGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleSound.Stop();
                this.Close();
                
            }


            if (Keys.Left == e.KeyCode)
            {
                HeroPlane.ChangeDirection(MainHeroPlane.DIRECTION.left);
            }

            if (Keys.Right == e.KeyCode)
            {
                HeroPlane.ChangeDirection(MainHeroPlane.DIRECTION.right);

            }

            if (Keys.Up == e.KeyCode)
            {
                HeroPlane.ChangeDirection(MainHeroPlane.DIRECTION.up);
            }

            if (Keys.Down == e.KeyCode)
            {
                HeroPlane.ChangeDirection(MainHeroPlane.DIRECTION.down);
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                simpleSound.PlayLooping();
                isPlaying = false;
            }
            else
            {
                simpleSound.Stop();
                isPlaying = true;
            }
        }


        private void NewGame_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        public void GameOver()
        {
            
            if(MessageBox.Show("New game?","Game over", MessageBoxButtons.YesNo) == DialogResult.OK)
            {
                StartGame();
            }
            else
            {
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            HeroPlane.Move(this.ClientSize.Width, this.ClientSize.Height);
            
            MoveEnemies();

            MoveClouds();

           
            if (HeroPlane.GameOver)
            {
                timer.Enabled = false;
                //timer.Stop();
                //GameOver();
            }

            lblLifes.Text = HeroPlane.life.ToString();

            Invalidate(true);
        }

        private void NewGame_Paint(object sender, PaintEventArgs e)
        {
        
            HeroPlane.Draw(e.Graphics);

            foreach(Enemies en in enemies)
            {
                en.Draw(e.Graphics);
            }

            foreach(Clouds c in clouds)
            {
                c.Draw(e.Graphics);
            }
        }

        
    }
}
