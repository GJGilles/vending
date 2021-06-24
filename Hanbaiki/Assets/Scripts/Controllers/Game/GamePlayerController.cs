using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GamePlayerController : GameCharacterController
    {
        protected override void Update()
        {
            if (!isDirty)
            {
                Vector2 input = InputManager.GetMovement();
                if (input.x != 0)
                {
                    int next = location + Mathf.FloorToInt(input.x);
                    TryMove(next);
                }
                else if (input.y != 0)
                {
                    int next = location - Mathf.FloorToInt(input.y) * map.GetMap().width;
                    TryMove(next);
                }
            }

            base.Update();
        }
    }
}