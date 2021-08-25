using System.Collections;
using UnityEngine;

namespace PotatoTools.Inventory
{
    public class ItemController : MonoBehaviour
    {
        public Rigidbody2D rb;
        public SpriteRenderer spr;

        public ItemObject item;

        public void Set(ItemObject i)
        {
            item = i;
            spr.sprite = i.spr;
        }
    }
}