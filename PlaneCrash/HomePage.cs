using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneCrash
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}
