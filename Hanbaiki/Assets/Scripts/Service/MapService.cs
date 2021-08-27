using Assets.Scripts.Objects;
using PotatoTools;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Service
{
    public static class MapService
    {
        private static List<LocationObject> locations = new List<LocationObject>();

        static MapService()
        {
            locations = AssetLoader.LoadObjects<LocationObject>();
            FileService.Add(new Data().GetService());
        }

        public static LocationObject Get(int id)
        {
            return locations.Find(x => x.GetHashCode() == id);
        }

        public static List<LocationObject> GetCurrent()
        {
            return locations.Where(i => i.unlocked).ToList();
        }

        public class Data : DataService<Dictionary<int, bool>>
        {
            protected override string name => "locations";

            protected override Dictionary<int, bool> GetData()
            {
                return locations
                  .ToDictionary(x => x.GetHashCode(), x => x.unlocked);
            }

            protected override void SetData(Dictionary<int, bool> data)
            {
                for (var i = 0; i < locations.Count; i++)
                {
                    if (data.ContainsKey(locations[i].GetHashCode()))
                    {
                        locations[i].unlocked = data[locations[i].GetHashCode()];
                    }
                }
            }
        }
    }
}