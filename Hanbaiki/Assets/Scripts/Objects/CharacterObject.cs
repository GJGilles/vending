using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterObject", order = 7)]
    public class CharacterObject : ScriptableObject
    {
        public RuntimeAnimatorController animator;
        public Sprite sprite;

        public List<DialogObject> dialogs = new List<DialogObject>();
        public int state = 0;
    }
}