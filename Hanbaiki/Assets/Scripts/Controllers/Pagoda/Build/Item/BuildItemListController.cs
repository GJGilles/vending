using Assets.Scripts.Objects;
using Assets.Scripts.Service;
using PotatoTools;
using PotatoTools.UI;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BuildItemListController : MonoBehaviour
    {
        public BuildController build;
        public ScrollListController list;

        public float coolTime = 0.2f;
        private float coolRemain = 0f;

        private void Start()
        {
            list.Clean();

            var items = ItemService.GetCurrent();
            for (int i = 0; i < items.Count; i++)
            {
                var inst = list.Add().GetComponent<BuildItemController>();
                inst.Set(items[i].title, items[i].spr);
            }
            list.GetItem(list.GetSelected()).GetComponent<BuildItemController>().SetHighlight(true);
        }

        private void Update()
        {
            if (InputManager.GetButtonTrigger(ButtonEnum.A))
            {
                build.DoneItem((IngredientObject)ItemService.GetCurrent()[list.GetSelected()]);
                return;
            }

            if (InputManager.GetButtonTrigger(ButtonEnum.B))
            {
                build.Prev();
                return;
            }

            float diff = InputManager.GetVertAxis();
            coolRemain -= Time.deltaTime;
            if (diff != 0 && coolRemain <= 0)
            {
                list.GetItem(list.GetSelected()).GetComponent<BuildItemController>().SetHighlight(false);
                list.UpdateSelect(Mathf.RoundToInt(diff));
                list.GetItem(list.GetSelected()).GetComponent<BuildItemController>().SetHighlight(true);

                coolRemain = coolTime;
            }
        }
    }
}