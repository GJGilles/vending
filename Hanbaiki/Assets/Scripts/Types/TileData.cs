using Assets.Scripts.Objects;
using PotatoTools.Inventory;
using System;

namespace Assets.Scripts
{
    public enum TileTypeEnum
    {
        None,
        Station,
        Crate,
        Output
    }

    [Serializable]
    public class TileData
    {
        public TileTypeEnum type = TileTypeEnum.None;
    }

    [Serializable]
    public class StationTileData : TileData
    {
        public StationObject station;
        public ItemInventory inventory;
    }

    [Serializable]
    public class CrateTileData : TileData
    {
        public IngredientObject item;
        public ItemInventory inventory;
    }

    [Serializable]
    public class LocationTileData : TileData
    {
        public LocationObject loc;
    }
}