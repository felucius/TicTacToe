using Microsoft.VisualBasic;
using TicTacToe;

namespace WinFormsApp1
{
    public partial class PlayGround : Form
    {
        private int playerScore;
        private int computerScore;
        private List<Button> buttons;
        private Random randomSelection;
        private Player humanPlayer;
        private Player computerPlayer;

        public PlayGround()
        {
            InitializeComponent();
            humanPlayer = Player.X;
            computerPlayer = Player.O;
            randomSelection = new Random();
            buttons = new List<Button> { btnTile1, btnTile2, btnTile3, btnTile6, btnTile5, btnTile4, btnTile9, btnTile8, btnTile7 };
            RestartGame();
        }

        private void RestartGame()
        {
            playerScore = 0;
            computerScore = 0;
            lblPlayer.Text = StringConstants.PLAYER_SCORE_BOARD + playerScore;
            lblComputer.Text = StringConstants.COMPUTER_SCORE_BOARD + computerScore;

            foreach(var button in buttons)
            {
                button.Enabled = true;
                button.Text = String.Empty;
                button.BackColor = Color.White;
            }
        }

        private void NextGame()
        {
            foreach (var button in buttons)
            {
                button.Enabled = true;
                button.Text = String.Empty;
                button.BackColor = Color.White;
            }
        }

        private void PlayerClick(Button btn)
        {
            // Player selects a tile that is going to be filled in.
            btn.Text = Player.X.ToString();
            btn.Enabled = false;
            btn.BackColor = Color.LightGreen;
        }

        /// <summary>
        /// Version of a stupid AI
        /// </summary>
        private void ComputerSelectionStupid()
        {
            var selectedTile = new Button();

            // If selection already contains an disabled button with the players choice, than a new tile is being searched for
            do
            {
                var selection = randomSelection.Next(buttons.Count);
                selectedTile = buttons[selection];
            }
            while (selectedTile.Text != String.Empty && buttons.Any(x => x.Enabled == true));

            if (selectedTile.Text.Equals(String.Empty))
            {
                selectedTile.Text = Player.O.ToString();
                selectedTile.Enabled = false;
                selectedTile.BackColor = Color.PaleVioletRed;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var action = (Button)sender;
            // If the player has selected one tile, then the computer may randomly select a tile
            PlayerClick(action);
            StartComputer();
        }

        private void computerTimer_Tick(object sender, EventArgs e)
        {
            ComputerSelectionStupid();
            StopComputer();
            CheckWinner();
        }

        private void StartComputer()
        {
            computerTimer.Enabled = true;
            computerTimer.Interval = 300;
        }

        private void StopComputer()
        {
            computerTimer.Enabled = false;
        }

        private void AddScore(Player player)
        {
            switch (player)
            {
                case Player.X:
                    playerScore++;
                    lblPlayer.Text = StringConstants.PLAYER_SCORE_BOARD + playerScore.ToString();
                    break;
                case Player.O:
                    computerScore++;
                    lblComputer.Text = StringConstants.COMPUTER_SCORE_BOARD + computerScore.ToString();
                    break;
            }
        }

        /// <summary>
        /// Checking the tiles and different patterns of the TicTacToe game for who has won
        /// </summary>
        private void CheckWinner()
        {
            if (
                // Horizontal checks
                btnTile1.Text.Equals(StringConstants.PLAYER_ICON) && btnTile2.Text.Equals(StringConstants.PLAYER_ICON) && btnTile3.Text.Equals(StringConstants.PLAYER_ICON) ||
                btnTile4.Text.Equals(StringConstants.PLAYER_ICON) && btnTile5.Text.Equals(StringConstants.PLAYER_ICON) && btnTile6.Text.Equals(StringConstants.PLAYER_ICON) ||
                btnTile7.Text.Equals(StringConstants.PLAYER_ICON) && btnTile8.Text.Equals(StringConstants.PLAYER_ICON) && btnTile9.Text.Equals(StringConstants.PLAYER_ICON) ||
                
                // Vertical checks
                btnTile1.Text.Equals(StringConstants.PLAYER_ICON) && btnTile4.Text.Equals(StringConstants.PLAYER_ICON) && btnTile7.Text.Equals(StringConstants.PLAYER_ICON) ||
                btnTile2.Text.Equals(StringConstants.PLAYER_ICON) && btnTile5.Text.Equals(StringConstants.PLAYER_ICON) && btnTile8.Text.Equals(StringConstants.PLAYER_ICON) ||
                btnTile3.Text.Equals(StringConstants.PLAYER_ICON) && btnTile6.Text.Equals(StringConstants.PLAYER_ICON) && btnTile9.Text.Equals(StringConstants.PLAYER_ICON) ||

                // Cross checks
                btnTile1.Text.Equals(StringConstants.PLAYER_ICON) && btnTile5.Text.Equals(StringConstants.PLAYER_ICON) && btnTile9.Text.Equals(StringConstants.PLAYER_ICON) ||
                btnTile3.Text.Equals(StringConstants.PLAYER_ICON) && btnTile5.Text.Equals(StringConstants.PLAYER_ICON) && btnTile7.Text.Equals(StringConstants.PLAYER_ICON))
            {
                MessageBox.Show(StringConstants.PLAYER_WINS_MESSAGE);
                AddScore(humanPlayer);
                NextGame();
            }

            if (
                // Horizontal checks
                btnTile1.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile2.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile3.Text.Equals(StringConstants.COMPUTER_ICON) ||
                btnTile4.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile5.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile6.Text.Equals(StringConstants.COMPUTER_ICON) ||
                btnTile7.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile8.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile9.Text.Equals(StringConstants.COMPUTER_ICON) ||
                
                // Vertical checks
                btnTile1.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile4.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile7.Text.Equals(StringConstants.COMPUTER_ICON) ||
                btnTile2.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile5.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile8.Text.Equals(StringConstants.COMPUTER_ICON) ||
                btnTile3.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile6.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile9.Text.Equals(StringConstants.COMPUTER_ICON) ||
                
                // Cross checks
                btnTile1.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile5.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile9.Text.Equals(StringConstants.COMPUTER_ICON) ||
                btnTile3.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile5.Text.Equals(StringConstants.COMPUTER_ICON) && btnTile7.Text.Equals(StringConstants.COMPUTER_ICON))
            {
                MessageBox.Show(StringConstants.COMPUTER_WINS_MESSAGE);
                AddScore(computerPlayer);
                NextGame();
            }

            if(buttons.All(x => x.Text != String.Empty))
            {
                MessageBox.Show(StringConstants.THE_MATCH_IS_A_TIE);
                NextGame();
            }
        }
    }
}