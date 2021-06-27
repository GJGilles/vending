using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers
{
    public class InventorySelectController : MonoBehaviour
    {
        public ItemSpriteLoader sprites;
        public UnityEvent<int> selected = new UnityEvent<int>();

        public int width = 2;
        public List<SpriteRenderer> slots = new List<SpriteRenderer>();

        private int selection = 0;

        public void SetItems(List<ItemData> it)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (i >= it.Count)
                    slots[i].sprite = null;
                else
                {
                    slots[i].sprite = sprites.GetSprite(it[i].id);
                }
            }

        }

        public void UpdateSelected(int location)
        {
            slots[selection].color = new Color(0, 0, 0);
            slots[location].color = new Color(100, 0, 0);
            selection = location;
        }

        private void Update()
        {
            if (InputManager.GetFireA())
                selected.Invoke(selection);

            Vector2 input = InputManager.GetMovement();
            if (input.x != 0)
            {
                int next = selection + Mathf.FloorToInt(input.x);
                if (next / width > selection / width) next -= width;
                if (next / width < selection / width) next += width;
                UpdateSelected(next);

            }
            else if (input.y != 0)
            {
                int next = selection + Mathf.FloorToInt(input.y) * width;
                if (next >= slots.Count) next -= slots.Count;
                if (next < 0) next += slots.Count;
                UpdateSelected(next);
            }
        }
    }
}