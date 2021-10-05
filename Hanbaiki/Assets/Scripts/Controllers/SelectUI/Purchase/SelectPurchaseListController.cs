using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.Character;
using PotatoTools.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers
{
    public class SelectPurchaseListController : MonoBehaviour
    {
        public ScrollListController list;
        public UnityEvent<Dictionary<IngredientObject, int>> OnDone = new UnityEvent<Dictionary<IngredientObject, int>>();

        private Dictionary<IngredientObject, int> number = new Dictionary<IngredientObject, int>();
        private SelectPurchaseController current;

        public float coolTime = 0.3f;
        protected float coolRemain = 0;

        public int GetCost()
        {
            int cost = 0;
            foreach (var val in number)
            {
                cost += val.Key.buy * val.Value;
            }
            return cost;
        }

        private void OnEnable()
        {
            list.Clean();
            number = new Dictionary<IngredientObject, int>();

            var items = IngredientService.GetCurrent();
            for (int i = 0; i < items.Count; i++)
            {
                var inst = list.Add().GetComponent<SelectPurchaseController>();
                inst.Set(items[i]);
                number.Add(items[i], 0);
            }
            list.GetItem(list.GetSelected()).GetComponent<SelectPurchaseController>().SetHighlight(true);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                if (GetCost() <= PlayerService.GetMoney())
                {
                    PlayerService.AddMoney(-GetCost());
                    OnDone.Invoke(number);
                    gameObject.SetActive(false);
                }
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                OnDone.Invoke(new Dictionary<IngredientObject, int>());
                gameObject.SetActive(false);
            }

            coolRemain -= Time.deltaTime;
            if (coolRemain > 0) return;

            float horz = InputManager.GetHorzAxis();
            if (horz != 0)
            {
                if (horz >= 0) Change(1);
                else Change(-1);

                coolRemain = coolTime;
            }

            float diff = InputManager.GetVertAxis();
            if (diff != 0)
            {
                list.UpdateSelect(Mathf.RoundToInt(diff));
                Select();

                coolRemain = coolTime;
            }
        }

        private void Select()
        {
            if (current != null) current.SetHighlight(false);
            current = list.GetItem(list.GetSelected()).GetComponent<SelectPurchaseController>();
            current.SetHighlight(true);
        }

        private void Change(int i)
        {
            number[current.Get()] += i;
        }
    }
}