using Assets.Scripts.Controllers.Character;
using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;
using PotatoTools;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildDeskController : SelectableController
    {
        public GameBuildController build;

        public override void Select(PlayerController player)
        {
            build.gameObject.SetActive(true);
        }
    }
}