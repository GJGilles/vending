using System;
using UnityEngine;

namespace Assets.Scripts.Types
{
    [Serializable]
    public class WeatherData
    {
        public int minTemp;
        public int maxTemp;

        public int sunup;
        public int sundown;

        public float precip;
    }
}