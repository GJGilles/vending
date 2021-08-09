using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class MonoInventoryController : MonoBehaviour
    {
        public int padding = 16;
        public int width = 3;
        public ItemInventory inventory;

        public RectTransform background;
        public ItemSlotController held;
        public RectTransform slotObj;

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private List<ItemSlotController> slots = new List<ItemSlotController>();

        private void Start()
        {
            int height = Mathf.CeilToInt(inventory.GetSize() / (float)width);
            background.sizeDelta = new Vector2(
                padding * (width + 1) + slotObj.rect.width * width,
                padding * (height + 1) + slotObj.rect.height * height
            );

            for (int i = 0; i < inventory.GetSize(); i++)
            {
                Vector2 pos = new Vector2(
                    (slotObj.rect.width / 2) + padding - (background.rect.width / 2) + i * (padding + slotObj.rect.width),
                    (slotObj.rect.height / 2) + padding - (background.rect.height / 2) + (i / width) * (padding + slotObj.rect.height)
                );

                RectTransform inst = Instantiate(slotObj, background);
                inst.anchoredPosition = pos;

                ItemSlotController s = inst.GetComponent<ItemSlotController>();
                s.Set(inventory.Peek(i));
                slots.Add(s);
            }

            SetSelect(inventory.GetLocation());
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                Interact(StackMoveEnum.All);
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.X))
            {
                Interact(StackMoveEnum.Half);
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.Y))
            {
                Interact(StackMoveEnum.One);
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                //Exit
            }

            Vector2 input = InputManager.GetMovement();
            int location = inventory.GetLocation();
            int next = location;
            if (input.x != 0)
            {
                next += Mathf.FloorToInt(input.x);
                if (next / width > location / width) next -= width;
                if (next < 0 || next / width < location / width) next += width;

            }
            else if (input.y != 0)
            {
                next += Mathf.FloorToInt(input.y) * width;
                if (next >= slots.Count) next -= slots.Count;
                if (next < 0) next += slots.Count;
            }

            coolRemain -= Time.deltaTime;
            if (coolRemain <= 0 && next != location)
            {
                SetSelect(next);
                coolRemain = coolTime;
            }
        }

        private void Interact(StackMoveEnum move)
        {
            if (held.Get() == null)
            {
                held.Set(inventory.Remove(move));
            }
            else
            {
                held.Set(inventory.Add(move, held.Get()));
            }
        }

        private void SetSelect(int location)
        {
            slots[inventory.GetLocation()].transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
            slots[location].transform.parent.GetComponent<SpriteRenderer>().color = Color.yellow;
            inventory.SetSelect(location);
        }
    }
}