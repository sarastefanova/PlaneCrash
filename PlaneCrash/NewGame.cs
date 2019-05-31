using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneCrash
{
    public partial class NewGame : Form
    {
        Player player;
        ScoresContainer container;
        SoundPlayer simpleSound = new SoundPlayer(PlaneCrash.Properties.Resources.game);
        bool isPlaying;

       
        public string FolderPath { get; set; }
        public string SerializationPath { get; set; }

        public MainHeroPlane HeroPlane { get; set; }

        public List<Enemies> enemies { get; set; } 

        public List<Clouds> clouds { get; set; }
        public bool isStarted { get; set; }
        
        public int min { get; set; }
        public int sec { get; set; }

        public List<int> scores { get; set; }

        public bool Canstart { get; set; }
        public NewGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            scores = new List<int>();
            Canstart = false;

            player = NewPlayer.player;
            
                StartGame();
            

           
    
        }

        public void StartGame()
        {
            //player = new Player("Ana-Sara", 0);
            container = new ScoresContainer();
           
             FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            min = 0;
            sec = 0;

            simpleSound.PlayLooping();


            HeroPlane = new MainHeroPlane(MainHeroPlane.PHOTOS.upDown);
            enemies = new List<Enemies>();
            clouds = new List<Clouds>();
            

            timer1.Start();
            timerGame.Start();
            isStarted = false;

            fillEnemiesList();
           
            fillCloudList();

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PlaneCrash");
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            Console.WriteLine($"Folder Path: [{FolderPath}]");

            SerializationPath = Path.Combine(FolderPath, "points.txt");
            Console.WriteLine($"File path: [{SerializationPath}]");

            Deserialization();


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


        public void Deserialization()
        {
            var myFile = new FileInfo(SerializationPath);
            if (!myFile.Exists)
            {
                return;
            }
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(SerializationPath, FileMode.Open, FileAccess.Read);
            container = (ScoresContainer)formatter.Deserialize(stream);
            stream.Close();
        }

        public void Serialization()
        {
            var myFile = new FileInfo(SerializationPath);
            if(myFile.Exists)
            {
                myFile.Attributes &= ~FileAttributes.Hidden;
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(SerializationPath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, container);
            stream.Close();
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
                        GameOver();
                      
                    }
                    else 
                    {
                        HeroPlane.life--;
                        lblLifes.Text = HeroPlane.life.ToString();
                        if (HeroPlane.life == 0)
                        {
                        HeroPlane.GameOver = true;
                        GameOver();
                      
                        }
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
           
            Rectangle R1 = new Rectangle(HeroPlane.X, HeroPlane.Y, HeroPlane.widthHero-50, HeroPlane.heightHero-30);
             Rectangle R2 = new Rectangle(en.X, en.Y, en.widthEnemy-50, en.heightEnemy-30);

            return (R2.X <(R1.X + R1.Width)) &&
                        (R1.X < (R2.X + R2.Width)) &&
                        (R2.Y < (R1.Y + R1.Height)) &&
                        (R1.Y < (R2.Y + R2.Height));
        }

        public int calculateTime()
        {
            int totalSeconds = 0;
            totalSeconds = min*60 + sec;

            return totalSeconds;
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

            HeroPlane.Move(this.ClientSize.Width, this.ClientSize.Height);

            if (e.KeyCode == Keys.P)
            {
                if (isStarted)
                {
                    isStarted = false;
                }
                else
                {
                    isStarted = true;
                }

                if (isStarted)
                {
                    
                    timer1.Stop();
                  
                }
                else
                {
                    
                    timer1.Start();
                  
                }
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

       

        public void GameOver()
        {
            
            timer1.Stop();
            timerGame.Stop();


            

            scores.Add(calculateTime());
            
            player.setScore(calculateTime());

            container.addPlayer(player);
            Serialization();

            if (MessageBox.Show("New game?","Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            
                MoveEnemies();
                MoveClouds();


                lblLifes.Text = HeroPlane.life.ToString();
            
               
            
           
            
            Invalidate(true);
        }

        private void TimerGame_Tick(object sender, EventArgs e)
        {
            sec++;

            if (sec == 60)
            {
                min++;
                sec = 0;
            }
            lblTime.Text = string.Format("{0:00}:{1:00}", min, sec);

            Invalidate(true);
        }

        private void NewGame_Paint(object sender, PaintEventArgs e)
        {

            HeroPlane.Draw(e.Graphics);

            foreach (Enemies en in enemies)
            {
                en.Draw(e.Graphics);
            }

            foreach (Clouds c in clouds)
            {
                c.Draw(e.Graphics);
            }
        }

       
    }
}
