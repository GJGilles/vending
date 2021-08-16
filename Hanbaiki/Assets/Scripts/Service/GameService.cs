using Assets.Scripts.Objects;
using PotatoTools;
using System.Collections.Generic;

namespace Assets.Scripts.Service
{
    public static class GameService
    {
        private static List<GameMapObject> maps = new List<GameMapObject>();
        private static int current = 0;

        static GameService()
        {
            maps = AssetLoader.LoadObjects<GameMapObject>();
        }

        public static int Width() { return maps[current].width; }
        public static int Height() { return maps[current].height;  }

        public static List<GameMapObject> GetAll()
        {
            return maps;
        }

        public static GameMapObject GetMap()
        {
            return maps[current];
        }

        public static void SetMap(int idx)
        {
            current = idx;
        }
    }
}