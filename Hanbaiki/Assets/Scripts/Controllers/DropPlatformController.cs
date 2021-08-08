using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DropPlatformController : MonoBehaviour
    {
        public Collider2D platform;

        private Collider2D drop;

        public void DropDown(Collider2D obj)
        {
            drop = obj;
            Physics2D.IgnoreCollision(drop, platform);
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider == drop)
            {
                Physics2D.IgnoreCollision(drop, platform, false);
                drop = null;
            }
        }
    }
}