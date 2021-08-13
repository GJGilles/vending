using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace Assets.Scripts.Service
{
    public static class QuestService
    {
        public static UnityEvent<int> OnGoalChange = new UnityEvent<int>();
        public static UnityEvent OnQuestChange = new UnityEvent();

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

            var done = GetCurrent().Where(x => x.goals.Count == 0).Where(x => unlock.characters.Any(y => x.character.character == y.character)).ToList();
            foreach (var d in done)
            {
                d.unlocked = false;
            }

            if (unlock.quests.Count > 0 || done.Count > 0)
            {
                OnQuestChange.Invoke();
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
            for (int i = 0; i < GetCurrent().Count; i++)
            {
                var q = GetCurrent()[i];

                bool changed = false;
                foreach (var goal in q.goals)
                {
                    if (goal.number > 0 && goal.location == loc && goal.item == item)
                    {
                        goal.number--;
                        changed = true;
                    }
                }
                q.goals.RemoveAll(x => x.number <= 0);

                if (changed) OnGoalChange.Invoke(q.GetHashCode());

                if (q.goals.Count == 0 && changed)
                {
                    DoUnlock(new List<CharacterState>() { q.character });
                }
            }
        }
    }
}