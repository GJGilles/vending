using Assets.Scripts.Objects;
using PotatoTools.Character;
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
        public PagodaFunnelController fun;

        private int tile = 0;
        private IngredientObject item;

        private GameObject Current;
        public Action Prev;

        private void OnEnable()
        {
            tile = -1;
            item = null;

            StartTile();

            player.isLocked = true;
        }

        private void OnDisable()
        {
            player.isLocked = false;
        }

        private void Cancel()
        {
            gameObject.SetActive(false);
        }

        private void StartTile()
        {
            if (Current) Current.SetActive(false);
            Current = tCtrl.gameObject;
            Current.SetActive(true);

            tile = -1;
            tCtrl.SetSprite(map.crateObj.GetComponent<SpriteRenderer>().sprite);
            Prev = Cancel;
        }

        public void DoneTile(int t)
        {
            tile = t;
            StartItem();
        }

        private void StartItem()
        {
            if (Current) Current.SetActive(false);
            Current = iList.gameObject;
            Current.SetActive(true);

            item = null;

            Prev = StartTile;
        }

        public void DoneItem(IngredientObject i)
        {
            item = i;

            map.SetTile(tile, item);

            StartTile();
        }
    }
}