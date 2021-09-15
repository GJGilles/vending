using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class FunnelController : SelectableController
    {
        public SplitInventoryController menuObject;

        [NonSerialized] public FunnelData data;

        private void Start()
        {
            var spr = GetComponent<SpriteRenderer>();

            var a = PagodaService.GetPosition(data.Input);
            var b = PagodaService.GetPosition(data.Output);

            int size = Mathf.RoundToInt((b - a).magnitude);
            float angle = Vector2.Angle((b - a), Vector2.right);

            transform.localPosition = Vector2.Lerp(a, b, 0.5f);
            transform.localEulerAngles = new Vector3(0, 0, angle);
            spr.size = new Vector2(size, 1);
        }

        public override void Select()
        {
            var inst = Instantiate(menuObject);
            inst.inventories = new List<ItemInventory>() { PlayerService.GetInventory(), data.inventory };
            inst.widths = new List<int>() { 4, 2 };
        }
    }
}