using BasktballExampleForms.Models;
using BasktballExampleForms.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasktballExampleForms.Forms
{
    public partial class AllTeamsForms : Form
    {
        GameRepository gameRepository = new GameRepository();
        public AllTeamsForms()
        {
            InitializeComponent();

            List<GameModel> dataGame = gameRepository.GetAllGames();
            foreach (GameModel item in dataGame)
            {
                dataGridView1.Rows.Add(item.GameRival, item.GameDate, item.Result);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }
    }
}
