using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class GameService
    {
        private static GameMapEnum map = GameMapEnum.Basic;
        private static List<TileData> tiles = new List<TileData>();

        static GameService()
        {
            // TODO: remove tests
            for (int i = 0; i < 11; i++)
            {
                tiles.Add(new TileData());
            }
            tiles.Add(new TileData() { type = TileTypeEnum.Station, data = (int)StationEnum.Steeper });
        }

        public static GameMapEnum GetMap()
        {
            return map;
        }

        public static void SetMap(GameMapEnum map)
        {
            GameService.map = map;
        }

        public static List<TileData> GetTiles()
        {
            return tiles;
        }
    }
}