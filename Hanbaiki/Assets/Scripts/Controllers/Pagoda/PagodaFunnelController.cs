﻿using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class PagodaFunnelController : MonoBehaviour
    {
        public PagodaTileController tiles;
        public FunnelController funnelObj;

        private void Start()
        {
        }

        public void SetFunnel(int x, int y)
        {
            var data = new FunnelData(x, y);
            PagodaService.AddFunnel(data);
            var inst = Instantiate(funnelObj, transform);
            inst.data = data;
        }
    }
}