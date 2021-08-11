using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuestObject", order = 8)]
    public class QuestObject : ScriptableObject
    {
        public List<QuestGoal> goals = new List<QuestGoal>();
        public CharacterState character = new CharacterState();
        public bool unlocked = false;
    }
}