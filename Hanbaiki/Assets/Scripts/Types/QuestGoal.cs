using Assets.Scripts.Objects;
using PotatoTools;
using System;

namespace Assets.Scripts
{
    [Serializable]
    public class QuestGoal
    {
        public int number;
    }

    [Serializable]
    public class QuestSellGoal : QuestGoal
    {
        public FoodObject item;
        public LocationObject location;
    }

    [Serializable]
    public class QuestTalkGoal : QuestGoal
    {
        public CharacterObject character;
    }

    [Serializable]
    public class QuestGiveGoal : QuestGoal
    {
        public CharacterObject character;

        public ItemObject item;
    }
}