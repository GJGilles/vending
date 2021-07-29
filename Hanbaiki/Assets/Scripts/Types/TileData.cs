using Assets.Scripts.Objects;
using System;
using UnityEngine;

namespace Assets.Scripts.Types
{
    public enum TileTypeEnum
    {
        None,
        Slot,
        Station,
        Input,
        Output,
        BuildDesk,
        WorkerDesk
    }

    [Serializable]
    public class TileData
    {
        public TileTypeEnum type = TileTypeEnum.None;

        public StationObject station;
        public int recipe;

        public ItemObject item;

        public LocationObject loc;
    }
}