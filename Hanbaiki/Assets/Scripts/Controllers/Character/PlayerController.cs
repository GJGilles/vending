using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class PlayerController : CharacterMovementController
    {
        public CharacterInventoryController inventory;
        public float dropTime = 1f;
        public bool isLocked = false;

        private DropPlatformController platform;
        private SelectableController selection;

        protected void Update()
        {
            if (isLocked) return;

            Vector2 input = InputManager.GetMovement();
            SetMove(Mathf.RoundToInt(input.x));
            if (platform != null && input.y < 0)
            {
                platform.DropDown(col);
            }

            if (selection != null && InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                selection.Select(this);
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                SetJump();
            }
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out SelectableController s))
            {
                selection = s;
            }
            if (collision.gameObject.TryGetComponent(out DropPlatformController p))
            {
                platform = p;
            }
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out SelectableController s) && selection == s)
            {
                selection = null;
            }
            if (collision.gameObject.TryGetComponent(out DropPlatformController p) && platform == p)
            {
                platform = null;
            }
        }
    }
}