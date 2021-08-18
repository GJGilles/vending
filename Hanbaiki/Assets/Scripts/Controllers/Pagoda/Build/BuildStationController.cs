using Assets.Scripts.Objects;
using PotatoTools.Character;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildStationController : MonoBehaviour
    {
        public SelectStationListController sList;
        public SelectTileController tCtrl;

        public PlayerController player;
        public PagodaTileController map;

        private void OnEnable()
        {
            StartStation();

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

        private void StartStation()
        {
            sList.gameObject.SetActive(true);

            sList.OnCancel = () =>
            {
                Cancel();
            };

            sList.OnDone = (StationObject s) =>
            {
                StartTile(s);
            };
        }

        private void StartTile(StationObject s)
        {
            tCtrl.gameObject.SetActive(true);
            tCtrl.SetSprite(s.spr);

            tCtrl.OnCancel = () =>
            {
                Cancel();
            };

            tCtrl.OnDone = (int i) =>
            {
                map.SetTile(i, s);
                StartStation();
            };
        }
    }
}