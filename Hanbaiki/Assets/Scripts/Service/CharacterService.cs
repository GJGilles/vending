using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using PotatoTools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class CharacterService
    {
        private static List<CharacterObject> characters = new List<CharacterObject>();

        static CharacterService()
        {
            characters = AssetLoader.LoadObjects<CharacterObject>();
        }

        public class Data : DataService<Dictionary<int, int>>
        {
            protected override string name => "characters";

            protected override Dictionary<int, int> GetData()
            {
                return characters
                  .GroupBy(x => x.GetHashCode())
                  .ToDictionary(x => x.Key, x => x.First().state);
            }

            protected override void SetData(Dictionary<int, int> data)
            {
                for (var i = 0; i < characters.Count; i++)
                {
                    if (data.ContainsKey(characters[i].GetHashCode()))
                    {
                        characters[i].state = data[characters[i].GetHashCode()];
                    }
                }
            }
        }
    }
}