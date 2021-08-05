using Assets.Scripts.Controllers.Character;
using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameOutputController : SelectableController
    {
        public LocationObject location;

        public override void Select(PlayerController player)
        {
            if (player.inventory.Peek() != null && VendingService.CanAdd(location, player.inventory.Peek()))
            {
                VendingService.Add(location, player.inventory.TryPop());
            }
        }
    }
}