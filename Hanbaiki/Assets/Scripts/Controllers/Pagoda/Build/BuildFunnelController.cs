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
        public PagodaFunnelController fun;

        private void OnEnable()
        {
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
            fCtrl.gameObject.SetActive(true); 
            
            fCtrl.OnCancel = () =>
            {
                Cancel();
            };

            fCtrl.OnDone = (FunnelData f) =>
            {
                StartItem(f);
            };
        }

        private void StartItem(FunnelData f)
        {
            iList.gameObject.SetActive(true);

            iList.OnCancel = () =>
            {
                Cancel();
            };

            iList.OnDone = (IngredientObject i) =>
            {
                fun.SetFunnel(f.x, f.y, f.direction, i);
                StartFunnel();
            };
        }
    }
}