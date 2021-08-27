using PotatoTools;
using System.Collections.Generic;

namespace Assets.Scripts.Service
{
    public enum SeasonEnum
    {
        Spring,
        Summer,
        Fall,
        Winter
    }


    public static class TimeService
    {
        private static int year = 0;
        private static int month = 0;
        private static int day = 0;
        private static int hour = 0;
        private static int minute = 0;

        private static float time = 0;

        static TimeService()
        {
            FileService.Add(new Data().GetService());
        }

        public static void Update(float diff)
        {
            time += diff;
            if (time >= 5)
            {
                time -= 5;

                minute += 10;
                if (minute == 60)
                {
                    minute = 0;
                    hour += 1;

                    if (hour == 23)
                    {
                        hour = 0;
                        day += 1;

                        WeatherService.UpdatePrecip(GetSeason());
                    }
                    WeatherService.UpdateTemp(GetSeason(), hour);
                }
                VendingService.Update();

                if (day == 27)
                {
                    day = 0;
                    month += 1;
                }

                if (month == 7)
                {
                    month = 0;
                    year += 1;
                }
            }
        }

        public static SeasonEnum GetSeason()
        {
            switch (year)
            {
                default:
                case 0:
                case 1:
                    return SeasonEnum.Spring;

                case 2:
                case 3:
                    return SeasonEnum.Summer;

                case 4:
                case 5:
                    return SeasonEnum.Fall;

                case 6:
                case 7:
                    return SeasonEnum.Winter;
            }
        }

        public static string GetMonth()
        {
            int num = (month % 2) + 1;
            return GetSeason().ToString() + "-" + num.ToString();
        }

        public static string GetDate()
        {
            return (day + 1).ToString() + " " + GetMonth() + " " + (year + 2021).ToString();
        }

        public static string GetTime()
        {
            return (hour + 1).ToString() + ":" + minute.ToString().PadLeft(2, '0');
        }

        public class Data : DataService<List<int>>
        {
            protected override string name => "time";

            protected override List<int> GetData()
            {
                return new List<int>() 
                {
                    year,
                    month,
                    day, 
                    hour, 
                    minute
                };
            }

            protected override void SetData(List<int> data)
            {
                year = data[0];
                month = data[1];
                day = data[2];
                hour = data[3];
                minute = data[4];
            }
        }
    }
}