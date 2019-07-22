using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace GermanReallife.Events
{
    public class PlayerDisconnect : Script
    {
      
        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Client player, DisconnectionType type, string reason)
        {
            switch (type)
            {
                case DisconnectionType.Left:
                    NAPI.Chat.SendChatMessageToAll("~b~" + player.Name + "~w~ hat den Server verlassen.");
                    break;
                case DisconnectionType.Timeout:
                    NAPI.Chat.SendChatMessageToAll("~b~" + player.Name + "~w~ timed out.");
                    break;

                case DisconnectionType.Kicked:
                    NAPI.Chat.SendChatMessageToAll("~b~" + player.Name + "~w~ wurde gekickt | Grund: " + reason);
                    break;
            }
        }
    }
}
