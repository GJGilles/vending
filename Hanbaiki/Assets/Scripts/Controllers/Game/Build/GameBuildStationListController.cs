﻿using Assets.Scripts.Service;
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

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private void Start()
        {
            var stations = StationService.GetCurrent();
            for (int i = 0; i < stations.Count; i++)
            {
                var inst = list.Add().GetComponent<GameBuildStationController>();
                inst.Set(stations[i], stations[i].spr);
            }
            list.GetItem(list.GetSelected()).GetComponent<GameBuildStationController>().SetHighlight(true);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.Fire1))
            {
                build.DoneStation(StationService.GetCurrent()[list.GetSelected()]);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.Fire2))
            {
                build.Prev();
                return;
            }

            float diff = InputManager.GetVertAxis();
            coolRemain -= Time.deltaTime;
            if (diff != 0 && coolRemain <= 0)
            {
                list.GetItem(list.GetSelected()).GetComponent<GameBuildStationController>().SetHighlight(false);
                list.UpdateSelect(Mathf.RoundToInt(diff));
                list.GetItem(list.GetSelected()).GetComponent<GameBuildStationController>().SetHighlight(true);

                coolRemain = coolTime;
            }
        }
    }
}