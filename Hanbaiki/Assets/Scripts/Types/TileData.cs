using Assets.Scripts.Objects;
using System;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public enum TileTypeEnum
    {
        None,
        Station,
        Input,
        Output
    }

    [Serializable]
    public class TileData
    {
        public TileTypeEnum type = TileTypeEnum.None;

        public StationObject station;

        public ItemObject item;

        public LocationObject loc;
    }
}