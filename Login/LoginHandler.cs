using GTANetworkAPI;
using GermanReallife.Datenbank;
using GermanReallife.Account;

namespace GermanReallife.Login
{
    public class LoginHandler : Script
    {
        [RemoteEvent("OnPlayerLoginAttempt")]
        public void OnPlayerLoginAttempt(Client player, string password)
        {
            PlayerInfo playerLookup = Database.GetData<PlayerInfo>("username", player.Name);
            if (playerLookup.CheckPassword(password))
            {
                if(playerLookup.banned == 1)
                {
                    player.TriggerEvent("LoginResult", 2);
                }
                else
                {
                    player.TriggerEvent("LoginResult", 1);
                    player.SetData("ID", playerLookup._id);
                    playerLookup.loggedin = 1;
                    Database.Update(playerLookup);
                    FinishHandler.FinishLogin(player);
                }
            }
            else
            {
                player.TriggerEvent("LoginResult", 0);
            }
        }

        [RemoteEvent("OnPlayerRegisterAttempt")]
        public void OnPlayerRegisterAttempt(Client player, string vorname, string nachname, string password)
        {
            PlayerInfo playerInfo = new PlayerInfo(player.Name, vorname, nachname, password, false);

            if (vorname != "" && nachname != "")
            {
                if (Database.GetData<PlayerInfo>("username", player.Name) != null)
                {
                    player.TriggerEvent("RegisterResult", 3);
                }
                else
                {
                    if (Database.GetData<PlayerInfo>("nachname", nachname) != null)
                    {
                        player.TriggerEvent("RegisterResult", 4);
                    }
                    else
                    {
                        player.TriggerEvent("RegisterResult", 1);
                        Database.Upsert(playerInfo);
                    }
                }
            }
            else
            {
                player.TriggerEvent("RegisterResult", 2);
            }
        }
    }
}
