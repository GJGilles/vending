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
            VendData data = VendingService.GetData(MapService.GetCurrent()[location]);
            int idx = 0;
            foreach (var key in data.items.Keys)
            {
                slots[idx].Set(key.spr, data.items[key].ToString());
                idx++;
            }
        }
    }
}