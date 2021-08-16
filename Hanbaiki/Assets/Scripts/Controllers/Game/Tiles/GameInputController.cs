using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameInputController : SelectableController
    {
        public SpriteRenderer spr;
        public SplitInventoryController menuObject;

        [NonSerialized] public IngredientObject item;

        private ItemInventory inventory = new ItemInventory(1);

        private void Start()
        {
            spr.sprite = item.spr;
            inventory.SetPermanent(0, item);

            // TODO: Remove test code
            inventory.Add(StackMoveEnum.All, new ItemStack(item, 10));
        }

        public override void Select(PlayerController p)
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { p.inventory, inventory };
            inst.widths = new List<int>() { 4, 1 };
            inst.OnClose.AddListener(() => p.isLocked = false);

            p.isLocked = true;
        }
    }
}