using Assets.Scripts.Objects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            return stations[id];
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