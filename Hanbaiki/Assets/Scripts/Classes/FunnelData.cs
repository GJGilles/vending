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
        public ItemInventory inventory = new ItemInventory(1);

        private int input = 0;
        private int output = 0;
        private ItemObject item;

        public FunnelData(int a, int b, ItemObject i)
        {
            input = a;
            output = b;
            item = i;

            TimeService.OnTick.AddListener(Update);
        }

        ~FunnelData()
        {
            TimeService.OnTick.RemoveListener(Update);
        }

        private void Update()
        {
            var a = PagodaService.GetTile(input);
            var b = PagodaService.GetTile(output);

            if (inventory.Peek(0) == null && a != null)
            {
                int idx = a.GetInventory().Find(item);
                if (idx >= 0)
                {
                    inventory.TryPush(a.GetInventory().Remove(StackMoveEnum.One, idx));
                }
            }
            
            if (inventory.Peek(0) != null && b != null)
            {
                var remain = b.GetInventory().TryPush(inventory.Remove(StackMoveEnum.All));
                if (remain != null)
                {
                    inventory.Add(StackMoveEnum.All, remain);
                }
            }
        }
    }
}