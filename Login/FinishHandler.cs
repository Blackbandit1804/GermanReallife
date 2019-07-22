using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using GermanReallife.Datenbank;
using GermanReallife.Account;
using GermanReallife.Gobal;

namespace GermanReallife.Login
{
    public static class FinishHandler
    {
        public static void FinishLogin(Client client)
        {
            int client_id = client.GetData("ID");
            PlayerStats playerStats = Database.GetById<PlayerStats>(client_id);

            if (playerStats == null)
            {
                playerStats = new PlayerStats();
                playerStats._id = client_id;
                Database.Upsert(playerStats);
            }

            if (playerStats.vorname == "None" || playerStats.nachname == "None")
            {
                client.SendChatMessage("~r~SERVER: ~w~Bitte wähle einen Vor/Nachname!");
                NAPI.ClientEvent.TriggerClientEvent(client, "StartCharBrowser");
                client.Position = playerStats.GetLastPosition();
                return;
            }
            else
            {
                client.SendChatMessage($"Willkommen, {playerStats.vorname} {playerStats.nachname} auf ~b~{Vars.Servername}");
                client.SendChatMessage($"~r~SERVER: ~w~Dies ist eine Entwickler Version von ~b~{Vars.Servername}!");
                client.SendChatMessage("~r~SERVER: ~w~Also sind Bug`s keine Seltenheit!");
                client.SendChatMessage($"~b~Name: {playerStats.vorname} {playerStats.nachname}");
                client.Position = playerStats.GetLastPosition();
                return;
            }
        }
    }
}
