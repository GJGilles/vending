using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class OutputController : SelectableController
    {
        public SplitInventoryController menuObject;

        [NonSerialized] public LocationTileData data;

        public override void Select()
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { PlayerService.GetInventory(), VendingService.GetInventory(data.loc) };
            inst.widths = new List<int>() { 4, 2 };
        }
    }
}