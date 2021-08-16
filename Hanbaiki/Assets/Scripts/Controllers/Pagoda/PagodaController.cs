using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PagodaController : MonoBehaviour
    {
        public GameObject stationObj;
        public GameObject inputObj;
        public GameObject outputObj;

        public SpriteRenderer background;

        private List<SelectableController> tiles = new List<SelectableController>();

        private void Start()
        {
            SetMap();
        }

        private void SetMap()
        {
            var map = GameService.GetMap();
            background.sprite = map.background;
            tiles = new List<SelectableController>(new SelectableController[map.tiles.Count]);

            for (int i = 0; i < map.tiles.Count; i++)
            {
                TileData tile = map.tiles[i];
                switch (tile.type)
                {
                    case TileTypeEnum.Station:
                        SetTile(i, tile.station);
                        break;

                    case TileTypeEnum.Input:
                        SetTile(i, tile.item);
                        break;

                    case TileTypeEnum.Output:
                        SetTile(i, tile.loc);
                        break;

                    case TileTypeEnum.None:
                    default:
                        tiles.Add(null);
                        break;
                }
            }
        }

        public SelectableController GetTile(int location)
        {
            return tiles[location];
        }

        public void SetTile(int location)
        {
            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);
        }

        public void SetTile(int location, StationObject station)
        {
            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);

            var inst = Instantiate(stationObj, GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<StationController>();
            inst.station = station;
            inst.GetComponent<SpriteRenderer>().sprite = inst.station.spr;
            tiles[location] = inst;
        }

        public void SetTile(int location, IngredientObject item)
        {
            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);

            var inst = Instantiate(inputObj, GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<CrateController>();
            inst.item = item;
            tiles[location] = inst;
        }

        public void SetTile(int location, LocationObject loc)
        {
            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);

            var inst = Instantiate(outputObj, GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<OutputController>();
            inst.location = loc;
            tiles[location] = inst;
        }

        public Vector2 GetPosition(int location)
        {
            var map = GameService.GetMap();
            Vector2 pos = (Vector2)transform.position + map.origin;

            pos.x += (location % map.width);
            pos.y += (location / map.width);

            return pos;
        }
    }
}