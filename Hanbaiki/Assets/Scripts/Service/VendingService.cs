using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class VendingService
    {
        private static int capacity = 6;
        private static Dictionary<LocationObject, VendData> machines = new Dictionary<LocationObject, VendData>();

        static VendingService()
        {
            var locations = AssetLoader.LoadObjects<LocationObject>();
            foreach (var loc in locations)
            {
                machines.Add(loc, new VendData() { location = loc });
            }
        }

        public static bool CanAdd(LocationObject loc, ItemObject item)
        {
            var items = machines[loc].items;

            return items.ContainsKey(item) || items.Count < capacity;
        }

        public static void Add(LocationObject loc, ItemObject item)
        {
            if (!CanAdd(loc, item)) return;

            var items = machines[loc].items;
            if (items.ContainsKey(item))
            {
                items[item]++;
            }
            else
            {
                items.Add(item, 1);
            }
        }

        public static void Update()
        {
            foreach (var loc in machines.Keys)
            {
                var items = machines[loc].items;
                foreach (var item in items.Keys)
                {
                    int rand = Random.Range(1, 101);
                    if (rand <= GetValue(item, loc.region))
                    {
                        items[item]--;
                        if (items[item] <= 0)
                        {
                            items.Remove(item);
                        }
                        PlayerService.AddMoney(item.cost);
                    }
                }
            }
        }

        public static VendData GetData(LocationObject loc)
        {
            return machines[loc];
        }

        public static bool FlavorMatch(ItemObject item, RegionObject region)
        {
            return item.flavor == region.favFlavor;
        }

        public static bool PrepMatch(ItemObject item, RegionObject region)
        {
            return item.prep == region.favPrep;
        }

        public static bool ColorMatch(ItemObject item, RegionObject region)
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

        public static bool TempMatch(ItemObject item, RegionObject region)
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

        public static int GetValue(ItemObject item, RegionObject region)
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