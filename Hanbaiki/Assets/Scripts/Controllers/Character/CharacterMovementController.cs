using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class CharacterMovementController : MonoBehaviour
    {
        public float speed = 0.5f;
        public float jump = 5f;
        public LayerMask groundMask;

        public CharacterAnimationController anim;
        public Rigidbody2D rb;
        public Collider2D col;

        public float timeGround = 0.3f;
        public float timeJump = 0.3f;
        private float lastGround = 0.3f;
        private float lastJump = 0.3f;

        protected virtual void Update()
        {
            if (IsGrounded()) lastGround = 0f;

            if (lastGround < timeGround && lastJump < timeJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                lastGround = timeGround;
                lastJump = timeJump;
            }

            lastGround += Time.deltaTime;
            lastJump += Time.deltaTime;
        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(col.bounds.center, new Vector2(col.bounds.extents.x, 0.1f), 0, Vector2.down, col.bounds.extents.y, groundMask);
        }

        protected void SetMove(int dir)
        {
            rb.velocity = new Vector2(dir * speed, rb.velocity.y);
            anim.SetWalk(dir != 0, dir < 0);
        }

        protected void SetJump()
        {
            lastJump = 0f;
        }
    }
}