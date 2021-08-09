using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class SplitInventoryController : MonoBehaviour
    {
        public int padding = 16;
        public List<int> widths = new List<int>();
        public List<ItemInventory> inventories = new List<ItemInventory>();

        public RectTransform background;
        public ItemSlotController held;
        public RectTransform slotObj;

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private List<RectTransform> zones = new List<RectTransform>();
        private List<List<ItemSlotController>> slots = new List<List<ItemSlotController>>();
        private int current = 0;

        private void Start()
        {
            float totalWidth = 0f;
            float totalHeight = 0f;

            for (int j = 0; j < inventories.Count; j++)
            {
                RectTransform zone = new GameObject().AddComponent<RectTransform>();
                slots.Add(new List<ItemSlotController>());

                int height = Mathf.CeilToInt(inventories[j].GetSize() / (float)widths[j]);
                zone.sizeDelta = new Vector2(
                    padding * (widths[j] + 1) + slotObj.rect.width * widths[j],
                    padding * (height + 1) + slotObj.rect.height * height
                );

                for (int i = 0; i < inventories[j].GetSize(); i++)
                {
                    Vector2 pos = new Vector2(
                        (slotObj.rect.width / 2) + padding - (zone.rect.width / 2) + i * (padding + slotObj.rect.width),
                        (slotObj.rect.height / 2) + padding - (zone.rect.height / 2) + (i / widths[j]) * (padding + slotObj.rect.height)
                    );

                    RectTransform inst = Instantiate(slotObj, zone);
                    inst.anchoredPosition = pos;

                    ItemSlotController s = inst.GetComponent<ItemSlotController>();
                    s.Set(inventories[j].Peek(i));
                    slots[j].Add(s);
                }

                zones.Add(zone);
                totalWidth += zone.rect.width;
                totalHeight = Mathf.Max(totalHeight, zone.rect.height);
            }

            float xPos = -totalWidth / 2;
            background.sizeDelta = new Vector2(totalWidth, totalHeight);
            foreach (var z in zones)
            {
                z.anchoredPosition = new Vector2(xPos + z.rect.width / 2, 0);
                xPos += z.rect.width;
            }

            SetSelect(current, inventories[current].GetLocation());
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
            int location = inventories[current].GetLocation();
            int next = location;
            int inv = current;
            if (input.x != 0)
            {
                next += Mathf.FloorToInt(input.x);
                if (next / widths[current] > location / widths[current])
                {
                    inv++;
                    if (inv >= inventories.Count) inv -= inventories.Count;
                    next = 0; // TODO: improve this
                }
                else if (next < 0 || next / widths[current] < location / widths[current])
                {
                    inv--;
                    if (inv < 0) inv += inventories.Count;
                    next = 0;
                }
            }
            else if (input.y != 0)
            {
                next += Mathf.FloorToInt(input.y) * widths[current];
                if (next >= slots.Count) next -= slots.Count;
                if (next < 0) next += slots.Count;
            }

            coolRemain -= Time.deltaTime;
            if (coolRemain <= 0 && (inv != current || next != location))
            {
                SetSelect(inv, next);
                coolRemain = coolTime;
            }
        }

        private void Interact(StackMoveEnum move)
        {
            if (held.Get() == null)
            {
                held.Set(inventories[current].Remove(move));
            }
            else
            {
                held.Set(inventories[current].Add(move, held.Get()));
            }
        }

        private void SetSelect(int inv, int location)
        {
            slots[current][inventories[current].GetLocation()].transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
            slots[inv][location].transform.parent.GetComponent<SpriteRenderer>().color = Color.yellow;
            inventories[inv].SetSelect(location);
            current = inv;
        }
    }
}