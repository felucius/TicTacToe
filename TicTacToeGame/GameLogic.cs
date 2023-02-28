namespace TicTacToe
{
    public class GameLogic
    {
        readonly List<KeyValuePair<Button, int>> board;

        public GameLogic()
        {
            board = new List<KeyValuePair<Button, int>>();
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
            foreach(var tile in tiles)
            {
                count += 1;
                board.Add(new KeyValuePair<Button, int>(tile, count));
            }

            return board;
        }
    }
}
