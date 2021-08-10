using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using Assets.Scripts.Types;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Inventory
{
    public enum StackMoveEnum
    {
        One,
        Half,
        All
    }

    public class ItemInventory
    {
        private int capacity = 6;
        private bool infinite = false;

        private List<ItemStack> items = new List<ItemStack>();
        private int selected = 0;

        public UnityEvent<int> OnChange = new UnityEvent<int>();

        public ItemInventory(int size, bool inf = false)
        {
            capacity = size;
            items = new List<ItemStack>(new ItemStack[capacity]);
            infinite = inf;
        }

        public int GetSize() { return capacity; }

        public int GetLocation() { return selected; }

        public int Find(ItemObject item)
        {
            return items.FindIndex(i => i != null && i.item == item);
        }

        public ItemStack Peek(int? idx = null)
        {
            if (idx == null)
            {
                idx = selected;
            }

            if (items[(int)idx] == null)
            {
                return null;
            }
            else
            {
                return items[(int)idx];
            }
        }

        public ItemStack Remove(StackMoveEnum amount, int? idx = null)
        {
            int i = idx == null ? selected : (int)idx;

            if (items[i] == null)
            {
                return null;
            }
            else
            {
                int count;
                switch (amount)
                {
                    default:
                    case StackMoveEnum.All:
                        count = items[i].number;
                        break;

                    case StackMoveEnum.Half:
                        count = items[i].number / 2;
                        break;

                    case StackMoveEnum.One:
                        count = 1;
                        break;
                }

                ItemStack output = new ItemStack(items[i].item, count);

                items[i].number -= count;
                if (items[i].number <= 0)
                {
                    items[i] = null;
                }

                OnChange.Invoke(i);
                return output;
            }
        }

        public ItemStack Add(StackMoveEnum amount, ItemStack stack, int? idx = null)
        {
            int i = idx == null ? selected : (int)idx;

            if (items[i] == null)
            {
                items[i] = new ItemStack(stack.item, 0);
            }
            
            if (items[i].item != stack.item)
            {
                if (amount == StackMoveEnum.All)
                {
                    var ret = items[i];
                    items[i] = stack;
                    OnChange.Invoke(i);
                    return ret;
                }
                else
                    return stack;
            }
            else
            {
                int diff;
                switch (amount)
                {
                    default:
                    case StackMoveEnum.All:
                        diff = stack.number;
                        break;
                    case StackMoveEnum.Half:
                        diff = stack.number / 2;
                        break;
                    case StackMoveEnum.One:
                        diff = 1;
                        break;
                }

                int next = infinite ? items[i].number + diff : Mathf.Min(items[i].number + diff, stack.item.stack);
                stack.number -= next - items[i].number;
                items[i].number = next;
                OnChange.Invoke(i);

                if (stack.number <= 0)
                {
                    return null;
                }
                else
                {
                    return stack;
                }
            }
        }

        public void SetSelect(int idx)
        {
            selected = idx;
            while (selected >= items.Count) selected -= items.Count;
            while (selected < 0) selected += items.Count;
        }
    }
}