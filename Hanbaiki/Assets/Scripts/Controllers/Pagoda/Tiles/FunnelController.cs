using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class FunnelController : SelectableController
    {
        public SpriteRenderer spr;
        public SplitInventoryController menuObject;

        private Func<ItemInventory> Input;
        private Func<ItemInventory> Output;
        private ItemObject item;

        public float moveTime = 0.5f;
        private float moveRemain = 0;

        private ItemInventory inventory = new ItemInventory(1);

        private void Update()
        {
            var input = Input();
            var output = Output();

            moveRemain -= Time.deltaTime;
            if (inventory.Peek(0) == null && input != null)
            {
                int idx = input.Find(item);
                if (idx >= 0)
                {
                    inventory.Add(StackMoveEnum.All, input.Remove(StackMoveEnum.One, idx));
                    moveRemain = moveTime;
                }
            }
            else if (moveRemain < 0 && output != null)
            {
                var remain = output.TryPush(inventory.Remove(StackMoveEnum.All));
                if (remain != null)
                {
                    inventory.Add(StackMoveEnum.All, remain);
                }
            }
        }

        public void Set(Sprite sprite, Func<ItemInventory> input, Func<ItemInventory> output, ItemObject it)
        {
            spr.sprite = sprite;
            Input = input;
            Output = output;
            item = it;
        }

        public override void Select(PlayerController player)
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { player.inventory, inventory };
            inst.widths = new List<int>() { 4, 2 };
            inst.OnClose.AddListener(() => player.isLocked = false);

            player.isLocked = true;
        }
    }
}