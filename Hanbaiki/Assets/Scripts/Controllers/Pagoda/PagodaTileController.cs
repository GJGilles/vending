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
        public SpriteRenderer floorObj;
        public TileController tileObject;

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
                if (data[i] == null || data[i].type == TileTypeEnum.None)
                {
                    tiles.Add(null);
                    continue;
                }
                else
                {
                    SetTile(i, data[i]);
                }
            }
        }

        public void SetTile(int location)
        {
            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);
        }

        public void SetTile(int location, TileData data)
        {
            if (tiles[location] != null)
                Destroy(tiles[location].gameObject);

            PagodaService.SetTile(location, data);

            var tile = Instantiate(tileObject, PagodaService.GetPosition(location) - new Vector2(0, 0.5f), new Quaternion(), transform);
            tile.data = data;
            tiles[location] = tile;
        }
    }
}