using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RecipeObject", order = 2)]
    public class RecipeObject : ScriptableObject
    {
        public List<IngredientObject> input;
        public IngredientObject output;
        public int ticks;
        public bool unlocked = true;
    }
}