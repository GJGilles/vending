using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class RecipeJournalController : MonoBehaviour
    {
        public ScrollListController list;

        public float coolTime = 0.3f;
        private float coolRemain = 0;

        private List<RecipeObject> recipes = new List<RecipeObject>();

        private void Start()
        {
            list.Clean();

            recipes = StationService.GetRecipes();
            for (int i = 0; i < recipes.Count; i++)
            {
                var inst = list.Add().GetComponent<RecipeEntryController>();
                inst.Set(recipes[i]);
            }
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

                coolRemain = coolTime;
            }
        }
    }
}
