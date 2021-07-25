using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public enum TileTypeEnum
    {
        None,
        Empty,
        Station,
        BuildDesk,
        RecipeDesk,
        WorkerDesk
    }

    public class TileData
    {
        public TileTypeEnum type = TileTypeEnum.None;
        public int data;
    }
}