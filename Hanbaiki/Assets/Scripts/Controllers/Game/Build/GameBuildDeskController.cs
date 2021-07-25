using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildDeskController : GameTileController
    {
        public override void Select(GameSelectionController selecter)
        {
            selecter.build.gameObject.SetActive(true);
        }
    }
}