using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class ItemService
    {
        private static List<ItemObject> items = new List<ItemObject>();

        public static void Load(List<ItemObject> i)
        {
            items = i;
        }

        public static ItemObject Get(int id)
        {
            return items[id];
        }
    }
}