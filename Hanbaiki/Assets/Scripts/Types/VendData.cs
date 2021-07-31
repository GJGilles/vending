using Assets.Scripts.Objects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public class VendData
    {
        public LocationObject location;
        public Dictionary<ItemObject, int> items = new Dictionary<ItemObject, int>();
    }
}