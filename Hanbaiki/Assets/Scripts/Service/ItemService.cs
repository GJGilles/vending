using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class ItemService
    {
        private static List<ItemObject> items = new List<ItemObject>();

        static ItemService()
        {
            items = AssetLoader.LoadObjects<ItemObject>();
        }

        public static ItemObject Get(int id)
        {
            return items[id];
        }

        public static List<ItemObject> GetCurrent()
        {
            return items.Where(i => i.unlocked && i.input).ToList();
        }

        public class Data : DataService<Dictionary<int, bool>>
        {
            protected override string name => "items";

            protected override Dictionary<int, bool> GetData()
            {
                return items
                  .GroupBy(x => x.GetHashCode())
                  .ToDictionary(x => x.Key, x => x.First().unlocked);
            }

            protected override void SetData(Dictionary<int, bool> data)
            {
                for (var i = 0; i < items.Count; i++)
                {
                    if (data.ContainsKey(items[i].GetHashCode()))
                    {
                        items[i].unlocked = data[items[i].GetHashCode()];
                    }
                }
            }
        }
    }
}