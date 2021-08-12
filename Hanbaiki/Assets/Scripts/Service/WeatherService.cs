using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
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
        }

        public static void UpdateTemp(SeasonEnum season, int hour)
        {
            foreach (var r in temp.Keys)
            {
                var data = r.weather[(int)season];
                int rand = Random.Range(data.minTemp, data.maxTemp + 1);
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
            foreach (var r in precip.Keys)
            {
                var data = r.weather[(int)season];
                int rand = Random.Range(1, 101);
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
    }
}