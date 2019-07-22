using GTANetworkAPI;
using BCrypt;

namespace GermanReallife.Account
{
    public class PlayerInfo
    {
        public int _id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int loggedin { get; set; }
        public int banned { get; set; }
        public string bangrund { get; set; }

        public PlayerInfo() { }

        public PlayerInfo(string username, string password, bool loggedin)
        {
            this.username = username;
            this.password = BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
        }

        public bool CheckPassword(string input)
        {
            if (password == null) return false;

            return BCryptHelper.CheckPassword(input, this.password);
        }
    }
}
