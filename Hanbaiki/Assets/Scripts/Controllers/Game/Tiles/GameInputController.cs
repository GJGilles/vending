using Assets.Scripts.Objects;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameInputController : GameTileController
    {
        public SpriteRenderer spr;
        public ItemObject item;

        private void Start()
        {
            spr.sprite = item.spr;
        }

        public override void Select(GameSelectionController selecter)
        {
            if (!selecter.IsHolding())
            {
                selecter.Take(item);
            }
            selecter.Deselect();
        }
    }
}