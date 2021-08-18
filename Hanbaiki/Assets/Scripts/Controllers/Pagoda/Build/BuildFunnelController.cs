using Assets.Scripts.Objects;
using PotatoTools.Character;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildFunnelController : MonoBehaviour
    {
        public SelectFunnelController fCtrl;
        public SelectItemListController iList;

        public PlayerController player;
        public PagodaTileController map;
        public PagodaFunnelController fun;

        private IngredientObject item;

        private GameObject Current;
        public Action Prev;

        private void OnEnable()
        {
            item = null;

            StartFunnel();

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

        private void StartFunnel()
        {
            if (Current) Current.SetActive(false);
            Current = fCtrl.gameObject;
            Current.SetActive(true);

            Prev = Cancel;
        }

        public void DoneFunnel()
        {
            //fun.SetFunnel();
        }

        private void StartItem()
        {
            if (Current) Current.SetActive(false);
            Current = iList.gameObject;
            Current.SetActive(true);

            item = null;

            Prev = StartFunnel;
        }

        public void DoneItem(IngredientObject i)
        {
            item = i;

            //map.SetTile(tile, item);

            StartFunnel();
        }
    }
}