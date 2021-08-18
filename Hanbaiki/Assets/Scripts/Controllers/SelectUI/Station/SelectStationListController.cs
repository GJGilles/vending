using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.UI;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SelectStationListController : SelectUIController<StationObject>
    {
        public ScrollListController list;

        private void Start()
        {
            list.Clean();

            var stations = StationService.GetCurrent();
            for (int i = 0; i < stations.Count; i++)
            {
                var inst = list.Add().GetComponent<SelectStationController>();
                inst.Set(stations[i], stations[i].spr);
            }
            list.GetItem(list.GetSelected()).GetComponent<SelectStationController>().SetHighlight(true);
        }

        protected override void Update()
        {
            base.Update();
            if (coolRemain > 0) return;

            float diff = InputManager.GetVertAxis();
            if (diff != 0)
            {
                list.GetItem(list.GetSelected()).GetComponent<SelectStationController>().SetHighlight(false);
                list.UpdateSelect(Mathf.RoundToInt(diff));
                list.GetItem(list.GetSelected()).GetComponent<SelectStationController>().SetHighlight(true);

                select = StationService.GetCurrent()[list.GetSelected()];

                coolRemain = coolTime;
            }
        }
    }
}