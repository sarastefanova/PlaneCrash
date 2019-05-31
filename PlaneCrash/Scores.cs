using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneCrash
{
    public partial class Scores : Form
    {
        NewGame newGame;
        private ScoresContainer container { get; set; }

        public List<Player> allPlayers { get; set; }

        public string FolderPath { get; set; }
        public string SerializationPath { get; set; }

        public Scores()
        {
            InitializeComponent();
            newGame = new NewGame();
            allPlayers = new List<Player>();

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PlaneCrash");

            SerializationPath = Path.Combine(FolderPath, "points.txt");

        }


        public void Deserialization()
        {
            var myFile = new FileInfo(SerializationPath);
            if(!myFile.Exists)
            {
                return;
            }
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(SerializationPath, FileMode.Open, FileAccess.Read);
            container = (ScoresContainer)formatter.Deserialize(stream);
            stream.Close();
        }

        private void Scores_Load(object sender, EventArgs e)
        {
           
            Deserialization();
           //allPlayers.Add(container.Players.ElementAt(0));

            int j = 0;
            container.SortScore();
            listBox1.DataSource = container.Players;
            

        }
    }
}
