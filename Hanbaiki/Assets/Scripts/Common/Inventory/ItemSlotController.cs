using Assets.Scripts.Types;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class ItemSlotController : MonoBehaviour
    {
        public UnityEngine.UI.Image item;
        public TMPro.TMP_Text number;

        private ItemStack stack;

        public ItemStack Get()
        {
            return stack;
        }

        public void Set(ItemStack s)
        {
            stack = s;
            item.sprite = stack != null ? stack.item.spr : null;
            number.text = stack != null ? stack.number.ToString() : "";
        }

        public void Highlight(bool h)
        {
            GetComponent<UnityEngine.UI.Image>().color = h ? Color.yellow : Color.gray;
        }
    }
}