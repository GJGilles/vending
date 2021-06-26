using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public enum TileTypeEnum
    {
        None,
        Empty,
        Object,
        Station
    }

    public class TileData
    {
        public TileTypeEnum type = TileTypeEnum.None;
        public int data;
    }
}