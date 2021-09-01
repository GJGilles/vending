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
            amount = Math.Min(amount, 100 - flavor[(int)i]);
            int inc = Mathf.FloorToInt(amount / 4f);
            amount = 4 * inc;

            for (int j = 0; j < flavor.Count; j++)
            {
                if ((int)i != j)
                {
                    amount -= inc - Mathf.Min(inc, flavor[j]);
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
                    flavor[j] -= Math.Min(inc, flavor[j]);
                }
            }
        }

        public void UpdatePrep(ItemPrepEnum i, int amount)
        {
            amount = Math.Min(amount, 100 - prep[(int)i]);
            int inc = Mathf.FloorToInt(amount / 4f);
            amount = 4 * inc;

            for (int j = 0; j < prep.Count; j++)
            {
                if ((int)i != j)
                {
                    amount -= inc - Mathf.Min(inc, prep[j]);
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
                    prep[j] -= Math.Min(inc, prep[j]);
                }
            }
        }
    }
}