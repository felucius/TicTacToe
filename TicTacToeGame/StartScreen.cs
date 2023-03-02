using TicTacToe.Models;

namespace TicTacToe
{
    public partial class StartScreen : Form
    {
        public static string PlayerName { get; set; }
        public static DifficultyEnum Difficulty { get; set; }

        public StartScreen()
        {
            InitializeComponent();

            LoadStartScreenComponents();
            LoadGameDifficulties();
        }

        private void LoadStartScreenComponents()
        {
            lblTitle.Text = "Tic Tac Toe";
            lblPlayerName.Text = "Player name";
            lblDifficulty.Text = "Choose difficulty";
            btnStartGame.Text = "Start game";
        }

        private void LoadGameDifficulties()
        {
            cbDifficulty.Items.Add(DifficultyEnum.EASY);
            cbDifficulty.Items.Add(DifficultyEnum.INTERMEDIATE);
            cbDifficulty.Items.Add(DifficultyEnum.HARD);
        }

        private void SetPlayerName()
        {
            PlayerName = tbPlayerName.Text;
        }

        private void SetDifficulty()
        {
            var difficulty = (DifficultyEnum) cbDifficulty.SelectedItem;
            Difficulty = difficulty;
        }
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            SetPlayerName();
            SetDifficulty();
            SendInformationToPlayGround(PlayerName, Difficulty);
        }

        private void SendInformationToPlayGround(string playerName, DifficultyEnum difficulty)
        {
            var playGround = new PlayGround(playerName, difficulty);
            this.Hide();
            playGround.Show();
        }
    }
}
