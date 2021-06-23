using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public enum GameMapEnum
    {
        Basic
    }

    public static class GameService
    {
        private static GameMapEnum map = GameMapEnum.Basic;

        public static GameMapEnum GetMap()
        {
            return map;
        }

        public static void SetMap(GameMapEnum map)
        {
            GameService.map = map;
        }
    }
}