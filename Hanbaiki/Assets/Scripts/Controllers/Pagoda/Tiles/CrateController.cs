using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CrateController : SelectableController
    {
        public SpriteRenderer spr;
        public SplitInventoryController menuObject;

        [NonSerialized] public CrateTileData data;

        private void Start()
        {
            spr.sprite = data.item.spr;
            data.inventory.SetPermanent(0, data.item);
        }

        public override void Select(PlayerController p)
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { p.inventory, data.inventory };
            inst.widths = new List<int>() { 4, 1 };
            inst.OnClose.AddListener(() => p.isLocked = false);

            p.isLocked = true;
        }

        public ItemInventory GetInventory() { return data.inventory; }
    }
}