using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LocationObject", order = 5)]
    public class LocationObject : ScriptableObject
    {
        public string title;
    }
}