using GTANetworkAPI;
using GermanReallife.Gobal;

namespace GermanReallife.Account
{
    public class PlayerStats
    {
        public int _id { get; set; }
        public int adminrank { get; set; }
        public double money { get; set; } = Vars.startMoney;
        public double bank { get; set; }
        public int bkonto { get; set; }
        public int bkontopin { get; set; }
        public int fraktion { get; set; }
        public int fleader { get; set; }
        public int fmember { get; set; }
        public int frank { get; set; }
        public int warns { get; set; }
        public int wantedlevel { get; set; }
        public int cuff { get; set; }
        public int jail { get; set; }
        public int jailtime { get; set; }
        public double[] last_location { get; set; } = new double[] { -391.6, 1169.07, 325.85 };
        public int autoschein { get; set; }
        public int motorradschein { get; set; }
        public int bootsschein { get; set; }
        public int waffenschein { get; set; }

        public Vector3 GetLastPosition()
        {
            return new Vector3(last_location[0], last_location[1], last_location[2]);
        }

        public bool AddMoney(double money_to_add)
        {
            if (money_to_add <= 0) return false;
            money += money_to_add;
            return true;
        }

        public bool SubMoney(double money_to_sub)
        {
            if (money_to_sub <= 0) return false;

            if (money_to_sub > money) return false;

            money -= money_to_sub;

            if (money < 0)
            {
                money = 0;
            }
            return true;
        }

        public bool HasEnoughMoney(double amount)
        {
            if (money >= amount) return true;
            return false;
        }
    }
}
