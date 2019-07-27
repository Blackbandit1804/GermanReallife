using System;
using GTANetworkAPI;
using GermanReallife.Gobal;
using GermanReallife.Blips;
using GermanReallife.Account;
using GermanReallife.Datenbank;

namespace GermanReallife
{
    public class Main : Script
    {
        // ======================= [OnResource Start] =======================
        [ServerEvent(Event.ResourceStart)]
        public void ResourceStart()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("(~~~~~~~~~~~~~~~~~~~~~)");
            Console.WriteLine($"( Script by {Vars.Coder} 2019) gestartet");
            Console.WriteLine($"( Version {Vars.Server_Version})");
            Console.WriteLine("(~~~~~~~~~~~~~~~~~~~~~)");
            Console.ResetColor();

           
            NAPI.Server.SetCommandErrorMessage("[~r~SERVER:~w~] Dieser Command Existiert nicht!");

            // ======================= [Server Setup] =======================
            ServerSetup();
        }

        // ======================= [PlayerConnected] =======================
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Client player)
        {
            PlayerInfo pInfo = Database.GetData<PlayerInfo>("username", player.Name);
            player.SendChatMessage($"╔═════Willkommen auf ~b~{Vars.Servername}~w~═════╗");
            player.SendChatMessage($"╠Server Version: ~b~{Vars.Server_Version}");
            player.SendChatMessage($"╠Spieler Name: ~b~ {pInfo.vorname}_{pInfo.nachname}");
            player.SendChatMessage("╚═══════════════════════════════╝");
        }

        private void ServerSetup()
        {
           NAPI.Server.SetGlobalServerChat(false);
           NAPI.Server.SetAutoSpawnOnConnect(false);
           NAPI.Server.SetAutoRespawnAfterDeath(false);

            // ---- Minimaps erstellen
            FrakBlip.FrakBlipsSetup();
        }
    }
}
