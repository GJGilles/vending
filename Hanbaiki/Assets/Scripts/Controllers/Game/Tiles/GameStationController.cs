using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Objects;

namespace Assets.Scripts.Controllers.Game
{
    public class GameStationController : GameTileController
    {
        public StationObject station;
        public int recipe = 0;

        public int size = 4;
        public GameObject menuObject;

        private GameSelectionController selecter;
        private List<ItemObject> items = new List<ItemObject>();
        private InventorySelectController menu;

        private float cooldown = 0f;
        private bool input = false;

        private void Update()
        {
            RecipeObject current = station.recipes[recipe];

            cooldown -= Time.deltaTime;
            if (input && cooldown <= 0)
            {
                if (items.Count + current.output.Count <= size)
                {
                    foreach (var i in current.output)
                        items.Add(i);

                    if (menu != null)
                        menu.SetItems(items);

                    input = false;
                }
            }
            else if (cooldown <= 0)
            {
                input = true;
                foreach (var i in current.input)
                {
                    input = input && items.Contains(i);
                }

                if (input)
                {
                    foreach (var i in current.input)
                    {
                        items.Remove(items.Where(it => it == i).First());
                    }
                    cooldown = current.time;
                }
            }
        }

        public override void Select(GameSelectionController selecter)
        {
            this.selecter = selecter;
            menu = Instantiate(menuObject, transform).GetComponent<InventorySelectController>();
            menu.selected.AddListener(Selected);
            menu.SetItems(items);
        }

        private void Selected(int idx)
        {
            if (idx < 0)
            {
                selecter.Deselect();
            }
            else if (!selecter.IsHolding() && idx < items.Count)
            {
                selecter.Take(items[idx]);
                items.RemoveAt(idx);
                selecter.Deselect();
            }
            else if (selecter.IsHolding() && CanAdd())
            {
                Add(selecter.Give());
            }
        }

        public override void Deselect()
        {
            Destroy(menu.gameObject);
            menu = null;
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