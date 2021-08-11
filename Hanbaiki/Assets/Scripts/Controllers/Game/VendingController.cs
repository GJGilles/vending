using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class VendingController : MonoBehaviour
    {
        public List<VendingSlotController> slots = new List<VendingSlotController>();

        private int location = 0;

        private void Update()
        {
            var data = VendingService.GetInventory(MapService.GetCurrent()[location]);
            for (int i = 0; i < data.GetSize(); i++)
            {
                var stack = data.Peek(i);
                if (stack == null)
                {
                    slots[i].Set(null, "");
                }
                else
                {
                    slots[i].Set(stack.item.spr, stack.number.ToString());
                }
            }
        }
    }
}