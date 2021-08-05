using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class PlayerController : CharacterController
    {
        public CharacterInventoryController inventory;

        public LayerMask dropLayer;
        private Collider2D dropCol;

        private SelectableController selection;

        protected void Update()
        {
            Vector2 input = InputManager.GetMovement();
            SetMove(Mathf.RoundToInt(input.x));
            if (dropCol != null && input.y < 0)
            {
                //Physics2D.SetLayerCollisionMask(col, dropCol);
            }

            if (selection != null && InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                selection.Select(this);
            }
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            SelectableController s;
            if (collision.gameObject.TryGetComponent(out s))
            {
                selection = s;
            }
            else if (dropLayer == (dropLayer | (1 << collision.gameObject.layer)))
            {
                dropCol = collision.otherCollider;
            }
        }

        protected void OnCollisionExit2D(Collision2D collision)
        {
            SelectableController s;
            if (collision.gameObject.TryGetComponent(out s) && selection == s)
            {
                selection = null;
            }
            else if (dropCol == collision.otherCollider)
            {
                dropCol = null;
            }
        }
    }
}