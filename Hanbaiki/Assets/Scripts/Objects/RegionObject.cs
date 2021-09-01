using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RegionObject", order = 6)]
    public class RegionObject : ScriptableObject
    {
        public List<WeatherData> weather;
    }
}