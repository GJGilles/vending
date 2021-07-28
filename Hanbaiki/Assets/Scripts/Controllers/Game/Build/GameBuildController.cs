using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildController : MonoBehaviour
    {
        public GameBuildStationListController sList;
        public GameBuildTileController tCtrl;
        public GameBuildRecipeListController rList;
        public GameBuildItemListController iList;
        public GameBuildMapController mCtrl;

        private StationObject station;
        private int tile = 0;
        private ItemObject item;
        private int location = 0;
        private int recipe = 0;

        private GameObject Current;
        public Action Prev;

        public StationObject GetStation()
        {
            return station;
        }

        private void Awake()
        {
            station = null;
            tile = -1;
            item = null;
            location = -1;
            recipe = -1;

            StartStation();
        }

        private void Cancel()
        {

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

            Prev = StartStation;
        }

        public void DoneTile(int t)
        {
            tile = t;
            if (StationService.IsInput(station))
            {
                StartItem();
            }
            else if (StationService.IsOutput(station))
            {
                StartMap();
            }
            else
            {
                StartRecipe();
            }
        }

        private void StartItem()
        {
            if (Current) Current.SetActive(false);
            Current = iList.gameObject;
            Current.SetActive(true);

            item = null;

            Prev = StartTile;
        }

        public void DoneItem(ItemObject i)
        {
            item = i;
            Submit();
        }

        private void StartMap()
        {
            if (Current) Current.SetActive(false);
            Current = mCtrl.gameObject;
            Current.SetActive(true);

            location = -1;

            Prev = StartTile;
        }

        public void DoneMap(int l)
        {
            location = l;
            Submit();
        }

        private void StartRecipe()
        {
            if (Current) Current.SetActive(false);
            Current = rList.gameObject;
            Current.SetActive(true);

            recipe = -1;

            Prev = StartTile;
        }

        public void DoneRecipe(int r)
        {
            recipe = r;
            Submit();
        }

        private void Submit()
        {

        }
    }
}