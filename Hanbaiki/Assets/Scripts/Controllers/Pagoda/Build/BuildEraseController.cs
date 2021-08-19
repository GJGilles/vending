using Assets.Scripts.Objects;
using PotatoTools.Character;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildEraseController : MonoBehaviour
    {
        public SelectTileController tCtrl;
        public Sprite spr;

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
            tCtrl.SetSprite(spr);

            tCtrl.OnCancel = () =>
            {
                Cancel();
            };

            tCtrl.OnDone = (int i) =>
            {
                map.SetTile(i);
                StartTile();
            };
        }
    }
}