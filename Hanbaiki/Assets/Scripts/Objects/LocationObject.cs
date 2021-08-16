using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MapObject", order = 5)]
    public class LocationObject : ScriptableObject
    {
        public RegionObject region;

        public Vector2 coords;
        public int population;

        public bool unlocked;
    }
}