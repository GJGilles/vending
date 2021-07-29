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
    }
}