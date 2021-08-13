using Assets.Scripts.Inventory;
using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Game
{
    public class VendingController : MonoBehaviour
    {
        public TMPro.TMP_Text city;
        public RectTransform map;
        public Animator precip;
        public TMPro.TMP_Text temp;

        public List<ItemSlotController> slots = new List<ItemSlotController>();

        private bool visible = true;
        private LocationObject location;
        private bool isDirty = false;

        private void Start()
        {
            location = MapService.GetCurrent()[0];
            ChangeLocation(location);
        }

        private void Update()
        {
            UpdateWeather();

            if (InputManager.GetButtonTrigger(ButtonEnum.L2))
            {
                visible = !visible;
            }

            var pos = GetComponent<RectTransform>();
            if (visible && pos.anchoredPosition.x < 0)
            {
                if (CommonAnimation.DampedMove(pos.anchoredPosition, new Vector2(0, 0), out Vector2 c))
                {
                    pos.anchoredPosition = new Vector2(0, 0);
                }
                else
                {
                    pos.anchoredPosition = c;
                }
            }
            if (!visible && pos.anchoredPosition.x > -pos.rect.width)
            {
                if (CommonAnimation.DampedMove(pos.anchoredPosition, new Vector2(-pos.rect.width, 0), out Vector2 c))
                {
                    pos.anchoredPosition = new Vector2(-pos.rect.width, 0);
                }
                else
                {
                    pos.anchoredPosition = c;
                }
            }

            if (!visible) return;

            if (isDirty)
            {
                isDirty = UpdateMap();
            }

            LocationObject next = location;
            var locs = MapService.GetCurrent();
            if (InputManager.GetButtonTrigger(ButtonEnum.L1))
            {
                int idx = locs.FindIndex(x => x == location) - 1;
                if (idx < 0) idx += locs.Count;
                next = locs[idx];
            }
            else if (InputManager.GetButtonTrigger(ButtonEnum.R1))
            {
                int idx = locs.FindIndex(x => x == location) + 1;
                if (idx >= locs.Count) idx -= locs.Count;
            }

            if (next != location)
            {
                ChangeLocation(next);
            }
        }

        private void ChangeLocation(LocationObject next)
        {
            VendingService.GetInventory(location).OnChange.RemoveListener(UpdateSlot);

            location = next;
            isDirty = true;

            city.text = location.name;

            var machine = VendingService.GetInventory(location);
            for (int i = 0; i < machine.GetSize(); i++)
            {
                UpdateSlot(i);
            }
            machine.OnChange.AddListener(UpdateSlot);

            UpdateWeather();
        }

        private void UpdateSlot(int i)
        {
            var machine = VendingService.GetInventory(location);
            var stack = machine.Peek(i);
            slots[i].Set(stack);
        }

        private bool UpdateMap()
        {
            Vector2 dest = -location.coords * map.localScale.x;
            bool dirty = !CommonAnimation.DampedMove(map.anchoredPosition, dest, out Vector2 next);

            if (dirty)
            {
                map.anchoredPosition = next;
            }
            else
            {
                map.anchoredPosition = dest;
            }
            return dirty;
        }

        private void UpdateWeather()
        {
            precip.SetInteger("Type", (int)WeatherService.GetPrecip(location.region));
            temp.text = WeatherService.GetTempNum(location.region).ToString() + " 'C";
        }
    }
}