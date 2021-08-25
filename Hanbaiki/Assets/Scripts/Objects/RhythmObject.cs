﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RhythmObject", order = 9)]
    public class RhythmObject : ScriptableObject
    {
        public List<RhythmNote> notes = new List<RhythmNote>();
    }
}