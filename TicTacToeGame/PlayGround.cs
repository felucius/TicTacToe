using TicTacToe;

namespace WinFormsApp1
{
    public partial class PlayGround : Form
    {
        private List<Button> buttons;
        private Random randomSelection;
        private int playerScore, computerScore;
        private Player humanPlayer, computerPlayer;

        private GameLogic gameLogic;
        private readonly List<KeyValuePair<Button, int>> tiles;

        public PlayGround()
        {
            InitializeComponent();

            // Initialize basic information
            humanPlayer = Player.X;
            computerPlayer = Player.O;
            randomSelection = new Random();
            buttons = new List<Button> { btnTile1, btnTile2, btnTile3, btnTile4, btnTile5, btnTile6, btnTile7, btnTile8, btnTile9 };
            
            // Create game logic
            gameLogic = new GameLogic();
            tiles = gameLogic.CreateBoard(buttons);

            RestartGame();
        }

        /// <summary>
        /// Clears the board and restarts the score
        /// </summary>
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

        /// <summary>
        /// Clears the board and start a new game
        /// </summary>
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
            while (selectedTile.Text != string.Empty && buttons.Any(x => x.Enabled == true));

            if (selectedTile.Text.Equals(string.Empty))
            {
                selectedTile.Text = Player.O.ToString();
                selectedTile.Enabled = false;
                selectedTile.BackColor = Color.PaleVioletRed;
            }
        }

        /// <summary>
        /// Enables the CPU to make a move
        /// </summary>
        private void StartComputer()
        {
            computerTimer.Enabled = true;
            computerTimer.Interval = 300;
        }

        /// <summary>
        /// Stops the CPU movement
        /// </summary>
        private void StopComputer()
        {
            computerTimer.Enabled = false;
        }

        /// <summary>
        /// Adds the score to the designated player
        /// </summary>
        /// <param name="player">the player who has won</param>
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
            var lines = gameLogic.CheckBoardLines();
            var playerMoves = new List<int>();
            var computerMoves = new List<int>();
            var isMatchPlayer = false;
            var isMatchCPU = false;

            foreach(var tile in tiles)
            {
                if(tile.Key.Text == StringConstants.PLAYER_ICON)
                {
                    playerMoves.Add(tile.Value);
                }

                if(tile.Key.Text == StringConstants.COMPUTER_ICON)
                {
                    computerMoves.Add(tile.Value);
                }
            }

            foreach(var boardLine in lines)
            {
                foreach (var line in boardLine)
                {
                    // Comparing the moves against the board lines
                    isMatchPlayer = line.All(x => playerMoves.Any(y => y == x));
                    isMatchCPU = line.All(x => computerMoves.Any(y => y == x));

                    if (isMatchPlayer)
                    {
                        MessageBox.Show(StringConstants.PLAYER_WINS_MESSAGE);
                        AddScore(humanPlayer);
                        NextGame();

                        break;
                    }
                    else if (isMatchCPU)
                    {
                        MessageBox.Show(StringConstants.COMPUTER_WINS_MESSAGE);
                        AddScore(computerPlayer);
                        NextGame();

                        break;
                    }

                    if (buttons.All(x => x.Text != string.Empty))
                    {
                        MessageBox.Show(StringConstants.THE_MATCH_IS_A_TIE);
                        NextGame();
                    }
                }
            }
        }

        // Events
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
    }
}