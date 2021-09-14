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
    public class TileController : SelectableController
    {
        public SplitInventoryController menuObject;

        [NonSerialized] public TileData data;

        private void Start()
        {
            data.SetSprite(gameObject);
        }

        public override void Select()
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { PlayerService.GetInventory(), data.GetInventory() };
            inst.widths = new List<int>() { 4, 2 };
        }
    }
}