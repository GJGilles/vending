using Assets.Scripts.Inventory;
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

        private int location = 0;
        private bool isDirty = false;

        private void Start()
        {
            ChangeLocation(location);
        }

        private void Update()
        {
            UpdateWeather();

            if (isDirty)
            {
                isDirty = UpdateMap();
            }

            int next = location;
            int length = MapService.GetCurrent().Count;
            if (InputManager.GetButtonTrigger(ButtonEnum.L1))
            {
                next--;
                if (next < 0) next += length;
            }
            else if (InputManager.GetButtonTrigger(ButtonEnum.R1))
            {
                next++;
                if (next >= length) next -= length;
            }

            if (next != location)
            {
                ChangeLocation(next);
            }
        }

        private void ChangeLocation(int next)
        {
            location = next;
            isDirty = true;

            var obj = MapService.GetCurrent()[location];
            city.text = obj.name;

            // TODO: Register to onchange events
            var machine = VendingService.GetInventory(obj);
            for (int i = 0; i < machine.GetSize(); i++)
            {
                var stack = machine.Peek(i);
                slots[i].Set(stack);
            }

            UpdateWeather();
        }

        private bool UpdateMap()
        {
            var obj = MapService.GetCurrent()[location];

            Vector2 dest = -obj.coords * map.localScale.x;
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
            var obj = MapService.GetCurrent()[location];

            precip.SetInteger("Type", (int)WeatherService.GetPrecip(obj.region));
            temp.text = WeatherService.GetTempNum(obj.region).ToString() + " 'C";
        }
    }
}