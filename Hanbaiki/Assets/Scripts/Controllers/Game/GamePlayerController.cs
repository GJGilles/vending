using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GamePlayerController : GameCharacterController
    {
        public GameSelectionController select;

        protected override void Update()
        {
            base.Update();

            if (!isDirty)
            {
                Vector2 input = InputManager.GetMovement();
                if (input.x != 0 && !select.IsSelected())
                {
                    int next = location + Mathf.FloorToInt(input.x);
                    TryMove(next);
                }
                else if (input.y != 0 && !select.IsSelected())
                {
                    int next = location - Mathf.FloorToInt(input.y) * map.GetMap().width;
                    TryMove(next);
                }

                if (isDirty)
                    select.UpdateSelection(location, direction);
            }
        }
    }
}