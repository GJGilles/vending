using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuestObject", order = 8)]
    public class QuestObject : ScriptableObject
    {
        public List<QuestGoal> goals => (List<QuestGoal>)new List<QuestGoal>().Concat(sell).Concat(give).Concat(talk);

        public List<QuestSellGoal> sell = new List<QuestSellGoal>();
        public List<QuestGiveGoal> give = new List<QuestGiveGoal>();
        public List<QuestTalkGoal> talk = new List<QuestTalkGoal>();

        public UnlockData data = new UnlockData();
        public bool unlocked = false;
    }
}