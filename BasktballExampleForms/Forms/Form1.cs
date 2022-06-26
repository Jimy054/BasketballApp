using BasktballExampleForms.Forms;
using BasktballExampleForms.Models;
using BasktballExampleForms.Repository;

namespace BasktballExampleForms
{
    public partial class Form1 : Form
    {
        GameRepository gameRepository = new GameRepository();
        TeamRepository teamRepository = new TeamRepository();
        TeamModel team = new TeamModel();
     //   BindingSource _binding = new BindingSource();
        List<GameModel> dataGame= new List<GameModel>();
        public Form1()
        {
            InitializeComponent();
            List<TeamModel> teams = new List<TeamModel>();
            teams = teamRepository.GetTeams();
            comboBox2.DataSource = teams;

            comboBox2.ValueMember = team.Acronym;
            comboBox2.DisplayMember= team.Name;
            dataGridView1.AllowUserToAddRows = false;

         //  _binding.DataSource = dataGame;


            //  teams = 



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            team.Acronym = "atl";
            FillGames(team);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllTeamsForms f2 = new AllTeamsForms(team);
            f2.Show();
            this.Hide();
        }
             

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            team = comboBox2.SelectedItem as TeamModel;
            if (team != null)
                FillGames(team);
        }


        private void FillGames(TeamModel teamModel)
        {
            dataGridView1.Rows.Clear();

            this.Cursor = Cursors.WaitCursor;
            dataGame = gameRepository.GetSomeGames(5, teamModel);
            foreach (GameModel item in dataGame)
            {
                dataGridView1.Rows.Add(item.GameRival, item.GameDate, item.Result);
            }
            this.Cursor = Cursors.Default;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}