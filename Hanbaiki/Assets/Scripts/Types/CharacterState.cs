using Assets.Scripts.Objects;
using System;
using UnityEngine;

namespace Assets.Scripts.Types
{
    [Serializable]
    public class CharacterState
    {
        public CharacterObject character;
        public int state;
    }
}