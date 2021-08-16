using Assets.Scripts.Objects;
using System;

namespace Assets.Scripts
{
    [Serializable]
    public class QuestGoal
    {
        public FoodObject item;
        public LocationObject location;
        public int number;
    }
}