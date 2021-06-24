using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class GameService
    {
        private static GameMapEnum map = GameMapEnum.Basic;
        private static List<TileData> tiles = new List<TileData>();

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