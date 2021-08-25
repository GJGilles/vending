﻿using Assets.Scripts.Objects;
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

        private void OnEnable()
        {
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
            tCtrl.gameObject.SetActive(true);
            tCtrl.SetSprite(map.outputObj.GetComponent<SpriteRenderer>().sprite);

            tCtrl.OnCancel = () =>
            {
                Cancel();
            };

            tCtrl.OnDone = (int i) =>
            {
                StartMap(i);
            };
        }

        private void StartMap(int i)
        {
            mCtrl.gameObject.SetActive(true);

            mCtrl.OnCancel = () =>
            {
                Cancel();
            };

            mCtrl.OnDone = (LocationObject loc) =>
            {
                map.SetTile(i, loc);
                StartTile();
            };
        }
    }
}