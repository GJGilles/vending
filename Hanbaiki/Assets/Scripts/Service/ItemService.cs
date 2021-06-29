using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class ItemService
    {
        private static Dictionary<ItemEnum, ItemData> items = new Dictionary<ItemEnum, ItemData>();

        static ItemService()
        {
            items.Add(ItemEnum.GTeaLeaves, new ItemData());
        }

        public static ItemData Get(ItemEnum id)
        {
            return items[id];
        }
    }
}