using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameMapController : MonoBehaviour
    {
        public GameObject stationObj;
        public GameObject inputObj;
        public GameObject outputObj;
        public GameObject buildDeskObj;
        public GameObject workerDeskObj;

        public SpriteRenderer background;

        private List<GameTileController> tiles = new List<GameTileController>();

        private void Start()
        {
            SetMap();
        }

        private void SetMap()
        {
            var map = GameService.GetMap();
            background.sprite = map.background;
            tiles = new List<GameTileController>(new GameTileController[map.tiles.Count]);

            for (int i = 0; i < map.tiles.Count; i++)
            {
                TileData tile = map.tiles[i];
                switch (tile.type)
                {
                    case TileTypeEnum.Station:
                        SetTile(i, tile.station, tile.recipe);
                        break;

                    case TileTypeEnum.Input:
                        SetTile(i, tile.item);
                        break;

                    case TileTypeEnum.Output:
                        SetTile(i, tile.loc);
                        break;

                    case TileTypeEnum.BuildDesk:
                        var build = Instantiate(buildDeskObj, GetPosition(i) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<GameBuildDeskController>();
                        tiles[i] = build;
                        break;

                    case TileTypeEnum.WorkerDesk:
                        var work = Instantiate(workerDeskObj, GetPosition(i) - new Vector2(0, 0.5f), new Quaternion(), transform);
                        //tiles[i] = work;
                        break;

                    case TileTypeEnum.None:
                    case TileTypeEnum.Slot:
                    default:
                        tiles.Add(null);
                        break;
                }
            }
        }

        public GameTileController GetTile(int location)
        {
            return tiles[location];
        }

        public bool IsOccupied(int location)
        {
            return tiles[location] != null;
        }

        public bool IsSettable(int location)
        {
            TileTypeEnum type = GameService.GetMap().tiles[location].type;
            return 
                type == TileTypeEnum.Slot ||
                type == TileTypeEnum.Input ||
                type == TileTypeEnum.Output ||
                type == TileTypeEnum.Station;
        }

        public void SetTile(int location, StationObject station, int recipe)
        {
            if (!IsSettable(location))
                return;

            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);

            var inst = Instantiate(stationObj, GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<GameStationController>();
            inst.station = station;
            inst.recipe = recipe;
            inst.GetComponent<SpriteRenderer>().sprite = inst.station.spr;
            tiles[location] = inst;
        }

        public void SetTile(int location, ItemObject item)
        {
            if (!IsSettable(location))
                return;

            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);

            var inst = Instantiate(inputObj, GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<GameInputController>();
            inst.item = item;
            tiles[location] = inst;
        }

        public void SetTile(int location, LocationObject loc)
        {
            if (!IsSettable(location))
                return;

            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);

            var inst = Instantiate(outputObj, GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<GameOutputController>();
            inst.location = loc;
            tiles[location] = inst;
        }

        public Vector2 GetPosition(int location)
        {
            var map = GameService.GetMap();
            Vector2 pos = (Vector2)transform.position + map.origin;

            pos.x += (location % map.width);
            pos.y += -(location / map.width);

            return pos;
        }

        public void Select(GameSelectionController selecter, int location)
        {
            if (tiles[location] is GameTileController)
                tiles[location].Select(selecter);
        }

        public void Deselect(int location)
        {
            if (tiles[location] is GameTileController)
                tiles[location].Deselect();
        }
    }
}