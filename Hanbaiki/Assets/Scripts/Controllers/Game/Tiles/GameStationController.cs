using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Objects;
using Assets.Scripts.Controllers.Character;
using Assets.Scripts.Inventory;
using System;

namespace Assets.Scripts.Controllers.Game
{
    public class GameStationController : SelectableController
    {
        [NonSerialized] public StationObject station;

        public int size = 4;
        public SplitInventoryController menuObject;

        private RecipeObject recipe;
        private ItemInventory inventory = new ItemInventory(4);

        private float cooldown = 0f;

        private void Update()
        {
            cooldown -= Time.deltaTime;
            if (recipe != null && cooldown <= 0)
            {
                if (inventory.TryPush(new ItemStack(recipe.output, 1)) == null)
                {
                    recipe = null;
                }
            }
            else if (cooldown <= 0)
            {
                foreach (var r in station.recipes)
                {
                    bool input = true;
                    foreach (var i in r.input)
                    {
                        input = input && inventory.Find(i) != -1;
                    }

                    if (input)
                    {
                        foreach (var i in r.input)
                        {
                            inventory.Remove(StackMoveEnum.One, inventory.Find(i));
                        }
                        cooldown = r.time;
                        recipe = r;
                        break;
                    }
                }
            }
        }

        public override void Select(PlayerController p)
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { p.inventory, inventory };
            inst.widths = new List<int>() { 4, 2 };
            inst.OnClose.AddListener(() => p.isLocked = false);

            p.isLocked = true;
        }
    }
}