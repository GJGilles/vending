using Assets.Scripts.Objects;
using System;
using UnityEngine;

namespace Assets.Scripts.Types
{
    [Serializable]
    public class QuestGoal
    {
        public ItemObject item;
        public LocationObject location;
        public int number;
    }
}