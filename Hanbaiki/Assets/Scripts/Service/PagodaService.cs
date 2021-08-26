using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Service
{
    public static class PagodaService
    {
        private static int height = 3;
        private static int width = 11;
        private static List<TileData> tiles = new List<TileData>();

        static PagodaService()
        {
            tiles = new List<TileData>(new TileData[height * width]);
        }

        public static int Height() { return height;  }

        public static int Width() { return width; }

        public static List<TileData> GetTiles() { return tiles; }

        public static void AddFloor() 
        { 
            height++;
            tiles.AddRange(new TileData[width]);
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
            }
        }
    }
}