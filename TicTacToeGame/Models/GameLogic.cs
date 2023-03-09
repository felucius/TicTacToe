using TicTacToe.Interfaces;
using TicTacToe.Models.Extensions;

namespace TicTacToe.Models
{
    public class GameLogic
    {
        private readonly Random randomSelection;
        readonly List<KeyValuePair<Button, int>> board;
        private KeyValuePair<Button, bool> tileIsMatched;

        public GameLogic()
        {
            board = new List<KeyValuePair<Button, int>>();
            tileIsMatched = new KeyValuePair<Button, bool>();
            randomSelection = new Random();
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
        public void AddPlayerScore(Player player)
        {
            var currentScore = player.GetScore();
            currentScore += 1;
            player.SetScore(currentScore);
        }

        /// <summary>
        /// Adds the score to the designated player
        /// </summary>
        /// <param name="player">the player who has won</param>
        public void AddCpuScore(Cpu cpuPlayer)
        {
            var currentScore = cpuPlayer.GetScore();
            currentScore += 1;
            cpuPlayer.SetScore(currentScore);
        }

        /// <summary>
        /// Checking the tiles and different patterns of the TicTacToe game for who has won
        /// </summary>
        public GameAnnouncements CheckWinner(List<KeyValuePair<Button, int>> tiles)
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
                        return GameAnnouncements.PLAYER_WINS;
                    }
                    else if (isMatchCPU)
                    {
                        return GameAnnouncements.CPU_WINS;
                    }

