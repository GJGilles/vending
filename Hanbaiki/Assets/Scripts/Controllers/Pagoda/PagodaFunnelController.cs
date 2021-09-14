using Assets.Scripts.Objects;
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

        private void Start()
        {
        }

        public void SetFunnel(int x, int y, IngredientObject item)
        {
            PagodaService.AddFunnel(new FunnelData(x, y, item));
        }
    }
}