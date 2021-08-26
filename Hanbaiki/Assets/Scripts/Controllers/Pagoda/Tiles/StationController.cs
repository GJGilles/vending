using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class StationController : SelectableController
    {
        [NonSerialized] public StationTileData data;

        public SplitInventoryController menuObject;

        private RecipeObject recipe;
        private float cooldown = 0f;

        private void Update()
        {
            cooldown -= Time.deltaTime;
            if (recipe != null && cooldown <= 0)
            {
                if (data.inventory.TryPush(new ItemStack(recipe.output, 1)) == null)
                {
                    recipe = null;
                }
            }
            else if (cooldown <= 0)
            {
                foreach (var r in data.station.recipes)
                {
                    bool input = true;
                    foreach (var i in r.input)
                    {
                        input = input && data.inventory.Find(i) != -1;
                    }

                    if (input)
                    {
                        foreach (var i in r.input)
                        {
                            data.inventory.Remove(StackMoveEnum.One, data.inventory.Find(i));
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
            inst.inventories = new List<ItemInventory>() { PlayerService.GetInventory(), data.inventory };
            inst.widths = new List<int>() { 4, 2 };
        }
        public ItemInventory GetInventory() { return data.inventory; }
    }
}