using Assets.Scripts.Objects;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildCrateController : MonoBehaviour
    {
        public SelectTileController tCtrl;
        public SelectItemListController iList;

        public PlayerController player;
        public PagodaTileController map;

        private void OnEnable()
        {
            StartTile();

            PlayerService.Lock();
        }

        private void OnDisable()
        {
            PlayerService.Unlock();
        }

        private void Cancel()
        {
            gameObject.SetActive(false);
        }

        private void StartTile()
        {
            tCtrl.gameObject.SetActive(true);
            tCtrl.SetSprite(map.crateObj.GetComponent<SpriteRenderer>().sprite);

            tCtrl.OnCancel = () =>
            {
                Cancel();
            };

            tCtrl.OnDone = (int i) =>
            {
                StartItem(i);
            };
        }

        private void StartItem(int loc)
        {
            iList.gameObject.SetActive(true);

            iList.OnCancel = () =>
            {
                Cancel();
            };

            iList.OnDone = (IngredientObject i) =>
            {
                map.SetTile(loc, new CrateTileData() { type = TileTypeEnum.Crate, item = i, inventory = new ItemInventory(1) });
                StartTile();
            };
        }
    }
}