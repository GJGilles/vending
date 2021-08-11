using Assets.Scripts.Controllers.Character;
using Assets.Scripts.Inventory;
using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameOutputController : SelectableController
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