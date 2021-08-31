using Assets.Scripts.Objects;
using PotatoTools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class PopularityService
    {
        private static List<int> flavor = new List<int>() { 20, 20, 20, 20, 20};
        private static List<int> prep = new List<int>() { 20, 20, 20, 20, 20 };

        static PopularityService()
        {
        }

        public static void UpdateFlavor(ItemFlavorEnum i, int amount)
        {
            amount = Mathf.CeilToInt(amount / 5f) * 5;
        }

        public static void UpdatePrep(ItemPrepEnum i, int amount)
        {
            amount = Mathf.CeilToInt(amount / 5f) * 5;
        }


        /*public class Data : DataService<Dictionary<int, bool>>
        {
            protected override string name => "items";

            protected override Dictionary<int, bool> GetData()
            {
            }

            protected override void SetData(Dictionary<int, bool> data)
            {
            }
        }*/
    }
}