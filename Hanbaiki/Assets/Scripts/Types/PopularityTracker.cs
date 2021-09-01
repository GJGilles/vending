using Assets.Scripts.Objects;
using PotatoTools;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class PopularityTracker
    {
        private List<int> flavor = new List<int>() { 20, 20, 20, 20, 20};
        private List<int> prep = new List<int>() { 20, 20, 20, 20, 20 };

        public string GetText()
        {
            string text = "";
            var temp = new List<int>() { 0, 1, 2, 3, 4 };

            temp = temp.OrderByDescending(x => flavor[x]).ToList();
            text += flavor[temp[0]] + "% - " + ((ItemFlavorEnum)temp[0]).ToString() + "\n";
            text += flavor[temp[1]] + "% - " + ((ItemFlavorEnum)temp[1]).ToString() + "\n";
            text += "\n";

            temp = temp.OrderByDescending(x => prep[x]).ToList();
            text += prep[temp[0]] + "% - " + ((ItemPrepEnum)temp[0]).ToString() + "\n";
            text += prep[temp[1]] + "% - " + ((ItemPrepEnum)temp[1]).ToString() + "\n";
            text += "\n";

            return text;
        }

        public int GetFlavor(ItemFlavorEnum i)
        {
            return flavor[(int)i];
        }

        public int GetPrep(ItemPrepEnum i)
        {
            return prep[(int)i];
        }

        public void UpdateFlavor(ItemFlavorEnum i, int amount)
        {
            amount = Math.Max(Math.Min(amount, 100 - flavor[(int)i]), -flavor[(int)i]);
            int inc = Mathf.FloorToInt(amount / 4f);
            amount = 4 * inc;

            for (int j = 0; j < flavor.Count; j++)
            {
                if ((int)i != j)
                {
                    amount -= inc - Math.Max(Math.Min(inc, flavor[j]), flavor[j] - 100);
                }
            }

            for (int j = 0; j < flavor.Count; j++)
            {
                if ((int)i == j)
                {
                    flavor[j] += amount;
                }
                else
                {
                    flavor[j] -= Math.Max(Math.Min(inc, flavor[j]), flavor[j] - 100);
                }
            }
        }

        public void UpdatePrep(ItemPrepEnum i, int amount)
        {
            amount = Math.Max(Math.Min(amount, 100 - prep[(int)i]), -prep[(int)i]);
            int inc = Mathf.FloorToInt(amount / 4f);
            amount = 4 * inc;

            for (int j = 0; j < prep.Count; j++)
            {
                if ((int)i != j)
                {
                    amount -= inc - Math.Max(Math.Min(inc, prep[j]), prep[j] - 100);
                }
            }

            for (int j = 0; j < prep.Count; j++)
            {
                if ((int)i == j)
                {
                    prep[j] += amount;
                }
                else
                {
                    prep[j] -= Math.Max(Math.Min(inc, prep[j]), prep[j] - 100);
                }
            }
        }
    }
}