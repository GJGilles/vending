using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PagodaTileController : MonoBehaviour
    {
        public StationController stationObj;
        public CrateController crateObj;
        public OutputController outputObj;
        public SpriteRenderer floorObj;

        private List<SelectableController> tiles = new List<SelectableController>();

        private void Start()
        {
            SetTiles();
        }

        private void SetTiles()
        {
            for (int i = 0; i < PagodaService.Height(); i++)
            {
                Instantiate(floorObj, transform).transform.localPosition = new Vector2(0, i * floorObj.size.y);
            }


            var data = PagodaService.GetTiles();
            tiles = new List<SelectableController>(new SelectableController[data.Count]);

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == null)
                {
                    tiles.Add(null);
                    continue;
                }

                switch (data[i].type)
                {
                    case TileTypeEnum.Station:
                        SetTile(i, data[i].station);
                        break;

                    case TileTypeEnum.Input:
                        SetTile(i, data[i].item);
                        break;

                    case TileTypeEnum.Output:
                        SetTile(i, data[i].loc);
                        break;

                    case TileTypeEnum.None:
                    default:
                        tiles.Add(null);
                        break;
                }
            }
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

            var inst = Instantiate(crateObj, GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform).GetComponent<CrateController>();
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
            int width = PagodaService.Width();
            Vector2 pos = new Vector2();

            pos.x += (location % width) - width / 2;
            pos.y += ((location / width) - 0.5f) * floorObj.size.y;

            return pos;
        }

        public ItemInventory GetInventory(int i)
        {
            if (tiles[i] is CrateController)
            {
                return ((CrateController)tiles[i]).GetInventory();
            }
            else if (tiles[i] is OutputController)
            {
                return VendingService.GetInventory(((OutputController)tiles[i]).location);
            }
            else if (tiles[i] is StationController)
            {
                return ((StationController)tiles[i]).GetInventory();
            }
            else
            {
                return null;
            }
        }
    }
}