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
        }
    }
}
