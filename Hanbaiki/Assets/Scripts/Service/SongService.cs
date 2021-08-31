using Assets.Scripts.Objects;
using PotatoTools;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Service
{
    public static class SongService
    {
        private static List<SongObject> songs = new List<SongObject>();

        static SongService()
        {
            songs = AssetLoader.LoadObjects<SongObject>();
            FileService.Add(new Data().GetService());
        }

        public static SongObject Get(int id)
        {
            return songs.Find(x => x.GetHashCode() == id);
        }

        public static List<SongObject> GetCurrent()
        {
            return songs.Where(i => i.unlocked).ToList();
        }

        public class Data : DataService<Dictionary<int, bool>>
        {
            protected override string name => "songs";

            protected override Dictionary<int, bool> GetData()
            {
                return songs
                  .ToDictionary(x => x.GetHashCode(), x => x.unlocked);
            }

            protected override void SetData(Dictionary<int, bool> data)
            {
                for (var i = 0; i < songs.Count; i++)
                {
                    if (data.ContainsKey(songs[i].GetHashCode()))
                    {
                        songs[i].unlocked = data[songs[i].GetHashCode()];
                    }
                }
            }
        }
    }
}