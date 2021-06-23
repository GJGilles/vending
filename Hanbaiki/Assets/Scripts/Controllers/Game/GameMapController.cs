using Assets.Scripts.Service;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameMapController : MonoBehaviour
    {
        [System.Serializable]
        public class GameMap
        {
            public GameMapEnum id = GameMapEnum.Basic;
            public SpriteRenderer background;

            public int height;
            public int width;
        }

        public List<GameMap> maps = new List<GameMap>();
        private GameMap current;

        private void Start()
        {
            SetMap(GameService.GetMap());
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
    }
}