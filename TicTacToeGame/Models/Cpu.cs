
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class Cpu : IUser
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string UserIcon { get; set; }
        public GameAnnouncements User { get; set; }

        public Cpu()
        {
            Name = "CPU";
            Score = 0;
            UserIcon = "O";
            User = GameAnnouncements.CPU_WINS;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetScore()
        {
            return Score;
        }

        public string GetUserIcon()
        {
            return UserIcon;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetScore(int score)
        {
            Score = score;
        }

        public void SetUserIcon(string userIcon)
        {
            UserIcon = userIcon;
        }
    }
}
