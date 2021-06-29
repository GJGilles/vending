using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public enum StationEnum
    {
        None,
        ItemIn,
        ItemOut,

        Blender,
        MochiMaker,
        NoodlePuller,
        TeaRoaster,
        WrapperPress,

        BigOven,
        DeepFryer,
        Fermenter,
        Freezer,
        FryTop,
        Oven,
        SaladMaker,
        SandwichMaker,
        SoupPot,
        SushiMaker,
        Steeper
    }

    public class StationData
    {
        public string name;
        public StationEnum id;
        public List<RecipeData> recipes;
    }
}