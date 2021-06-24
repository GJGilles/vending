using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public enum GameMapEnum
    {
        Basic
    }

    [System.Serializable]
    public class GameMap
    {
        public GameMapEnum id = GameMapEnum.Basic;
        public Vector2 origin = new Vector2();
        public SpriteRenderer background;

        public int height;
        public int width;
    }
}