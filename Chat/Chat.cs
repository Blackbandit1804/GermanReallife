using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using GermanReallife.Account;
using GermanReallife.Gobal;

namespace GermanReallife.Chat
{
    public class Chat : Script
    {
        public Chat()
        {
            // Global Chat deaktivieren
            NAPI.Server.SetGlobalServerChat(false);
        }

        [ServerEvent(Event.ChatMessage)]
        public void EventChatMessage(Client client, string message)
        {
            PlayerStats pStats = PlayerHelper.GetPlayerStats(client);
            Client[] clients = NAPI.Pools.GetAllPlayers().FindAll(x => x.Position.DistanceTo2D(client.Position) <= Vars.CHAT_RANGES).ToArray();
            {
                for(int i = 0; i < clients.Length; i++)
                {
                    if (!clients[i].Exists) continue;
                    clients[i].SendChatMessage($"{pStats.vorname}_{pStats.nachname} sagt: {message}");
                }
            }
        }
    }
}
