﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RecipeObject", order = 2)]
    public class RecipeObject : ScriptableObject
    {
        public List<ItemObject> input;
        public List<ItemObject> output;
        public float time;
    }
}