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
    }
}