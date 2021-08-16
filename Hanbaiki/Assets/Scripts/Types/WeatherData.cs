using System;

namespace Assets.Scripts
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