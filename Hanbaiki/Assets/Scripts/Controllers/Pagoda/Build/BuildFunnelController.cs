using Assets.Scripts.Objects;
using PotatoTools.Character;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildFunnelController : MonoBehaviour
    {
        public SelectTileController tList;
        public SelectAxisController aList;
        public SelectItemListController iList;

        public PlayerController player;
        public PagodaFunnelController fun;

        private void OnEnable()
        {
            StartTileA();

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

        private void StartTileA()
        {
            tList.gameObject.SetActive(true);
            tList.target.sprite = null;

            tList.OnCancel = () =>
            {
                Cancel();
            };

            tList.OnDone = (int loc) =>
            {
                StartTileB(loc);
            };
        }

        private void StartTileB(int a)
        {
            aList.gameObject.SetActive(true);
            //aList.pivot.sprite = null;
            aList.target.sprite = null;

            aList.OnCancel = () =>
            {
                Cancel();
            };

            aList.OnDone = (int loc) =>
            {
                StartItem(a, loc);
            };
        }

        private void StartItem(int a, int b)
        {
            iList.gameObject.SetActive(true);

            iList.OnCancel = () =>
            {
                Cancel();
            };

            iList.OnDone = (IngredientObject i) =>
            {
                fun.SetFunnel(a, b, i);
                StartTileA();
            };
        }
    }
}