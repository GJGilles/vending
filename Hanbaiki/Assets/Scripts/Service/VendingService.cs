using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class VendingService
    {
        private static Dictionary<LocationObject, ItemInventory> machines = new Dictionary<LocationObject, ItemInventory>();

        static VendingService()
        {
            var locations = AssetLoader.LoadObjects<LocationObject>();
            foreach (var loc in locations)
            {
                machines.Add(loc, new ItemInventory(6));
            }
        }

        public static ItemInventory GetInventory(LocationObject loc)
        {
            return machines[loc];
        }

        public static void Update()
        {
            foreach (var loc in machines.Keys)
            {
                var m = machines[loc];
                for (int i = 0; i < m.GetSize(); i++)
                {
                    var stack = m.Peek(i);
                    if (stack == null) continue;

                    var item = stack.item;
                    int rand = Random.Range(1, 101);
                    if (stack.item is FoodObject && rand <= GetValue((FoodObject)stack.item, loc.region))
                    {
                        m.Remove(StackMoveEnum.One, i);
                        PlayerService.AddMoney(((FoodObject)item).cost);
                        QuestService.Update(loc, item);
                    }
                }
            }
        }

        public static bool FlavorMatch(FoodObject item, RegionObject region)
        {
            return item.flavor == region.favFlavor;
        }

        public static bool PrepMatch(FoodObject item, RegionObject region)
        {
            return item.prep == region.favPrep;
        }

        public static bool ColorMatch(FoodObject item, RegionObject region)
        {
            var weather = WeatherService.GetPrecip(region);
            switch (weather)
            {
                case PrecipEnum.Snow:
                    return item.color == ItemColorEnum.White;
                case PrecipEnum.Rain:
                    return item.color == ItemColorEnum.Green;
                case PrecipEnum.Overcast:
                    return item.color == ItemColorEnum.Black;
                default:
                case PrecipEnum.Clear:
                    return item.color == ItemColorEnum.Yellow;
                case PrecipEnum.Heatwave:
                    return item.color == ItemColorEnum.Red;
            }
        }

        public static bool TempMatch(FoodObject item, RegionObject region)
        {
            var temp = WeatherService.GetTemp(region);
            switch (temp)
            {
                case TempEnum.Freezing:
                    return item.temp == ItemTempEnum.Hot;
                case TempEnum.Cold:
                    return item.temp == ItemTempEnum.Warm;
                default:
                case TempEnum.Pleasant:
                    return item.temp == ItemTempEnum.Mild;
                case TempEnum.Warm:
                    return item.temp == ItemTempEnum.Cool;
                case TempEnum.Hot:
                    return item.temp == ItemTempEnum.Cold;
            }
        }

        public static int GetValue(FoodObject item, RegionObject region)
        {
            int chance = 10;
            if (FlavorMatch(item, region)) chance += 20;
            if (PrepMatch(item, region)) chance += 20;
            if (ColorMatch(item, region)) chance += 20;
            if (TempMatch(item, region)) chance += 20;
            return chance;
        }
    }
}