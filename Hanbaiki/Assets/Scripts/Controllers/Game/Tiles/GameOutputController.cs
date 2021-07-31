using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameOutputController : GameTileController
    {
        public LocationObject location;

        public override void Select(GameSelectionController selecter)
        {
            if (selecter.IsHolding() && VendingService.CanAdd(location, selecter.GetItem()))
            {
                VendingService.Add(location, selecter.Give());
            }
            selecter.Deselect();
        }
    }
}