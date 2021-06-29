using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildListController : MonoBehaviour
    {
        public StationSpriteLoader sprites;
        public GameObject list;
        public GameObject itemObj;

        private int selected = 0;
        private bool isDirty = false;
        private List<GameBuildItemController> items = new List<GameBuildItemController>();

        public StationEnum GetSelected()
        {
            return StationService.GetCurrent()[selected];
        }

        private float GetHeight()
        {
            return list.GetComponent<RectTransform>().rect.height - itemObj.GetComponent<RectTransform>().rect.height;
        }

        private float GetSize()
        {
            return itemObj.GetComponent<RectTransform>().rect.height;
        }

        private void Start()
        {
            var stations = StationService.GetCurrent();
            for (int i = 0; i < stations.Count; i++)
            {
                var inst = Instantiate(itemObj, new Vector2(0, GetHeight() / 2 - i * GetSize()), new Quaternion(), list.transform).GetComponent<GameBuildItemController>();
                inst.Set(StationService.Get(stations[i]), sprites.GetSprite(stations[i]));
            }
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

        public void UpdateSelect(int diff)
        {
            if (selected + diff < 0) { diff += items.Count; }
            if (selected + diff >= items.Count) { diff -= items.Count; }
            selected += diff;
            isDirty = true;
        }    
    }
}