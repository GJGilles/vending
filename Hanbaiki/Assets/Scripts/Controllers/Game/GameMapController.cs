using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameMapController : MonoBehaviour
    {
        public GameObject stationObj;
        public StationSpriteLoader stationSpr;
        public ItemSpriteLoader itemSpr;
        public List<GameMap> maps = new List<GameMap>();
        private GameMap current;

        private List<GameTileController> tiles = new List<GameTileController>();

        private void Start()
        {
            SetMap(GameService.GetMap());

            var data = GameService.GetTiles();
            for (int i = 0; i < current.width * current.height; i++)
            {
                if (i >= data.Count)
                {
                    tiles.Add(null);
                }
                else
                {
                    switch (data[i].type)
                    {
                        case TileTypeEnum.Station:
                            var inst = Instantiate(stationObj, GetPosition(i) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<GameStationController>();
                            inst.station = (StationEnum)data[i].data;
                            inst.GetComponent<SpriteRenderer>().sprite = stationSpr.GetSprite(inst.station);
                            inst.itemSprites = itemSpr;
                            tiles.Add(inst);
                            break;
                        default:
                            tiles.Add(null);
                            break;
                    }
                }
            }
        }

        public GameMap GetMap()
        {
            return current;
        }

        public void SetMap(GameMapEnum id)
        {
            foreach (var map in maps)
            {
                if (map.id == id)
                {
                    current = map;
                    GameService.SetMap(id);
                    return;
                }
            }
            throw new System.Exception("No Map for ID");
        }

        public Vector2 GetPosition(int location)
        {
            int width = current.width;
            int height = current.height;
            Vector2 pos = (Vector2)transform.position + current.origin;

            pos.x += (location % width);
            pos.y += -(location / width);

            return pos;
        }

        public bool IsOccupied(int location)
        {
            return tiles[location] != null;
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