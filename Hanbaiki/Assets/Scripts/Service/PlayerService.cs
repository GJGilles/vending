namespace Assets.Scripts.Service
{
    public static class PlayerService
    {
        private static int money = 0;

        public static int GetMoney()
        {
            return money;
        }

        public static void AddMoney(int amount)
        {
            money += amount;
        }
    }
}