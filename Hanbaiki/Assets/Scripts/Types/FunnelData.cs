using Assets.Scripts.Objects;
using System;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    [Serializable]
    public class FunnelData
    {
        public int x = 0;
        public int y = 0;
        public MoveDirection direction = MoveDirection.None;
    }
}