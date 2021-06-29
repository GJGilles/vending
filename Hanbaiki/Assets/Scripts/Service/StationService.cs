using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service
{
    public static class StationService
    {
        private static Dictionary<StationEnum, StationData> stations = new Dictionary<StationEnum, StationData>();
        private static List<StationEnum> current = new List<StationEnum>() { StationEnum.TeaRoaster };
        /*
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
        Steeper*/

        static StationService()
        {
            Add(StationEnum.Blender, "Blender", new List<RecipeData>() {
                new RecipeData(new List<ItemEnum>() { ItemEnum.Flour, ItemEnum.Eggs, ItemEnum.Sugar }, new List<ItemEnum>() { ItemEnum.Dough }, 1),
                new RecipeData(new List<ItemEnum>() { ItemEnum.Flour, ItemEnum.Eggs, ItemEnum.Water }, new List<ItemEnum>() { ItemEnum.Batter }, 1)
            });

            Add(StationEnum.MochiMaker, "Mochi Maker", new List<RecipeData>());

            Add(StationEnum.NoodlePuller, "Noodle Puller", new List<RecipeData>());

            Add(StationEnum.TeaRoaster, "Tea Roaster", new List<RecipeData>());

            Add(StationEnum.WrapperPress, "Wrapper Press", new List<RecipeData>());

            Add(StationEnum.BigOven, "Big Oven", new List<RecipeData>());

            Add(StationEnum.DeepFryer, "Deep Fryer", new List<RecipeData>());

            Add(StationEnum.Fermenter, "Fermenter", new List<RecipeData>());

            Add(StationEnum.Freezer, "Freezer", new List<RecipeData>());

            Add(StationEnum.FryTop, "Fry Top", new List<RecipeData>());

            Add(StationEnum.Oven, "Oven", new List<RecipeData>());

            Add(StationEnum.SaladMaker, "Salad Maker", new List<RecipeData>());

            Add(StationEnum.SandwichMaker, "Sandwich Maker", new List<RecipeData>());

            Add(StationEnum.SoupPot, "Soup Pot", new List<RecipeData>());
        }

        public static StationData Get(StationEnum id)
        {
            return stations[id];
        }

        public static Dictionary<StationEnum, StationData> GetAll() 
        {
            return stations;
        }

        public static List<StationEnum> GetCurrent()
        {
            return current;
        }

        private static void Add(StationEnum id, string name, List<RecipeData> recipes)
        {
            stations.Add(id, new StationData() { id = id, name = name, recipes = recipes });
        }
    }
}