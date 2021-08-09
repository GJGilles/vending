using Assets.Scripts.Controllers.Character;
using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildController : MonoBehaviour
    {
        public GameBuildTypeController tyCtrl;
        public GameBuildStationListController sList;
        public GameBuildTileController tCtrl;
        public GameBuildItemListController iList;
        public GameBuildMapController mCtrl;

        public PlayerController player;
        public GameMapController map;

        private TileTypeEnum type = TileTypeEnum.None;
        private StationObject station;
        private int tile = 0;
        private ItemObject item;
        private LocationObject location;

        private GameObject Current;
        public Action Prev;

        private void OnEnable()
        {
            type = TileTypeEnum.None;
            station = null;
            tile = -1;
            item = null;
            location = null;

            StartType();

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

        private void StartType()
        {
            if (Current) Current.SetActive(false);
            Current = tyCtrl.gameObject;
            Current.SetActive(true);

            type = TileTypeEnum.None;

            Prev = Cancel;
        }

        public void DoneType(TileTypeEnum t)
        {
            type = t; 
            if (type == TileTypeEnum.Station)
            {
                StartStation();
            }
            else
            {
                StartTile();
            }
        }

        private void StartStation()
        {
            if (Current) Current.SetActive(false);
            Current = sList.gameObject;
            Current.SetActive(true);

            station = null;

            Prev = StartType;
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
            if (type == TileTypeEnum.Input)
            {
                tCtrl.SetSprite(map.inputObj.GetComponent<SpriteRenderer>().sprite);
                Prev = StartType;
            }
            else if (type == TileTypeEnum.Output)
            {
                tCtrl.SetSprite(map.outputObj.GetComponent<SpriteRenderer>().sprite);
                Prev = StartType;
            }
            else
            {
                tCtrl.SetSprite(station.spr);
                Prev = StartStation;
            }
        }

        public void DoneTile(int t)
        {
            tile = t;
            if (type == TileTypeEnum.Input)
            {
                StartItem();
            }
            else if (type == TileTypeEnum.Output)
            {
                StartMap();
            }
            else if (type == TileTypeEnum.None)
            {
                map.SetTile(tile);
                StartTile();
            }
            else
            {
                map.SetTile(tile, station);
                StartTile();
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

            map.SetTile(tile, item);

            StartTile();
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