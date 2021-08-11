using Assets.Scripts.Objects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Types
{
    [Serializable]
    public class UnlockData
    {
        public List<LocationObject> locations = new List<LocationObject>();
        public List<RecipeObject> recipes = new List<RecipeObject>();
        public List<StationObject> stations = new List<StationObject>();
        public List<QuestObject> quests = new List<QuestObject>();
        public List<CharacterState> characters = new List<CharacterState>();
    }
}