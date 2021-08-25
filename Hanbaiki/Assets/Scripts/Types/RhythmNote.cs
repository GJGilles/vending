using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    [Serializable]
    public class RhythmNote
    {
        public MoveDirection direction = MoveDirection.Left;
        public float time = 0f;
    }
}
