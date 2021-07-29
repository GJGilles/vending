using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StationObject", order = 1)]
    public class StationObject : ScriptableObject
    {
        public string title;
        public Sprite spr;
        public List<RecipeObject> recipes;
        public bool unlocked = true;
    }
}