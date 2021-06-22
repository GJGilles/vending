using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public static class CommonAnimation
    {
        public static bool Step(Vector2 a, Vector2 b, out Vector2 c, float rate = 0.03f, float threshold = 0.1f) 
        {
            c = Vector2.Lerp(a, b, rate);
            return Mathf.Abs((a - b).magnitude) < threshold;
        }
    }
}