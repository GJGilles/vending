using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Game;
using UnityEngine;
using System;

namespace Assets.Scripts.Controllers
{
    public class SelectAxisController : SelectUIController<int>
    {
        public CameraFollow cam;
        public SpriteRenderer pivot;
        public SpriteRenderer target;

        [NonSerialized] public int center;
        private Transform prev;

        private void OnEnable()
        {
            target.gameObject.SetActive(true);
            prev = cam.target;
            cam.target = target.transform;
            //pivot.transform.localPosition = PagodaService.GetPosition(center);
            UpdateSelected(select);
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
            int width = PagodaService.Width();
            int size = width * PagodaService.Height();

            int next = select;
            if (input.x != 0)
            {
                next = (select / width) * width + ((select + Mathf.RoundToInt(input.x)) % width);
            }
            else if (input.y != 0)
            {
                next = select + Mathf.RoundToInt(input.y) * width;
            }

            if (next != select && ((center % width == next % width) || (center / width == next / width)))
            {
                if (next < 0) next += size;
                if (next >= size) next -= size;
                UpdateSelected(next);
                coolRemain = coolTime;
            }
        }

        public void SetSprite(Sprite spr)
        {
            target.sprite = spr;
        }

        private void UpdateSelected(int loc)
        {
            select = loc;
            target.transform.position = PagodaService.GetPosition(loc) - new Vector2(0, 0.5f);
        }
    }
}