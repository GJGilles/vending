using Assets.Scripts.Objects;
using PotatoTools;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Service
{
    public static class CharacterService
    {
        private static List<CharacterObject> characters = new List<CharacterObject>();

        static CharacterService()
        {
            characters = AssetLoader.LoadObjects<CharacterObject>();
        }

        public class Data : DataService<Dictionary<int, List<int>>>
        {
            protected override string name => "characters";

            protected override Dictionary<int, List<int>> GetData()
            {
                return characters
                  .ToDictionary(x => x.GetHashCode(), x => x.dialogs.Select(y => y.GetHashCode()).ToList());
            }

            protected override void SetData(Dictionary<int, List<int>> data)
            {
                var dialogs = AssetLoader.LoadObjects<DialogObject>().ToDictionary(x => x.GetHashCode());

                for (var i = 0; i < characters.Count; i++)
                {
                    if (data.ContainsKey(characters[i].GetHashCode()))
                    {
                        var c = data[characters[i].GetHashCode()];
                        for (var j = c.Count - 1; j >= 0; j--)
                        {
                            characters[i].dialogs.Push(dialogs[c[j]]);
                        }
                    }
                }
            }
        }
    }
}