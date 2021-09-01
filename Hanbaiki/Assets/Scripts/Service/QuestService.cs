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
            FileService.Add(new Data().GetService());

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
                c.character.PushDialog(c.dialog);
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

        private static void OnDialog(CharacterObject character, DialogObject dialog)
        {
            DoUnlock(((DialogUnlockObject)dialog).unlocks);

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

        public class Data : DataService<Dictionary<int, Dictionary<int, int>>>
        {
            protected override string name => "quests";

            protected override Dictionary<int, Dictionary<int, int>> GetData()
            {
                return quests.Where(x => x.unlocked).ToDictionary(x => x.GetHashCode(), x => x.goals.ToDictionary(y => y.GetHashCode(), y => y.number));
            }

            protected override void SetData(Dictionary<int, Dictionary<int, int>> data)
            {
                foreach (var q in quests)
                {
                    if (data.ContainsKey(q.GetHashCode()))
                    {
                        q.unlocked = true;
                        var d = data[q.GetHashCode()];
                        for (int i = q.goals.Count - 1; i >= 0; i--)
                        {
                            if (d.ContainsKey(q.goals[i].GetHashCode()))
                            {
                                q.goals[i].number = d[q.goals[i].GetHashCode()];
                            }
                            else
                            {
                                q.goals.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        q.unlocked = false;
                    }
                }
            }
        }
    }
}