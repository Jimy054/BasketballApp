using BasktballExampleForms.Forms;
using BasktballExampleForms.Models;
using BasktballExampleForms.Repository;

namespace BasktballExampleForms
{
    public partial class Form1 : Form
    {
        GameRepository gameRepository = new GameRepository();
        TeamRepository teamRepository = new TeamRepository();
        public Form1()
        {
            InitializeComponent();
            List<TeamModel> teams = new List<TeamModel>();
            teams = teamRepository.GetTeams();
            comboBox2.DataSource = teams;
          //  teams = 
            List<GameModel> dataGame = gameRepository.GetSomeGames(5);            
            foreach (GameModel item in dataGame)
            {
                dataGridView1.Rows.Add(item.GameRival,item.GameDate,item.Result         ); 
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllTeamsForms f2 = new AllTeamsForms();
            f2.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}