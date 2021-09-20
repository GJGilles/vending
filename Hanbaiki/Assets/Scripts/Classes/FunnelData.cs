using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Inventory;
using System;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class FunnelData
    {
        private int input = 0;
        private int output = 0;

        public FunnelData(int a, int b)
        {
            input = a;
            output = b;

            TimeService.OnTick.AddListener(Update);
        }

        ~FunnelData()
        {
            TimeService.OnTick.RemoveListener(Update);
        }

        public int Input { get => input; }
        public int Output { get => output; }

        private void Update()
        {
            var a = PagodaService.GetTile(input);
            var b = PagodaService.GetTile(output);

            if (a != null && b != null)
            {
                var stack = a.GetInventory().TryPull();

                if (stack != null)
                    stack = b.GetInventory().TryPush(stack);

                if (stack != null)
                    a.GetInventory().TryPush(stack);
            }
        }
    }
}