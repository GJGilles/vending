using Assets.Scripts.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class CharacterMovementController : MonoBehaviour
    {
        public float speed = 0.5f;
        public float jump = 5f;

        public CharacterAnimationController anim;
        public Rigidbody2D rb;
        public Collider2D col;

        protected void SetMove(int dir)
        {
            rb.velocity = new Vector2(dir * speed, rb.velocity.y);
            anim.SetWalk(dir != 0, dir < 0);
        }

        protected void SetJump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
}