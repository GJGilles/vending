﻿using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System.Collections.Generic;
using System.Linq;
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
            FileService.Add(new Data().GetService());
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
                    if (stack.item is FoodObject && rand <= GetValue((FoodObject)stack.item, loc))
                    {
                        m.Remove(StackMoveEnum.One, i);
                        QuestService.Update(loc, item);

                        FoodObject food = (FoodObject)item;
                        loc.popularity.UpdateFlavor(food.flavor, -4);
                        loc.popularity.UpdatePrep(food.prep, -4);
                        PlayerService.AddMoney(food.sell);
                    }
                }
            }
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

        public static int GetValue(FoodObject item, LocationObject loc)
        {
            int chance = 10;
            chance += (20 * loc.popularity.GetFlavor(item.flavor)) / 100;
            chance += (20 * loc.popularity.GetPrep(item.prep)) / 100;
            if (ColorMatch(item, loc.region)) chance += 20;
            if (TempMatch(item, loc.region)) chance += 20;
            return chance;
        }

        public class Data : DataService<Dictionary<int, InventoryData>>
        {
            protected override string name => "vending";

            protected override Dictionary<int, InventoryData> GetData()
            {
                return machines.ToDictionary(x => x.Key.GetHashCode(), x => x.Value.Save());
            }

            protected override void SetData(Dictionary<int, InventoryData> data)
            {
                foreach (var val in data)
                {
                    machines[MapService.Get(val.Key)].Load(val.Value);
                }
            }
        }
    }
}