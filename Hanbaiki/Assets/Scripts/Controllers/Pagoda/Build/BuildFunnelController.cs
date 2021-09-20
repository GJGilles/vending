using Assets.Scripts.Objects;
using PotatoTools.Character;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildFunnelController : MonoBehaviour
    {
        public Sprite targetSpr;

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
            tList.target.sprite = targetSpr;

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
            aList.center = a;
            aList.gameObject.SetActive(true);
            aList.target.sprite = targetSpr;

            aList.OnCancel = () =>
            {
                Cancel();
            };

            aList.OnDone = (int loc) =>
            {
                fun.SetFunnel(a, loc);
                StartTileA();
            };
        }
    }
}