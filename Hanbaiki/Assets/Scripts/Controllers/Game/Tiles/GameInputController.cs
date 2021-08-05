using Assets.Scripts.Controllers.Character;
using Assets.Scripts.Objects;
using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameInputController : SelectableController
    {
        public SpriteRenderer spr;
        public ItemObject item;

        private void Start()
        {
            spr.sprite = item.spr;
        }

        public override void Select(PlayerController player)
        {
            if (!player.inventory.IsFull())
            {
                player.inventory.TryPush(item);
            }
        }
    }
}