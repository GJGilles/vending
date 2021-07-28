using Assets.Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class StationService
    {
        private static List<StationObject> stations = new List<StationObject>();
        private static List<StationObject> current = new List<StationObject>();

        private static StationObject itemIn;
        private static StationObject itemOut;

        static StationService()
        {
            stations = AssetLoader.LoadObjects<StationObject>();

            // TODO: Fix this
            current = stations;
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
            return current;
        }

        public static bool IsInput(StationObject s)
        {
            return s == itemIn;
        }

        public static bool IsOutput(StationObject s)
        {
            return s == itemOut;
        }
    }
}