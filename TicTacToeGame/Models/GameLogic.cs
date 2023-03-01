using TicTacToe.Models.Extensions;

namespace TicTacToe.Models
{
    public class GameLogic
    {
        private readonly Random randomSelection;
        readonly List<KeyValuePair<Button, int>> board;
        private readonly List<KeyValuePair<Button, int>> tiles;

        public GameLogic()
        {
            board = new List<KeyValuePair<Button, int>>();
            randomSelection = new Random();
            tiles = CreateBoard(buttons);

        }

        /// <summary>
        /// Checking the tiles and different patterns of the TicTacToe game for who has won
        /// </summary>
        public List<List<List<int>>> CheckBoardLines()
        {
            // Horizontal checks
            List<List<int>> horizontalChecks = new List<List<int>>()
            {
                new List<int>{ 1, 2, 3 },
                new List<int>{ 4, 5, 6 },
                new List<int>{ 7, 8, 9},
            };

            List<List<int>> verticalChecks = new List<List<int>>()
            {
                new List<int>{ 1, 4, 7 },
                new List<int>{ 2, 5, 8 },
                new List<int>{ 3, 6, 9 },
            };

            List<List<int>> crossChecks = new List<List<int>>()
            {
                new List<int>{ 1, 5, 9 },
                new List<int>{ 3, 5, 7 },
            };

            List<List<List<int>>> checkGameLines = new List<List<List<int>>>();

            checkGameLines.Add(horizontalChecks);
            checkGameLines.Add(verticalChecks);
            checkGameLines.Add(crossChecks);

            return checkGameLines;
        }

        /// <summary>
        /// Creating the game board
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public List<KeyValuePair<Button, int>> CreateBoard(List<Button> tiles)
        {
            var count = 0;
            foreach (var tile in tiles)
            {
                count += 1;
                board.Add(new KeyValuePair<Button, int>(tile, count));
            }

            return board;
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
        /// Clears the board and start a new game
        /// </summary>
        private void NextGame(List<Button> board)
        {
            foreach (var tile in board)
            {
                tile.Enabled = true;
                tile.Text = string.Empty;
                tile.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Checking the tiles and different patterns of the TicTacToe game for who has won
        /// </summary>
        public void CheckWinner()
        {
            var lines = CheckBoardLines();
            var playerMoves = new List<int>();
            var computerMoves = new List<int>();
            var isMatchPlayer = false;
            var isMatchCPU = false;

            foreach (var tile in tiles)
            {
                if (tile.Key.Text == StringConstants.PLAYER_ICON)
                {
                    playerMoves.Add(tile.Value);
                }

                if (tile.Key.Text == StringConstants.COMPUTER_ICON)
                {
                    computerMoves.Add(tile.Value);
                }
            }

            foreach (var boardLine in lines)
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

        /// <summary>
        /// Version of a stupid AI
        /// </summary>
        public void ComputerSelectionStupid(Button selectedTile, List<Button> board)
        {
            // If selection already contains an disabled button with the players choice, than a new tile is being searched for
            do
            {
                var selection = randomSelection.Next(board.Count);
                selectedTile = board[selection];
            }
            while (selectedTile.Text != string.Empty && board.Any(x => x.Enabled == true));

            if (selectedTile.Text.Equals(string.Empty))
            {
                selectedTile.Text = Player.O.ToString();
                selectedTile.Enabled = false;
                selectedTile.BackColor = Color.PaleVioletRed;
            }
        }
    }
}
