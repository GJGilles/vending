using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Objects;
using Assets.Scripts.Controllers.Character;

namespace Assets.Scripts.Controllers.Game
{
    public class GameStationController : SelectableController
    {
        public StationObject station;

        public int size = 4;
        public GameObject menuObject;

        private RecipeObject recipe;
        private List<ItemObject> items = new List<ItemObject>();
        private PlayerController player;
        private InventorySelectController menu;

        private float cooldown = 0f;

        private void Update()
        {
            cooldown -= Time.deltaTime;
            if (recipe != null && cooldown <= 0)
            {
                if (items.Count + recipe.output.Count <= size)
                {
                    foreach (var i in recipe.output)
                        items.Add(i);

                    if (menu != null)
                        menu.SetItems(items);

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
                        input = input && items.Contains(i);
                    }

                    if (input)
                    {
                        foreach (var i in r.input)
                        {
                            items.Remove(items.Where(it => it == i).First());
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
            player = p;
            menu = Instantiate(menuObject, transform).GetComponent<InventorySelectController>();
            menu.selected.AddListener(Selected);
            menu.SetItems(items);
        }

        private void Selected(int idx)
        {
            if (!player.inventory.IsFull() && 0 <= idx && idx < items.Count)
            {
                player.inventory.TryPush(items[idx]);
                items.RemoveAt(idx);
            }
            else if (player.inventory.Peek() != null && CanAdd())
            {
                Add(player.inventory.TryPop());
            }
        }

        public bool CanAdd()
        {
            return items.Count < size;
        }

        public void Add(ItemObject item)
        {
            items.Add(item);
            if (menu != null)
                menu.SetItems(items);
        }
    }
}