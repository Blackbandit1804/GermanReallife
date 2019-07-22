using System;
using GTANetworkAPI;
using GermanReallife.Datenbank;

namespace GermanReallife.Account
{
    public static class PlayerHelper
    {
        public static PlayerStats GetPlayerStats(Client client)
        {
            if (!client.HasData("ID")) return null;

            int client_id = client.GetData("ID");
            PlayerStats clientStats = Database.GetById<PlayerStats>(client_id);
            return clientStats;
        }

        public static Client GetClientByName(string name)
        {
            Client client = null;
            foreach (Client client_itr in NAPI.Pools.GetAllPlayers())
            {
                if (client.Name.ToLower() == name.ToLower())
                {
                    return client_itr;
                }
            }
            return client;
        }
    }
}
