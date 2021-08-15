using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Inventory
{
    public class SplitInventoryController : MonoBehaviour
    {
        [NonSerialized] public List<int> widths = new List<int>();
        [NonSerialized] public List<ItemInventory> inventories = new List<ItemInventory>();
        [NonSerialized] public UnityEvent OnClose = new UnityEvent();

        public Canvas canvas;
        public RectTransform background;
        public RectTransform slotObj;

        public int padding = 16;
        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private ItemSlotController held;
        private List<RectTransform> zones = new List<RectTransform>();
        private List<List<ItemSlotController>> slots = new List<List<ItemSlotController>>();
        private List<UnityAction<int>> listeners = new List<UnityAction<int>>();
        private Tuple<int, int> last = new Tuple<int, int>(0, 0);
        private int current = 0;

        private void Start()
        {
            canvas.worldCamera = Camera.current;

            float totalWidth = 0f;
            float totalHeight = 0f;

            for (int j = 0; j < inventories.Count; j++)
            {
                RectTransform zone = new GameObject().AddComponent<RectTransform>();
                zone.SetParent(background.transform);
                zone.localScale = new Vector3(1f, 1f, 1f);
                slots.Add(new List<ItemSlotController>());

                int height = Mathf.CeilToInt(inventories[j].GetSize() / (float)widths[j]);
                zone.sizeDelta = new Vector2(
                    padding * (widths[j] + 1) + slotObj.sizeDelta.x * widths[j],
                    padding * (height + 1) + slotObj.sizeDelta.y * height
                );

                for (int i = 0; i < inventories[j].GetSize(); i++)
                {
                    Vector2 pos = new Vector2(
                        (slotObj.sizeDelta.x / 2) + padding - (zone.sizeDelta.x / 2) + (i - widths[j] * (i / widths[j])) * (padding + slotObj.sizeDelta.x),
                        (slotObj.sizeDelta.y / 2) + padding - (zone.sizeDelta.y / 2) + (i / widths[j]) * (padding + slotObj.sizeDelta.y)
                    );

                    RectTransform inst = Instantiate(slotObj, zone);
                    inst.anchoredPosition = pos;

                    ItemSlotController s = inst.GetComponent<ItemSlotController>();
                    s.Set(inventories[j].Peek(i));
                    slots[j].Add(s);
                }

                zones.Add(zone);
                totalWidth += zone.sizeDelta.x;
                totalHeight = Mathf.Max(totalHeight, zone.sizeDelta.y);

                {
                    int inv = j;
                    UnityAction<int> change = (int i) => ChangeDisplay(inv, i);
                    inventories[j].OnChange.AddListener(change);
                    listeners.Add(change);
                }
            }

            float xPos = -totalWidth / 2;
            background.sizeDelta = new Vector2(totalWidth, totalHeight);
            foreach (var z in zones)
            {
                z.anchoredPosition = new Vector2(xPos + z.sizeDelta.x / 2, 0);
                xPos += z.sizeDelta.x;
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
                Close();
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
                    next = GetNextIndex(location / widths[current], inventories[current].GetSize() / widths[current], inventories[inv].GetSize() / widths[inv]) * widths[inv];
                }
                else if (next < 0 || next / widths[current] < location / widths[current])
                {
                    inv--;
                    if (inv < 0) inv += inventories.Count;
                    next = Math.Min(inventories[inv].GetSize() - 1, (GetNextIndex(location / widths[current], inventories[current].GetSize() / widths[current], inventories[inv].GetSize() / widths[inv]) + 1)* widths[inv] - 1);
                }
            }
            else if (input.y != 0)
            {
                next += Mathf.FloorToInt(input.y) * widths[current];
                if (next >= slots[current].Count) next -= slots[current].Count;
                if (next < 0) next += slots[current].Count;
            }

            coolRemain -= Time.deltaTime;
            if (coolRemain <= 0 && (inv != current || next != location))
            {
                SetSelect(inv, next);
                coolRemain = coolTime;
            }
        }

        private void Close()
        {
            OnClose.Invoke();
            if (held != null)
            {
                inventories[last.Item1].Add(StackMoveEnum.All, held.Get(), last.Item2);
                Destroy(held.gameObject);
            }

            for (int i = 0; i < inventories.Count; i++)
            {
                inventories[i].OnChange.RemoveListener(listeners[i]);
            }

            Destroy(gameObject);
        }

        public void ChangeDisplay(int inv, int idx)
        {
            slots[inv][idx].Set(inventories[inv].Peek(idx));
        }

        private void Interact(StackMoveEnum move)
        {
            if (held == null)
            {
                last = new Tuple<int, int>(current, inventories[current].GetLocation());
                var content = inventories[current].Remove(move);

                if (content != null)
                {
                    held = Instantiate(slotObj, background).GetComponent<ItemSlotController>();
                    held.Set(content);
                    held.GetComponent<RectTransform>().anchoredPosition = GetPosition(current, inventories[current].GetLocation());
                }
            }
            else
            {
                var ret = inventories[current].Add(move, held.Get());
                if (ret == null)
                {
                    Destroy(held.gameObject);
                }
                else
                {
                    held.Set(ret);
                }
            }
        }

        private int GetNextIndex(int aIdx, int aLen, int bLen)
        {
            int bIdx = aIdx + (bLen - aLen) / 2;
            if (bIdx < 0 || aIdx == 0) bIdx = 0;
            if (bIdx >= bLen || aIdx == aLen - 1) bIdx = bLen - 1;
            return bIdx;
        }

        private void SetSelect(int inv, int location)
        {
            slots[current][inventories[current].GetLocation()].Highlight(false);
            slots[inv][location].Highlight(true);
            inventories[inv].SetSelect(location);
            current = inv;

            if (held != null)
            {
                held.GetComponent<RectTransform>().anchoredPosition = GetPosition(current, inventories[current].GetLocation());
            }
        }

        private Vector2 GetPosition(int idx, int location)
        {
            Vector2 pos = zones[idx].anchoredPosition + new Vector2(slotObj.sizeDelta.x, slotObj.sizeDelta.y);
            pos.x -= zones[idx].sizeDelta.x / 2;
            pos.y -= zones[idx].sizeDelta.y / 2;

            int x = (location % widths[idx]);
            int y = (location / widths[idx]);

            pos.x += x * slotObj.sizeDelta.x + (x + 1) * padding;
            pos.y += y * slotObj.sizeDelta.y + (y + 1) * padding;

            return pos;
        }
    }
}