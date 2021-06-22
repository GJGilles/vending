using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public class RecipeData
    {
        public List<ItemEnum> input;
        public List<ItemEnum> output;
        public float time;

        public RecipeData(List<ItemEnum> input, List<ItemEnum> output, float time)
        {
            this.input = input;
            this.output = output;
            this.time = time;
        }
    }
}