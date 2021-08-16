using Assets.Scripts.Objects;
using PotatoTools;
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
    }
}