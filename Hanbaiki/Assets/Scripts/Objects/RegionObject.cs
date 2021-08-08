﻿using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RegionObject", order = 6)]
    public class RegionObject : ScriptableObject
    {
        public List<WeatherData> weather;

        public ItemFlavorEnum favFlavor;
        public ItemPrepEnum favPrep;
    }
}