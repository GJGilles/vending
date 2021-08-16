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
        public List<Sprite> sprites = new List<Sprite>();

        public FunnelController funnelObj;
        public PagodaTileController tiles;

        private List<FunnelController> horzFunnel = new List<FunnelController>();
        private List<FunnelController> vertFunnel = new List<FunnelController>();

        public int GetHeight()
        {
            return PagodaService.Height() * 2 - 1;
        }

        public int GetWidth(int y)
        {
            if (y % 2 == 0)
            {
                return PagodaService.Width();
            }
            else
            {
                return PagodaService.Width() - 1;
            }
        }

        public Vector2 GetPosition(int x, int y)
        {
            if (y % 2 == 0)
            {
                return new Vector2(x + 0.5f, y);
            }
            else
            {
                return new Vector2(x, y + 0.5f);
            }
        }

        public void SetFunnel(int x, int y, MoveDirection dir, ItemObject item)
        {
            var inst = Instantiate(funnelObj, transform);
            inst.transform.localPosition = GetPosition(x, y);

            int idx = GetIndex(x, y);
            Func<ItemInventory> input = () => null;
            Func<ItemInventory> output = () => null;
            if (y % 2 == 0)
            {
                int a = PagodaService.Width() * y + x;
                if (dir == MoveDirection.Right)
                {
                    input = () => tiles.GetInventory(a);
                    output = () => tiles.GetInventory(a + 1);
                }
                else
                {
                    input = () => tiles.GetInventory(a + 1);
                    output = () => tiles.GetInventory(a);
                }
                horzFunnel[idx] = inst;
            }
            else 
            {
                input = () => tiles.GetInventory(idx + GetWidth(idx));
                output = () => tiles.GetInventory(idx);
                vertFunnel[idx] = inst;
            }
            inst.Set(sprites[(int)dir], input, output, item);
        }

        private int GetIndex(int x, int y)
        {
            return (y / 2) * GetWidth(y) + x;
        }
    }
}