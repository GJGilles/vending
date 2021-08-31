using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SongObject", order = 10)]
    public class SongObject : RhythmObject
    {
        public string title = "";
        public Sprite spr;

        public ItemFlavorEnum flavor = ItemFlavorEnum.Salty;
        public ItemPrepEnum prep = ItemPrepEnum.Raw;
        public bool unlocked = false;
    }
}