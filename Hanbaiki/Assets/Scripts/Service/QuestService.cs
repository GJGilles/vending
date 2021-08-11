using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class QuestService
    {
        private static List<QuestObject> quests = new List<QuestObject>();

        static QuestService()
        {
            quests = AssetLoader.LoadObjects<QuestObject>();
        }

        public static QuestObject Get(int id)
        {
            return quests[id];
        }

        public static List<QuestObject> GetCurrent()
        {
            return quests.Where(s => s.unlocked).ToList();
        }

        public static void DoUnlock(UnlockData unlock)
        {
            foreach (var loc in unlock.locations)
            {
                loc.unlocked = true;
            }

            foreach (var r in unlock.recipes)
            {
                r.unlocked = true;
            }

            foreach (var s in unlock.stations)
            {
                s.unlocked = true;
            }

            foreach (var q in unlock.quests)
            {
                q.unlocked = true;
            }

            foreach (var c in unlock.characters)
            {
                c.character.state = c.state;
            }
        }

        public static void DoUnlock(List<CharacterState> states)
        {
            foreach (var c in states)
            {
                c.character.state = c.state;
            }
        }

        public static void Update(LocationObject loc, ItemObject item)
        {
            foreach (var q in GetCurrent())
            {
                bool done = true;
                bool changed = false;
                foreach (var goal in q.goals)
                {
                    if (goal.number > 0 && goal.location == loc && goal.item == item)
                    {
                        goal.number--;
                        changed = true;
                    }
                    done = done && goal.number <= 0;
                }

                if (done && changed)
                {
                    DoUnlock(new List<CharacterState>() { q.character });
                }
            }
        }
    }
}