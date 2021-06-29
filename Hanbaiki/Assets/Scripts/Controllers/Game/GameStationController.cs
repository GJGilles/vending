using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameStationController : GameTileController
    {
        public StationEnum station = StationEnum.ItemIn;
        public int recipe = 0;
        public ItemSpriteLoader itemSprites;

        public int size = 4;
        public GameObject menuObject;

        private GameSelectionController selecter;
        private List<ItemData> items = new List<ItemData>();
        private InventorySelectController menu;

        private float cooldown = 0f;
        private bool input = false;

        private void Update()
        {
            RecipeData current = StationService.Get(station).recipes[recipe];

            cooldown -= Time.deltaTime;
            if (input && cooldown <= 0)
            {
                if (items.Count + current.output.Count <= size)
                {
                    foreach (var id in current.output)
                        items.Add(ItemService.Get(id));
                    input = false;
                }
            }
            else if (cooldown <= 0)
            {
                input = true;
                foreach (var id in current.input)
                {
                    input = input && items.Select(i => i.id).Contains(id);
                }

                if (input)
                {
                    foreach (var id in current.input)
                    {
                        items.Remove(items.Where(i => i.id == id).First());
                    }
                    cooldown = current.time;
                }
            }
        }

        public override void Select(GameSelectionController selecter)
        {
            this.selecter = selecter;
            menu = Instantiate(menuObject, transform).GetComponent<InventorySelectController>();
            menu.sprites = itemSprites;
            menu.selected.AddListener(Selected);
            menu.SetItems(items);
        }

        private void Selected(int idx)
        {
            if (idx < items.Count)
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
            Destroy(menu);
            menu = null;
        }

        public bool CanAdd()
        {
            return items.Count < size;
        }

        public void Add(ItemData item)
        {
            items.Add(item);
            if (menu != null)
                menu.SetItems(items);
        }

        public void Remove()
        {

        }

        public void RemoveAt(int idx)
        {

        }
    }
}