using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuestObject", order = 8)]
    public class QuestObject : ScriptableObject
    {
        public List<QuestGoal> goals = new List<QuestGoal>();
        public UnlockData data = new UnlockData();
        public bool unlocked = false;
    }
}