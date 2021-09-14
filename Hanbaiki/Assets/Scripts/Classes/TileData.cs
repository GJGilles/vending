using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Inventory;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public enum TileTypeEnum
    {
        None,
        Station,
        Crate,
        Output
    }

    public class TileData
    {
        public TileTypeEnum type = TileTypeEnum.None;

        public TileData()
        {
            TimeService.OnTick.AddListener(Update);
        }

        ~TileData()
        {
            TimeService.OnTick.RemoveListener(Update);
        }

        protected virtual void Update() { }

        public virtual ItemInventory GetInventory() { return null; }

        public virtual void SetSprite(GameObject obj) { }
    }

    public class StationTileData : TileData
    {
        public StationObject station;
        public ItemInventory inventory;

        private RecipeObject recipe;
        private int cooldown = 0;

        protected override void Update()
        {
            cooldown--;
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
                        cooldown = r.ticks;
                        recipe = r;
                        break;
                    }
                }
            }
        }

        public override ItemInventory GetInventory()
        {
            return inventory;
        }

        public override void SetSprite(GameObject obj)
        {
            obj.GetComponent<SpriteRenderer>().sprite = station.spr;
        }
    }

    public class CrateTileData : TileData
    {
        public IngredientObject item;
        public ItemInventory inventory;

        public CrateTileData()
        {
            inventory.SetPermanent(0, item);
        }

        public override ItemInventory GetInventory()
        {
            return inventory;
        }

        public override void SetSprite(GameObject obj)
        {
            obj.GetComponent<SpriteRenderer>().sprite = AssetLoader.LoadAsset<Sprite>("Sprites/Stations/ing_crate.png");

            var child = new GameObject().AddComponent<SpriteRenderer>();
            child.transform.SetParent(child.transform);
            child.transform.localPosition = new Vector2(0, 0.2f);
            child.sprite = item.spr;
        }
    }

    public class LocationTileData : TileData
    {
        public LocationObject loc;

        public override ItemInventory GetInventory()
        {
            return VendingService.GetInventory(loc);
        }

        public override void SetSprite(GameObject obj)
        {
            obj.GetComponent<SpriteRenderer>().sprite = AssetLoader.LoadAsset<Sprite>("Sprites/Stations/portal.png");
        }
    }
}