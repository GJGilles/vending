using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameCharacterController : MonoBehaviour
    {
        protected enum CharacterDirectionEnum
        {
            Up,
            Right,
            Down,
            Left
        }

        public float speed = 0.5f;
        public GameMapController map;
        public CharacterAnimationController anim;

        protected int location = 0;
        protected CharacterDirectionEnum direction = CharacterDirectionEnum.Down;
        protected bool isDirty = true;

        protected Vector2 GetPosition()
        {
            int width = map.GetMap().width;
            int height = map.GetMap().height;
            Vector2 pos = (Vector2)map.transform.position + new Vector2(-width / 2f, height / 2f);

            pos.x += (location % width);
            pos.y += -(location / width);

            return pos;
        }

        protected void TryMove(int next)
        {
            int width = map.GetMap().width;
            int height = map.GetMap().height;
            if (next / width == location / width && next >= 0)
            {
                direction = (next > location) ? CharacterDirectionEnum.Right : CharacterDirectionEnum.Left;
                location = next;
                isDirty = true;
            }
            else if (next >= 0 && next < width * height)
            {
                direction = (next > location) ? CharacterDirectionEnum.Up : CharacterDirectionEnum.Down;
                location = next;
                isDirty = true;
            }

            if (isDirty)
            {
                anim.SetDirection((int)direction);
                anim.SetWalk(true);
            }
        }

        private void Update()
        {
            if (isDirty)
            {
                Vector2 a = transform.position;
                Vector2 b = GetPosition();
                Vector2 c = new Vector2();
                isDirty = !CommonAnimation.LinearMove(a, b, out c, speed);
                transform.position = c;

                if (!isDirty)
                    anim.SetWalk(false);
            }
        }
    }
}