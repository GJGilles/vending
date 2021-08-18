using Assets.Scripts.Objects;
using PotatoTools.Character;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildOutputController : MonoBehaviour
    {
        public SelectTileController tCtrl;
        public SelectMapController mCtrl;

        public PlayerController player;
        public PagodaTileController map;

        private int tile = 0;
        private LocationObject location;

        private GameObject Current;
        public Action Prev;

        private void OnEnable()
        {
            tile = -1;
            location = null;

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
            tCtrl.SetSprite(map.outputObj.GetComponent<SpriteRenderer>().sprite);
            Prev = Cancel;
        }

        public void DoneTile(int t)
        {
            tile = t;
            StartMap();
        }

        private void StartMap()
        {
            if (Current) Current.SetActive(false);
            Current = mCtrl.gameObject;
            Current.SetActive(true);

            location = null;

            Prev = StartTile;
        }

        public void DoneMap(LocationObject l)
        {
            location = l;

            map.SetTile(tile, location);

            StartTile();
        }
    }
}