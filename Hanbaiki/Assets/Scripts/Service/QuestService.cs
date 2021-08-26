using Assets.Scripts.Objects;
using PotatoTools;
using PotatoTools.Character;
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

            CharacterService.OnDialog.AddListener(OnDialog);
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
                c.character.dialogs.Push(c.dialog);
            }

            var done = GetCurrent().Where(x => x.goals.Count == 0).ToList();
            foreach (var d in done)
            {
                d.unlocked = false;
            }

            if (unlock.quests.Count > 0 || done.Count > 0)
            {
                OnQuestChange.Invoke();
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
                    if (!(goal is QuestSellGoal)) continue;

                    var g = (QuestSellGoal)goal;
                    if (g.number > 0 && g.location == loc && g.item == item)
                    {
                        g.number--;
                        changed = true;
                    }
                }
                q.goals.RemoveAll(x => x is QuestSellGoal && ((QuestSellGoal)x).number <= 0);

                if (changed) OnGoalChange.Invoke(q.GetHashCode());

                if (q.goals.Count == 0 && changed)
                {
                    DoUnlock(q.data);
                }
            }
        }

        private static void OnDialog(CharacterObject character)
        {
            for (int i = 0; i < GetCurrent().Count; i++)
            {
                var q = GetCurrent()[i];

                bool changed = false;
                for (int j = q.goals.Count - 1; j >= 0; j--)
                {
                    var goal = q.goals[j];
                    if (goal is QuestTalkGoal && ((QuestTalkGoal)goal).character == character)
                    {
                        changed = true;
                        q.goals.RemoveAt(j);
                    }
                    else if (goal is QuestGiveGoal && ((QuestGiveGoal)goal).character == character)
                    {
                        var g = (QuestGiveGoal)goal;
                        if (PlayerService.GetInventory().CanPull(new ItemStack(g.item, g.number)))
                        {
                            changed = true;
                            PlayerService.GetInventory().TryPull(new ItemStack(g.item, g.number));
                            q.goals.RemoveAt(j);
                        }
                    }
                }


                if (changed) OnGoalChange.Invoke(q.GetHashCode());

                if (q.goals.Count == 0 && changed)
                {
                    DoUnlock(q.data);
                }
            }
        }
    }
}