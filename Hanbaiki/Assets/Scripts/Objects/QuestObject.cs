using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuestObject", order = 8)]
    public class QuestObject : ScriptableObject
    {
        [NonSerialized] public List<QuestGoal> goals = new List<QuestGoal>();

        public List<QuestSellGoal> sell = new List<QuestSellGoal>();
        public List<QuestGiveGoal> give = new List<QuestGiveGoal>();
        public List<QuestTalkGoal> talk = new List<QuestTalkGoal>();

        public UnlockData data = new UnlockData();
        public bool unlocked = false;

        private void OnEnable()
        {
            goals = new List<QuestGoal>();
            foreach (var g in sell) goals.Add(g);
            foreach (var g in give) goals.Add(g);
            foreach (var g in talk) goals.Add(g);
        }
    }
}