                    if (tiles.All(x => x.Key.Text != string.Empty))
                    {
                        return GameAnnouncements.TIE;
                    }
                }
            }

            return GameAnnouncements.ONGOING;
        }

        /// <summary>
        /// Simplified AI version where the CPU is only looking for empty squares to put its selection on.
        /// </summary>
        /// <param name="selectedTile">The selected tile by the CPI</param>
        /// <param name="board">The board where the tiles are placed</param>
        /// <param name="cpuPlayer">The CPU player that makes a selection</param>
        public void ComputerSelectionEasy(Button selectedTile, List<Button> board, Cpu cpuPlayer)
        {
            // If selection already contains an disabled button with the players choice, than a new tile is being searched for
            do
            {
                var selection = randomSelection.Next(board.Count);
                selectedTile = board[selection];
            }
            while (selectedTile.Text != string.Empty && board.Any(x => x.Enabled == true));

            FillInSelectedTile(selectedTile, cpuPlayer);
        }

        /// <summary>
        /// Improved AI where the CPU is going for better strategic.
        /// </summary>
        /// <param name="selectedTile">The selected tile by the CPI</param>
        /// <param name="board">The board where the tiles are placed</param>
        /// <param name="cpuPlayer">The CPU player that makes a selection</param>
        public void ComputerSelectionIntermediate(Button selectedTile, List<Button> board, Cpu cpuPlayer, Player player)
        {
            var cornerTiles = new List<int>()
            {
                0, 2, 6, 8
            };

            do
            {
                var tempSelectedTile = selectedTile;
                var selection = randomSelection.Next(board.Count);

                // Check the corners first. Did the player select the first tile in one of the corners? CPU follows up on that
                if (board.Count(x=>x.Text == player.GetUserIcon()) == 1)
                {
                    do
                    {
                        selection = randomSelection.Next(board.Count);

                        // Check if selection falls within corners of the board
                        if (selection == 0 || selection == 2 || selection == 6 || selection == 8)
                        {
                            selectedTile = board[selection];
                        }
                    }
                    while (!cornerTiles.Any(x => selection == x));
                }
                else
                {
                    foreach (var tile in board)
                    {
                        // Check if board tiles was not set by CPU
                        if (tile.Text != cpuPlayer.GetUserIcon() && tile.Text != string.Empty)
                        {
                            // Check on horizontal lines
                            tileIsMatched = CheckHorizontalLines(selectedTile, board, player.GetUserIcon());

                            // Check on vertical lines
                            tileIsMatched = CheckVerticalLines(selectedTile, board, player.GetUserIcon());

                            // Check on cross lines
                            tileIsMatched = CheckCrossLines(selectedTile, board, player.GetUserIcon());
                        }
                    }
                }

                //if(selectedTile.Text == StringConstants.TILE_IS_NOT_A_MATCH)
                if(!tileIsMatched.Value)
                {
                    selection = randomSelection.Next(board.Count);
                    selectedTile = board[selection];
                }

            }
            while (tileIsMatched.Key.Text != string.Empty && board.Any(x => x.Enabled == true));

            FillInSelectedTile(selectedTile, cpuPlayer);
        }

        /// <summary>
        /// Better AI version where the CPU is trying to block the users choice.
        /// </summary>
        /// <param name="selectedTile">The selected tile by the CPI</param>
        /// <param name="board">The board where the tiles are placed</param>
        /// <param name="cpuPlayer">The CPU player that makes a selection</param>
        public void ComputerSelectionHard(Button selectedTile, List<Button> board, Cpu cpuPlayer)
        {
            // Check the corners first. Did the player put on of theirs in the corner? CPU blocks the player and put its selection in the middle


        }

        /// <summary>
        /// Fills in the selected tile on the board.
        /// </summary>
        /// <param name="selectedTile">The selected tile from the CPU</param>
        /// <param name="cpuPlayer">The player</param>
        private void FillInSelectedTile(Button selectedTile, Cpu cpuPlayer)
        {
            if (selectedTile.Text.Equals(string.Empty))
            {
                selectedTile.Text = cpuPlayer.GetUserIcon();
                selectedTile.Enabled = false;
                selectedTile.BackColor = Color.PaleVioletRed;
            }
        }

        private KeyValuePair<Button, bool> CheckHorizontalLines(Button selectedTile, List<Button> board, string playerIcon)
        {
            // First row
            if (board[0].Text == playerIcon && board[1].Text == playerIcon)
            {
                selectedTile = board[2];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[1].Text == playerIcon && board[2].Text == playerIcon)
            {
                selectedTile = board[0];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[0].Text == playerIcon && board[2].Text == playerIcon)
            {
                selectedTile = board[1];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            // Second row
            if (board[3].Text == playerIcon && board[4].Text == playerIcon)
            {
                selectedTile = board[5];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[4].Text == playerIcon && board[5].Text == playerIcon)
            {
                selectedTile = board[3];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[3].Text == playerIcon && board[5].Text == playerIcon)
            {
                selectedTile = board[4];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            // Third row
            if (board[6].Text == playerIcon && board[7].Text == playerIcon)
            {
                selectedTile = board[8];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[7].Text == playerIcon && board[8].Text == playerIcon)
            {
                selectedTile = board[6];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[6].Text == playerIcon && board[8].Text == playerIcon)
            {
                selectedTile = board[7];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);

                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            tileIsMatched = tileIsMatched.Value == true ? new KeyValuePair<Button, bool>(selectedTile, true) : new KeyValuePair<Button, bool>(selectedTile, false);
            //selectedTile.Text = selectedTile.Text == StringConstants.TILE_IS_MATCH ? StringConstants.TILE_IS_MATCH : StringConstants.TILE_IS_NOT_A_MATCH;
            return tileIsMatched;
        }

        private KeyValuePair<Button, bool> CheckVerticalLines(Button selectedTile, List<Button> board, string playerIcon)
        {
            // First row
            if (board[0].Text == playerIcon && board[3].Text == playerIcon)
            {
                selectedTile = board[6];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[3].Text == playerIcon && board[6].Text == playerIcon)
            {
                selectedTile = board[0];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[0].Text == playerIcon && board[6].Text == playerIcon)
            {
                selectedTile = board[3];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            // Second row
            if (board[1].Text == playerIcon && board[4].Text == playerIcon)
            {
                selectedTile = board[7];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[4].Text == playerIcon && board[7].Text == playerIcon)
            {
                selectedTile = board[1];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[1].Text == playerIcon && board[7].Text == playerIcon)
            {
                selectedTile = board[4];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            // Third row
            if (board[2].Text == playerIcon && board[5].Text == playerIcon)
            {
                selectedTile = board[8];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[5].Text == playerIcon && board[8].Text == playerIcon)
            {
                selectedTile = board[2];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[2].Text == playerIcon && board[8].Text == playerIcon)
            {
                selectedTile = board[5];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }
            
            tileIsMatched = tileIsMatched.Value == true ? new KeyValuePair<Button, bool>(selectedTile, true) : new KeyValuePair<Button, bool>(selectedTile, false);

            //selectedTile.Text = selectedTile.Text == StringConstants.TILE_IS_MATCH ? StringConstants.TILE_IS_MATCH : StringConstants.TILE_IS_NOT_A_MATCH;
            return tileIsMatched;
        }

        private KeyValuePair<Button, bool> CheckCrossLines(Button selectedTile, List<Button> board, string playerIcon)
        {
            // First cross
            if (board[0].Text == playerIcon && board[4].Text == playerIcon)
            {
                selectedTile = board[8];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[4].Text == playerIcon && board[8].Text == playerIcon)
            {
                selectedTile = board[0];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[0].Text == playerIcon && board[8].Text == playerIcon)
            {
                selectedTile = board[4];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            // Second cross
            if (board[2].Text == playerIcon && board[4].Text == playerIcon)
            {
                selectedTile = board[6];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[4].Text == playerIcon && board[6].Text == playerIcon)
            {
                selectedTile = board[2];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            if (board[2].Text == playerIcon && board[6].Text == playerIcon)
            {
                selectedTile = board[4];
                tileIsMatched = new KeyValuePair<Button, bool>(selectedTile, true);
                //selectedTile.Text = StringConstants.TILE_IS_MATCH;
            }

            tileIsMatched = tileIsMatched.Value == true ? new KeyValuePair<Button, bool>(selectedTile, true) : new KeyValuePair<Button, bool>(selectedTile, false);

            //selectedTile.Text = selectedTile.Text == StringConstants.TILE_IS_MATCH ? StringConstants.TILE_IS_MATCH : StringConstants.TILE_IS_NOT_A_MATCH;
            return tileIsMatched;
        }
    }
}
