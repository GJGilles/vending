using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Character
{
    public class CharacterInventoryController : MonoBehaviour
    {
        public UnityEngine.UI.Image bar;
        public GameObject slotObj;

        public int capacity = 6;

        private List<ItemObject> items = new List<ItemObject>();
        private int selected = 0;

        private void Start()
        {
            for (int i = 0; i < capacity; i++)
            {

            }
        }

        public bool IsFull()
        {
            return items.Count == capacity;
        }

        public ItemObject Peek()
        {
            if (items.Count == 0)
            {
                return null;
            }
            else
            {
                return items[selected];
            }
        }

        public ItemObject TryPop()
        {
            if (items.Count == 0)
            {
                return null;
            }
            else
            {
                var item = items[selected];
                items.RemoveAt(selected);
                if (selected > 0) selected--;

                return item;
            }
        }

        public bool TryPush(ItemObject item)
        {
            if (items.Count >= capacity)
            {
                return false;
            }
            else
            {
                items.Add(item);
                return true;
            }
        }

        public void ChangeSelect(int diff)
        {
            if (items.Count == 0)
            {
                selected = 0;
                return;
            }

            selected += diff;
            while (selected >= items.Count) selected -= items.Count;
            while (selected < 0) selected += items.Count;
        }
    }
}