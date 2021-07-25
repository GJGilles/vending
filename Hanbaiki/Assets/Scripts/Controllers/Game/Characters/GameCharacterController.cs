using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public enum CharacterDirectionEnum
    {
        Up,
        Right,
        Down,
        Left
    }

    public class GameCharacterController : MonoBehaviour
    {
        public float speed = 0.5f;
        public GameMapController map;
        public CharacterAnimationController anim;

        protected int location = 0;
        protected CharacterDirectionEnum direction = CharacterDirectionEnum.Down;
        protected bool isDirty = true;

        protected void TryMove(int next)
        {
            int width = map.GetMap().width;
            int height = map.GetMap().height;
            if (next / width == location / width && next >= 0)
            {
                direction = (next > location) ? CharacterDirectionEnum.Right : CharacterDirectionEnum.Left;
                isDirty = true;
                if (!map.IsOccupied(next))
                    location = next;
            }
            else if (next >= 0 && next < width * height && next % width == location % width)
            {
                direction = (next > location) ? CharacterDirectionEnum.Down : CharacterDirectionEnum.Up;
                isDirty = true;
                if (!map.IsOccupied(next))
                    location = next;
            }

            if (isDirty)
            {
                anim.SetDirection((int)direction);
                anim.SetWalk(true);
            }
        }

        protected virtual void Update()
        {
            if (isDirty)
            {
                Vector2 a = transform.position;
                Vector2 b = map.GetPosition(location);
                Vector2 c = new Vector2();
                isDirty = !CommonAnimation.LinearMove(a, b, out c, speed);
                transform.position = c;

                if (!isDirty)
                    anim.SetWalk(false);
            }
        }
    }
}