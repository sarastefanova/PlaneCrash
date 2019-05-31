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
    public partial class NewPlayer : Form
    {
        public static Player player { get; set; }
        
        public NewPlayer()
        {
            InitializeComponent();
          
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            player = new Player(txtName.Text,0,txtCountry.Text);

            NewGame newGame = new NewGame();
            DialogResult dialog = newGame.ShowDialog();
            this.Close();

       
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Enter your name!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtName, null);
                e.Cancel = false;
            }

        }
    }
}
