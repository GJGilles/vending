using Assets.Scripts.Objects;
using PotatoTools;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public enum TempEnum
    {
        Freezing,
        Cold,
        Pleasant,
        Warm,
        Hot
    }

    public enum PrecipEnum
    {
        Snow,
        Rain,
        Overcast,
        Clear,
        Heatwave
    }

    public static class WeatherService
    {
        private static Dictionary<RegionObject, int> temp = new Dictionary<RegionObject, int>();

        private static Dictionary<RegionObject, bool> precip = new Dictionary<RegionObject, bool>();

        static WeatherService()
        {
            List<RegionObject> regions = AssetLoader.LoadObjects<RegionObject>();
            foreach (var r in regions)
            {
                temp.Add(r, 20);
                precip.Add(r, false);
            }
            FileService.Add(new Data().GetService());
        }

        public static void UpdateTemp(SeasonEnum season, int hour)
        {
            var keys = new List<RegionObject>(temp.Keys);
            for(int i = 0; i < keys.Count; i++)
            {
                var r = keys[i];
                var data = r.weather[(int)season];
                int rand = UnityEngine.Random.Range(data.minTemp, data.maxTemp + 1);
                if (data.sunup <= hour && hour <= data.sundown)
                {
                    if (rand > temp[r]) temp[r]++;
                }
                else
                {
                    if (rand < temp[r]) temp[r]--;
                }
            }
        }

        public static void UpdatePrecip(SeasonEnum season)
        {
            var keys = new List<RegionObject>(temp.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                var r = keys[i];
                var data = r.weather[(int)season];
                int rand = UnityEngine.Random.Range(1, 101);
                precip[r] = rand >= data.precip;
            }
        }

        public static TempEnum GetTemp(RegionObject r)
        {
            if (temp[r] <= 0)
            {
                return TempEnum.Freezing;
            }
            else if (temp[r] <= 10)
            {
                return TempEnum.Cold;
            }
            else if (temp[r] <= 20)
            {
                return TempEnum.Pleasant;
            }
            else if (temp[r] <= 25)
            {
                return TempEnum.Warm;
            }
            else
            {
                return TempEnum.Hot;
            }
        }

        public static int GetTempNum(RegionObject r)
        {
            return temp[r];
        }

        public static PrecipEnum GetPrecip(RegionObject r)
        {
            if (precip[r])
            {
                if (temp[r] <= 5)
                {
                    return PrecipEnum.Snow;
                }
                else if (temp[r] <= 20)
                {
                    return PrecipEnum.Rain;
                }
                else
                {
                    return PrecipEnum.Overcast;
                }
            }
            else
            {
                if (temp[r] <= 25)
                {
                    return PrecipEnum.Clear;
                }
                else
                {
                    return PrecipEnum.Heatwave;
                }
            }
        }


        [Serializable]
        public class WeatherData
        {
            public Dictionary<int, int> temp;
            public Dictionary<int, bool> precip;
        }

        public class Data : DataService<WeatherData>
        {
            protected override string name => "weather";

            protected override WeatherData GetData()
            {
                return new WeatherData()
                {
                    temp = temp.ToDictionary(x => x.Key.GetHashCode(), x => x.Value),
                    precip = precip.ToDictionary(x => x.Key.GetHashCode(), x => x.Value)
                };
            }

            protected override void SetData(WeatherData data)
            {
                var regions = AssetLoader.LoadObjects<RegionObject>();

                temp = data.temp.ToDictionary(x => regions.Find(y => y.GetHashCode() == x.Key), x => x.Value);
                precip = data.precip.ToDictionary(x => regions.Find(y => y.GetHashCode() == x.Key), x => x.Value);
            }
        }
    }
}