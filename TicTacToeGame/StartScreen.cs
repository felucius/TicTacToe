using TicTacToe.Models;
using TicTacToe.Models.Extensions;

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
        }

        private void SetPlayerName()
        {
            if (!tbPlayerName.Text.Equals(string.Empty))
            {
                PlayerName = tbPlayerName.Text;
            }
            else
            {
                PlayerName = StringConstants.PLAYER_NAME_DEFAULT;
            }
        }

        private void SetDifficulty()
        {
            if(cbDifficulty.SelectedItem != null)
            {
                var difficulty = (DifficultyEnum) cbDifficulty.SelectedItem;
                Difficulty = difficulty;
            }
            else
            {
                // Default difficulty if no selection has been made
                Difficulty = DifficultyEnum.EASY;
            }
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
