using System;
using System.Media;
using System.Windows.Forms;



namespace PlaneCrash
{
    public partial class HomePage : Form
    {
        public SoundPlayer simpleSound = new SoundPlayer(PlaneCrash.Properties.Resources.Menu);
        public bool isPlaying;
        
        public HomePage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            isPlaying = false;
            simpleSound.Play();

        }


        private void BtnNewGame_Click_1(object sender, EventArgs e)
        {
            NewGame newGame = new NewGame();
            newGame.ShowDialog();
        }

        private void BtnInstructions_Click(object sender, EventArgs e)
        {
            HowToPlay howToPlay = new HowToPlay();
            howToPlay.ShowDialog();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit game, are you sure?", "Quit game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

    

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                simpleSound.Play();
                isPlaying = false;
            }
            else {
                simpleSound.Stop();
                isPlaying = true;
            }
           
        }

        private void HomePage_Activated(object sender, EventArgs e)
        {
            simpleSound.Play();
        }

        private void btnScores_Click(object sender, EventArgs e)
        {

            Scores scores = new Scores();
            scores.ShowDialog();
        }
    }
}
