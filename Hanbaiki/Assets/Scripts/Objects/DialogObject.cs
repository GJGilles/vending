using Assets.Scripts.Dialog;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogObject", order = 7)]
    public class DialogObject : ScriptableObject
    {
        public List<CharacterObject> characters = new List<CharacterObject>();
        public List<DialogBlock> dialogs = new List<DialogBlock>();
        public UnlockData unlocks = new UnlockData();
    }
}