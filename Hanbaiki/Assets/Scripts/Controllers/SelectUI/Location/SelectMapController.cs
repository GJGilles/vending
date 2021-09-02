using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectMapController : SelectUIController<LocationObject>
    {
        public RectTransform map;
        public TMPro.TMP_Text text;
        public SelectLocationController locObj;

        private int selected = 0;
        private List<SelectLocationController> objects = new List<SelectLocationController>();

        private bool isDirty = false;
        private Vector2 dest = new Vector2();

        private void OnEnable()
        {
            Clean();

            var locs = MapService.GetCurrent();
            for (int i = 0; i < locs.Count; i++)
            {
                var inst = Instantiate(locObj, map.transform).GetComponent<SelectLocationController>();
                inst.GetComponent<RectTransform>().anchoredPosition = locs[i].coords;
                inst.location = locs[i];
                objects.Add(inst);
            }

            select = objects[0].location;
            dest = -objects[0].location.coords * map.localScale.x;
            isDirty = true;
        }

        protected override void Update()
        {
            base.Update();

            if (isDirty)
            {
                Vector2 next = new Vector2();
                isDirty = !CommonAnimation.DampedMove(map.anchoredPosition, dest, out next);
                map.anchoredPosition = next;

                if (!isDirty)
                {
                    text.text = objects[selected].location.name;
                }
            }

            if (coolRemain > 0) return;

            float diff = InputManager.GetVertAxis();
            if (diff != 0)
            {
                selected -= Mathf.RoundToInt(diff);
                if (selected < 0) selected += objects.Count;
                if (selected >= objects.Count) selected -= objects.Count;

                select = objects[selected].location;
                dest = -select.coords * map.localScale.x;
                text.text = "";
                isDirty = true;

                coolRemain = coolTime;
            }
        }

        private void Clean()
        {
            while (objects.Count > 0)
            {
                Destroy(objects[0].gameObject);
                objects.RemoveAt(0);
            }
        }
    }
}