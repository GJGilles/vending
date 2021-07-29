using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameMapObject", order = 4)]
    public class GameMapObject : ScriptableObject
    {
        public Vector2 origin = new Vector2();
        public Sprite background;

        public int height;
        public int width;
        public List<TileData> tiles = new List<TileData>();
    }
}