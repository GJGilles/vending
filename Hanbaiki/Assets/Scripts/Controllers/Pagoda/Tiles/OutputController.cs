using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers
{
    public class OutputController : SelectableController
    {
        public SplitInventoryController menuObject;

        [NonSerialized] public LocationObject location;

        public override void Select(PlayerController p)
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { p.inventory, VendingService.GetInventory(location) };
            inst.widths = new List<int>() { 4, 2 };
            inst.OnClose.AddListener(() => p.isLocked = false);

            p.isLocked = true;
        }
    }
}