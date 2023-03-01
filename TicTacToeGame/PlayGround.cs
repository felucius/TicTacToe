using System.Numerics;
using TicTacToe.Models;
using TicTacToe.Models.Extensions;

namespace TicTacToe
{
    public partial class PlayGround : Form
    {
        private List<Button> boardGame;
        private GameLogic gameLogic;
        private readonly List<KeyValuePair<Button, int>> tiles;
        private readonly Cpu cpuPlayer;
        private readonly Player player;

        public PlayGround()
        {
            InitializeComponent();

            // Initialize players
            cpuPlayer = new Cpu();
            player = new Player();

            boardGame = new List<Button> { btnTile1, btnTile2, btnTile3, btnTile4, btnTile5, btnTile6, btnTile7, btnTile8, btnTile9 };
            
            // Create game logic
            gameLogic = new GameLogic();
            tiles = gameLogic.CreateBoard(boardGame);

            RestartGame();
        }

        /// <summary>
        /// Clears the board and restarts the score
        /// </summary>
        private void RestartGame()
        {
            cpuPlayer.SetScore(0);
            player.SetScore(0);

            lblPlayer.Text = StringConstants.PLAYER_SCORE_BOARD + player.GetScore();
            lblComputer.Text = StringConstants.COMPUTER_SCORE_BOARD + cpuPlayer.GetScore();

            foreach (var button in boardGame)
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
            foreach (var button in boardGame)
            {
                button.Enabled = true;
                button.Text = String.Empty;
                button.BackColor = Color.White;
            }
        }

        private void PlayerClick(Button tile)
        {
            // Player selects a tile that is going to be filled in.
            tile.Text = player.GetUserIcon();
            tile.Enabled = false;
            tile.BackColor = Color.LightGreen;
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
            //var selection = (Button)sender;
            var selection = new Button();
            gameLogic.ComputerSelectionStupid(selection, boardGame, cpuPlayer);
            StopComputer();
            var isWinner = gameLogic.CheckWinner(tiles);

            // If there is a winner, add the score to the correct winner
            switch (isWinner)
            {
                case GameAnnouncements.PLAYER_WINS:
                     MessageBox.Show(StringConstants.PLAYER_WINS_MESSAGE);
                    gameLogic.AddPlayerScore(player);
                    lblPlayer.Text = StringConstants.PLAYER_SCORE_BOARD + player.GetScore().ToString();
                    NextGame();
                    break;
                case GameAnnouncements.CPU_WINS:
                    MessageBox.Show(StringConstants.COMPUTER_WINS_MESSAGE);
                    gameLogic.AddCpuScore(cpuPlayer);
                    lblComputer.Text = StringConstants.COMPUTER_SCORE_BOARD + cpuPlayer.GetScore().ToString();
                    NextGame();
                    break;
                case GameAnnouncements.TIE:
                    MessageBox.Show(StringConstants.THE_MATCH_IS_A_TIE);
                    NextGame();
                    break;
            }
        }
    }
}