using PotatoTools;
using PotatoTools.Game;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class BuildFunnelController : MonoBehaviour
    {
        public CameraFollow cam;
        public PagodaFunnelController map;
        public BuildController build;

        public SpriteRenderer target;
        public float coolTime = 0.3f;

        private Transform prev;
        private int x = 0;
        private int y = 0;
        private MoveDirection direction = MoveDirection.Right;
        private float coolRemain = 0;

        private void OnEnable()
        {
            target.gameObject.SetActive(true);
            prev = cam.target;
            cam.target = target.transform;
            UpdatePosition();
        }

        private void OnDisable()
        {
            target.gameObject.SetActive(false);
            cam.target = prev;
        }

        private void Update()
        {
            Vector2 input = InputManager.GetMovement();
            int width = map.GetWidth(y);
            int height = map.GetHeight();

            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                //build.DoneTile(location);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                build.Prev();
                return;
            }

            coolRemain -= Time.deltaTime;
            if (coolRemain > 0)
            {
                return;
            }

            if (input.x != 0)
            {
                if (direction == MoveDirection.Right)
                {
                    direction = MoveDirection.Left;
                }
                else
                {
                    direction = MoveDirection.Right;
                    x += Mathf.RoundToInt(input.x);
                    if (x < 0) x += width;
                    if (x >= width) x -= width;
                }
            }
            
            if (input.y != 0)
            {
                y += Mathf.RoundToInt(input.y);
                if (y < 0) y += height;
                if (y >= height) y -= height;
                if (x >= map.GetWidth(y)) x = map.GetWidth(y) - 1;

                if (y % 2 == 0)
                {
                    direction = MoveDirection.Right;
                }
                else
                {
                    direction = MoveDirection.Down;
                }
            }

            if (input.x != 0 || input.y != 0)
            {
                UpdatePosition();
            }
        }

        private void UpdatePosition()
        {
            target.transform.position = map.GetPosition(x, y);
            target.sprite = map.sprites[(int)direction];
        }
    }
}