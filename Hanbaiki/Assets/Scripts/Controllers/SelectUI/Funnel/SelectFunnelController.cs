using PotatoTools;
using PotatoTools.Game;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class SelectFunnelController : SelectUIController<FunnelData>
    {
        public CameraFollow cam;
        public PagodaFunnelController map;

        public SpriteRenderer target;
        private Transform prev;

        private void OnEnable()
        {
            select = new FunnelData() { x = 0, y = 0, direction = MoveDirection.Right };
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

        protected override void Update()
        {
            base.Update();
            if (coolRemain > 0) return;

            Vector2 input = InputManager.GetMovement();
            int width = map.GetWidth(select.y);
            int height = map.GetHeight();

            if (input.x != 0)
            {
                if (select.direction == MoveDirection.Right)
                {
                    select.direction = MoveDirection.Left;
                }
                else
                {
                    select.direction = MoveDirection.Right;
                    select.x += Mathf.RoundToInt(input.x);
                    if (select.x < 0) select.x += width;
                    if (select.x >= width) select.x -= width;
                }
            }
            
            if (input.y != 0)
            {
                select.y += Mathf.RoundToInt(input.y);
                if (select.y < 0) select.y += height;
                if (select.y >= height) select.y -= height;
                if (select.x >= map.GetWidth(select.y)) select.x = map.GetWidth(select.y) - 1;

                if (select.y % 2 == 0)
                {
                    select.direction = MoveDirection.Right;
                }
                else
                {
                    select.direction = MoveDirection.Down;
                }
            }

            if (input.x != 0 || input.y != 0)
            {
                UpdatePosition();
                coolRemain = coolTime;
            }
        }

        private void UpdatePosition()
        {
            target.transform.localPosition = map.GetPosition(select.x, select.y) + new Vector2(0, 1);
            target.sprite = map.sprites[(int)select.direction];
        }
    }
}