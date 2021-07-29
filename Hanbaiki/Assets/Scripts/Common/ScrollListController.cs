using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScrollListController : MonoBehaviour
    {
        public GameObject itemObj;

        private int selected = 0;
        private bool isDirty = false;
        private List<GameObject> items = new List<GameObject>();

        public int GetSelected()
        {
            return selected;
        }

        public GameObject GetItem(int i)
        {
            return items[i];
        }

        public void UpdateSelect(int diff)
        {
            if (selected - diff < 0) { diff -= items.Count; }
            if (selected - diff >= items.Count) { diff += items.Count; }
            selected -= diff;
            isDirty = true;
        }

        public void Clean()
        {
            while(items.Count > 0)
            {
                Destroy(items[0].gameObject);
                items.RemoveAt(0);
            }
        }

        public GameObject Add()
        {
            var inst = Instantiate(itemObj, transform);
            inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, GetHeight() / 2f - items.Count * GetSize());
            items.Add(inst);
            return inst;
        }

        private float GetHeight()
        {
            return GetComponent<RectTransform>().rect.height - itemObj.GetComponent<RectTransform>().rect.height;
        }

        private float GetSize()
        {
            return itemObj.GetComponent<RectTransform>().rect.height;
        }

        private void Update()
        {
            if (isDirty)
            {
                float start = items[selected].GetComponent<RectTransform>().anchoredPosition.y;
                float dest = Mathf.Max(GetHeight() / 2 - selected * GetSize(), Mathf.Min(0, -GetHeight() / 2 + (items.Count - selected) * GetSize()));
                isDirty = !CommonAnimation.DampedMove(new Vector2(0, start), new Vector2(0, dest), out Vector2 moved);

                foreach (var item in items)
                {
                    var rect = item.GetComponent<RectTransform>();
                    rect.anchoredPosition = rect.anchoredPosition + (moved - new Vector2(0, start));
                }
            }
        }
    }
}