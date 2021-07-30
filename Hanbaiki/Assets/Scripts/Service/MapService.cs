using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class MapService
    {
        private static List<LocationObject> locations = new List<LocationObject>();

        static MapService()
        {
            locations = AssetLoader.LoadObjects<LocationObject>();
        }

        public static LocationObject Get(int id)
        {
            return locations[id];
        }

        public static List<LocationObject> GetCurrent()
        {
            return locations.Where(i => i.unlocked).ToList();
        }
    }
}