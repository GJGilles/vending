using Assets.Scripts.Common;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers.Game
{
    public class GameBuildStationListController : MonoBehaviour
    {
        public GameBuildController build;
        public ScrollListController list;

        private void Start()
        {
            var stations = StationService.GetCurrent();
            for (int i = 0; i < stations.Count; i++)
            {
                var inst = list.Add().GetComponent<GameBuildItemController>();
                inst.Set(stations[i], stations[i].spr);
            }
        }

        private void Update()
        {
            if (InputManager.GetFireA())
            {
                build.DoneStation(StationService.GetCurrent()[list.GetSelected()]);
                return;
            }

            if (InputManager.GetFireB())
            {
                build.Prev();
                return;
            }

            float diff = InputManager.GetVertAxis();
            if (diff != 0)
            {
                list.UpdateSelect(Mathf.RoundToInt(diff));
            }
        }
    }
}