using Assets.Scripts.Objects;
using System;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    [Serializable]
    public class FunnelData
    {
        public MoveDirection right = MoveDirection.None;
        public MoveDirection up = MoveDirection.None;
    }
}