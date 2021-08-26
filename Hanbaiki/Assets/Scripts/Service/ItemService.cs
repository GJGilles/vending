using Assets.Scripts.Objects;
using PotatoTools;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Service
{
    public static class ItemService
    {
        private static List<IngredientObject> items = new List<IngredientObject>();

        static ItemService()
        {
            items = AssetLoader.LoadObjects<IngredientObject>();
        }

        public static ItemObject Get(int id)
        {
            return items[id];
        }

        public static List<IngredientObject> GetCurrent()
        {
            return items.Where(i => i.unlocked).ToList();
        }

        public class Data : DataService<Dictionary<int, bool>>
        {
            protected override string name => "items";

            protected override Dictionary<int, bool> GetData()
            {
                return items
                  .ToDictionary(x => x.GetHashCode(), x => x.unlocked);
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