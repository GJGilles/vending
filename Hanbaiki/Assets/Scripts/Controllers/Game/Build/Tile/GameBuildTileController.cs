using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildTileController : MonoBehaviour
    {
        public CameraFollow cam;
        public GameMapController map;
        public GameSelectionController selecter;
        public GameBuildController build;

        public SpriteRenderer target;
        public float coolTime = 0.3f;

        private Transform prev;
        private int location = 0;
        private float coolRemain = 0;

        private void OnEnable()
        {
            target.gameObject.SetActive(true);
            prev = cam.target;
            cam.target = target.transform;
            UpdateSelected(location);
        }

        private void OnDisable()
        {
            target.gameObject.SetActive(false);
            cam.target = prev;
        }

        private void Update()
        {
            Vector2 input = InputManager.GetMovement();
            int width = GameService.Width();
            int size = width * GameService.Height();

            if (InputManager.GetButtonTrigger(ButtonEnum.Fire1) && map.IsSettable(location))
            {
                build.DoneTile(location);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.Fire2))
            {
                build.Prev();
                return;
            }

            int next = location;
            if (input.x != 0)
            {
                next = (location / width) * width + ((location + Mathf.RoundToInt(input.x)) % width);
            }
            else if (input.y != 0)
            {
                next = location - Mathf.RoundToInt(input.y) * width;
            }

            coolRemain -= Time.deltaTime;
            if (next != location && coolRemain <= 0)
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
            location = loc;
            target.transform.position = map.GetPosition(loc) - new Vector2(0, 0.5f);
        }
    }
}