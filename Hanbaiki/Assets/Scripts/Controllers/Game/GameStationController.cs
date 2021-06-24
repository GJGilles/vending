using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameStationController : GameTileController
    {
        public StationEnum station = StationEnum.ItemIn;

        private List<ItemData> input = new List<ItemData>();
        private List<ItemData> output = new List<ItemData>();
    }
}