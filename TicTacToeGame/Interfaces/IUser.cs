
namespace TicTacToe.Interfaces
{
    public interface IUser
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string UserIcon { get; set; }

        public string GetName();

        public int GetScore();

        public string GetUserIcon();

        public void SetName(string name);

        public void SetScore(int score);

        public void SetUserIcon(string userIcon); 
    }
}
