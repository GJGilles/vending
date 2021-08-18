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

        private StationObject station;
        private int tile = 0;

        private GameObject Current;
        public Action Prev;

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
            if (Current) Current.SetActive(false);
            Current = sList.gameObject;
            Current.SetActive(true);

            station = null;

            Prev = Cancel;
        }

        public void DoneStation(StationObject s) 
        {
            station = s;
            StartTile();
        }

        private void StartTile()
        {
            if (Current) Current.SetActive(false);
            Current = tCtrl.gameObject;
            Current.SetActive(true);

            tile = -1;
                tCtrl.SetSprite(station.spr);
                Prev = StartStation;
        }

        public void DoneTile(int t)
        {
            tile = t;
            map.SetTile(tile, station);
            StartTile();
        }
    }
}