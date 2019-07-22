using System;
using System.Collections.Generic;
using System.Text;

namespace GermanReallife.Gobal
{
    public static class Vars
    {
        /* Allgemein Strings */
        public static string Servername = "German Reallife";
        public static string Server_Version = "0.0.2";
        public static string Coder = "MagicPotter";

        /* Geschlecht */
        public const int SEX_NONE = -1;
        public const int SEX_MALE = 0;
        public const int SEX_FEMALE = 1;

        /* Telefonnummer */
        public const int NUMBER_POLIZEI = 133;
        public const int NUMBER_RETTUNG = 144;
        public const int NUMBER_NEWS = 114;
        public const int NUMBER_ADAC = 111;
        public const int NUMBER_TAXI = 878;

        /* Fraktion */
        public const int FACTION_NONE = 0;
        public const int FACTION_POLIZEI = 1;
        public const int FACTION_ROTESKREUZ = 2;
        public const int FACTION_NEWS = 3;
        public const int FACTION_ADAC = 4;
        public const int MAX_FACTION_VEHICLES = 100;

        /* JOBS */
        public const int JOB_NONE = 0;
        public const int JOB_BAUER = 1;
        public const int JOB_TAXIFAHRER = 2;
        public const int JOB_MULLMANN = 3;
        public const int JOB_TRUCKER = 4;

        /* Administrative Ranks */
        public const int STAFF_NONE = 0;
        public const int STAFF_SUPPORT = 1;
        public const int STAFF_GAME_MASTER = 2;
        public const int STAFF_S_GAME_MASTER = 3;
        public const int STAFF_ADMIN = 4;

        /* Chat */
        public const int CHAT_RANGES = 15;
    }
}
