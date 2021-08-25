using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PotatoTools.Inventory
{
    public class ItemVacuumController : MonoBehaviour
    {
        public float range;
        public float force;

        public UnityEvent<ItemObject> OnPickup = new UnityEvent<ItemObject>();

        private void OnTriggerStay2D (Collider2D collision)
        {
            if (collision.TryGetComponent(out ItemController ctrl))
            {
                float dist = Mathf.Abs((transform.position - ctrl.transform.position).magnitude);

                if (dist < range)
                {
                    OnPickup.Invoke(ctrl.item);
                    Destroy(ctrl.gameObject);
                }
                else
                {
                    ctrl.rb.AddForce(force * (transform.position - ctrl.transform.position).normalized * Time.deltaTime);
                }
            }
        }
    }
}