using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using GermanReallife.Account;
using GermanReallife.Gobal;
using GermanReallife.Datenbank;

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
            PlayerInfo pInfo = Database.GetData<PlayerInfo>("username", client.Name);
            Client[] clients = NAPI.Pools.GetAllPlayers().FindAll(x => x.Position.DistanceTo2D(client.Position) <= Vars.CHAT_RANGES).ToArray();
            {
                for(int i = 0; i < clients.Length; i++)
                {
                    if (!clients[i].Exists) continue;
                    clients[i].SendChatMessage($"{pInfo.vorname}_{pInfo.nachname} sagt: {message}");
                }
            }
        }
    }
}
