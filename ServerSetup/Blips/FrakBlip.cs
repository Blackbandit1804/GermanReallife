using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTANetworkAPI;
namespace GermanReallife.Blips
{
    public static class FrakBlip
    {
        public static void FrakBlipsSetup()
        {
            //Polizeiwachen BLIPS
            Blip Polizei = NAPI.Blip.CreateBlip(60, new Vector3(427.6091, -981.9763, 30.71009), 1.0f, 38);
            NAPI.Blip.SetBlipName(Polizei, "Polizei Wache"); NAPI.Blip.SetBlipShortRange(Polizei, true);

            //Rettungswache BLIPS
            Blip Rettung = NAPI.Blip.CreateBlip(61, new Vector3(1151.196, -1529.605, 35.36937), 1.0f, 1);
            NAPI.Blip.SetBlipName(Rettung, "Rettungs Wache"); NAPI.Blip.SetBlipShortRange(Rettung, true);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("=============[Fraktion Blips wurden erstellt]=============");
            Console.ResetColor();
        }
    }
}
