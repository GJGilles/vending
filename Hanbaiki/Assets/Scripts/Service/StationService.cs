using Assets.Scripts.Objects;
using PotatoTools;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Service
{
    public static class StationService
    {
        private static List<StationObject> stations = new List<StationObject>();

        static StationService()
        {
            stations = AssetLoader.LoadObjects<StationObject>();
            FileService.Add(new Data().GetService());
        }

        public static StationObject Get(int id)
        {
            return stations.Find(x => x.GetHashCode() == id);
        }

        public static List<StationObject> GetAll() 
        {
            return stations;
        }

        public static List<StationObject> GetCurrent()
        {
            return stations.Where(s => s.unlocked).ToList();
        }

        public class Data : DataService<Dictionary<int, bool>>
        {
            protected override string name => "stations";

            protected override Dictionary<int, bool> GetData()
            {
                return stations
                  .ToDictionary(x => x.GetHashCode(), x => x.unlocked);
            }

            protected override void SetData(Dictionary<int, bool> data)
            {
                for (var i = 0; i < stations.Count; i++)
                {
                    if (data.ContainsKey(stations[i].GetHashCode()))
                    {
                        stations[i].unlocked = data[stations[i].GetHashCode()];
                    }
                }
            }
        }
    }
}