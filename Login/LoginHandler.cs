using GTANetworkAPI;
using GermanReallife.Datenbank;
using GermanReallife.Account;

namespace GermanReallife.Login
{
    public class LoginHandler : Script
    {
        [RemoteEvent("OnPlayerCharacterAttempt")]
        public void OnPlayerCharacterAttempt(Client client, string vorname, string nachname)
        {
            if (vorname != "" && nachname != "")
            {
                if (Database.GetData<PlayerStats>("nachname", nachname) != null)
                {
                    client.SendChatMessage("~r~Nachname schon vergeben");
                    client.TriggerEvent("CharacterResult", 0);
                }
                else
                {
                    PlayerStats pStats = PlayerHelper.GetPlayerStats(client);
                    pStats.vorname = vorname;
                    pStats.nachname = nachname;
                    Database.Upsert(pStats);
                    client.TriggerEvent("CharacterResult", 1);
                    client.SendNotification($"~g~Du heißt nun {pStats.vorname}_{pStats.nachname}");
                }
            }
            else
            {
                client.SendChatMessage("~r~Vor/Nachname wurden nicht ausgefüllt");
                client.TriggerEvent("CharacterResult", 0);
            }
        }

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
        public void OnPlayerRegisterAttempt(Client player, string password)
        {
            PlayerInfo playerInfo = new PlayerInfo(player.Name, password, false);
            if (Database.GetData<PlayerInfo>("username", player.Name) != null)
            {
                player.TriggerEvent("RegisterResult", 0);
            }
            else
            {
                player.TriggerEvent("RegisterResult", 1);
                Database.Upsert(playerInfo);
            }
        }
    }
}
