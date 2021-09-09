using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ItemJournalController : MonoBehaviour
    {
        public ScrollListController list;
        public ItemEntryController entry;

        public float coolTime = 0.3f;
        private float coolRemain = 0;

        private List<IngredientObject> items = new List<IngredientObject>();

        private void Start()
        {
            list.Clean();

            items = IngredientService.GetCurrent();
            for (int i = 0; i < items.Count; i++)
            {
                var inst = list.Add();
                inst.GetComponent<UnityEngine.UI.Image>().sprite = items[i].spr;
            }
            entry.Set(items[list.GetSelected()]);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                gameObject.SetActive(false);
                return;
            }

            coolRemain -= Time.deltaTime;
            if (coolRemain > 0) return;

            float diff = InputManager.GetVertAxis();
            if (diff != 0)
            {
                list.UpdateSelect(Mathf.RoundToInt(diff));
                entry.Set(items[list.GetSelected()]);

                coolRemain = coolTime;
            }
        }
    }
}