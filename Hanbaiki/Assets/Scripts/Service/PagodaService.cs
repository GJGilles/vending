using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class PagodaService
    {
        private static int height = 3;
        private static int width = 11;
        private static List<TileData> tiles = new List<TileData>();
        private static List<FunnelData> funnels = new List<FunnelData>();

        static PagodaService()
        {
            tiles = new List<TileData>(new TileData[height * width]);
            FileService.Add(new Data().GetService());
        }

        public static int Height() { return height;  }

        public static int Width() { return width; }

        public static Vector2 GetPosition(int location)
        {
            int width = Width();
            Vector2 pos = new Vector2();

            pos.x += (location % width) - width / 2;
            pos.y += ((location / width) - 0.5f);

            return pos;
        }

        public static TileData GetTile(int i) { return tiles[i];  }

        public static List<TileData> GetTiles() { return tiles; }

        public static void AddFloor() 
        { 
            height++;
            tiles.AddRange(new TileData[width]);
        }

        public static void SetTile(int i, TileData data)
        {
            tiles[i] = data;
        }

        public static void AddFunnel(FunnelData data)
        {
            funnels.Add(data);
        }


        [Serializable]
        public class PagodaTile
        {
            public int type;
            public int id;
            public InventoryData inventory;
        }

        [Serializable]
        public class PagodaData
        {
            public int height;
            public List<PagodaTile> tiles = new List<PagodaTile>();
        }

        public class Data : DataService<PagodaData>
        {
            protected override string name => "pagoda";

            protected override PagodaData GetData()
            {
                PagodaData data = new PagodaData() { height = height };

                foreach (var t in tiles)
                {
                    if (t.type == TileTypeEnum.Station)
                    {
                        var s = (StationTileData)t;
                        data.tiles.Add(new PagodaTile() {
                            type = (int)t.type,
                            id = s.station.GetHashCode(),
                            inventory = s.inventory.Save()
                        });
                    }
                    else if (t.type == TileTypeEnum.Crate)
                    {
                        var c = (CrateTileData)t;
                        data.tiles.Add(new PagodaTile()
                        {
                            type = (int)t.type,
                            id = c.item.GetHashCode(),
                            inventory = c.inventory.Save()
                        });
                    }
                    else if (t.type == TileTypeEnum.Output)
                    {
                        var o = (LocationTileData)t;
                        data.tiles.Add(new PagodaTile()
                        {
                            type = (int)t.type,
                            id = o.loc.GetHashCode(),
                            inventory = null
                        });
                    }
                    else
                    {
                        data.tiles.Add(null);
                    }
                }

                return data;
            }

            protected override void SetData(PagodaData data)
            {
                height = data.height;
                tiles = new List<TileData>(new TileData[height * width]);

                for (int i = 0; i < data.tiles.Count; i++)
                {
                    if (data.tiles[i] == null)
                    {
                        tiles[i] = null;
                    }
                    else if ((TileTypeEnum)data.tiles[i].type == TileTypeEnum.Station)
                    {
                        var station = StationService.Get(data.tiles[i].id);
                        var inventory = new ItemInventory(4);
                        inventory.Load(data.tiles[i].inventory);

                        tiles[i] = new StationTileData() { type = TileTypeEnum.Station, station = station, inventory = inventory };
                    }
                    else if ((TileTypeEnum)data.tiles[i].type == TileTypeEnum.Crate)
                    {
                        var item = IngredientService.Get(data.tiles[i].id);
                        var inventory = new ItemInventory(1);
                        inventory.Load(data.tiles[i].inventory);

                        tiles[i] = new CrateTileData() { type = TileTypeEnum.Crate, item = item, inventory = inventory };
                    }
                    else if ((TileTypeEnum)data.tiles[i].type == TileTypeEnum.Output)
                    {
                        var loc = MapService.Get(data.tiles[i].id);

                        tiles[i] = new LocationTileData() { type = TileTypeEnum.Output, loc = loc };
                    }
                }
            }
        }
    }
}